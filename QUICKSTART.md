# 🎯 Quick Start - Kyly Products

**⏱️ 5 minutos para começar**

## 1️⃣ Pré-requisitos Rápidos

```bash
# Verificar instalações (Windows)
dotnet --version          # Deve ser 7.0 ou superior
node --version            # Deve ser 16 ou superior
npm --version             # Deve vir com Node.js
git --version             # Deve estar instalado
```

## 2️⃣ Clone e Execute (2 terminais)

### Terminal 1 - Backend
```bash
cd src/KylyProductsAPI
dotnet run
# Espere aparecer: "Now listening on: http://localhost:5000"
```

### Terminal 2 - Frontend
```bash
cd src/KylyProductsWeb
npm install
npm run dev
# Espere aparecer: "Local: http://localhost:3000"
```

## 3️⃣ Acesse a Aplicação

1. Abra browser: **http://localhost:3000**
2. Login com:
   - **Usuário**: demo
   - **Senha**: demo123
3. Busque por: "camiseta", "azul", "105735", etc.

## 🔗 Links Úteis

- **Frontend**: http://localhost:3000
- **API Docs**: http://localhost:5000/swagger
- **Dados**: sample_db.csv na raiz

## ❌ Erro com Portas?

```bash
# Mude a porta no arquivo vite.config.js ou Program.cs
# Ou encerre o processo usando a porta
```

## 📘 Próximos Passos

1. [Ver documentação completa](README.md)
2. [Guia de setup detalhado](SETUP.md)
3. [Aprenda como contribuir](CONTRIBUTING.md)
4. [Checklist de requisitos](CHECKLIST.md)

## 🚀 Docker (Alternativa)

```bash
# Tudo em um comando
docker-compose up

# Acesse: http://localhost:3000
```

---

**Pronto para desenvolvver? 💪**
