namespace tetris;

public enum E_DrawType
{
    Wall,
    I, // 长条型
    O, // 正方形
    T, // T型
    S, // S型（左梯子）
    Z, // Z型（右梯子）
    J, // L型（左）
    L // L型（右）
}

public struct DrawObject : IDraw
{
    public Position pos;
    public E_DrawType type;

    public DrawObject(E_DrawType type)
    {
        this.type = type;
    }

    public DrawObject(E_DrawType type, int x, int y) : this(type)
    {
        this.pos = new Position(x, y);
    }

    public void Draw()
    {
        Console.SetCursorPosition(pos.x, pos.y);
        switch (type)
        {
            case E_DrawType.Wall:
                Console.ForegroundColor = ConsoleColor.Red;
                break;
            case E_DrawType.I:
                Console.ForegroundColor = ConsoleColor.Green;
                break;
            case E_DrawType.O:
                Console.ForegroundColor = ConsoleColor.Cyan;
                break;
            case E_DrawType.T:
                Console.ForegroundColor = ConsoleColor.Magenta;
                break;
            case E_DrawType.S:
            case E_DrawType.Z:
                Console.ForegroundColor = ConsoleColor.Blue;
                break;
            case E_DrawType.J:
            case E_DrawType.L:
                Console.ForegroundColor = ConsoleColor.Yellow;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        Console.Write("■");
    }

    //TODO: 将方块类型转换成墙壁
    public void ChangeType(E_DrawType type)
    {
        this.type = type;
    }
}