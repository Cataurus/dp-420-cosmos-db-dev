using System;
using Azure.Cosmos;

string endpoint = "https://cataurusfynn.documents.azure.com:443/";
string key = "MLJqQ2DvtM1XclHO69fMXLGpYPCHNh3QBGJXOA8hL7IQHXFxGR8kj6HS364LAzGXSC2Ro5XfzSkoACDbeHOI1A==";

CosmosClient client = new CosmosClient(endpoint, key);
CosmosDatabase database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");
CosmosContainer container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId");

string sql = "select * from products p";

var query = new QueryDefinition(sql);

await foreach (Product product in container.GetItemQueryIterator<Product>(query))
{    
    Console.WriteLine($"[{product.id}]\t{product.name,35}\t{product.price,15:C}");
}
