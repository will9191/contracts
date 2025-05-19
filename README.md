
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

**Desktop:** .NET MAUI

**Back-end:** C#, Asp.NET 9.0

**Banco de dados:** SQL Server

**API Test:** Scalar
## Rodando localmente

Clone o projeto

```bash
  git clone https://github.com/will9191/contracts
```

**Web API**

Entre no diretório do projeto

```bash
  cd server
```

Verifique se o .NET está instalado (usando a versão 9)

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

**Desktop**

Navegue para o diretório do projeto (contracts/desktop)

Verifique se o .NET está instalado (usando a versão 9)

```bash
  dotnet --version
```

Restaure os pacotes NuGet

```bash
  dotnet restore
```

Faça o build do projeto

```bash
  dotnet build -f net9.0-windows10.0.19041.0 -c Debug -p:PublishReadyToRun=true -p:WindowsPackageType=None

```

Rode o projeto

```bash
  dotnet run -f net9.0-windows10.0.19041.0 -c Debug -p:PublishReadyToRun=true -p:WindowsPackageType=None

```

## Screenshots

![summary-by-cpf-view](https://github.com/user-attachments/assets/15646670-fda8-4c63-8b96-4d9bd1df33b1)

![contracts-by-cpf](https://github.com/user-attachments/assets/1ce6a6b5-8a24-4674-a334-1d6beb6d5ca2)

![contracts-by-file](https://github.com/user-attachments/assets/e9b7748f-6b11-4e85-8824-4f074fd50495)

![contracts-view](https://github.com/user-attachments/assets/70c230ec-dad9-4bae-b949-dd05a519f9bd)

![login](https://github.com/user-attachments/assets/6503e8d4-2147-4b20-93f4-adbac4a33e27)

![add-contracts-from-file](https://github.com/user-attachments/assets/ca4e1448-f77e-4644-baf2-836cdf0c3953)

![contract-files](https://github.com/user-attachments/assets/5b9f07ae-d7e8-4aa2-bdca-2696efec6cd6)

![register](https://github.com/user-attachments/assets/0d94e13f-5db4-4b3b-9d8d-320b023190a7)

![summary-by-cpf](https://github.com/user-attachments/assets/4ea00f05-c1d2-4d27-95cc-e4d20124885f)
