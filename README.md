# GerenciamentoDeTarefas

Sistema de gerenciamento de tarefas e projetos desenvolvido em .NET 8 e C# 12.0, utilizando arquitetura em tês camadas, Entity Framework Core, API RESTful e boas práticas de desenvolvimento.

## Sumário

- [Descrição](#descrição)
- [Funcionalidades](#funcionalidades)
- [Tecnologias Utilizadas](#tecnologias-utilizadas)
- [Estrutura do Projeto](#estrutura-do-projeto)
- [Instalação](#instalação)
- [Como Usar](#como-usar)
- [Migrations e Banco de Dados](#migrations-e-banco-de-dados)
- [Contribuição](#contribuição)
- [Licença](#licença)

---

## Descrição

Este projeto tem como objetivo facilitar o gerenciamento de tarefas e projetos, permitindo o cadastro de usuários, projetos e tarefas, além de validações e notificações automáticas. A API foi construída para ser escalável, segura e de fácil manutenção.

## Funcionalidades

- Cadastro, edição e exclusão de usuários
- Gerenciamento de projetos e tarefas
- Validações automáticas de dados
- Notificações de erros e operações inválidas
- Hash de senhas para segurança
- API RESTful com endpoints para todas as entidades principais

## Tecnologias Utilizadas

- **.NET 8**
- **C# 12.0**
- **Entity Framework Core**
- **AutoMapper**
- **ASP.NET Core Web API**
- **SQL Server** (padrão, pode ser alterado)
- **Swagger** (para documentação e testes)

## Estrutura do Projeto
src/ ├── Gerenciamento.API/           
# Camada de apresentação (Controllers, Configurações) ├── Gerenciamento.Business/      
# Regras de negócio, serviços, validações, notificações ├── Gerenciamento.Data/          
# Persistência de dados, repositórios, contexto EF

Principais arquivos e diretórios:
- `Controllers`: Endpoints da API
- `Models`: Entidades do domínio
- `Services`: Lógica de negócio
- `Repository`: Acesso ao banco de dados
- `Configurations`: Configurações de DI, AutoMapper, etc.

## Instalação

1. **Clone o repositório:**
git clone https://github.com/henrickk/GerenciamentoDeTarefas.git

2. **Acesse a pasta do projeto:**
cd GerenciamentoDeTarefas/src

3. **Configure a string de conexão do banco de dados**  
Edite o arquivo `appsettings.json` em `Gerenciamento.API` com sua string de conexão SQL Server.

4. **Restaure os pacotes:**
dotnet restore

5. **Execute as migrations para criar o banco:**
dotnet ef database update --project Gerenciamento.Data

6. **Inicie a aplicação:**
dotnet run --project Gerenciamento.API

## Como Usar

- Acesse `https://localhost:5001/swagger` para visualizar e testar os endpoints da API.
- Utilize ferramentas como Postman ou Insomnia para consumir os endpoints.
- Exemplos de endpoints:
- `GET /api/usuarios`
- `POST /api/projetos`
- `GET /api/tarefas`

## Migrations e Banco de Dados

- As migrations estão localizadas em `src/Gerenciamento.Data/Migrations`.
- O contexto principal é `MeuDbContext`.
- Para criar novas migrations:
dotnet ef migrations add NomeDaMigration --project Gerenciamento.Data

## Contribuição

Contribuições são bem-vindas!  
Para contribuir, siga os passos abaixo:

1. Fork este repositório
2. Crie uma branch (`git checkout -b feature/NovaFuncionalidade`)
3. Commit suas alterações (`git commit -m 'Adiciona nova funcionalidade'`)
4. Push para a branch (`git push origin feature/NovaFuncionalidade`)
5. Abra um Pull Request

## Licença

Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.
