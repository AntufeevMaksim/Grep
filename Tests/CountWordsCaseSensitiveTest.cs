using Xunit;
using CountWords;

namespace Tests;

public class CountWordsCaseSensitiveTest
{
  [Fact]
  public void TestNormalCase()
  {
    CountWordsCaseSensitive count_words = new CountWordsCaseSensitive();
    int count = count_words.CountWords(" he she it we we they ", "we");
    Assert.Equal(2, count);
  }

  [Fact]
  public void TestEmptyString()
  {
    CountWordsCaseSensitive count_words = new CountWordsCaseSensitive();
    int count = count_words.CountWords("", "we");
    Assert.Equal(0, count);
  }

}
