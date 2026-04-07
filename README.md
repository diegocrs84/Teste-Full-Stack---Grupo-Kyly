# Produtos da Kyly - Solução Full Stack

Uma solução completa em C# e React para busca e filtragem de produtos com autenticação JWT.

## 🚀 Características

- **API REST** moderna em ASP.NET Core 7
- **Frontend** responsivo com React e Vite
- **Autenticação JWT** segura
- **Busca inteligente** com paginação (15 registros por página)
- **Priorização de resultados** baseada em listas de relevância
- **UX elaborada** com design moderno e intuitivo
- **CORS habilitado** para comunicação segura entre frontend e backend

## 📋 Requisitos

- .NET 7 SDK
- Node.js 16+ com npm
- Windows, Linux ou macOS

## 🛠️ Instalação e Execução

### 1. Preparar o Ambiente

```bash
# Clone ou entre no diretório do projeto
cd "C:\Projetos\Teste Full Stack - Grupo Kyly"
```

### 2. Backend (ASP.NET Core)

```bash
cd src/KylyProductsAPI

# Restaurar dependências
dotnet restore

# Executar a aplicação
dotnet run

# A API estará disponível em: http://localhost:5000
# Swagger UI: http://localhost:5000/swagger
```

**Credenciais padrão para teste:**
- Usuário: `demo`
- Senha: `demo123`

### 3. Frontend (React + Vite)

Em outro terminal:

```bash
cd src/KylyProductsWeb

# Instalar dependências
npm install

# Executar em desenvolvimento
npm run dev

# A aplicação estará em: http://localhost:3000
```

## 🔐 Autenticação

1. Abra http://localhost:3000
2. Faça login com:
   - Usuário: `demo`
   - Senha: `demo123`
3. Use o token JWT automaticamente para todas as requisições

## 📖 API Endpoints

### Autenticação
```
POST /api/auth/login
Content-Type: application/json

{
  "username": "demo",
  "password": "demo123"
}

Response:
{
  "success": true,
  "message": "Autenticado com sucesso",
  "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9..."
}
```

### Busca de Produtos
```
GET /api/products/search?keyword=camiseta&page=1
Authorization: Bearer {token}

Response:
{
  "items": [
    {
      "id": "105735.6532.1",
      "productCode": "105735",
      "productDescription": "CAMISETA MASC.",
      "colorCode": "6532",
      "colorDescription": "AZUL 19-4049 KYLY",
      "sizeCode": "1",
      "sizeDescription": "P",
      "relevancePriority": 1
    }
  ],
  "totalCount": 245,
  "currentPage": 1,
  "pageSize": 15,
  "totalPages": 17
}
```

## 📁 Estrutura do Projeto

```
src/
├── KylyProductsAPI/
│   ├── Controllers/          # API Controllers
│   ├── Models/               # Modelos de dados
│   ├── Services/             # Serviços de negócio
│   ├── Properties/           # Propriedades do projeto
│   ├── Program.cs            # Configuração da aplicação
│   ├── appsettings.json      # Configurações
│   └── KylyProductsAPI.csproj
│
└── KylyProductsWeb/
    ├── src/
    │   ├── components/       # Componentes React
    │   ├── services/         # Serviços do frontend
    │   ├── styles/           # Estilos CSS
    │   ├── App.jsx
    │   └── main.jsx
    ├── public/
    ├── package.json
    ├── vite.config.js
    └── index.html
```

## 🎨 Design

- **Cores**: Gradiente roxo (#667eea a #764ba2)
- **Tipografia**: Segoe UI, São-serifas modernas
- **Responsividade**: Mobile-first, funciona em todos os tamanhos
- **Animações**: Suaves transições para melhor UX

## 🧪 Dados de Teste

O projeto inclui:
- `sample_db.csv`: Database com ~5000 produtos
- `lista_relevancia_1.txt`: Lista de produtos prioritários (⭐ Lista 1)
- `lista_relevancia_2.txt`: Lista de produtos secundários (⭐ Lista 2)

Os resultados da busca são ordenados por relevância:
1. Produtos da Lista 1
2. Produtos da Lista 2
3. Demais produtos

## 🐳 Docker (Opcional)

Para facilitar o deploy, você pode usar Docker:

```bash
docker-compose up -d
```

A solução completa estará acessível em `http://localhost:3000`

## 📝 Variáveis de Ambiente

Crie um arquivo `.env` se necessário:

```
API_URL=http://localhost:5000
API_SECRET=sua_chave_secreta_super_segura_e_longa_aqui_minimo_32_caracteres
AUTH_USERNAME=demo
AUTH_PASSWORD=demo123
```

## 🚀 Build para Produção

### Backend
```bash
cd src/KylyProductsAPI
dotnet publish -c Release
```

### Frontend
```bash
cd src/KylyProductsWeb
npm run build
# Artifacts em: dist/
```

## 📞 Suporte

Para dúvidas ou problemas:
1. Verifique se as portas 5000 (backend) e 3000 (frontend) estão disponíveis
2. Certifique-se de que o arquivo `sample_db.csv` está no diretório raiz
3. Verifique os logs da API em seu terminal

## 📄 Licença

Desenvolvido para o teste técnico Grupo Kyly.

---

**Desenvolvido com ❤️ em C# e React**
