
class Grep
{
  Params _params = new Params();

  Dictionary<CheckSumMode, ICheckSum> _checkSum = new Dictionary<CheckSumMode, ICheckSum>{
    {CheckSumMode.MD5, new CheckSumMD5()}
  };
  Dictionary<CountWordsMode, ICountWords> _countWords = new Dictionary<CountWordsMode, ICountWords>{
    {CountWordsMode.CaseSensitive, new CountWordsCaseSensitive()}
  };

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
        _output = _countWords[_params.CountWordsMode].CountWords(_fileText, _params.Word).ToString();
        break;
      case (Mode.CheckSum):
        _output = System.BitConverter.ToString(_checkSum[_params.CheckSumMode].CheckSum(_fileText));
        break;
    }

    Console.WriteLine(_output);
    
  }

  
}


