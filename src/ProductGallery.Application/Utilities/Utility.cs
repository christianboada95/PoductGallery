using Microsoft.AspNetCore.Http;
using System.Security.Cryptography;

namespace ProductGallery.Application.Utilities;

public static class Utility
{
    public static async Task<byte[]> ToBytes(this IFormFile file)
    {
        byte[] bytes = new byte[file.Length];
        using (Stream sm = file.OpenReadStream())
        {
            await sm.ReadAsync(bytes);
        }
        return bytes;
    }

    public static byte[] ToHash(this byte[] filebytes) => MD5.Create().ComputeHash(filebytes);
}
