using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using POCF1.Api.ViewModels;
using POCF1.Business.Interfaces;
using POCF1.Business.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace POCF1.Api.Controllers
{
    [Route("api/[controller]")]
    public class EquipesController : MainController
    {
        private readonly IEquipeRepository _equipeRepository;
        private readonly IEquipeService _equipeService;
        private readonly IMapper _mapper;

        public EquipesController(IEquipeRepository equipeRepository, IEquipeService equipeService, IMapper mapper)
        {
            _equipeRepository = equipeRepository;
            _equipeService = equipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EquipeViewModel>> ObterTodos()
        {
            var equipe = _mapper.Map<IEnumerable<EquipeViewModel>>(await _equipeRepository.ObterTodos());

            return equipe;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EquipeViewModel>> ObterPorId(int id)
        {
            var equipe = _mapper.Map<EquipeViewModel>(await _equipeRepository.ObterPorId(id));

            if (equipe == null) return NotFound();

            return equipe;
        }

        [HttpPost]
        public async Task<ActionResult<EquipeViewModel>> Adicionar(EquipeViewModel equipeViewModel)
        {
            if (!ModelState.IsValid) return BadRequest();

            var equipe = _mapper.Map<Equipe>(equipeViewModel);
            var result = await _equipeService.Adicionar(equipe);

            if (!result) return BadRequest();

            return Ok(equipe);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EquipeViewModel>> Atualizar(int id, EquipeViewModel equipeViewModel)
        {
            if (id != equipeViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            var equipe = _mapper.Map<Equipe>(equipeViewModel);
            var result = await _equipeService.Atualizar(equipe);

            if (!result) return BadRequest();

            return Ok(equipe);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EquipeViewModel>> Excluir(int id)
        {
            var equipe = _mapper.Map<EquipeViewModel>(await _equipeRepository.ObterEquipe(id));

            if (equipe == null) return NotFound();

            var result = await _equipeService.Remover(id);

            if (!result) return BadRequest();

            return Ok(equipe);
        }
    }
}
