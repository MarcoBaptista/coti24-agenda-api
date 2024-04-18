# Agenda ASP.NET com Estrutura DDD

Este é um exemplo de aplicação ASP.NET que utiliza a arquitetura Domain-Driven Design (DDD) para criar uma agenda de contatos. O DDD é uma abordagem que enfatiza a modelagem do domínio e a organização do código em torno dos conceitos centrais do negócio.

## Pré-requisitos

- [.NET SDK](https://dotnet.microsoft.com/download) instalado.
- Conhecimento básico de ASP.NET, C# e DDD.

## Estrutura do Projeto

A estrutura do projeto seguirá o padrão DDD:

- **Agenda.Domain**: Contém as entidades, regras de negócio e interfaces de serviços.
- **Agenda.Application**: Implementa os casos de uso da aplicação.
- **Agenda.Infrastructure**: Lida com a persistência de dados, serviços externos e outras infraestruturas.
- **Agenda.Web**: Projeto ASP.NET que expõe a interface do usuário.

## Configuração

1. Clone o repositório.
2. Abra o projeto no Visual Studio ou Visual Studio Code.
3. Configure a string de conexão com o banco de dados no arquivo `appsettings.json` dentro do projeto `Agenda.Web`.

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "SUA_STRING_DE_CONEXÃO_AQUI"
  }
}
```

4. Execute as migrações para criar o banco de dados:

```shell
dotnet ef database update
```

## Funcionalidades

- Cadastro de contatos com nome, telefone, e-mail etc.
- Listagem de contatos.
- Edição e exclusão de contatos.

## Executando a Aplicação

1. No terminal, navegue até a pasta `Agenda.Web`.
2. Execute o comando:

```shell
dotnet run
```

3. Acesse a aplicação em `http://localhost:5000`.

## Contribuições

Contribuições são bem-vindas! Sinta-se à vontade para abrir issues ou enviar pull requests.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).