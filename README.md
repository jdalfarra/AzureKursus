# AzureKursus

## Dag 1:

** WEB APPS: **
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
** FUNCTION APP (azure functions) **
	- consumtion plan spinner en maskine op i MAKS 7 min
	- simple app using fluent api
	- 
** API APP **
** LOGIC APP **
** MOBILE APP **

## Dag 2

** Key vault: **
Save confidential keys:
 - Certificates
 - Secrets
    |_ URL
 -  Replace hardcoded keys:
 	- AzureServiceTokenProvider()
	- KeyVaultClient(new KeyVaultClient.AuthenticationCallback(azureServiceTokenProvider.KeyVaultTokenCallback))
	- KeyVaultClient.GetSecretAsync("keyvault url").GetAwaiter().GetResult().Result
	- T
  
** Logic apps: **
- Workflow solution
- Triggers
- Actions
- Connectors

** Storage accounts: **

Storage account: only blobs options
encryption with key vaults


** BLOB **
	- BLOCK BLOBS
	  - Streaming, images, videos etc.
	- APPEND BLOBS
	  - Good for logging or appending
	- PAGE BLOBS
	  - Files, compressed

ASP.NET web application
- first: find the strategy to transfer data
	- Access Keys
- Nuget packages: Microsoft.Azure.Storage.Blob
 - CloudStorageAccount.Parse(connectionstring)
 - CloudBlobClient = ^.CreateCloudBlobClient()
 - CloudBlobContainer ^.GetContainerReference()
 - ^.createIfNotExits()
 - cloudBlobContainer.ListBlobs()
 - Check for types
 - Cast to the proper types and list the Blobs with the model
 
** Azure function **
 - handleBlobupload
 - name: StorageAccountConnection
 - path: files
 - add StorageAccountConnection to local.settings.json
 - also add StorageAccountConnection to when deploying to azure PlatformFeatures -> configurations -> new application  setting
 - 

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

** Cognitive services **
- L.U.I.S (voice)
- Computer vision api (billeder)
- BOT / QnA maker
- A.I. / M.L.
- FACE api 

** Cosmos DB: **
- Option to choose different types of storage

** Graph: ** 
https://developer.microsoft.com/en-us/graph/graph-explorer
 - create, edit, read 
 
Scaling

## Dag 4:

## Dag 5:

** API Management **
** Busses: **
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

** Azure Search: **
