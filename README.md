# Desafio GeoPet

Aplicação de informação de pessoas cuidadoras e de pets além de buscas de informações de endereços por latitude e longitude.

## Demonstração

```
https://drive.google.com/file/d/1CcWix5ftZ1MZQQfl-x3tFbHf8UiUWkIN/view?usp=sharing
```

## 🚀 Começando


Essas instruções permitirão que você obtenha uma cópia do projeto e possa executar na sua máquina local para fins de desenvolvimento e teste.

* SSH
```
git clone git@github.com:jadeilsonm/GeoPet.git
```

* HTTPS
```
git clone https://github.com/jadeilsonm/GeoPet.git
```


## 📋 Pré-requisitos

- Docker - (opcional)*
- Dotnet 6
- dotnet ef
- Banco de dados SqlServer

## 🔧 Instalação


Entre no diretorio GeoPet:
```sh
cd GeoPet
```
Instale as dependencias do projetos:
```sh
dotnet restore
```
Crie um databese no SqlServer, segue exemplo:

```
CREATE DATABASE GeoPet
```

Edite as constantes no diretorio Shared/Constants/Defaults:
```
CONNECTION_SGRING = @"
                Server=Endereçõ do seu servidor Sql;
                Database=nome do database criado no passo anterior;
                User=sa;
                Password=senha do servidor Sql;
                TrustServerCertificate=True
            ";
```
Execute a migration para criar as tabelas no database:
```sh
dotnet ef database update
```
Agora inicie o serviço:
```sh
cd GeoPetProject/GeoPet
dotnet run
```
Se tudo ocorreu bem ira mostrar um console ***Server up*** no terminal.


### ⌨️ E testes unitarios

Para Executar teste

```sh
cd GeoPetProject/GeoPet.Test
dotnet test
```

## 📦 Desenvolvimento

Neste projeto tive como grande desafio o relacionamento entre os dados, e os consumos de outras api.

## 🛠️ Construído com:

ferramentas usadas para criar o projeto.

* [Dotnet](https://dotnet.microsoft.com/pt-br/) - framework criado pela Microsoft e voltado ao desenvolvimento web.
* [SqlServer](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads) - Utilizado para armazenar os dados.
* [JWT](https://jwt.io/) - Utilizado como padrão para autenticação
* [Swagger](https://swagger.io/) - Utilizado para documentação.
* [Docker](https://www.docker.com/) - Utilizado para desenvolvimento e ou testes da aplicação.


## 📌 Versão

* versão 1.0

* Foi utilizado [github](https://github.com/) para controle de versão e armazenamento de codigo fonte.

## ✒️ Autores

* **desenvolvedor** - *Trabalho Inicial* - [desenvolvedor](https://github.com/jadeilsonm)


## 🎁 Expressões de gratidão

* Conte a outras pessoas sobre este projeto 📢
* Convide alguém da equipe para uma café ☕ 
* Obrigado publicamente 🤓.
