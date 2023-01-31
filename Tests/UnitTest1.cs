using Xunit;
using CountWords;

namespace Tests;

public class UnitTest1
{
    [Fact]
    public void Test1()
    {
	CountWords.CountWordsCaseSensitive count = new CountWords.CountWordsCaseSensitive();
	int x = count.CountWords(" he she it we we they ", "we");
	Assert.Equal(2, x);
    }
}
