using System.Security.Cryptography;
using System.Text;
class CheckSum
{
  public byte[] Checksum(string text)
  {
    var md5 = MD5.Create();
    byte[] checksum = md5.ComputeHash(Encoding.UTF8.GetBytes(text));
    return checksum;
  }
}