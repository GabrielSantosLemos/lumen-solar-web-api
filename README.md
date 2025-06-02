# lumen-solar-web-api

O projeto Lumen Solar surge como resposta à necessidade de reduzir desigualdades energéticas em comunidades de baixa renda. Com uma propriedade de 100 m² e 72 m² de painéis solares, a proposta visa comercializar o excedente de energia no Mercado Livre de Energia (MLE) e direcionar os recursos arrecadados para famílias de baixa renda..

## 🧰 Pré-requisitos

Antes de iniciar o projeto, certifique-se de ter os seguintes softwares instalados:

- [.NET SDK (recomendado: 8.0 ou superior)](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Git](https://git-scm.com/) (para clonar o repositório)
- [Visual Studio 2022+](https://visualstudio.microsoft.com/) ou [Visual Studio Code](https://code.visualstudio.com/)

---

## ⚙️ Instalação

1. Clone o repositório:

```bash
git clone https://github.com/seu-usuario/lumen-solar-web-api.git
cd lumen-solar-api
```

2. Configure a string de conexão com o PostgreSQL no arquivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=lumen_solar_db;Username=seu_usuario;Password=sua_senha"
}
```

3. Execute as migrações para criar o banco de dados:

```bash
dotnet ef database update
```

---

## 🚀 Executando a aplicação

Execute a aplicação com o comando:

```bash
dotnet run
```

A API estará disponível em:  
[https://localhost:5001](https://localhost:5001) ou [http://localhost:5000](http://localhost:5000)

---

## 🛠️ Tecnologias Utilizadas

- ASP.NET Core 8
- Entity Framework Core
- PostgreSQL
- Swagger (Swashbuckle)
