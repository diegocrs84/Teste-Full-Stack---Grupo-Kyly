<!-- markdownlint-disable MD041 -->

# 📚 Documentação - Índice Completo

Bem-vindo! Use este índice para navegar pela documentação do projeto Kyly Products.

## 🚀 Começar

| Documento | Tempo | Descrição |
|-----------|-------|-----------|
| [QUICKSTART.md](QUICKSTART.md) | 5 min | Iniciar em 5 minutos |
| [SETUP.md](SETUP.md) | 30 min | guia detalhado de instalação |
| [README.md](README.md) | 10 min | Visão geral do projeto |

## 📖 Documentação de Referência

| Tópico | Arquivo | Assunto |
|--------|---------|---------|
| Contribuição | [CONTRIBUTING.md](CONTRIBUTING.md) | Como fazer PR, GitFlow |
| Solução de Problemas | [TROUBLESHOOTING.md](TROUBLESHOOTING.md) | Erros e soluções |
| Checklist | [CHECKLIST.md](CHECKLIST.md) | Verificar requisitos |
| Resumo | [SUMMARY.md](SUMMARY.md) | O que foi entregue |
| Currículo | [CV.md](CV.md) | Template do seu CV |

## 🎯 Por Objetivo

### Quer...

**Rodar rápido?**
→ [QUICKSTART.md](QUICKSTART.md)

**Instalar passo a passo?**
→ [SETUP.md](SETUP.md)

**Entender o projeto?**
→ [README.md](README.md)

**Contribuir/fazer PR?**
→ [CONTRIBUTING.md](CONTRIBUTING.md)

**Resolver um erro?**
→ [TROUBLESHOOTING.md](TROUBLESHOOTING.md)

**Saber o que foi feito?**
→ [SUMMARY.md](SUMMARY.md)

**Atualizar seu CV?**
→ [CV.md](CV.md)

## 🛠️ Desenvolvadores

### Backend (C# / ASP.NET Core)

```
Começar:                  dotnet run
Documentação API:         http://localhost:5000/swagger
Arquivo principal:        Program.cs
Configuração:             appsettings.json
Controllers:              src/KylyProductsAPI/Controllers/
Models:                   src/KylyProductsAPI/Models/
Services:                 src/KylyProductsAPI/Services/
```

**Mais informações**: [SETUP.md](SETUP.md) → Backend

### Frontend (React / Vite)

```
Começar:                  npm run dev
Endereço:                 http://localhost:3000
Arquivo principal:        src/App.jsx
Componentes:              src/components/
Serviços:                 src/services/
Estilos:                  src/styles/
```

**Mais informações**: [SETUP.md](SETUP.md) → Frontend

## 📋 Estrutura do Projeto

```
├── README.md                   # Visão geral
├── QUICKSTART.md               # 5 minutos
├── SETUP.md                    # Instalação
├── CONTRIBUTING.md             # Contribuição
├── TROUBLESHOOTING.md          # Erros
├── CHECKLIST.md                # Requisitos
├── SUMMARY.md                  # Resumo
│
├── src/KylyProductsAPI/        # Backend
│   ├── Controllers/
│   ├── Models/
│   ├── Services/
│   └── Program.cs
│
├── src/KylyProductsWeb/        # Frontend
│   ├── src/components/
│   ├── src/services/
│   ├── src/styles/
│   └── vite.config.js
│
└── docker-compose.yml          # Containerização
```

## 🔐 Credenciais

```
Usuário:  demo
Senha:    demo123
Token:    JWT (gerado automaticamente)
```

## 🌐 URLs de Execução Local

```
Frontend:           http://localhost:3000
Backend API:        http://localhost:5000
Backend API Docs:   http://localhost:5000/swagger
```

## 📱 Endpoints da API

```
POST   /api/auth/login              # Autenticar
GET    /api/products/search         # Buscar produtos
```

Documentação completa em: http://localhost:5000/swagger

## 🐳 Docker

```bash
# Executar tudo
docker-compose up

# Parar
docker-compose down
```

## 🔄 Git Workflow

```bash
# Clonar/Fork
git clone https://github.com/grupokyly/teste-fullstack.git

# Criar branch
git checkout -b feature/meu-nome

# Fazer commits
git commit -m "feat: descrição"

# Push
git push origin feature/meu-nome

# Abrir PR no GitHub
```

**Detalhes**: [CONTRIBUTING.md](CONTRIBUTING.md)

## ❓ FAQ Rápido

**P: Como instalar?**
R: Veja [QUICKSTART.md](QUICKSTART.md) (5 min) ou [SETUP.md](SETUP.md) (30 min)

**P: Como testar?**
R: Execute backend e frontend, acesse http://localhost:3000

**P: Como fazer PR?**
R: Veja [CONTRIBUTING.md](CONTRIBUTING.md)

**P: Algo não funciona?**
R: Consulte [TROUBLESHOOTING.md](TROUBLESHOOTING.md)

**P: O que foi entregue?**
R: Veja [SUMMARY.md](SUMMARY.md)

## 🎓 Aprendizado

Documentos para aprender:
- ASP.NET Core: [SETUP.md](SETUP.md) → Backend
- React: [SETUP.md](SETUP.md) → Frontend
- Git: [CONTRIBUTING.md](CONTRIBUTING.md)
- Docker: [docker-compose.yml](docker-compose.yml)

## 📞 Suporte

1. **Leia primeiro**: [TROUBLESHOOTING.md](TROUBLESHOOTING.md)
2. **Não encontrou?**: Abra issue no GitHub
3. **Detalhes**: Veja logs do terminal

## 🔗 Links Úteis

- [.NET Documentation](https://docs.microsoft.com/dotnet)
- [React Documentation](https://react.dev)
- [Vite Documentation](https://vitejs.dev)
- [JWT Documentation](https://jwt.io)
- [GitHub Docs](https://docs.github.com)

## 📄 Documentos por Tipo

### Arquivo | Público | Propósito
|----------|---------|----------
README.md | Todos | Visão geral da solução
QUICKSTART.md | Devs | Iniciar em 5 min
SETUP.md | Devs | Setup passo a passo
CONTRIBUTING.md | Contributors | Como contribuir/PR
TROUBLESHOOTING.md | Todos | Resolver problemas
SUMMARY.md | Todos | O que foi feito
CHECKLIST.md | PMs | Requisitos validados
CV.md | Pessoal | Seu currículo
INDEX.md | Todos | Este arquivo (navegação)

## 🎯 Roadmap de Leitura Recomendado

```
NOVO NO PROJETO?
  ↓
Leia: README.md (5 min)
  ↓
Execute: QUICKSTART.md (5 min)
  ↓
Explore: código no VSCode
  ↓
Customize: CV.md com seus dados
  ↓
Envie: Pull Request
```

## ✅ Versão & Status

```
Versão:   1.0.0
Status:   ✅ Completo
Data:     Janeiro 2024
Idioma:   Português
```

---

**Última atualização**: janeiro 2024

> Documentação mantida em Markdown e versionada no Git
