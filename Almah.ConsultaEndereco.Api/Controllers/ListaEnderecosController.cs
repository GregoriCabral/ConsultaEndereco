using Almah.ConsultaEndereco.Servico.ViaCep;
using Microsoft.AspNetCore.Mvc;

namespace Almah.ConsultaEndereco.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaEnderecosController:ControllerBase
    {
        [HttpGet(Name = "GetEnderecoPorEstadoeECidade")]
        public async Task<IActionResult> ObterListaDeEnderecos(string estado, string cidade)
        {
            var requisicao = await new ViaCepService().ObterListaDeEnderecoPorUfCidade(estado, cidade);
            return Ok(requisicao);
        }
    }
}
