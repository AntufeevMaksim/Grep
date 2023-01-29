
class Params
{
  public StartParam StartParam {get; private set;}
  public string FilePath {get; private set;}
  public Mode Mode{get; private set;}
  public string Word{get; private set;}
  public CheckSumMode CheckSumMode{get; private set;}
  public CountWordsMode CountWordsMode{get; private set;}

  public void Parse(string[] args)
  {
    CheckSumMode = CheckSumMode.MD5; //test
    CountWordsMode = CountWordsMode.CaseSensitive;//test

    ParseStartParam(args[0]);

    if (StartParam == StartParam.Help)
      return;

    FilePath = args[1];

    ParseMode(args[3]);

    if (Mode == Mode.CountWords)
      Word = args[5];
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
}

enum StartParam
{
  Help,
  WorkWithFile
}

enum Mode
{
  CountWords,
  CheckSum
}

enum CheckSumMode
{
  MD5
}

enum CountWordsMode
{
  CaseSensitive
}