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
    public class CorridasController : MainController
    {
        private readonly ICorridaRepository _corridaRepository;
        private readonly ICorridaService _corridaService;
        private readonly IMapper _mapper;

        public CorridasController(
            ICorridaRepository corridaRepository,
            ICorridaService corridaService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _corridaRepository = corridaRepository;
            _corridaService = corridaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CorridaViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<CorridaViewModel>>(await _corridaRepository.ObterTodos());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CorridaViewModel>> ObterPorId(int id)
        {
            var corrida = _mapper.Map<CorridaViewModel>(await _corridaRepository.ObterPorId(id));

            if (corrida == null) return NotFound();

            return corrida;
        }

        [HttpPost]
        public async Task<ActionResult<CorridaViewModel>> Adicionar(CorridaViewModel corridaViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            var model = _mapper.Map<Corrida>(corridaViewModel);
            await _corridaService.Adicionar(model);

            return CustomResponse(_mapper.Map<CorridaViewModel>(model));
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<CorridaViewModel>> Atualizar(int id, CorridaViewModel corridaViewModel)
        {
            if (id != corridaViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _corridaService.Atualizar(_mapper.Map<Corrida>(corridaViewModel));

            return CustomResponse(corridaViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CorridaViewModel>> Excluir(int id)
        {
            var corridaViewModel = _mapper.Map<CorridaViewModel>(await _corridaRepository.ObterPorId(id));

            if (corridaViewModel == null) return NotFound();

            await _corridaService.Remover(id);

            return CustomResponse(corridaViewModel);
        }
    }
}
