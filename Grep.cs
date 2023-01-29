
class Grep
{
  Params _params = new Params();

  CountWordsCaseSensitive _countWords = new CountWordsCaseSensitive();
  CheckSumMD5 _checkSum = new CheckSumMD5();

  string _helpInformation = "help";
  string _fileText;
  string _output;

  public void Run(string[] args)
  {
    _params.Parse(args);

    switch (_params.StartParam)
    {
      case (StartParam.Help):
        Console.WriteLine(_helpInformation);
        return;
      case (StartParam.WorkWithFile):
        _fileText = File.ReadAllText(_params.FilePath);
        break;
    }

    switch (_params.Mode)
    {
      case (Mode.CountWords):
        _output = _countWords.CountWords(_fileText, _params.Word).ToString();
        break;
      case (Mode.CheckSum):
        _output = System.BitConverter.ToString(_checkSum.CheckSum(_fileText));
        break;
    }

    Console.WriteLine(_output);

  }

}

