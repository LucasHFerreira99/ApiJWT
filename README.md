# API com Autenticação JWT em C#

Este repositório contém uma API desenvolvida em C# que utiliza JWT (JSON Web Token) Bearer Token para autenticação. A API permite a autenticação segura de usuários e o acesso a recursos protegidos.

Esta API no momento `registra` e realiza o `Login` de um usuário com a utilização do JTW.

## Pré-requisitos

Antes de começar, você precisará de:

- [SDK .NET Core](https://dotnet.microsoft.com/download)
- [Visual Studio](https://visualstudio.microsoft.com/) ou outra IDE de sua preferência
- [Postman](https://www.postman.com/) ou outra ferramenta para testes de API (opcional)


## Estrutura do Projeto

- **`Controllers`**: Contém os controladores da API:
  - `AuthController`: Gerencia a autenticação e a geração de tokens.
  - `UsuarioController`: Gerencia operações relacionadas aos usuários.

- **`Models`**: Contém os modelos de dados:
  - `UsuarioModel`: Representa os dados de um usuário.
  - `ResponseModel`: Representa a resposta da API para solicitações.

- **`Services`**: Contém serviços e lógica de negócios:
  - `AuthService`: Implementa a lógica de autenticação e Registro.
  - `SenhaService`: Implementa a lógica para o gerenciamento e validação de senhas e também a criação de tokens JWT.

- **`DTOs`**: Contém os Data Transfer Objects, utilizados para a transferência de dados entre a API e o cliente:
  - `UsuarioLoginDto`: Dados necessários para o processo de login.
  - `UsuarioCriacaoDto`: Dados necessários para o registro de um novo usuário.

- **`Enums`**: Contém enums que definem valores constantes e enumerados utilizados na aplicação:
  - `CargoEnum`: Define os cargos de usuário na aplicação, como Operacional, Administrador e SuperAdministrador.


## Instalação

1. **Clone o Repositório**

   ```
   git clone https://github.com/LucasHFerreira99/ApiJWT.git
   ```
   
2. **Restaure os Pacotes**

   Navegue até o diretório do projeto e execute o comando a seguir para restaurar os pacotes NuGet necessários:

   ```bash
   dotnet restore


3. **Configure as Variáveis de Ambiente**

   Você precisará configurar a chave secreta para o JWT no arquivo `appsettings.json`. Atualize o valor de `AppSettings:Token` com uma chave secreta segura conforme necessário para sua aplicação.

   O arquivo `appsettings.json` deve ser configurado da seguinte forma:

   ```json
   {
     "AppSettings": {
       "Token": "SuaChaveSecretaAqui",
     }
   }
   ```
   
	  Você precisará tambem configurar o seu banco de dados SQL para armazenamento dos dados de seu usuario. Atualize o valor de `ConnectionStrings:DefaultConnection` conforme os seus dados de acesso ao SQL Server.

	  ```json
	   {
	     "ConnectionStrings": {
	       "DefaultConnection": "SuaStringDeConexãoAqui",
	     }
	   }
	  ```

