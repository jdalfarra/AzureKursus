# Azure Kursus 

## Dag 1:

**WEB APPS:**
[REPO - web app](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologiks.Kursus.Website)
- WEB APP 
	- WEB APP service plan: windows machine with iss where you can add WEB APPS
	- template
	- Deployment slot: 
		- add slot
		- traffic
		- swap
	- Authentication / authorization
		- add azure active directory - login med azure active directory
		- Express app
	- Application insights:
		- Applicationmap: dependencies (ex. sql database)
		- Live metrics stream: live representaiton of metrics
		- Dependency call rate: error, performance
	- Trafic manager
	- WEB JOBS <- when functions is not a option
		- continuous
		- triggered
		- create web job <- publish <- check log
**FUNCTION APP (azure functions):**
[REPO - function app](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.Functions)
	- consumtion plan spinner en maskine op i MAKS 7 min
	- simple app using fluent api

## Dag 2

**Key vault:**
Save confidential keys:
 - Certificates
 - Secrets
    - URL
 -  Replace hardcoded keys:
 	- AzureServiceTokenProvider()
	- KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback))
	- KeyVaultClient.GetSecretAsync("keyvault url").GetAwaiter().GetResult().Result
  
**Logic apps:**
- Workflow solution
- Triggers
- Actions
- Connectors

**Storage accounts:**

Storage account: only blobs options
encryption with key vaults


**BLOB:**
[REPO - blob](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.StorageQueueApp)

- BLOCK BLOBS
  - Streaming, images, videos etc.
- APPEND BLOBS
  - Good for logging or appending
- PAGE BLOBS
  - Files, compressed
 
**Azure function:**
[REPO - Function](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.Functions)
 - handleBlobupload
 - name: StorageAccountConnection
 - path: files
 - add StorageAccountConnection to local.settings.json
 - also add StorageAccountConnection to when deploying to azure PlatformFeatures -> configurations -> new application  setting
 
 
- FILE
- QUEUE
	- First in - not first out
- TABLE
	- NO-SQL
	- No relations
	- Mandatory fields: Row key & Partition key

- Cosmos DB
	- Scalability i forhold til Table
	- Indexering 
	- API: Azure table
	- Geo redundancy
	- Intet netværk

## Dag 3:

**Cognitive services:**
[REPO - cognitive services](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.CognitiveServices)
- L.U.I.S (voice)
- Computer vision api (billeder)
- BOT / QnA maker
- A.I. / M.L.
- FACE api 

**Cosmos DB:**
[REPO - cosmos](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.CosmosDB)
- Option to choose different types of storage

**Graph:** 
https://developer.microsoft.com/en-us/graph/graph-explorer
 - create, edit, read 
 - Scaling

## Dag 4:
**Authentication:**
[REPO - Auth website](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.AuthWebsite)
 - Groups, rules etc. 
 - Basic auth in .NET possible
 
## Dag 5:

**API Management:**
**Busses:**
[REPO - servicebus](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.ServiceBusQueue)
[REPO - queue](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.StorageQueueApp)
  - Storage Queue
	- Azure Functions
	- Passing a message from frontend to backend without the user having to wait for it to be processed (orders)
nuget:
Microsoft.Azure.Storage.Queue

- Service Bus Queue
	- Topics: can be used to more recivers
- Microsoft Graph
- Azure Relay

## Dag 6:

**Azure Search:**
 - Posibility to create custom indexes, faceting 
 - Trafic manager:
 	- Can help selecting where to fetch data from: geolocation, load, performance, priority
 - Keys: Admin-key (CRUD) + query-key (read)
 - Indexes, can be created using .NET (SearchServiceClient)
**Indexes:**
 - Content, relational databases, streaming data, NoSQL databases
 - Creating the index each field needs a type (string, int, double etc..)
 - Retrievable *(retived as result)*, Filterable *(filter by fx color)*, Sortable *(sort)*, facetable *(facets)*, searchable *(search)*
 - REST CRUD operations
 - Lucene, ODATA or easy search

_Ex on querying:_ 
```
//Find all hotels less than 150 and return the hotelId and description
SearchParameters parameters = new SearchParameters()
{
   Filer = "baseRate lt 150",
   Select = new[] { "hotelId", "description" 
}

DocumentSearchResult<Hotel> results = indexClient.Documents.Search<Hotel>("budget", parameters);
```

Query syntax:

| Opertation | type |
| ------------- | ------------- |
| AND  | +  |
| OR  | \| |
| NOT  | - |
| Suffix  | * |
| Phare  | "" |
| Precedence  | () |

**Traffic management:**
 - _Destribution_: 2 app service plans in different region
 - _loadbalance_: distribute load to diffrent web apps
 - _application gateway_: routing, security (sql injection etc.)
	- ex. document -> send traffic to one web app, videos send traffic to another web app

**API APPS:**
[REPO - API app](https://github.com/jdalfarra/AzureKursus/tree/master/Teknologisk.Kursus/Teknologisk.Kursus.APIAPP)
 - Similar functionality to Web apps
 - integrated with logic apps and API managemnet
 - Built in authenticaion

**Containers:**
 - Splitting the application into small areas like (Backend, Frontend, Datalayer etc.)
 - Scalling advantages, can scale the containers that is under most load
 	- Without need of scaling the whole infrastructure
 - Kubenetes
 	- Nodes containing VM's, that all can run different apps or services

| [AZ-203 learning repo](https://github.com/MicrosoftLearning/AZ-203-DevelopingSolutionsforMicrosoftAzure) | [AZ-301 learning repo](https://github.com/MicrosoftLearning/AZ-301-MicrosoftAzureArchitectDesign) |
------------------------------------------------------------------------------------------------------
