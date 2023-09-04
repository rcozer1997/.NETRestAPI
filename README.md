# .NET Rest API

Rest API project developed as a part of a backend job test. The main objective of the test is to design and implement a comprehensive REST API specifically tailored for event management. This entails the full spectrum of functionalities, including user and event registration, data retrieval, updates, and deletion (CRUD operations). 
Additionally, security is paramount, and is required to implement authentication mechanisms to safeguard access to these endpoints.

## Technologies Used
- **.NET Core 6.0:** The application is developed using .NET Core, a cross-platform framework for building modern web applications.

- **C#:** The primary programming language used in BocaAPI is C#, which is a powerful and versatile language supported by the .NET ecosystem.

- **SQL Server:** The API uses SQL Server as the underlying database for storing entity tags and related information.

- **EF Core:** Entity Framework Core is an open-source, cross-platform Object-Relational Mapping (ORM) framework developed by Microsoft. It is a part of the Entity Framework family of data access technologies and is designed for .NET applications.

- **ASP.NET Identity:** A framework provided by Microsoft as part of the ASP.NET web application development stack. It is designed to handle user authentication and identity management in web applications.


## Architecture

The API architecture consists of the following components:

- **Controllers:** The Controllers handle the incoming HTTP requests and route them to the appropriate actions. 

- **Services:** The Service here handle only with the Authentication methods. 

- **Repositories:** The Repositories layer is responsible for data access and storage. It handle with operations like retrieving, storing, updating, and deleting.

- **Data:** The Data contains the Database context and the Maps used to mapping the data to a proper format.
  
- **Models:** Used to store the classes that represent the data models used by the API, such as EventModels and UserModels.

- **DTO:** A crucial component for organizing and managing the classes. Is used to facilitate and improve the efficiency when transfering data between different parts of the application.


## Database

- The API uses SQL Server as the database for storing entity tags. The application creates three main tables (**Events**, **EventsParticipants** and **Users**). Note that the "User" is the table AspNetUsers, created by the ASPNET Identity.
A resume of each of them:
- **Events:** At this table, we store the events created with the following columns:
  ``Id`` (int/unique): Filter events by tag ID.
  ``Title`` (string): Defines the title of the event. Must have at least 8 characters.
  ``Description`` (string): Defines a description for the event. Must have max. 50 characters.
  ``Date`` (DateTime): ) Defines the data when the event will occur.
  ``ResponsibleId`` (string/unique): It shows the Id of the responsible that created the event.
- **EventsParticipants:** At this table we make a relation between Users and Events, to associate the users that are participants of an event. It has the following columns: 
  ``Id`` (int/unique): Filter relations by tag ID.
  ``EventId`` (int/unique): Filter the events by tag ID.
  ``UserId`` (string/unique): Filter the user participants by tag ID.
- **Users:** Stores the informations of a registered user. 
  ``Id`` (string/unique): Filter users by tag ID.
  ``Name`` (string): Stores the name of the registered user.
  ``UserName`` (string/unique): Stores the UserName that is the same thing then Email. Used to login at the system. 
  ``NormalizedUserName`` (string): Normalizes the UserName to capital letters.
  ``Email`` (string/unique): Stores the email used by the registered user.
  ``NormalizedEmail`` (string): Normalizes the email to capital letters.
  ``PasswordHash`` (string): Stores the password hashed.


## Instructions to run the program

1. *Database*
   
- You must have SQL Server installed, because this is what the program is configured to use.
- At the "appsettings.json" file, you must change the "Password" field, in ConnectionStrings, to your "sa" password, in SQL Server.
- At the visual studio terminal, you must run "Update-Database -Context SystemDBContext
     OR
  You can run at your terminal "dotnet ef database update -c SystemDBContext". If you dont have "ef" installed, you can install it by typing: "dotnet tool install --global dotnet-ef".
2. *Running*
- The program is configured to run at the local: https://localhost:7038/
- After running the program, you can access it with Swagger, at https://localhost:7038/swagger/index.html.
- The swagger is configured to have the "Authorize" mode, at the top of the page. So when you create an user and do login, you can copy the Token generated at the response field, go to "Authorize", type Bearer and paste the token. Like: "Bearer ~token~".

## Endpoints

As CRUD operations, the endpoints of the application are very simple. Here i list them, with the expected inputs and outputs. With the exception of the "Login" endpoint, ALL endpoints here are accessible only with the properly authentication. You must be logged and authorized (as explained in the topic above).
1. **User**
   
- *https://localhost:7038/api/User/search_all* - GET method. Doesn't requires an input. As output, lists all registered users.
  
- *https://localhost:7038/api/User/search_by_id/{id}* - GET method. Searches a specific user by the ID, so it requires the wanted user ID as input.
  
- *https://localhost:7038/api/User/signup* - POST method. Endpoint used to register a new user. It requires a json with name, email and password, like the following example:
  {
  "name": "string",
  "email": "string",
  "password": "string"
  }
  
- *https://localhost:7038/api/User/update/{id}* - PUT method. Updates the name and email of a registered user. It requires 2 inputs: The ID of the user that is going to be updated and a json with the new name and email, like the following:
  {
  "name": "string",
  "email": "string",
  }
  
