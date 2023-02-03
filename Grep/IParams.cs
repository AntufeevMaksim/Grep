
namespace Prog
{
  public interface IParams
  {
    StartParam StartParam { get; }
    string FilePath { get; }
    Mode Mode { get; }
    string Word { get; }

    void Parse(string[] args);
  }
}
