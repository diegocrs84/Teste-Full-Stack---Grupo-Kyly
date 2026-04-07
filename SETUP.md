# Setup Guide - Kyly Products

## Pré-requisitos

### Windows
- .NET 7 SDK: https://dotnet.microsoft.com/download
- Node.js 16+: https://nodejs.org/
- Git: https://git-scm.com/

### macOS
```bash
# Usando Homebrew
brew install dotnet
brew install node
brew install git
```

### Linux (Ubuntu/Debian)
```bash
# .NET 7
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh
chmod +x dotnet-install.sh
./dotnet-install.sh --version 7.0

# Node.js
curl -fsSL https://deb.nodesource.com/setup_18.x | sudo -E bash -
sudo apt-get install -y nodejs

# Git
sudo apt-get install git
```

## Verificar Instalação

```bash
# .NET
dotnet --version

# Node
node --version
npm --version

# Git
git --version
```

## Passos para Execução

### 1. Clonar o Repositório

```bash
git clone https://github.com/grupokyly/teste-fullstack.git
cd teste-fullstack
```

### 2. Verificar Arquivos de Dados

Certifique-se de que estes arquivos existem na raiz do projeto:
- `sample_db.csv` (Database de produtos)
- `lista_relevancia_1.txt` (Produtos prioritários)
- `lista_relevancia_2.txt` (Produtos secundários)

### 3. Backend - ASP.NET Core

```bash
# Navegue para o backend
cd src/KylyProductsAPI

# Restaurar dependências NuGet
dotnet restore

# Executar a aplicação
dotnet run

# Output esperado:
# info: Microsoft.Hosting.Lifetime[14]
#       Now listening on: http://localhost:5000
#       Now listening on: https://localhost:5001
```

**Verificar se está funcionando:**
- Abra: http://localhost:5000/swagger
- Você deverá ver a documentação Swagger da API

### 4. Frontend - React

Em **outro terminal**, execute:

```bash
# Navegue para o frontend
cd src/KylyProductsWeb

# Instalar dependências npm
npm install

# Executar em modo desenvolvimento
npm run dev

# Output esperado:
# VITE v4.x.x ready in xxx ms
# ➜  Local:   http://localhost:3000/
```

**Verificar se está funcionando:**
- Abra: http://localhost:3000
- Você deverá ver a tela de login

### 5. Testar a Aplicação

1. Acesse http://localhost:3000
2. Faça login com:
   - **Usuário**: demo
   - **Senha**: demo123
3. Na página de busca, tente buscar por:
   - Código: "105735"
   - Descrição: "CAMISETA"
   - Cor: "AZUL"
   - Tamanho: "P"

## Troubleshooting

### Porta 5000 já está em uso (Backend)
```bash
# Windows
netstat -ano | findstr :5000
taskkill /PID <PID> /F

# macOS/Linux
lsof -i :5000
kill -9 <PID>
```

### Porta 3000 já está em uso (Frontend)
```bash
# Mude a porta no vite.config.js
# Ou encerre o processo que está usando
```

### Erro ao restaurar NuGet
```bash
cd src/KylyProductsAPI
dotnet nuget add source https://api.nuget.org/v3/index.json --name nuget.org
dotnet restore
```

### Erro ao instalar npm
```bash
cd src/KylyProductsWeb
rm -rf node_modules package-lock.json
npm cache clean --force
npm install
```

### Arquivo CSV não encontrado
- Verifique se `sample_db.csv` está no diretório raiz do projeto
- O caminho deve ser relativo: `./sample_db.csv`

## Estrutura de Arquivos Esperada

```
teste-fullstack/
├── sample_db.csv
├── lista_relevancia_1.txt
├── lista_relevancia_2.txt
├── README.md
├── .gitignore
├── docker-compose.yml
└── src/
    ├── KylyProductsAPI/
    │   ├── Controllers/
    │   ├── Models/
    │   ├── Services/
    │   ├── appsettings.json
    │   ├── KylyProductsAPI.csproj
    │   ├── Program.cs
    │   └── Dockerfile
    │
    └── KylyProductsWeb/
        ├── src/
        ├── public/
        ├── package.json
        ├── vite.config.js
        ├── index.html
        └── Dockerfile
```

## Compilação para Produção

### Backend
```bash
cd src/KylyProductsAPI
dotnet publish -c Release
# Output em: bin/Release/net7.0/publish/
```

### Frontend
```bash
cd src/KylyProductsWeb
npm run build
# Output em: dist/
```

## Usando Docker (Alternativa)

Se você tem Docker instalado:

```bash
# Na raiz do projeto
docker-compose up -d

# A aplicação estará em http://localhost:3000
# Para parar:
docker-compose down
```

## Variáveis de Ambiente Opcionais

Crie um arquivo `.env` na raiz se necessário:

```env
# Backend
ASPNETCORE_ENVIRONMENT=Development
Auth__Username=demo
Auth__Password=demo123
Jwt__Secret=sua_chave_secreta_aqui_minimo_32_caracteres
Port=5000

# Frontend
VITE_API_URL=http://localhost:5000
```

## Próximos Passos

1. Familiarize-se com a API via Swagger: http://localhost:5000/swagger
2. Teste os endpoints de autenticação e busca
3. Explore o código-fonte para entender a arquitetura
4. Faça customizações conforme necessário

## Suporte

Para dúvidas, verifique:
- Logs do terminal (tanto backend quanto frontend)
- Console do navegador (F12) para erros do frontend
- Arquivo `appsettings.json` para configurações do backend

---

**Bom desenvolvimento! 🚀**
