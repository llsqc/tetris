namespace tetris;

public class InputThread
{
    Thread inputThread;
    
    public event Action inputEvent;
    
    private static InputThread instance = new InputThread();

    public static InputThread Instance
    {
        get { return instance; }
    }

    private InputThread()
    {
        inputThread = new Thread(InputCheck);
        inputThread.IsBackground = true;
        inputThread.Start();
    }

    private void InputCheck()
    {
        while (true)
        {
            inputEvent?.Invoke();
        }
    }
}