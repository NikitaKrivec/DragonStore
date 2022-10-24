using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monster_Review_Store.Data;
using Monster_Review_Store.DTO;
using Monster_Review_Store.Interfaces;
using Monster_Review_Store.Models;

namespace Monster_Review_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;
        public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]
        public IActionResult GetCategories()
        {
            var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetCategories());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(categories);
        }

        [HttpGet("{categoryId}")]
        [ProducesResponseType(200, Type = typeof(Category))]
        [ProducesResponseType(200)]
        public IActionResult GetCategory(int categoryId)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
            {
                return NotFound();
            }
            var category = _mapper.Map<CategoryDTO>(_categoryRepository.GetCategory(categoryId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(category);
        }

        [HttpGet("dragon/{categoryId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Monster>))]
        [ProducesResponseType(200)]
        public IActionResult GetDragonByCategoryId(int categoryId)
        {
            var dragons = _mapper.Map<List<DragonDTO>>
                (_categoryRepository.GetDragonByCategory(categoryId));

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(dragons);
        }
    }
}
