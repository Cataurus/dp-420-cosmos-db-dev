using System;
using Microsoft.Azure.Cosmos;

string endpoint = "https://cataurusfynn.documents.azure.com:443/";
string key = "IlmVbRdKaOWBNLWSgIEVj0lStJGrNaotH468Jyp8iWwdVjOcWq5DfOCPgDvOHRDqeo6J3wetibHYACDbr6NKUA==";

CosmosClient client = new CosmosClient(endpoint, key);
    
Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");

Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId", 400);

/* Step 1

Product saddle = new("0120", "Worn Saddle", "9603ca6c-9e28-4a02-9194-51cdb7fea816");
Product handlebar = new("012A", "Rusty Handlebar", "9603ca6c-9e28-4a02-9194-51cdb7fea816");

PartitionKey partitionKey = new ("9603ca6c-9e28-4a02-9194-51cdb7fea816");

TransactionalBatch batch = container.CreateTransactionalBatch(partitionKey)
    .CreateItem<Product>(saddle)
    .CreateItem<Product>(handlebar);

using TransactionalBatchResponse response = await batch.ExecuteAsync();

Console.WriteLine($"Status:\t{response.StatusCode}");

*/

// Step 2

Product light = new("012B", "Flickering Strobe Light", "9603ca6c-9e28-4a02-9194-51cdb7fea816");
Product helmet = new("012C", "New Helmet", "0feee2e4-687a-4d69-b64e-be36afc33e74");

PartitionKey partitionKey = new ("9603ca6c-9e28-4a02-9194-51cdb7fea816");

TransactionalBatch batch = container.CreateTransactionalBatch(partitionKey)
    .CreateItem<Product>(light)
    .CreateItem<Product>(helmet);

using TransactionalBatchResponse response = await batch.ExecuteAsync();

Console.WriteLine($"Status:\t{response.StatusCode}");