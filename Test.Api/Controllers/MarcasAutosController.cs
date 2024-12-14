using Microsoft.AspNetCore.Mvc;
using Test.Application.Contracts;
using Test.Domain.Entities;

namespace Test.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcasAutosController(IBaseRepository<MarcaAuto> marcaAutoRepository)
    {
        private readonly IBaseRepository<MarcaAuto> _marcaAutoRepository = marcaAutoRepository;

        [HttpGet]
        public IQueryable<MarcaAuto> Get() => _marcaAutoRepository.Query();
    }
    }
