using VideoStore.Domain.Base;
using VideoStore.Domain.Models.Enums;

namespace VideoStore.Domain.Categories.Contracts
{
    public class CategoryCommand : CommandBase
    {
        public string Id { get; set; }
        public string Description { get; set; }

        public CategoryCommand SetOperation(Operation operation)
        {
            Operation = operation;
            return this;
        }
    }
}
