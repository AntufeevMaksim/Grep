
class Grep
{
  Params _params = new Params();
  CountWords _countWords = new CountWords();
  CheckSum _checkSum = new CheckSum();
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
        _output = _countWords.Count(_fileText, _params.Word).ToString();
        break;
      case (Mode.CheckSum):
        _output = System.BitConverter.ToString(_checkSum.Checksum(_fileText));
        break;
    }

    Console.WriteLine(_output);
    
  }

  
}


