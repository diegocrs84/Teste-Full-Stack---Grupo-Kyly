# 🚀 Guia de Contribuição e Pull Request

Este documento descreve o processo para fazer contribuições ao projeto e criar um Pull Request.

## 📋 Pré-requisitos

1. Ter o projeto configurado localmente (ver [SETUP.md](./SETUP.md))
2. Git configurado com seu nome e email:
   ```bash
   git config --global user.name "Seu Nome"
   git config --global user.email "seu.email@example.com"
   ```

## 🌿 GitFlow - Fluxo de Desenvolvimento

Usamos GitFlow para organizar o desenvolvimento:

```
main (produção)
  ├── release/* (releases)
  └── develop (desenvolvimento)
      ├── feature/* (novas features)
      └── bugfix/* (correções)
```

## 📝 Passos para Criar um Pull Request

### 1. Clone ou Fork o Repositório

```bash
# Se você tem acesso direto:
git clone https://github.com/grupokyly/teste-fullstack.git

# Se você é um contribuidor externo (Fork):
# 1. Click "Fork" no GitHub
# 2. Clone seu fork:
git clone https://github.com/seu-usuario/teste-fullstack.git
cd teste-fullstack
```

### 2. Crie uma Branch para Sua Feature

```bash
# Atualize primeiro
git fetch origin
git checkout develop

# Crie uma branch a partir de develop
git checkout -b feature/sua-feature-aqui
# ou
git checkout -b bugfix/descricao-do-bug

# Padrões de nomenclatura:
# - feature/adicionar-filtro-cor
# - feature/melhorar-performance-busca
# - bugfix/corrigir-autenticacao
# - refactor/reorganizar-estrutura
```

### 3. Faça Suas Alterações

```bash
# Desenvolva sua feature/correção
# Commit frequentemente com mensagens claras:

git add .
git commit -m "feat: adicionar novo endpoint de busca avançada"
git commit -m "fix: corrigir erro de paginação"
git commit -m "docs: atualizar documentação da API"
```

**Padrões de Commit:**
- `feat:` - Nova feature
- `fix:` - Correção de bug
- `docs:` - Documentação
- `refactor:` - Refatoração de código
- `test:` - Testes
- `chore:` - Tarefas (dependências, build, etc.)

### 4. Mantenha Sua Branch Atualizada

```bash
# Fetch das últimas mudanças
git fetch origin
git rebase origin/develop

# Se houver conflitos, resolva-os e continue
git add .
git rebase --continue
```

### 5. Push para Seu Repositório

```bash
git push origin feature/sua-feature-aqui
```

### 6. Abra um Pull Request no GitHub

1. Vá para https://github.com/grupokyly/teste-fullstack
2. Clique em "Pull requests" → "New pull request"
3. Ou se você tem um fork, você verá um aviso "Compare & pull request"

### 7. Preencha o Template do PR

**Título do PR:**
```
[tipo] descrição breve (máx 72 caracteres)
```

**Descrição:**
```markdown
## 📝 Descrição
Descrição clara do que foi feito.

## 🎯 Objetivo
O que isso resolve? (issue #123)

## ✅ Checklist
- [ ] Código testado localmente
- [ ] Formatação correta (prettier/eslint)
- [ ] Documentação atualizada
- [ ] Sem console.log ou debug code
- [ ] Tests passando

## 📸 Screenshots (se aplicável)
Adicione imagens de antes/depois

## 🔗 Relacionado
Relacionado a: #issue_number
Fecha: #issue_number
```

**Exemplo completo:**

```markdown
## 📝 Descrição
Implementei a funcionalidade de filtro de cor na busca de produtos.

## 🎯 Objetivo
Permite que usuários filtrem resultados por cor, melhorando a experiência de busca.
Resolve #45

## ✅ Checklist
- [x] Código testado localmente
- [x] API validando filtro de cor
- [x] Frontend atualizando com filtro
- [x] Testes unitários adicionados
- [x] Documentação do endpoint atualizada

## 📸 Screenshots
[Imagens do novo filtro]

## 🧪 Como testar
1. Buscar por produto sem filtro
2. Adicionar filtro de cor "AZUL"
3. Verificar se resultados são filtrados
```

## ✨ Boas Práticas

### Código
- ✅ Siga o padrão de código existente
- ✅ Use nomes descritivos para variáveis
- ✅ Adicione comentários para lógica complexa
- ✅ Mantenha funções pequenas e focadas
- ✅ Teste seu código antes de fazer commit

### Commits
- ✅ Commits pequenos e lógicos
- ✅ Mensagens claras em português/inglês
- ✅ Uma mudança por commit
- ✅ Evite commits "oops" ou "fix"

### PRs
- ✅ Uma funcionalidade por PR
- ✅ Descrição clara e concisa
- ✅ Sempre partir de e mergear em `develop`
- ✅ Aguarde revisão antes de mergear
- ✅ Responda aos comentários de revisão

## 🔍 Revisão de Código

Um mantenedor do projeto vai revisar seu PR. Possíveis feedbacks:

1. **Aprovado (✅)**: PR será mergeado em `develop`
2. **Mudanças Solicitadas**: Atualize seu código conforme solicitado
3. **Comentários**: Responda aos comentários e faça commit's adicionais

```bash
# Faça as alterações solicitadas
git add .
git commit -m "refactor: endereçar feedback de revisão"
git push origin feature/sua-feature-aqui
```

## 🎯 Seu CV no Repositório

Como requisito, você deve manter seu CV atualizado:

```bash
# Crie um commit com seu CV
git add CV.md
git commit -m "docs: atualizar CV com novo projeto"

# Ou crie um arquivo de CV personalizado
git add CV-seu-nome.md
git commit -m "docs: adicionar CV"
```

## 🚀 Mergeando para Produção

Após vários PRs mergeados em `develop`, um mantenedor criará um `release/X.Y.Z` e depois mergeará em `main`.

```bash
# Isso é feito pelo mantenedor automaticamente
git checkout -b release/1.0.0 develop
# ... versioning updates ...
git checkout main
git merge --no-ff release/1.0.0
git tag -a v1.0.0
```

## 📚 Referências

- [GitHub Flow](https://guides.github.com/introduction/flow/)
- [GitFlow](https://nvie.com/posts/a-successful-git-branching-model/)
- [Conventional Commits](https://www.conventionalcommits.org/)
- [Keep a Changelog](https://keepachangelog.com/)

## ❓ Dúvidas?

- Abra uma issue com a tag `question`
- Verifique as issues existentes
- Revisite a documentação do projeto

---

**Obrigado por contribuir! 🙏**
