using Almah.ConsultaEndereco.Dominio.Entities;
using Newtonsoft.Json;

namespace Almah.ConsultaEndereco.Servico.ViaCep
{
    public class ViaCepService
    {
        //Função assincrona que ira comunicar com o servidor viacep
        public async Task<EnderecoEntity> ObterEnderecoPorCep(string cep)
        {
            //Abrindo um protocolo HTTP para comunicar-se com outro servidor
            var httpClient = new HttpClient();

            //Executando a operação de requisição para a rota da ViaCep, passando o CEP de forma dinâmica
            var retornoRequisicao = await httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");

            //Verificando se a requisição respondeu com sucesso
            if (retornoRequisicao.IsSuccessStatusCode)
            {
                //Deu sucesso, consegui comunicar com a ViaCep
                //Obter a informação retornada pela API
                var objetoSerializado = await retornoRequisicao.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<EnderecoEntity>(objetoSerializado); 
            }

            return new EnderecoEntity();
        }

        public async Task<List<EnderecoEntity>> ObterListaDeEnderecoPorUfCidade(string estado, string cidade)
        {
            var httpClient = new HttpClient();
            var retonroRequisicao = await httpClient.GetAsync($"https://viacep.com.br/ws/{estado}/{cidade}/Rua/json/");

            if(retonroRequisicao.IsSuccessStatusCode)
            {
                var objetoSerializado = await retonroRequisicao.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<List<EnderecoEntity>>(objetoSerializado);
            }

            return new List<EnderecoEntity>();
        }
    }
}
