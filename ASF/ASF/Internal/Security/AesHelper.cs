using System;
using System.Security.Cryptography;
using System.Text;

namespace ASF.Internal.Security;

/// <summary>
  ///  aes 加密/解密
  /// </summary>
  public static class AesHelper
  {
    /// <summary>
    /// aes 加密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <param name="blockSize"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Encrypt(string data, string key, byte[] iv, CipherMode cipherMode, PaddingMode paddingMode,int blockSize = 128)
    {
      if (string.IsNullOrEmpty(data))
      {
        throw new ArgumentNullException(nameof(data));
      }

      if (string.IsNullOrEmpty(key))
      {
        throw new ArgumentNullException(nameof(key));
      }

      if (iv == null)
      {
        throw new ArgumentNullException(nameof(iv));
      }

      using (var aes = Aes.Create())
      {
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = iv;
        aes.BlockSize = blockSize;
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        using (var ctf = aes.CreateEncryptor())
        {
          var content = Encoding.UTF8.GetBytes(data);
          return Convert.ToBase64String(ctf.TransformFinalBlock(content, 0, content.Length));
        }
      }
    }
    /// <summary>
    /// aes 解密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="iv"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <param name="blockSize"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Decrypt(string data, string key, byte[] iv, CipherMode cipherMode, PaddingMode paddingMode,int blockSize = 128)
    {
      if (string.IsNullOrEmpty(data))
      {
        throw new ArgumentNullException(nameof(data));
      }

      if (string.IsNullOrEmpty(key))
      {
        throw new ArgumentNullException(nameof(key));
      }

      if (iv == null)
      {
        throw new ArgumentNullException(nameof(iv));
      }

      using (var aes = Aes.Create())
      {
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.IV = iv;
        aes.BlockSize = blockSize;
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        using (var ctf = aes.CreateDecryptor())
        {
          var content = Convert.FromBase64String(data);
          return Encoding.UTF8.GetString(ctf.TransformFinalBlock(content, 0, content.Length));
        }
      }
    }
    /// <summary>
    /// aes 加密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Encrypt(string data, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
      if (string.IsNullOrEmpty(data))
      {
        throw new ArgumentNullException(nameof(data));
      }

      if (string.IsNullOrEmpty(key))
      {
        throw new ArgumentNullException(nameof(key));
      }

      using (var aes = Aes.Create())
      {
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        using (var ctf = aes.CreateEncryptor())
        {
          var content = Encoding.UTF8.GetBytes(data);
          return Convert.ToBase64String(ctf.TransformFinalBlock(content, 0, content.Length));
        }
      }
    }
    /// <summary>
    /// aes 解密
    /// </summary>
    /// <param name="data"></param>
    /// <param name="key"></param>
    /// <param name="cipherMode"></param>
    /// <param name="paddingMode"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentNullException"></exception>
    public static string Decrypt(string data, string key, CipherMode cipherMode, PaddingMode paddingMode)
    {
      if (string.IsNullOrEmpty(data))
      {
        throw new ArgumentNullException(nameof(data));
      }

      if (string.IsNullOrEmpty(key))
      {
        throw new ArgumentNullException(nameof(key));
      }

      using (var aes = Aes.Create())
      {
        aes.Key = Encoding.UTF8.GetBytes(key);
        aes.Mode = cipherMode;
        aes.Padding = paddingMode;

        using (var ctf = aes.CreateDecryptor())
        {
          var content = Convert.FromBase64String(data);
          byte[] resultArray = ctf.TransformFinalBlock(content, 0, content.Length);
          return Encoding.UTF8.GetString(resultArray);
        }
      }
    }
  }