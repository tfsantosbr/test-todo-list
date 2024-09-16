# TODO List - API .NET e Aplicação Angular

Este projeto consiste em uma **API .NET 8** para gerenciar uma TODO list e uma aplicação **Angular** que consome essa API para gerenciar os itens.

## Pré-requisitos

Para rodar o projeto localmente, você precisa ter instalado:

- **Node.js** e **npm**: [Download Node.js](https://nodejs.org/)
- **.NET SDK** (versão 8 ou superior): [Download .NET](https://dotnet.microsoft.com/download)
- **Docker** e **Docker Compose**: [Download Docker](https://www.docker.com/products/docker-desktop)
- **Angular CLI** (instalar via npm): `npm install -g @angular/cli`

## Testes Unitários

Execute os testes da API com:

```bash
dotnet test
```

## Executar Smoke Tests com .http

Para testar os endpoints da API, você pode usar arquivos .http e o Visual Studio Code com a extensão REST Client.

Abra o arquivo .http no VS Code e use o botão Send Request para realizar as requisições.

## Executando com Docker Compose

### 1. Rodar com Docker Compose

Execute os containers da API e da aplicação Angular com:

```bash
docker-compose up -d --build
```

Acesse a aplicação no navegador em `http://localhost:4200`.

### 2. Parar os Containers

Para parar os containers, execute:

```bash
docker-compose down
```
