//using System.Linq;

class CountWords
{
  public int Count(string text, string word)
  {
    int count = text.Split().Where(w => w==word).Count();
    return count;
  }
}