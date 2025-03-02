namespace tetris;

public class GameScene : ISceneUpdate
{
    Map map = null;

    public GameScene()
    {
        map = new Map();
    }

    public void Update()
    {
        map.Draw();
    }
}