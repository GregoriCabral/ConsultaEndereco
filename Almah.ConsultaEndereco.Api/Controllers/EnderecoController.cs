using Almah.ConsultaEndereco.Servico.ViaCep;
using Microsoft.AspNetCore.Mvc;

namespace Almah.ConsultaEndereco.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController:ControllerBase
    {
        //Adicionar isso para diferentes requisições
        [HttpGet(Name = "GetEnderecoPorCep")]
        public async Task<IActionResult> ObterEndereco(string cep)
        {
            var requisicao = await new ViaCepService().ObterEnderecoPorCep(cep);
            return Ok(requisicao);
        }
    }
}
