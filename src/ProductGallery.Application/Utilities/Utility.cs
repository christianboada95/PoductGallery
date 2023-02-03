using Microsoft.AspNetCore.Http;
using System.Linq.Dynamic.Core;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

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

    public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string orderByQueryString)
    {
        if (!query.Any() || string.IsNullOrWhiteSpace(orderByQueryString))
            return query;

        var orderParams = orderByQueryString.Trim().Split(',');
        var propertyInfos = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var orderQueryBuilder = new StringBuilder();
        foreach (var param in orderParams)
        {
            if (string.IsNullOrWhiteSpace(param))
                continue;
            var propertyFromQueryName = param.Split(" ")[0];
            var objectProperty = propertyInfos.FirstOrDefault(pi => pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));
            if (objectProperty == null)
                continue;
            var sortingOrder = param.EndsWith(" desc") ? "descending" : "ascending";
            orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {sortingOrder}, ");
        }
        var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');
        if (string.IsNullOrWhiteSpace(orderQuery))
            return query;

        return query.OrderBy(orderQuery);
    }
}
