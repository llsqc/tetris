namespace tetris;

public class Map : IDraw
{
    private List<DrawObject> walls = new List<DrawObject>();
    public List<DrawObject> dynamicWalls = new List<DrawObject>();

    public int mapW;
    public int mapH;

    public Map()
    {
        mapH = Game.height - 6;

        for (int i = 0; i < Game.width; i += 2)
        {
            walls.Add(new DrawObject(E_DrawType.Wall, i, mapH));
        }

        for (int i = 0; i < mapH; i++)
        {
            walls.Add(new DrawObject(E_DrawType.Wall, 0, i));
            walls.Add(new DrawObject(E_DrawType.Wall, Game.width - 2, i));
        }
    }

    public void Draw()
    {
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].Draw();
        }

        for (int i = 0; i < dynamicWalls.Count; i++)
        {
            dynamicWalls[i].Draw();
        }
    }

    public void AddWalls(List<DrawObject> walls)
    {
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].ChangeType(E_DrawType.Wall);
            dynamicWalls.Add(walls[i]);
        }
    }
}