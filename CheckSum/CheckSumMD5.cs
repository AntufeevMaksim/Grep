
using System.Security.Cryptography;
using System.Text;

class CheckSumMD5 : ICheckSum
{
  public byte[] CheckSum(string text)
  {
    var md5 = MD5.Create();
    byte[] checksum = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
    return checksum;
  }
}
