
using Moq;
using Xunit;
using Prog;
using CountWords;
using CheckSum;

using System.IO;

namespace Tests;

public class GrepTest
{
  [Fact]
  public void TestCountWords()
  {
    var count_words = new Mock<ICountWords>();
    count_words.Setup(c => c.CountWords("I you we they he she it this we \n","we")).Returns(2);
    
    var param = new Mock<IParams>();
    param.Setup(p => p.Mode).Returns(Mode.CountWords);
    param.Setup(p => p.StartParam).Returns(StartParam.WorkWithFile);
    param.Setup(p => p.Word).Returns("we");

    string text = "I you we they he she it this we \n";

    Grep grep = new Grep(new CheckSumMD5(), count_words.Object);
    string output = grep.Run(param.Object, text);

    Assert.Equal("2", output);  
  }

  [Fact]
  public void TestCheckSum()
  {
    var check_sum = new Mock<ICheckSum>();
    check_sum.Setup(a => a.CheckSum("I you we they he she it this we \n")).Returns(new byte[]{0x99, 0x99});

    Grep grep = new Grep(check_sum.Object, new CountWordsCaseSensitive());

    var param = new Mock<IParams>();
    param.Setup(p => p.Mode).Returns(Mode.CheckSum);
    param.Setup(p => p.StartParam).Returns(StartParam.WorkWithFile);

    string text = "I you we they he she it this we \n";

    string output = grep.Run(param.Object, text);

    Assert.Equal("99-99", output);
  }
  }
