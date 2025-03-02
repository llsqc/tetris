namespace tetris;

public enum E_ChangeType
{
    Left,
    Right
}

public class BlockManagement : IDraw
{
    private List<DrawObject> blocks;

    private Dictionary<E_DrawType, BlockInfo> blockInfoDic;

    private BlockInfo nowBlockInfo;

    private int nowInfoIndex;

    public BlockManagement()
    {
        blockInfoDic = new Dictionary<E_DrawType, BlockInfo>()
        {
            { E_DrawType.O, new BlockInfo(E_DrawType.O) },
            { E_DrawType.I, new BlockInfo(E_DrawType.I) },
            { E_DrawType.T, new BlockInfo(E_DrawType.T) },
            { E_DrawType.J, new BlockInfo(E_DrawType.J) },
            { E_DrawType.L, new BlockInfo(E_DrawType.L) },
            { E_DrawType.S, new BlockInfo(E_DrawType.S) },
            { E_DrawType.Z, new BlockInfo(E_DrawType.Z) }
        };

        RandomCreateBlock();
    }

    public void RandomCreateBlock()
    {
        Random rnd = new Random();

        E_DrawType type = (E_DrawType)rnd.Next(1, 8);

        blocks = new List<DrawObject>()
        {
            new DrawObject(type),
            new DrawObject(type),
            new DrawObject(type),
            new DrawObject(type)
        };

        blocks[0].pos = new Position(24, 5);
        nowBlockInfo = blockInfoDic[type];

        nowInfoIndex = rnd.Next(0, nowBlockInfo.Count);
        Position[] pos = nowBlockInfo[nowInfoIndex];
        for (int i = 0; i < pos.Length; i++)
        {
            blocks[i + 1].pos = blocks[0].pos + pos[i];
        }
    }

    public void Draw()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].Draw();
        }
    }

    public void ClearDraw()
    {
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].ClearDrawObject();
        }
    }

    public void Change(E_ChangeType type)
    {
        ClearDraw();

        switch (type)
        {
            case E_ChangeType.Left:
                --nowInfoIndex;
                if (nowInfoIndex < 0)
                {
                    nowInfoIndex = nowBlockInfo.Count - 1;
                }

                break;
            case E_ChangeType.Right:
                ++nowInfoIndex;
                if (nowInfoIndex >= nowBlockInfo.Count)
                {
                    nowInfoIndex = 0;
                }

                break;
        }

        Position[] pos = nowBlockInfo[nowInfoIndex];
        for (int i = 0; i < pos.Length; i++)
        {
            blocks[i + 1].pos = blocks[0].pos + pos[i];
        }

        Draw();
    }

    public bool CanChange(E_ChangeType type, Map map)
    {
        int nowIndex = nowInfoIndex;

        switch (type)
        {
            case E_ChangeType.Left:
                --nowIndex;
                if (nowIndex < 0)
                {
                    nowIndex = nowBlockInfo.Count - 1;
                }

                break;
            case E_ChangeType.Right:
                ++nowIndex;
                if (nowIndex >= nowBlockInfo.Count)
                {
                    nowIndex = 0;
                }

                break;
        }

        Position[] nowPos = nowBlockInfo[nowIndex];

        Position tempPos;
        for (int i = 0; i < nowPos.Length; i++)
        {
            tempPos = nowPos[i] + blocks[0].pos;
            if (tempPos.x < 2 ||
                tempPos.x >= Game.width - 2 ||
                tempPos.y >= map.mapH)
            {
                return false;
            }
        }

        for (int i = 0; i < nowPos.Length; i++)
        {
            tempPos = nowPos[i] + blocks[0].pos;
            for (int j = 0; j < map.dynamicWalls.Count; j++)
            {
                if (tempPos == map.dynamicWalls[j].pos)
                {
                    return false;
                }
            }
        }

        return true;
    }

    public void MoveLeftRight(E_ChangeType type)
    {
        ClearDraw();

        Position movePos = new Position(type == E_ChangeType.Left ? -2 : 2, 0);
        for (int i = 0; i < blocks.Count; i++)
        {
            blocks[i].pos += movePos;
        }

        Draw();
    }

    public bool CanMoveLeftRight(E_ChangeType type, Map map)
    {
        Position movePos = new Position(type == E_ChangeType.Left ? -2 : 2, 0);

        Position pos;
        for (int i = 0; i < blocks.Count; i++)
        {
            pos = blocks[i].pos + movePos;
            if (pos.x < 2 || pos.x >= Game.width - 2)
            {
                return false;
            }
        }

        for (int i = 0; i < blocks.Count; i++)
        {
            pos = blocks[i].pos + movePos;
            for (int j = 0; j < map.dynamicWalls.Count; j++)
            {
                if (pos == map.dynamicWalls[j].pos)
                {
                    return false;
                }
            }
        }

        return true;
    }
}