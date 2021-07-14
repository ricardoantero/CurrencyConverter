# Currency Converter

Projeto de conversão monetária de uma ou mais moedas por usuário.

## 🚀 Começando

O Projeto completo está disponível nesse repositório do GITHUB utilizando a branch **Main**


### 🔧 Instalação, Utilização e Considerações

Exemplos de como se deve executar para ter um ambiente de desenvolvimento:

**Instalação**
```
* Com o projeto aberto no Visual Studio, entrar no arquivo: appsettings.json e apontar para connection string da sua maquina

* Para criar o banco de dados podemos utilizar duas opções
1ª Rodar o script na pasta root desse projeto: SQLScripts.sql
2º Rodar o comando migrations:
** add-migration GerarMigration ; Update-Database


```
**Utilização**
```
* Página do Swagger com a documentação e endpoint das API será aberto no default.

* Para os modelos: Usuário, Moeda e Transação os endpoint de CRUD serão exibidos

* Para retornar todas as transações por usuário, consumir a API: /api/users/userstransaction/{id}
	Parametros: 
		id - Id do usuário devidamente cadastrado na tabela de usuários.

* Para realizar a transação entre moedas, consumir a API: /api​/currencyconverter
	Parametros: 
		idUser - Código do Usuário registrado na tabela de usuários.
		OriginCurrency - Código da moeda utilizado como base (ex:. BRL, USD), o código da moeda necessita estar registrado na tabela de moedas.
		OriginValue - Valor de origem no qual deseja ser convertido
		DestinationCurrency - Lista de Moedas que receberão a conversão de acordo com a moeda base inserida.
```

**Considerações**
```
* Para os Endpoints de transações por usuário e conversão de moedas os códigos e mensagens de erro são retornadas na requisição

* Os Logs são registrados na tabela "Log" criada dinamicamente pelo Serilog.
```

## 📦 Desenvolvimento
```
* Escolhi o framework .NET Core por ser um framework mais atual com possíbilidade de aplicar e rodar em diferentes ambientes.

* Utilizei das boas práticas do DDD para separação das camadas onde:
	Camada de Aplicação: recebe os controlladores e fica responsável por receber as aquisições e direcionar para um serviço.
	Camada de Domíenio: Implementa as Classes e interfaces
	Camada de Serviço: Efetuado a regra de negócios
	Camada de Infra Data: Realizado a persistencia no banco de dados
	Camada de Infra CrossCutting IoC: Camada que não obedece a hierarquia, onde realizamos o mapeamento das demais e os registros e consumo de API externas.

* Utilizei o Swagger para melhorar a exibição e mapear os Endpoints

* Utilizei o Serilog para facilitar a implementação e conseguir persistir na base de dados os Logs registrados.

* Iníciei a aplicação de teste unitário xUnit sem cobertura alguma por enquanto da aplicação (íniciando os estudos em testes unitários)

* Iniciei a publicação da Imagem no DockerHub - comando: "docker pull rantero/currencyconverterapi"
```

## 🛠️ Construído com

* [SDK .NET CORE 3.1](https://dotnet.microsoft.com/download/visual-studio-sdks)
* [Visual Studio 2019 Community](https://visualstudio.microsoft.com/pt-br/downloads/)
* [SQL Server 18](https://docs.microsoft.com/pt-br/sql/ssms/download-sql-server-management-studio-ssms?view=sql-server-ver15)
* [Swagger](https://swagger.io/docs/)
* [Serilog](https://serilog.net/)

## 📌 Versão

Para versionamento e exibição da API utilizei [Swagger](https://swagger.io/docs/)

## ✒️ Autores

* **Ricardo Antero** - *Desenvolvedor* - [Repositório](https://github.com/ricardoantero/CurrencyConverter)
