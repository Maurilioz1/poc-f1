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
    public class PilotosController : MainController
    {
        private readonly IPilotoRepository _pilotoRepository;
        private readonly IPilotoService _pilotoService;
        private readonly IMapper _mapper;

        public PilotosController(
            IPilotoRepository pilotoRepository,
            IPilotoService pilotoService,
            IMapper mapper,
            INotificador notificador) : base(notificador)
        {
            _pilotoRepository = pilotoRepository;
            _pilotoService = pilotoService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<PilotoViewModel>> ObterTodos()
        {
            return _mapper.Map<IEnumerable<PilotoViewModel>>(await _pilotoRepository.ObterPilotosEquipes());
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<PilotoViewModel>> ObterPorId(int id)
        {
            var piloto = _mapper.Map<PilotoViewModel>(await _pilotoRepository.ObterPilotoEquipe(id));

            if (piloto == null) return NotFound();

            return piloto;
        }

        [HttpPost]
        public async Task<ActionResult<PilotoViewModel>> Adicionar(PilotoViewModel pilotoViewModel)
        {
            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pilotoService.Adicionar(_mapper.Map<Piloto>(pilotoViewModel));

            return CustomResponse(pilotoViewModel);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<PilotoViewModel>> Atualizar(int id, PilotoViewModel pilotoViewModel)
        {
            if (id != pilotoViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return CustomResponse(ModelState);

            await _pilotoService.Atualizar(_mapper.Map<Piloto>(pilotoViewModel));

            return CustomResponse(pilotoViewModel);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<PilotoViewModel>> Excluir(int id)
        {
            var piloto = _mapper.Map<PilotoViewModel>(await _pilotoRepository.ObterPilotoEquipe(id));

            if (piloto == null) return NotFound();

            await _pilotoService.Remover(id);

            return CustomResponse(piloto);
        }
    }
}
