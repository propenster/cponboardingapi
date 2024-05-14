# CP Onboarding API


## ChangeLog

- Commit [529614d856f08c1b84de3b730e8c9ced727a5ad9](https://github.com/propenster/cponboardingapi/529614d856f08c1b84de3b730e8c9ced727a5ad9)
**Starting-Project**
This is the beginning, start of the project where we create a new .NET 8 Web API project.

- Commit [fd5e4866a4e303aceea23c23bd1fb88b3ffd4fad](https://github.com/propenster/cponboardingapi/fd5e4866a4e303aceea23c23bd1fb88b3ffd4fad)
**Add models and cosmosdb client**
I added models, (check the Models folder for all the models) a few of them and included the Microsoft Azure Cosmos DB Client from nuget.org, then added things like swagger for OpenAPI documentation, and configurations in the dependency injection container.

- Commit [2fcf97c05c8c2dd1808655e1ab490947318770cf](https://github.com/propenster/cponboardingapi/2fcf97c05c8c2dd1808655e1ab490947318770cf)
**Add some more models, dtos and created the data repository**
I added some more models, dtos (requests and responses) and created the Repository class and it's interface IRepository and registered it in the DI container.

- Commit [bc48c821c806aab826f5a200935f55b401bf1813](https://github.com/propenster/cponboardingapi/bc48c821c806aab826f5a200935f55b401bf1813)
**Get rid of the custom CosmosDbClient towards less abstractions that will scatter my head and ease of testing**
Initially, I thought to create a single class that will handle everything related to connecting to my CosmosDB emulator and fetching and acting on data but I realized with this approach I'm going to have to make some redundant calls to var container = GetContainer() which is bad. Actually I was going to do it for every method so I switched to adding connection stuff for CosmosDb inside Program.cs where I registered my IRepository and Repository and thus enabling me to make my Repository a singleton.

- Commit [2618b9899f0dacdc2b0a2ca4557480f3dc82c473]((https://github.com/propenster/cponboardingapi/2618b9899f0dacdc2b0a2ca4557480f3dc82c473))
**Tested api is working fine, added api documentation and postman collection**
This is where I did an end to end manual test of all the endpoints on the API and validated they all work. Also I made a PDF documentation of the entire API and testing guide for whoever may have need to test the API.

- Commit [eacf92cd736037aaf59112443cccd62c3f926fce](https://github.com/propenster/cponboardingapi/eacf92cd736037aaf59112443cccd62c3f926fce)
**Add unit tests and postman collection into the project folder**
I added an xUnit test project to the solution and wrote tests for both the Repository and the EmployerController. I also used this opportunity to include the postman collection that I exported from my end-to-end test into the project folder.
