using LancheBom.Domain.Models;
using LancheBom.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LancheBom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LanchesController : ControllerBase
    {
        private LancheRepository _lancheRepository;
        public LanchesController(LancheRepository lancheRepository)
        {
            _lancheRepository = lancheRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Lanche>> Create(Lanche lanche)
        {
            await _lancheRepository.Create(lanche);
            return Ok(lanche);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lanche>>> Get()
        {
            var lanches = await _lancheRepository.Get();
            return Ok(lanches);
        }

    }
}