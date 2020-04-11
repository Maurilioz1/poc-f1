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

        public EquipesController(
            IEquipeRepository equipeRepository,
            IEquipeService equipeService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _equipeRepository = equipeRepository;
            _equipeService = equipeService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<EquipeViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<EquipeViewModel>>(await _equipeRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<EquipeViewModel>> ObterPorId(int id)
        {
            var equipe = _mapper.Map<EquipeViewModel>(await _equipeRepository.ObterEquipePilotos(id));

            if (equipe == null) return NotFound();

            return equipe;
        }

        [HttpPost]
        public async Task<ActionResult<EquipeViewModel>> Adicionar(EquipeViewModel equipeViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipeService.Adicionar(_mapper.Map<Equipe>(equipeViewModel));

            return CustomResponse(equipeViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<EquipeViewModel>> Atualizar(int id, EquipeViewModel equipeViewModel)
        {
            if (id != equipeViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _equipeService.Atualizar(_mapper.Map<Equipe>(equipeViewModel));

            return CustomResponse(equipeViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<EquipeViewModel>> Excluir(int id)
        {
            var equipeViewModel = _mapper.Map<EquipeViewModel>(await _equipeRepository.ObterPorId(id));

            if (equipeViewModel == null) return NotFound();

            await _equipeService.Remover(id);

            return CustomResponse(equipeViewModel);
        }
    }
}
