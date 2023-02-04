using System.Reflection;
using System.Diagnostics;

public class MapControllerToView
{
    public static void Main(string[] args)
    {
        GameController game = new GameController();
        game.Start();
    }
}
public class GameView
{
    public static void Start(string message, string nameGame, int level)
    {
        Console.WriteLine(message + " + " + nameGame + " - " + level);
    }
}

public class GameController : Controller
{
    public void Start()
    {
        try
        {
            var sucessResult = View(new object[] { "Start game", "TowerHaNoi", 12345 });
            if (!sucessResult)
            {
                //Wtrite log error in View()

            }

        }
        catch (Exception ex)
        {
            //Wtrite log error in View()
            Console.WriteLine("Error throw Exception: " +ex.Message);
        }

    }
}
public class Controller
{
    protected bool View(object[] parameters)
    {
        string nameControllerCurrent;
        string nameMethodCurrent;
        StackTrace stackTrace = new StackTrace();
        StackFrame? stackFrame;
        MethodBase? methodBase;

        nameControllerCurrent = this.GetType().Name;
        string viewName = ChangeGameControllerToView(nameControllerCurrent);
        if (stackTrace != null)
        {
            stackFrame = stackTrace.GetFrame(1);
            if (stackFrame != null)
            {
                methodBase = stackFrame.GetMethod();
                if (methodBase != null)
                {
                    nameMethodCurrent = methodBase.Name;
                    Console.WriteLine(nameControllerCurrent + " " + nameMethodCurrent + " " + viewName);
                    CallStaticMethodByString(viewName, nameMethodCurrent, parameters);
                    return true;
                }
            }
        }
        return false;
    }
    private static void CallStaticMethodByString(string viewName, string methodName, object[] parameters)
    {
        Type? type = Type.GetType(viewName);
        MethodBase? memberInfo;
        if (type != null)
        {
            memberInfo = type.GetMethod(methodName);
            if (memberInfo != null)
            {
                memberInfo.Invoke(null, parameters);
            }
        }
    }
    private string ChangeGameControllerToView(string nameControllerCurrent)
    {
        string viewName = nameControllerCurrent.Replace("Controller", "View");
        return viewName;
    }
}