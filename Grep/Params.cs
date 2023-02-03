
namespace Prog
{
  public class Params : IParams
  {
    //  public bool ArgError{get; private set;}
    private bool _argError;

    public StartParam StartParam { get; private set; }
    public string FilePath { get; private set; }
    public Mode Mode { get; private set; }
    public string Word { get; private set; }

    public void Parse(string[] args)
    {

      ParseArgs(args);

      while (_argError)
      {
        PrintError("Invalid arguments, try again");
        args = Console.ReadLine().Split();
        ParseArgs(args);
      }

      while (!File.Exists(FilePath))
      {
        ChangeFilePath();
      }
    }

    private void ChangeFilePath()
    {
      PrintError("File path is incorrect, try again");
      FilePath = Console.ReadLine();
    }

    private void ParseArgs(string[] args)
    {
      try
      {
        ParseStartParam(args[0]);

        if (StartParam == StartParam.Help)
          return;

        FilePath = args[1];

        ParseMode(args[3]);

        if (Mode == Mode.CountWords)
          Word = args[5];

        _argError = false;
      }
      catch (IndexOutOfRangeException)
      {
        _argError = true;
      }
    }
    private void ParseMode(string arg)
    {
      switch (arg)
      {
        case ("words"):
          Mode = Mode.CountWords;
          break;
        case ("checksum"):
          Mode = Mode.CheckSum;
          break;
        default:
          break;
      }
    }

    private void ParseStartParam(string arg)
    {
      switch (arg)
      {
        case ("-h"):
          StartParam = StartParam.Help;
          break;
        case ("-f"):
          StartParam = StartParam.WorkWithFile;
          break;
        default:
          StartParam = StartParam.Help;
          break;
      }
    }
    private void PrintError(string text)
    {
      Console.ForegroundColor = ConsoleColor.Red;
      Console.WriteLine(text);
      Console.ForegroundColor = ConsoleColor.White;
    }
  }

  public enum StartParam
  {
    Help,
    WorkWithFile
  }

  public enum Mode
  {
    CountWords,
    CheckSum
  }
}
