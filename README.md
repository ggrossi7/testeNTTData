# Guia de Configuração e Execução do Projeto NTTData

Pré-requisitos
Antes de iniciar, verifique se os seguintes itens estão instalados e configurados corretamente em sua estação de trabalho:

Docker Desktop: Certifique-se de que o Docker Desktop está instalado e funcionando.
Visual Studio: O Visual Studio 2022 deve estar instalado (versão 17.6 ou superior) com os workloads necessários para o desenvolvimento em .NET, incluindo suporte ao Docker.
.NET 8.0 SDK: O SDK da versão 8.0 do .NET deve estar instalado.


Passos para Configuração e Execução
1. Abrir o Projeto
Abra o arquivo de solução do projeto no Visual Studio:
Caminho do arquivo: Ambev.DeveloperEvaluation.sln

2. Alterar o Projeto de Inicialização para docker-compose
No Visual Studio, siga os passos abaixo para configurar o docker-compose como o projeto de inicialização:
Localize o Configuration Selector no canto superior central da interface.
Clique na seta ao lado do projeto atualmente selecionado.
Selecione docker-compose na lista de opções.

3. Executar o Projeto com Docker Compose
Após selecionar o docker-compose como o projeto de inicialização, clique no botão Start (ícone de ▶️) no Visual Studio para iniciar o sistema.

4. Acessar o Swagger UI
Após a inicialização, o sistema será carregado automaticamente no Swagger UI, onde você poderá testar as APIs disponíveis.

5. Realizar Operações no Swagger
No Swagger UI, localize a seção Sales e realize as operações desejadas conforme as necessidades do projeto.