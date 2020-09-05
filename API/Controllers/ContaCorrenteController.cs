using System;
using Domain.DTO;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service.Interfaces;

namespace API.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class ContaCorrenteController : ControllerBase
    {
        private readonly ILogger<ContaCorrenteController> _logger;

        private readonly IContaCorrenteService _contaCorrenteService;

        public ContaCorrenteController(ILogger<ContaCorrenteController> logger, IContaCorrenteService contaCorrenteService)
        {
            _logger = logger;
            _contaCorrenteService = contaCorrenteService;
        }

        [HttpPost("CadastrarContaCorrrente")]
        public ActionResult CadastrarContaCorrrente(ContaCorrenteDTO contaCorrenteDTO)
        {
            try
            {
                var result = _contaCorrenteService.CadastrarContaCorrrente(contaCorrenteDTO);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("RealizarTransferencia")]
        public ActionResult RealizarTransferencia(TransferenciaDTO transferenciaDTO)
        {
            try
            {
                var result = _contaCorrenteService.RealizarTransferencia(transferenciaDTO);

                return Ok(result);
            }
            catch (AppNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
