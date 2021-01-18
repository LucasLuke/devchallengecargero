# devchallengecargero
Desafio de programação da cagueiro

Esta API possui a as seguintes funcionalidades...
1- Registro de usuarios;
2- Cadastro de um endereço associado ao usuario;
3- Deletar o usuario;
4- Atualizar endereço cadastrado;
5- Filtro de endereço pelo nome do usuario.

Ferramentas utilizadas:
Visual Studio;
Talend API Tester;
gmaps-api-net

As funcionalidades desse sistema espera as seguintes informações:

1- Registro de usuarios;

Json contendo o nome do usuario:
{"Name":"Fulano de tal"}

Após o cadastro o sistema irá retornar o nome do usuario registrado em caso de sucesso.


2- Cadastro de um endereço associado ao usuario:

{
  "Street":"rua xx",
  "ZipCode":"10000000",
  "Number":111,
  "Complement":"prox a yy",
  "City":"Xxxxxx",
  "District":"xxxxx",
  "State":"AA",
  "UserName":"Fulano de Tal"
}

Retorna o registro cadastrado em caso de sucesso.

3- Deletar o Endereço:

{
  "Id": "1",
  "user":"Fulano de Tal"
}

retorna json com status da atualização.

4- Atualizar endereço cadastrado:
{
  "Id":1
  "user":"Fulano de Tal",
  "number": 5,
  "complement": "xxxxxx"
}

retorna json com status da atualização.

5- Filtro de endereço pelo nome do usuario:
{
  "user": "Fulano de Tal"
}

Retorna json com endereços associados ao usuario.
