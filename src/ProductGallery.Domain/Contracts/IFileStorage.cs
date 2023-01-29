using System;
using ProductGallery.Domain.Commom;

namespace ProductGallery.Domain.Contracts;

public interface IFileStorage<T> where T : FileBase
{
    Task<string> SaveFileAsync(T file, CancellationToken cancellationToken = default);
    Task DeleteFileAsync(T file, CancellationToken cancellationToken = default);
}