- *https://localhost:7038/api/User/delete/{id}* - DELETE method. Deletes a registered user from the database. It requires the ID of the user to be deleted as input at the end of the url. Like:
   "https://localhost:7038/api/User/delete/a89bae3d-615a-44a7-940e-9f0b630aeeaa" (The ASPNET Identity hashes the ID, so it's how the ID is stored.)

2. **Events**
- *https://localhost:7038/api/Events/search_all* - GET Method. Similar to the User's one, doesn't requires an input and, as output, lists all registered events.
  
- *https://localhost:7038/api/Events/search_by_id/{id}* - GET Method. Find's a specific event by its ID. Need's the ID as input, like the following:
    https://localhost:7038/api/Events/search_by_id/3
  
- https://localhost:7038/api/Events/register - POST Method. Create a new event. Its required a Json, like the following:
{
  "title": "stringst",
  "description": "string",
  "date": "2023-09-04",
  "responsibleEmail": "string",
  "participantsEmails": [
     "string"
  ]
}
Note: "ResponsibleEmail" is the email of the responsible by the event, and "participantsEmails", is where you put the emails of the users that are going to join the event.
 
- *https://localhost:7038/api/Events/update/{id}* - PUT Method. Changes an event title, description and date using a json as input and the ID of the event, like the following:
https://localhost:7038/api/Events/update/3
{
  "title": "stringst",
  "description": "string",
  "date": "2023-09-04"
}

- *https://localhost:7038/api/Events/delete/{id}* - DELETE Method. Delete an event by its ID. 

3. **Auth**
- *https://localhost:7038/api/Auth/Login* - POST Method. Realizes the login of a registered user. Requires a json as input, with email and password. As output, sends a Token at the Response Body, used for Authorization.
  Input exemple:
  {
  "email": "rafael@gmail.com",
  "password": "rafael123"
  }

  
## Packages used (at Visual Studio)

- "Microsoft.AspNetCore.Authentication" Version="2.1.2" 
- "Microsoft.AspNetCore.Authentication.JwtBearer" Version="6.0.21" 
- "Microsoft.AspNetCore.Identity" Version="2.1.39" 
- "Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="6.0.21" 
- "Microsoft.EntityFrameworkCore" Version="7.0.10" 
- "Microsoft.EntityFrameworkCore.Design" Version="7.0.10"
- "Microsoft.EntityFrameworkCore.SqlServer" Version="7.0.10"
- "Microsoft.EntityFrameworkCore.Tools" Version="7.0.10"

## Test Questions

1.	Perguntas conceituais:
  a.	Descreva a utilidade de métodos assíncronos e os cuidados que devem ser tomados ao utilizá-los.
  b.	Explique o que são os Códigos de Status 2xx, 4xx e 5xx (Ex.: 200, 201, 404, 401, 500, etc.)
  c.	Explique os conceitos de Inversão de Controle e Injeção de Dependências

Answers:

A. Os métodos assíncronos permitem que o programa execute tarefas em segundo plano, o que significa que o programa pode continuar a executar outras tarefas enquanto aguarda a conclusão de operações demoradas. Na prática, isso mantém a responsividade do sistema e proporciona um melhor desempenho. Em sistemas de tempo real, a utilização de métodos assíncronos é crucial para atender a requisitos de tempo e responder a eventos imediatos. 
Contudo, alguns cuidados devem ser tomados. Ao usar operações assíncronas, é importante garantir que múltiplas tarefas não acessem ou modifiquem recursos compartilhados de forma concorrente. Além disso, o tratamento de erros em operações assíncronas pode ser mais complexo do que em operações síncronas. É importante ter um mecanismo adequado para capturar e lidar com erros que possam ocorrer em operações assíncronas. Podemos citar também um cuidado maior que deve-se ter em relação ao vazamento de recursos, tendo-se que certificar-se de que recursos, como memória, sejam liberados corretamente.

B. Os códigos de status HTTP são números de três dígitos que são retornados como parte da resposta de um servidor web para uma solicitação HTTP. Eles indicam o resultado da solicitação e fornecem informações sobre como a solicitação foi tratada pelo servidor. De acordo com as faixas de código (2xx, 4xx e 5xx), temos:
Na faixa "2XX' encontram-se os códigos de solicitação bem-sucedida, significando que o servidor foi capaz de processar a requisição. Como exemplo, temos o código 200 (Ok) e 2021 (Created). 
Na faixa "4XX" temos a faixa de códigos de "Client Error". São códigos que, no geral, indicam que houve um erro na solicitação feita ao servidor. Como exemplo, temos o código 404 (Not Found), que diz que o conteúdo solicitado não foi encontrado, e o 401 (Unauthorized), que diz que o solicitante não possui permissão para acessar o recurso. 
Já na faixa "5XX" temos o a faixa de "Server Error". Como na faixa anterior, indicam que houve um erro na solicitação, contudo, dessa vez por parte do servidor, onde o servidor não consegue responder adequadamente à requisição. Como exemplo, temos o 500 (Internal Server Error), que representa um erro genérico indicando que algo deu errado no servidor. E temos o 503 (Service Unavailable),  indicando que o servidor está temporariamente incapaz de atender à solicitação.

C. A Inversão de Controle é um princípio de design de software que se concentra na mudança do fluxo de controle em um sistema. Tradicionalmente, o controle do fluxo é determinado pelo código que você escreve, ou seja, você chama funções e métodos conforme necessário para executar tarefas. Com a IoC, essa lógica de controle é invertida. Em vez de o seu código controlar diretamente a execução de todas as suas dependências e componentes, você delega o controle a um mecanismo ou estrutura de IoC. Isso significa que o código que você escreve se concentra nas funcionalidades específicas do seu aplicativo e não precisa se preocupar com a criação ou gerenciamento de objetos e suas dependências.
Já a Injeção de Dependências é um padrão que se encaixa na IoC e é uma técnica específica para fornecer as dependências de um componente externamente em vez de criá-las internamente. Em outras palavras, em vez de um componente criar ou instanciar suas próprias dependências, essas dependências são "injetadas" no componente de fora. Isso ajuda a tornar o código mais flexível, uma vez que você pode trocar ou atualizar as implementações de dependência sem modificar o código do componente que as usa. Isso facilita a substituição de partes do sistema e o teste de unidades isoladas.
