using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monster_Review_Store.DTO;
using Monster_Review_Store.Interfaces;
using Monster_Review_Store.Models;

namespace Monster_Review_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class DragonController : Controller
    {
        private readonly IDragonRepository _dragonRepository;
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public DragonController(IDragonRepository monsterRepository,
            IReviewRepository reviewRepository, IMapper mapper)
        {
            _dragonRepository = monsterRepository;
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Monster>))]
        public IActionResult GetDragons()
        {
            var monster = _mapper.Map<List<DragonDTO>>(_dragonRepository.GetDragons());

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(monster);
        }

        [HttpGet("{dragonId}")]
        [ProducesResponseType(200, Type = typeof(Monster))]
        [ProducesResponseType(200)]
        public IActionResult GetDragon(int dragonId)
        {
            if(!_dragonRepository.MonsterExists(dragonId))
            {
                return NotFound();
            }
            var monster = _mapper.Map<DragonDTO>(_dragonRepository.GetDragon(dragonId));
            //var monster = _dragonRepository.GetDragon(dragonId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(monster);
        }

        [HttpGet("{dragonId}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        [ProducesResponseType(200)]
        public IActionResult GetDragonRating(int dragonId)
        {
            if (!_dragonRepository.MonsterExists(dragonId))
            {
                return NotFound();
            }

            var rating = _dragonRepository.GetMonsterRating(dragonId);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rating);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateDragon([FromQuery] int ownerId, [FromQuery] int categoryId, [FromBody] DragonDTO newDragon)
        {
            if (newDragon == null)
            {
                return BadRequest(ModelState);
            }

            var dragon = _dragonRepository.GetDragons()
                .Where(c => c.Name.Trim().ToUpper() == newDragon.Name.TrimEnd().ToUpper())
                .FirstOrDefault();

            if (dragon != null)
            {
                ModelState.AddModelError("", "Country already exists");
                return StatusCode(422, ModelState);
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dragonMap = _mapper.Map<Monster>(newDragon);

            if (!_dragonRepository.CreateDragon(ownerId, categoryId, dragonMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{dragonId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult UpdateDragon(int dragonId, [FromQuery] int ownerId,
            [FromQuery] int categoryId,[FromBody] DragonDTO updatedDragon)
        {
            if (updatedDragon == null)
            {
                return BadRequest(ModelState);
            }

            if (dragonId != updatedDragon.Id)
            {
                return BadRequest(ModelState);
            }

            if (!_dragonRepository.MonsterExists(dragonId))
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var dragonMap = _mapper.Map<Monster>(updatedDragon);

            if (!_dragonRepository.UpdateDragon(ownerId, categoryId, dragonMap))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{dragonId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteDragon(int dragonId)
        {
            if (!_dragonRepository.MonsterExists(dragonId))
            {
                return NotFound();
            }

            var reviewsDelete = _reviewRepository.GetReviewsOfADragon(dragonId);
            var dragonDelete = _dragonRepository.GetDragon(dragonId);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(!_reviewRepository.DeleteReviews(reviewsDelete.ToList()))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            if (!_dragonRepository.DeleteDragon(dragonDelete))
            {
                ModelState.AddModelError("", "Something went wrong");
                return StatusCode(500, ModelState);
            }

            return Ok("Succesfully deleted");
        }
    }

}
