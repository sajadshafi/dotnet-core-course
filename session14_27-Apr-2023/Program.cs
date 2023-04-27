//Dependency injection demo

public class Program {

    private Logger _l;
    private LogLevels _ll;
    public Program(LogLevels ll, Logger l)
    {
        _l = l;
        _ll = ll;
    }

    LogLevels ll = new LogLevels();
    Logger logger = new Logger(ll);
}


public class Logger {
    //LogLevels logl = new LogLevels();

    private LogLevels _logL;
    public Logger(LogLevels logL) {
        _logL = logL;
    }

    public string logLevel { get; set; }


    public void Log(string message, LogLevels ll) {
        Console.WriteLine(message);
        ll.LogLevel();
    }
}

public class LogLevels {
    public void LogLevel() {
        Console.WriteLine("this log is critical");
    }
}


public class TestLogger {


    public void TestLog() {

        LogLevels logl = new LogLevels();
        Logger ll = new Logger(logl);

    }
}