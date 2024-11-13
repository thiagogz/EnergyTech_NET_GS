# Energy Tech - A TPC Solution

## Sumário
- [Integrantes;](#integrantes)
- [Descrição da Solução;](#descrição-da-solução)
- [Tecnologias utilizadas;](#tecnologias-utilizadas)
- [Instruções para uso da aplicação;](#instruções-para-uso-da-aplicação)
- [Testes de Endpoints da API.](#testes-de-endpoints-da-api)

## Integrantes
- Beatriz Lucas - RM99104;
- Enzo Farias - RM98792;
- Ewerton Gonçalves - RM98571;
- Guilherme Tantulli - RM97890;
- Thiago Zupelli - RM99085.

## Descrição da Solução
A Energy Tech é uma plataforma em formado de marketplace, onde empresas, pequenos produtores e consumidores individuais podem comercializar energia renovável excedente, de forma segura e transparente.\
O sistema inclui um programa de doação de energia para comunidades carentes, incentivando os fornecedores a contribuírem para a inclusão social, além de receber benefícios fiscais adicionais ao promover acesso à energia limpa em áreas vulneráveis.\
O app combina tecnologias de IoT e blockchain para validar e registrar a energia gerada, armazenada e disponível para venda ou doação, assegurando que o marketplace opere com dados precisos e que as transações sejam seguras.

## Tecnologias utilizadas
- **`Linguagem de Programação`**: C#;
- **`Framework`**: .NET Core 8.0;
- **`Banco de Dados`**: Oracle Database;
- **`Design Pattern`**: Repository Pattern;
- **`Authentication`**: Firebase Authentication; 
- **`Authorization`**: JWT Bearer.

## Instruções para uso da aplicação

**Execução da Aplicação**:\
    - Para iniciar a aplicação, você deve dar play com a configuração **`https`**. Isso pode ser feito diretamente dentro do seu Visual Studio (Ambiente de Desenvolvimento Integrado).

**Execução das requisições**:\
    - Após inicializar a aplicação, uma página web será aberta no seu navegador padrão. Nela, você poderá visualizar a documentação da API, bem como realizar requisições para a mesma;\
    - Para o primeiro registro, você deve utilizar o endpoint **`/api/Auth/register`**. Com o cadastro feito, basta utilizar as credenciais no endpoint **`/api/Auth/login`**. Após isso, você receberá o token de autenticação, que deve ser utilizado para realizar as demais requisições;\
    - A API requer autenticação para realizar as requisições. Para isso, você deve clicar no botão **`Authorize`** e inserir o token de autententicação **`Bearer`**, gerado ao fazer o login na aplicação;\
    - Para realizar a requisição desejada, basta clicar no endpoint desejado e, em seguida, no botão **`Try it out`**. Após isso, você poderá preencher os campos necessários para a requisição e, por fim, clicar no botão **`Execute`**.

## Testes de Endpoints da API
#### POST AuditLog:
```js
{
 "auditId": 105,
 "tableName": "tb_app_fornecedores",
 "actionType": "INSERT",
 "recordId": 1,
 "actionDate": "2024-11-10T23:06:49",
 "userName": "RM99085"
}
```

#### UPDATE AuditLog:
```js
{
 "auditId": 105,
 "tableName": "tb_app_fornecedores",
 "actionType": "UPDATE",
 "recordId": 1,
 "actionDate": "2024-11-10T23:06:49",
 "userName": "RM99085"
}
```

#### POST Cliente:
```js
{
  "clienteId": 21,
  "nome": "João Pedro",
  "email": "joaopedro@gmail.com",
  "senhaHash": "senha_hash1",
  "telefone": "11912123434",
  "endereco": "Rua do teste, 123",
  "dataCadastro": "2024-11-11T22:28:48.584Z"
}
```

#### UPDATE Cliente:
```js
{
  "clienteId": 21,
  "nome": "João Paulo",
  "email": "joaopaulo@gmail.com",
  "senhaHash": "senha_hash1",
  "telefone": "11912123434",
  "endereco": "Rua do teste, 123",
  "dataCadastro": "2024-11-11T22:28:48.584Z"
}
```

#### POST Energia:
```js
{
  "energiaId": 11,
  "tipoEnergia": "Solar",
  "quantidadeDisponivel": 1200,
  "precoUnitario": 0.50,
  "dataGeracao": "2024-11-11T22:35:55.116Z",
  "fornecedorId": 1,
  "fornecedor": null
}
```

#### UPDATE Energia:
```js
{
  "energiaId": 11,
  "tipoEnergia": "Solar",
  "quantidadeDisponivel": 4200,
  "precoUnitario": 0.96,
  "dataGeracao": "2024-11-11T22:35:55.116Z",
  "fornecedorId": 3,
  "fornecedor": null
}
```

#### POST EstoqueEnergia:
```js
{
  "estoqueId": 11,
  "energiaId": 1,
  "dispositivoId": "DISP_SOLAR11",
  "quantidadeArmazenada": 2000,
  "dataAtualizacao": "2024-11-11T22:45:39.583Z",
  "energia": null
}
```

#### UPDATE EstoqueEnergia:
```js
{
  "estoqueId": 11,
  "energiaId": 4,
  "dispositivoId": "DISP_SOLAR11",
  "quantidadeArmazenada": 2000,
  "dataAtualizacao": "2024-11-11T22:45:39.583Z",
  "energia": null
}
```

#### POST Fornecedor:
```js
{
  "fornecedorId": 11,
  "nome": "Power Solar",
  "email": "powersolar@example.com",
  "senhaHash": "senha_hash1",
  "telefone": "11956567878",
  "endereco": "Avenida do Teste, 123",
  "dataCadastro": "2024-11-10T23:06:49"
}
```

#### UPDATE Fornecedor:
```js
{
  "fornecedorId": 11,
  "nome": "Poder do Sol",
  "email": "poderdosol@example.com",
  "senhaHash": "senha_hash1",
  "telefone": "11956567878",
  "endereco": "Avenida do Teste, 123",
  "dataCadastro": "2024-11-10T23:06:49"
}
```

#### POST Transação:
```js
{
  "transacaoId": 11,
  "tipoTransacao": "Compra",
  "quantidade": 5000,
  "valorTotal": 450,
  "dataTransacao": "2024-11-11T22:42:21.084Z",
  "clienteId": 2,
  "energiaId": 3,
  "blockchainHash": "hash_transacao_11",
  "statusBlockchain": "Confirmada",
  "cliente": null,
  "energia": null
}
```

#### UPDATE Transação:
```js
{
  "transacaoId": 11,
  "tipoTransacao": "Compra",
  "quantidade": 2000,
  "valorTotal": 300,
  "dataTransacao": "2024-11-11T22:42:21.084Z",
  "clienteId": 4,
  "energiaId": 5,
  "blockchainHash": "hash_transacao_11",
  "statusBlockchain": "Confirmada",
  "cliente": null,
  "energia": null
}
```

#### POST Login:
```js
{
  "email": "testeapi@gmail.com",
  "senha": "testeapi123"
}
```
