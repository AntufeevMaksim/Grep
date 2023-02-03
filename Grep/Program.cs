
using CheckSum;
using CountWords;
using Prog;


internal class Program
{
  static void Main(string[] args)
  {
      Params param = new Params();
      param.Parse(args);
      string text = File.ReadAllText(param.FilePath);
      Grep grep = new Grep(new CheckSumMD5(), new CountWordsCaseSensitive());
      Console.WriteLine(grep.Run(param, text));
  }
}
