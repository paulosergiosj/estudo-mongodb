using MongoDB.Bson;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using VideoStore.Application.Categories.Interfaces;
using VideoStore.Application.Helpers;
using VideoStore.Domain.Base;
using VideoStore.Domain.Categories.Contracts;
using VideoStore.Domain.Categories.Repositories;

namespace VideoStore.Application.Categories.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IValidator<CategoryCommand> _validator;
        private readonly ICategoryMapper _categoryMapper;
        private readonly ICategoryServiceBuilder _categoryServiceBuilder;

        public CategoryService(
            ICategoryRepository categoryRepository,
            IValidator<CategoryCommand> validator,
            ICategoryMapper categoryMapper,
            ICategoryServiceBuilder categoryServiceBuilder)
        {
            _categoryRepository = categoryRepository;
            _validator = validator;
            _categoryMapper = categoryMapper;
            _categoryServiceBuilder = categoryServiceBuilder;
        }

        public async Task<Result> CreateCategory(CategoryCommand categoryCommand)
        {
            var (isValid, message) = await _validator.IsValid(categoryCommand);

            if (!isValid)
                return ResultHelper.GetErrorResult(message);

            var category = _categoryMapper.MapCommandToEntity(categoryCommand);

            await _categoryRepository.InsertAsync(category);

            return new Result(HttpStatusCode.Created);
        }

        public async Task<Result> DeleteCategory(ObjectId id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            category.Remove();
            await _categoryRepository.UpdateAsync(category);

            return new Result(HttpStatusCode.OK);
        }

        public Result GetAllCategories() => new Result(_categoryRepository.GetByExpression(_categoryServiceBuilder.Build(), _categoryMapper.MapResponse()), HttpStatusCode.OK);

        public Result GetCategoryById(ObjectId id)
        {
            var builder = _categoryServiceBuilder.FilterById(id).Build();
            return new Result(_categoryRepository.GetByExpression(builder, _categoryMapper.MapResponse()).First(), HttpStatusCode.OK);
        }

        public async Task<Result> UpdateCategory(CategoryCommand categoryCommand)
        {
            var (isValid, message) = await _validator.IsValid(categoryCommand);

            if (!isValid)
                return ResultHelper.GetErrorResult(message);

            var category = _categoryMapper.MapCommandToEntity(categoryCommand);

            await _categoryRepository.UpdateAsync(category);

            return new Result(HttpStatusCode.OK);
        }
    }
}
