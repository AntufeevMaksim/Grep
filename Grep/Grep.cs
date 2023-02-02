
using CheckSum;
using CountWords;

namespace Prog
{
  public class Grep
  {
    Params _params = new Params();

    ICheckSum _checkSum;
    ICountWords _countWords;

    string _helpInformation = "help";

    public Grep(ICheckSum check_sum, ICountWords count_words)
    {
      _checkSum = check_sum;
      _countWords = count_words;
    }

    public string Run(string[] args)
    {
      _params.Parse(args);


      StreamReader stream = default;
      switch (_params.StartParam)
      {
        case (StartParam.Help):
          return _helpInformation;
        case (StartParam.WorkWithFile):
          stream = new StreamReader(_params.FilePath);
          break;
      }

      string output = StartWorkWithFile(stream);

      return output;

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
}
