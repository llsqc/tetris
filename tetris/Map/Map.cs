using System.Diagnostics.CodeAnalysis;

namespace tetris;

public class Map : IDraw
{
    private List<DrawObject> walls = new List<DrawObject>();
    public List<DrawObject> dynamicWalls = new List<DrawObject>();

    private GameScene nowGameScene;

    public int mapW;
    public int mapH;

    private int[] recordInfo;

    public Map(GameScene scene)
    {
        nowGameScene = scene;
        mapH = Game.height - 6;
        mapW = 0;

        recordInfo = new int[mapH];

        for (int i = 0; i < Game.width; i += 2)
        {
            walls.Add(new DrawObject(E_DrawType.Wall, i, mapH));
            ++mapW;
        }

        mapW -= 2;

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

    public void ClearDraw()
    {
        for (int i = 0; i < dynamicWalls.Count; i++)
        {
            dynamicWalls[i].ClearDrawObject();
        }
    }

    public void AddWalls(List<DrawObject> walls)
    {
        for (int i = 0; i < walls.Count; i++)
        {
            walls[i].ChangeType(E_DrawType.Wall);
            dynamicWalls.Add(walls[i]);

            if (walls[i].pos.y <= 0)
            {
                nowGameScene.StopThread();
                Game.ChangeScene(ESceneType.End);
                return;
            }

            recordInfo[mapH - 1 - walls[i].pos.y]++;
        }

        ClearDraw();
        CheckClear();
        Draw();
    }

    public void CheckClear()
    {
        List<DrawObject> delList = new List<DrawObject>();
        for (int i = 0; i < recordInfo.Length; i++)
        {
            if (recordInfo[i] == mapW)
            {
                for (int j = 0; j < dynamicWalls.Count; j++)
                {
                    if (i == mapH - dynamicWalls[j].pos.y - 1)
                    {
                        delList.Add(dynamicWalls[j]);
                    }
                    else if (mapH - 1 - dynamicWalls[j].pos.y > i)
                    {
                        ++dynamicWalls[j].pos.y;
                    }
                }

                for (int j = 0; j < delList.Count; j++)
                {
                    dynamicWalls.Remove(delList[j]);
                }

                for (int j = i; j < recordInfo.Length - 1; j++)
                {
                    recordInfo[j] = recordInfo[j + 1];
                }

                recordInfo[^1] = 0;
                CheckClear();
                break;
            }
        }
    }
}