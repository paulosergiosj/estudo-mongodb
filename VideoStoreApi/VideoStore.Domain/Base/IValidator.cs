using System.Threading.Tasks;

namespace VideoStore.Domain.Base
{
    public interface IValidator<T>
    {
        Task<(bool, string)> IsValid(T value);
    }
}
