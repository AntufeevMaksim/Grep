
using CheckSum;
using CountWords;

namespace Prog
{
  public class Grep
  {

    ICheckSum _checkSum;
    ICountWords _countWords;

    string _helpInformation = "help";

    public Grep(ICheckSum check_sum, ICountWords count_words)
    {
      _checkSum = check_sum;
      _countWords = count_words;

    }

    public string Run(IParams param, string text)
    {

      if (param.StartParam == StartParam.Help)
      {
        return _helpInformation;
      }

      // switch (param.StartParam)
      // {
      //   case (StartParam.Help):
      //     return _helpInformation;
      //   case (StartParam.WorkWithFile):
      //     stream = new StreamReader(param.FilePath);
      //     break;
      // }

      string output = StartWorkWithFile(text, param);

      return output;

    }

    private string StartWorkWithFile(string text, IParams param)
    {
      string output = "";
      switch (param.Mode)
      {
        case (Mode.CountWords):
          output = _countWords.CountWords(text, param.Word).ToString();
          break;
        case (Mode.CheckSum):
          output = System.BitConverter.ToString(_checkSum.CheckSum(text));
          break;
      }
      return output;
    }
  }
}
