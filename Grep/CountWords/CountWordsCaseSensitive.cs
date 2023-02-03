
namespace CountWords
{
  public class CountWordsCaseSensitive : ICountWords
  {
    public int CountWords(string text, string word)
    {
      int count = text.Split().Where(w => w == word).Count();
      return count;
    }
  }
}
