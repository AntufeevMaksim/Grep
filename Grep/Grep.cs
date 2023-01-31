
using CheckSum;
using CountWords;

class Grep
{
  Params _params = new Params();

  CountWordsCaseSensitive _countWords = new CountWordsCaseSensitive();
  CheckSumMD5 _checkSum = new CheckSumMD5();

  string _helpInformation = "help";


  public void Run(string[] args)
  {
    _params.Parse(args);

  
    StreamReader stream = default;
    switch (_params.StartParam)
    {
      case (StartParam.Help):
        Console.WriteLine(_helpInformation);
        return;
      case (StartParam.WorkWithFile):
        stream = new StreamReader(_params.FilePath);
        break;
    }

    string output = StartWorkWithFile(stream);

    Console.WriteLine(output);

  }

  private string StartWorkWithFile(StreamReader stream)
  {
    string output = "";
    string text = stream.ReadToEnd();
    switch (_params.Mode)
    {
      case (Mode.CountWords):
        output = _countWords.CountWords(text, _params.Word).ToString();
        break;
      case (Mode.CheckSum):
        output = System.BitConverter.ToString(_checkSum.CheckSum(text));
        break;
    }
    return output;
  }
}

