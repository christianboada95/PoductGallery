using System.Linq.Expressions;

namespace ProductGallery.Domain.Contracts;

public interface ISpecification<T>
{
    Expression<Func<T, bool>> Criteria { get; }
    int? Take { get; }
    int? Skip { get; }
    List<Expression<Func<T, object>>> Includes { get; }
}
