using System;
using Microsoft.Azure.Cosmos;

string endpoint = "https://cataurusfynn.documents.azure.com:443/";
string key = "naxcy26gGRtU31ucgN7ObPp8lWhEUV6GNWpLes82ltQT6RFzrMNBKxpk9nXaSgmclTBcjA50LKbhACDbfkmwJg==";

CosmosClient client = new CosmosClient(endpoint, key);

Database database = await client.CreateDatabaseIfNotExistsAsync("cosmicworks");
Container container = await database.CreateContainerIfNotExistsAsync("products", "/categoryId");

string sql = "SELECT p.id, p.name, p.price FROM products p ";

QueryDefinition query = new (sql);

QueryRequestOptions options = new ();

options.MaxItemCount = 50;

FeedIterator<Product> iterator = container.GetItemQueryIterator<Product>(query, requestOptions: options);

while (iterator.HasMoreResults)
{    
    FeedResponse<Product> products = await iterator.ReadNextAsync();
    
    foreach (Product product in products)    
    {        
        Console.WriteLine($"[{product.id}]\t[{product.name,40}]\t[{product.price,10}]");    
    }    
    
    Console.WriteLine("");    
    Console.WriteLine("Press any key to get more results");    
    Console.ReadKey();
}
