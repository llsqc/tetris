namespace tetris;

public class GameScene : ISceneUpdate
{

    int updateIndex = 0;

    public GameScene()
    {

    }

    public void Update()
    {
        Console.ReadKey(true);
        Game.ChangeScene(ESceneType.End);
    }
}