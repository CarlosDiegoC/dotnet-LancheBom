using LancheBom.Domain.Models;
using LancheBom.Repository;
using Microsoft.AspNetCore.Mvc;

namespace LancheBom.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdicionaisController : ControllerBase
    {
        private AdicionalRepository _adicionalRepository;
        public AdicionaisController(AdicionalRepository adicionalRepository)
        {
            _adicionalRepository = adicionalRepository;
        }

        [HttpPost]
        public async Task<ActionResult<Adicional>> Create(Adicional adicional)
        {
            await _adicionalRepository.Create(adicional);
            return Ok(adicional);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Adicional>>> Get()
        {
            var adicionais = await _adicionalRepository.Get();
            return Ok(adicionais);
        }
    }
}