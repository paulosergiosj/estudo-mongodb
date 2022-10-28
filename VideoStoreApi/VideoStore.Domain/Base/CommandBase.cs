using VideoStore.Domain.Models.Enums;
using VideoStore.Domain.Movies.Contracts;

namespace VideoStore.Domain.Base
{
    public class CommandBase
    {
        public Operation Operation { get; internal set; }
    }
}
