using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Monster_Review_Store.Data;
using Monster_Review_Store.DTO;
using Monster_Review_Store.Interfaces;
using Monster_Review_Store.Models;
using System.Threading;

namespace Monster_Review_Store.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class MonsterController : Controller
    {
        private readonly IDragonRepository _monsterRepository;
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        public MonsterController(IDragonRepository monsterRepository, IMapper mapper)
        {
            _monsterRepository = monsterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Monster>))]
        public IActionResult GetDragons()
        {
            var monster = _mapper.Map<List<DragonDTO>>(_monsterRepository.GetMonsters());

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
            if(!_monsterRepository.MonsterExists(dragonId))
            {
                return NotFound();
            }
            var monster = _mapper.Map<DragonDTO>(_monsterRepository.GetMonster(dragonId));
            //var monster = _monsterRepository.GetMonster(dragonId);

            if(!ModelState.IsValid)
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
            if (!_monsterRepository.MonsterExists(dragonId))
            {
                return NotFound();
            }

            var rating = _monsterRepository.GetMonsterRating(dragonId);
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return Ok(rating);

        }
    }

}
