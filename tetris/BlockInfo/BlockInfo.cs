namespace tetris;

public class BlockInfo
{
    private List<Position[]> list;

    public BlockInfo(E_DrawType type)
    {
        list = new List<Position[]>();

        switch (type)
        {
            case E_DrawType.I:
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(0, 1),
                    new Position(0, 2)
                });
                list.Add(new Position[3]
                {
                    new Position(-4, 0),
                    new Position(-2, 0),
                    new Position(2, 0)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -2),
                    new Position(0, -1),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(-2, 0),
                    new Position(2, 0),
                    new Position(4, 0)
                });
                break;
            case E_DrawType.O:
                list.Add(new Position[3]
                {
                    new Position(2, 0),
                    new Position(0, 1),
                    new Position(2, 1)
                });
                break;
            case E_DrawType.T:
                list.Add(new Position[3]
                {
                    new Position(-2, 0),
                    new Position(2, 0),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(-2, 0),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(-2, 0),
                    new Position(2, 0)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(2, 0),
                    new Position(0, 1)
                });
                break;
            case E_DrawType.S:
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(2, 0),
                    new Position(2, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(2, 0),
                    new Position(0, 1),
                    new Position(-2, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(-2, -1),
                    new Position(-2, 0),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(2, -1),
                    new Position(-2, 0)
                });
                break;
                break;
            case E_DrawType.Z:
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(-2, 0),
                    new Position(-2, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(-2, -1),
                    new Position(0, -1),
                    new Position(2, 0)
                });
                list.Add(new Position[3]
                {
                    new Position(2, -1),
                    new Position(2, 0),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(0, 1),
                    new Position(2, 1),
                    new Position(-2, 0)
                });
                break;
            case E_DrawType.J:
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(0, 1),
                    new Position(2, -1)
                });
                list.Add(new Position[3]
                {
                    new Position(2, 0),
                    new Position(-2, 0),
                    new Position(2, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(-2, 1),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(-2, -1),
                    new Position(-2, 0),
                    new Position(2, 0)
                });
                break;
            case E_DrawType.L:
                list.Add(new Position[3]
                {
                    new Position(-2, -1),
                    new Position(0, -1),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(2, -1),
                    new Position(-2, 0),
                    new Position(2, 0)
                });
                list.Add(new Position[3]
                {
                    new Position(0, -1),
                    new Position(2, 1),
                    new Position(0, 1)
                });
                list.Add(new Position[3]
                {
                    new Position(2, 0),
                    new Position(-2, 0),
                    new Position(-2, 1)
                });
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(type), type, null);
        }
    }

    public Position[] this[int index]
    {
        get
        {
            if (index < 0)
            {
                return list[0];
            }

            if (index >= list.Count)
            {
                return list[list.Count - 1];
            }

            return list[index];
        }
    }

    public int Count
    {
        get => list.Count;
    }
}