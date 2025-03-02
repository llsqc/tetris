﻿namespace tetris;

public class GameScene : ISceneUpdate
{
    Map map;
    BlockManagement blockManagement;

    public GameScene()
    {
        map = new Map();
        blockManagement = new BlockManagement();
    }

    public void Update()
    {
        map.Draw();
        blockManagement.Draw();

        switch (Console.ReadKey(true).Key)
        {
            case ConsoleKey.LeftArrow:
                if (blockManagement.CanChange(E_ChangeType.Left, map))
                {
                    blockManagement.Change(E_ChangeType.Left);
                }

                break;
            case ConsoleKey.RightArrow:
                if (blockManagement.CanChange(E_ChangeType.Right, map))
                {
                    blockManagement.Change(E_ChangeType.Right);
                }

                break;
        }
    }
}