# Gerenciamento de Tarefas

Projeto de gerenciamento de tarefas desenvolvido em **.NET Core**, inspirado no curso [“Projetando Arquiteturas em Três Camadas”](https://www.desenvolvedor.io/). O objetivo foi aplicar boas práticas de desenvolvimento, arquitetura em camadas e padrões de projeto.

---

## 📌 Tecnologias utilizadas

- **.NET Core 8**
- **C#**
- **Entity Framework Core** (Code First, Migrations)
- **SQLite** (banco de dados local, pode ser substituído)
- **Repository Pattern**
- **AutoMapper**
- **FluentValidation**
- **JWT** (para autenticação, se necessário)
- **Camadas**:
  - **API** → Endpoints REST
  - **Business** → Regras de negócio e validações
  - **Data** → Persistência de dados

---

## 🏗 Estrutura do projeto

GerenciamentoDeTarefas/
│
├── Gerenciamento.API/          # Camada de API
├── Gerenciamento.Business/     # Camada de regras de negócio
├── Gerenciamento.Data/         # Camada de persistência e mapeamento
└── Gerenciamento.Tests/        # (Opcional) Testes unitários

---

## ⚡ Funcionalidades

- CRUD de **Projetos**
- CRUD de **Tarefas**
- CRUD de **Usuários**
- Relacionamento entre usuários, projetos e tarefas
- Filtragem de tarefas por status, prioridade ou usuário
- Validações e notificações via **FluentValidation**
- Controle de datas de criação e conclusão
- Boas práticas de arquitetura e padrões de projeto aplicados

---

## 🛠 Principais conceitos aplicados

- **Repository Pattern** → separação da camada de dados da camada de negócio
- **DTOs e AutoMapper** → conversão entre entidades e modelos de transferência
- **Notificador** → gerenciamento de mensagens e erros
- **Camadas separadas** → API, Business e Data
- **Boas práticas de código** → responsabilidade única, código limpo e manutenção facilitada

---

## 🚀 Como executar o projeto

1. Clone o repositório:

```bash
git clone https://github.com/henrickk/GerenciamentoDeTarefas.git
cd GerenciamentoDeTarefas
````

2. Abra a solução no **Visual Studio** ou **VS Code**

3. Atualize o banco de dados usando **Entity Framework Core**:

```bash
dotnet ef database update
```

4. Execute a API:

```bash
dotnet run --project Gerenciamento.API
```

5. Acesse os endpoints via **Postman**, **Insomnia** ou navegador (Swagger disponível, se configurado).

---

## 📂 Estrutura das entidades

* **Usuario**

  * Id, Nome, Email, SenhaHash, Role, DataCadastro, Ativo
  * Relacionamento com Projetos e Tarefas
* **Projeto**

  * Id, Nome, Descricao, DataInicio, DataFim, DataConclusao
  * Relacionamento com Tarefas e Usuário dono
* **Tarefa**

  * Id, Titulo, Descricao, Status, Prioridade, DataCriacao, DataConclusao
  * Relacionamento com Projeto e Usuário responsável

---

## 📚 Referências

* Curso: [Projetando Arquiteturas em Três Camadas - desenvolvedor.io](https://www.desenvolvedor.io/)
* Documentação .NET: [https://docs.microsoft.com/dotnet/](https://docs.microsoft.com/dotnet/)
* Entity Framework Core: [https://docs.microsoft.com/ef/core/](https://docs.microsoft.com/ef/core/)

---

## 📂 Repositório

[https://github.com/henrickk/GerenciamentoDeTarefas](https://github.com/henrickk/GerenciamentoDeTarefas)

---

## 📝 Observações

Este projeto é uma aplicação de aprendizado e prática de boas práticas em **.NET Core**. Pode ser expandido com autenticação JWT, testes unitários e outras funcionalidades para produção.

---

**Autor:** Henrick Adrian
**LinkedIn:** [https://www.linkedin.com/in/henrick-adrian](https://www.linkedin.com/in/henrick-adrian)
