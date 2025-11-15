
# Talency API (.NET) – Global Solution FIAP 2025/2

API em .NET 9 que para a nossa solução **TalentRoad / Talency**, focada em **trilhas profissionais, requalificação de carreira e acompanhamento de progresso**.

A API expõe emdpoints para:
- Usuários e autenticação (JWT)
- Trilhas e etapas
- Roadmaps e metas
- Progresso do usuário
- Testes / quizzes e respostas

---

## 👥 Integrantes

- **Felipe Menezes Prometti** – RM555174 – 2TDSPM  
- **Maria Eduarda Pires** – RM558976 – 2TDSPZ  
- **Samuel Damasceno** – RM558876 – 2TDSPM  

---

## 🌍 Visão da Nossa Solução TalentRoad

A plataforma ajuda pessoas a se prepararem para o futuro do trabalho através de:

- **Trilhas profissionais** (ex.: Dev Fullstack, Cientista de Dados, UX, Energia Verde, Cibersegurança)  
- **Testes práticos e quizzes** por etapa da trilha  
- **Roadmap personalizado** com metas e ordem sugerida de estudo  
- **Dashboard de evolução** (progresso, trilhas concluídas, habilidades desenvolvidas)  

---

## 🧱 Arquitetura (.NET)

Estrutura do repositório:

```plaintext
📦 Talency
 ┣ 📂 src
 ┃  ┣ 📂 Api             → Controllers, JWT, Swagger, Health
 ┃  ┣ 📂 Application     → DTOs, Services, Interfaces de Serviço
 ┃  ┣ 📂 Domain          → Entidades e Interfaces de Repositório
 ┃  ┗ 📂 Infrastructure  → MongoDbContext, Repositórios, TokenService, PasswordHasher
 ┗ 📂 tests              → Testes de unidade e integração (xUnit)
```

**Principais entidades (Domain)**  
`Usuario`, `Trilha`, `EtapaTrilha`, `ProgressoUsuario`, `Roadmap`, `Meta`, `Habilidade`, `UsuarioHabilidade`, `Teste`, `Resposta`.

---

## 🔗 Exemplos de Endpoints

### Usuário / Autenticação
- `POST /api/usuario/register` – registra usuário (se implementado)
- `POST /api/usuario/login` – autentica e retorna JWT
- `GET /api/usuario/me` – dados do usuário logado (`[Authorize]`)

### Trilhas
- `GET /api/trilha` – lista trilhas
- `GET /api/trilha/{id}` – detalhes de uma trilha
- `POST /api/trilha` – cria trilha
- `PUT /api/trilha/{id}` – atualiza trilha
- `DELETE /api/trilha/{id}` – remove trilha

### Roadmaps / Metas / Progresso (exemplos)
- `GET /api/roadmap/usuario/{idUsuario}`
- `GET /api/progresso/usuario/{idUsuario}`
- `POST /api/meta`
- `PUT /api/meta/{id}`

---

## 🛠️ Tecnologias

- **Back-end**: .NET 9
- **Banco**: MongoDB 
- **Autenticação**: JWT Bearer 
- **Documentação**: Swagger  
- **Testes**: xUnit
- **Outros**: HealthChecks, API Versioning, CORS

---

## ▶️ Como Rodar o Projeto

### 1. Pré-requisitos

- .NET SDK 9.0  
- Docker (ou MongoDB instalado localmente)

### 2. Subir o MongoDB

```bash
docker run -d --name talency-mongo -p 27017:27017 mongo:latest
```

### 3. Rodar a API

```bash
cd src/Api
dotnet run
```

A API vai subir em: `http://localhost:5296`

### 5. Acessar o Swagger

- URL: `http://localhost:5296/swagger`

Fluxo rápido:

1. Criar usuário (ou usar algum já existente)
2. Fazer login em `POST /api/Usuario/login` ou cadastro em  `POST /api/Usuario/register`
3. Copiar o token retornado
4. Clicar em **Authorize** no Swagger e colar:
   ```text
   Bearer {seu_token}
   ```
5. Testar as rotas protegidas (`/api/Trilha`, `api/Habilidade`, etc.)

---

## 🧪 Testes Automatizados

Para rodar os testes:

```bash
cd tests
dotnet test
```

---

**Talency / TalentRoad – Global Solution FIAP 2025/2**  
