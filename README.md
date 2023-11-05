# Cadastro de Pessoas API

Este é um projeto de uma API de cadastro e gerenciamento de informações de pessoas, desenvolvido em ASP.NET Core.

## Funcionalidades

- Consultar todas as pessoas cadastradas.
- Consultar pessoa por código.
- Consultar pessoas por UF (Unidade Federativa).
- Gravar nova pessoa.
- Atualizar informações de uma pessoa.
- Excluir pessoa do sistema.

## Tecnologias Utilizadas

- ASP.NET Core 7
- Swagger para documentação da API
- JSON Web Tokens (JWT) para autenticação

## Pré-requisitos

- .NET Core 7 SDK instalado

##Documentação da API
A documentação da API está disponível no Swagger. Após iniciar o projeto

##Autorização
A API usa autorização via JWT (JSON Web Tokens). Você deve obter um token de acesso para acessar os endpoints protegidos. Use o endpoint /token para obter um token válido.

##Testes Unitários
Este projeto inclui testes unitários para garantir a qualidade do código. 
