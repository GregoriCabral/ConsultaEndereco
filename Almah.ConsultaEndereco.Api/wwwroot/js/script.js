function clearFormCep() {
    document.getElementById('cep').value = ("");
    document.getElementById('rua').value = ("");
    document.getElementById('bairro').value = ("");
    document.getElementById('cidade').value = ("");
    document.getElementById('estado').value = ("");
}

function clearList() {
    let lista = document.getElementById('responseList');
    lista.innerHTML = '';
}


function pesquisaCep(valor) {

    var cep = valor.replace(/\D/g, '');

    if (cep != "") {

        var validacep = /^[0-9]{8}$/;

        if (validacep.test(cep)) {
            fetch(`/Endereco?cep=${cep}`)
                .then(response => response.json())
                .then(dados => {

                    if (!dados.erro) {
                        document.getElementById('rua').value = dados.logradouro;
                        document.getElementById('bairro').value = dados.bairro;
                        document.getElementById('cidade').value = dados.localidade;
                        document.getElementById('estado').value = dados.uf;
                    } else {
                        clearFormCep();
                        alert('CEP não encontrado');
                    }
                });
        }
        else {
            clearFormCep();
            alert("CEP não encontrado");
        }
    }
    else {
        clearFormCep();
        alert("Formato de CEP inválido.");
    }
};

function listarEnderecos(estado, cidade) {

    if (estado != "" && cidade != "") {
        fetch(`/ListaEnderecos?estado=${estado}&cidade=${cidade}`)
            .then(response => response.json())
            .then(dados => {
                if (dados != "") {
                    clearList();
                    dados.forEach(enderecos => {
                        let lista = document.getElementById('responseList');
                        let item = document.createElement('p')
                        item.textContent = `Rua: ${enderecos.logradouro}, Bairro: ${enderecos.bairro}, Cidade: ${enderecos.localidade}, Estado: ${enderecos.uf}, CEP: ${enderecos.cep}`;
                        lista.appendChild(item);
                    })
                } else {
                    clearList();
                    alert("Nenhum endereço encontrado");
                }
            });
    } else {
        alert('Informações inválidas');
    }
}