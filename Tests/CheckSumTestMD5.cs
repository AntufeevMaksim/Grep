using Xunit;
using CheckSum;

namespace Tests;

public class CheckSumMD5Test
{
  [Fact]
  public void TestNormalCase()
  {
    CheckSumMD5 check_sum = new CheckSumMD5();
    var sum = check_sum.CheckSum(" he she it 1234 *!` ");
    Assert.Equal("9E-D6-1E-27-1F-06-6A-8A-09-AB-19-17-31-FB-FB-71", System.BitConverter.ToString(sum));
  }

  [Fact]
  public void TestEmptyString()
  {
    CheckSumMD5 check_sum = new CheckSumMD5();
    var sum = check_sum.CheckSum("");
    Assert.Equal("D4-1D-8C-D9-8F-00-B2-04-E9-80-09-98-EC-F8-42-7E", System.BitConverter.ToString(sum));
  }

}