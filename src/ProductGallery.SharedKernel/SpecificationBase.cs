using ProductGallery.Domain.Contracts;
using System.Linq.Expressions;

namespace ProductGallery.SharedKernel;

public abstract class SpecificationBase<T> : ISpecification<T>
{
    public SpecificationBase(Expression<Func<T, bool>> criteria)
    {
        Criteria = criteria;
    }

    public Expression<Func<T, bool>> Criteria { get; }
    public int? Take { get; internal set; } = null;
    public int? Skip { get; internal set; } = null;
    public List<Expression<Func<T, object>>> Includes { get; } = new List<Expression<Func<T, object>>>();

    protected virtual void AddTake(int take) => Take = take;
    protected virtual void AddSkip(int skip) => Skip = skip;
    protected virtual void AddInclude(Expression<Func<T, object>> includeExpression)
    {
        Includes.Add(includeExpression);
    }


}
