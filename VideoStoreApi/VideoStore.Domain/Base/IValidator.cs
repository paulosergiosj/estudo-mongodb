using System.Linq.Expressions;
using System;
using System.Threading.Tasks;

namespace VideoStore.Domain.Base
{
    public interface IValidator<T> where T : class
    {
        Task<(bool, string)> IsValid(T value);

        Validator<T> Must(Expression<Func<T, bool>> validation, string errorMessage);
    }
}
