# 🛠️ Troubleshooting - Resolução de Problemas

## Backend Issues

### ❌ "Port 5000 is already in use"

**Windows:**
```powershell
# Encontrar processo na porta 5000
netstat -ano | findstr :5000

# Encerrar processo (substitua PID)
taskkill /PID 12345 /F
```

**Linux/Mac:**
```bash
lsof -i :5000
kill -9 <PID>
```

**Alternativa:** Mude a porta em `appsettings.json`
```json
"Port": "5001"
```

### ❌ "The CSV file was not found"

- Certifique-se que `sample_db.csv` está na **raiz do projeto**
- Não na pasta `src/`, mas na raiz: `./sample_db.csv`
- Se usar Docker, `docker-compose.yml` já copia os arquivos

### ❌ "Restore failed"

```bash
cd src/KylyProductsAPI

# Limpar cache
dotnet clean

# Restaurar novamente
dotnet restore

# Se mesmo assim falhar:
rm -rf bin obj
dotnet restore
```

### ❌ JWT Token inválido

- Verifique se `Jwt:Secret` tem mínimo 32 caracteres
- Cheque se frontend está enviando token no header `Authorization: Bearer <token>`
- Tokens expiram em 60 minutos (configurável)

---

## Frontend Issues

### ❌ "Port 3000 is already in use"

**Windows:**
```powershell
netstat -ano | findstr :3000
taskkill /PID 12345 /F
```

**Alternative:** Mude em `vite.config.js`
```js
server: {
  port: 3001  // Mude aqui
}
```

### ❌ "npm ERR! ERESOLVE unable to resolve dependency tree"

```bash
cd src/KylyProductsWeb

# Opção 1: Force install (pode gerar warnings)
npm install --legacy-peer-deps

# Opção 2: Limpar e reinstalar
rm -rf node_modules package-lock.json
npm cache clean --force
npm install
```

### ❌ "Cannot find axios"

```bash
cd src/KylyProductsWeb

# Axios não foi instalado
npm install axios
```

### ❌ "CORS Error"

Erro: `Access to XMLHttpRequest at 'http://localhost:5000/...' from origin 'http://localhost:3000' has been blocked`

**Solução:** Backend CORS já está configurado. Verifique:

1. Backend está rodando em http://localhost:5000
2. Frontend em http://localhost:3000
3. Se mudar porta, atualize `appsettings.json`:
```json
"Cors": {
  "AllowedOrigins": ["http://localhost:3000", "http://localhost:3001"]
}
```

### ❌ "Blank page on localhost:3000"

1. Abra DevTools (F12)
2. Veja a aba "Console" para erros
3. Erros comuns:
   - API não está rodando → inicie backend
   - Port mismatch → veja `vite.config.js`

---

## Git & Repository Issues

### ❌ "fatal: not a git repository"

```bash
# Você está na pasta errada
cd C:\Projetos\Teste\ Full\ Stack\ -\ Grupo\ Kyly

# Ou initialize Git
git init
git add .
git commit -m "Initial commit"
```

### ❌ "Permission denied (publickey)"

```bash
# Gerar chave SSH
ssh-keygen -t ed25519

# Adicionar ao GitHub:
# 1. Copiar conteúdo de ~/.ssh/id_ed25519.pub
# 2. GitHub Settings > SSH Keys > New SSH Key
# 3. Paste e save
```

### ❌ Merge conflicts

```bash
# Durante um merge com conflitos:

# 1. Abra os arquivos com <<<<<<, ======, >>>>>> 
# 2. Escolha as mudanças desejadas
# 3. Remova os marcadores de conflito
# 4. Commit

git add .
git commit -m "Resolve merge conflicts"
```

### ❌ "This branch is X commits behind"

```bash
# Atualize sua branch
git fetch origin
git rebase origin/develop
# ou
git merge origin/develop
```

---

## Docker Issues

### ❌ "Docker daemon is not running"

- **Windows**: Abra "Docker Desktop"
- **Linux**: `sudo service docker start`
- **Mac**: Abra Docker.app

### ❌ "Port 5000 already in use (Docker)"

```bash
# Encerre containers
docker-compose down

# Ou use porta diferente em docker-compose.yml
# ports:
#   - "5001:5000"
```

### ❌ "Cannot find image"

```bash
# Rebuild
docker-compose build

# Run
docker-compose up
```

---

## Network Issues

### ❌ "Failed to fetch from localhost"

- Verificar se backend está rodando: http://localhost:5000/swagger
- Verificar se não há firewall bloqueando
- Se usar VPN, desabilitar pode ajudar

### ❌ "CORS still blocked even after config"

1. Reinicie **ambos** backend e frontend
2. Cache: Ctrl+Shift+R (hard refresh)
3. DevTools > Network > veja headers `Access-Control-Allow-Origin`

---

## Performance Issues

### 🐢 "App is very slow"

1. **Frontend**: Abra DevTools > Performance tab
2. **Backend**: Cheque se CSV está sendo lido muito frequentemente
   - ProductService caching deveria ajudar
3. Limpe cache do navegador (Ctrl+Shift+Delete)

### 📊 "High memory usage"

- Feche outras aplicações
- Backends/frontends extras podem estar rodando
- Limpar `node_modules` e `bin/obj`

---

## Testing Issues

### ❌ "Tests not found"

```bash
# Testes não foram implementados yet
# Mas você pode adicionar:

cd src/KylyProductsAPI

# Instalar xUnit
dotnet add package xunit
dotnet add package xunit.runner.visualstudio

# Criar test project
dotnet new xunit -n KylyProductsAPI.Tests
```

---

## General Debugging

### 🔍 Enable Debug Logging

**Backend:**
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Debug",
      "Microsoft": "Information"
    }
  }
}
```

**Frontend:**
```js
// Nos serviços da API
console.log('Request:', config);
console.log('Response:', response);
```

### 📋 Check Versions

```bash
dotnet --version          # Deve ser 7.0.x
node --version            # Deve ser 16+
npm --version             # Deve ser 8+
git --version             # Qualquer versão com suporte
```

---

## 📞 Mais Ajuda?

1. **Verifique logs**: Terminal onde backend/frontend estão rodando
2. **DevTools**: F12 no navegador para erros frontend
3. **GitHub Issues**: Procure por problemas similares
4. **Ask for help**: Abra uma issue descrevendo o erro

---

## 🎯 Checklist de Troubleshooting

- [ ] Verificou se .NET 7 SDK está instalado?
- [ ] Verificou se Node.js 16+ está instalado?
- [ ] Verificou se portas 5000 e 3000 estão disponíveis?
- [ ] Git está bem configurado?
- [ ] sample_db.csv está na raiz do projeto?
- [ ] Restartou terminal após instalar ferramentas?
- [ ] Limpou browser cache (Ctrl+Shift+Del)?
- [ ] Tentou `dotnet clean` e `npm cache clean`?

**Se nada funcionar, tente tudo de novo depois de:** 
```bash
# Limpar tudo
rm -rf src/KylyProductsWeb/node_modules
rm -rf src/KylyProductsAPI/bin src/KylyProductsAPI/obj

# Reinstalar
cd src/KylyProductsAPI && dotnet restore
cd ../KylyProductsWeb && npm install

# Rodar novamente
```

---

**Boa sorte! 🚀**
