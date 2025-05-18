
# Contracts (desafio)

Contracts é uma aplicação que permite gerenciar contratos, permitindo adição por upload de arquivos. Inclui funcionalidades de:


- Autenticação por Jwt
- Nível de acesso às funcionalidades
- Suporte à leitura de arquivos .csv para leitura e inserção de dados automaticamente
- Consulta de arquivos importados e usuário responsável pela importação
- Paginação
- Consulta de valor total de todos os contratos dos clientes, fazendo a busca pelo CPF
- Maior atraso em dias do maior vencimento de pagamento
## Stack utilizada

**Back-end:** C#, Asp.NET 9.0

**Banco de dados:** SQL Server

**API Test:** Scalar
## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/will9191/contracts
```

Entre no diretório do projeto

```bash
  cd server
```

Instale as dependências

```bash
  dotnet --version (.NET 9 sendo utilizada)
```

Restaure os pacotes NuGet

```bash
  dotnet restore
```

Faça o build do projeto

```bash
  dotnet build
```

Rode o projeto

```bash
  dotnet run --project server
```

Abra na web pelo localhost e navegue para /scalar para testar a API. Exemplos:

```bash
https://localhost:7230/scalar
```
```bash
http://localhost:5166/scalar
```

## Screenshots

![add-contracts-from-file](https://github.com/user-attachments/assets/ca4e1448-f77e-4644-baf2-836cdf0c3953)

![contract-files](https://github.com/user-attachments/assets/5b9f07ae-d7e8-4aa2-bdca-2696efec6cd6)

![register](https://github.com/user-attachments/assets/0d94e13f-5db4-4b3b-9d8d-320b023190a7)

![summary-by-cpf](https://github.com/user-attachments/assets/4ea00f05-c1d2-4d27-95cc-e4d20124885f)
