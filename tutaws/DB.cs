using System;
using System.Collections.Generic;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.DocumentModel;
using Amazon.DynamoDBv2.Model;
using Amazon.Runtime;

namespace tutaws
{

	public class DB
	{
		public static AmazonDynamoDBClient client = new AmazonDynamoDBClient();
		private static string tableName = "ProductCatalog1";
		static DB()
		{
			int a = 0;
			int b = 0;
			int c = 0;
			var config = new AppConfig();
			config.AwsAccessKey = "AKIA5NEAXENLQJ43PY23";
			config.AwsRegion = "ap-south-1";
			config.AwsSecretKey = "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";
			var client = CreateClient(config);
			var table = Table.LoadTable(client, new TableConfig("ProductCatalog1"));
		}
		static void Main(string[] args)
		{
			//GetallItems();
			//	CreateItem();
			//GetItem();
			//	//CreateTableProductCatalog();


		}

		private static void GetItem()
		{
			var request = new GetItemRequest
			{
				TableName = tableName,
				Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { N = "202" } } },
			};
			var response = client.GetItemAsync(request);

			// Check the response.
			var result = response.Result;
			var attributeMap = result.Item.TryGetValue("Title", out var auth); // Attribute list in the response.
																			   //var Authorname = attributeMap["Authors"];
			var response2 = auth.S;
		}

		public static AmazonDynamoDBClient CreateClient(AppConfig appConfig)
		{
			var dynamoDbConfig = new AmazonDynamoDBConfig
			{
				RegionEndpoint = RegionEndpoint.GetBySystemName(appConfig.AwsRegion)
			};
			var awsCredentials = new AwsCredentials(appConfig);
			return new AmazonDynamoDBClient(awsCredentials, dynamoDbConfig);
		}

		public class AwsCredentials : AWSCredentials
		{
			private readonly AppConfig _appConfig;
			public AwsCredentials(AppConfig appConfig)
			{
				_appConfig = appConfig;
			}

			public override ImmutableCredentials GetCredentials()
			{
				return new ImmutableCredentials(_appConfig.AwsAccessKey,
						   _appConfig.AwsSecretKey, null);
			}

		}
		public class AppConfig
		{
			public string AwsRegion { get; set; }
			public string AwsAccessKey { get; set; }
			public string AwsSecretKey { get; set; }
		}


		//private static void CreateTableProductCatalog()
		//{


		//var response = client.CreateTableAsync(new CreateTableRequest
		//{
		//    TableName = tableName,
		//    AttributeDefinitions = new List<AttributeDefinition>()
		//                  {
		//                      new AttributeDefinition
		//                      {
		//                          AttributeName = "Id",
		//                          AttributeType = "N"
		//                      }
		//                  },
		//    KeySchema = new List<KeySchemaElement>()
		//                  {
		//                      new KeySchemaElement
		//                      {
		//                          AttributeName = "Id",
		//                          KeyType = "HASH"
		//                      }
		//                  },
		//    ProvisionedThroughput = new ProvisionedThroughput
		//    {
		//        ReadCapacityUnits = 10,
		//        WriteCapacityUnits = 5
		//    }
		//});
		public static string CreateItem(string Title, string id)
		{
			var request = new PutItemRequest
			{

				TableName = tableName,
				Item = new Dictionary<string, AttributeValue>()
				{
					{ "Id", new AttributeValue { N = id }},
					{ "Title", new AttributeValue { S = Title }},
					{ "ISBN", new AttributeValue { S = "11-11-11-11" }},
					{ "Price", new AttributeValue { S = "20.00" }},
					{
					"Authors",
					new AttributeValue
					{ SS = new List<string>{"Author1", "Author2"}   }
		  }
	  }
			};

			var resp = client.PutItemAsync(request).Result.HttpStatusCode.ToString();
			return resp;

		}
		//public static ProductCatalogue1 GetallItems(string id1)
		//{
		//	var request = new GetItemRequest
		//	{
		//		TableName = tableName,
		//		Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { N = id1 } } },
		//		ProjectionExpression = "Id, ISBN, Title, Authors",
		//		ConsistentRead = true
		//	};
		//	var response = client.GetItemAsync(request);
		//	//var attributeList = response.Item;
		//	// Check the response.
		//	var result = response.Result;
		//	var attributeMap = result.Item;
		//	ProductCatalogue1 PC = new ProductCatalogue1();
		//	try
  //          {
		//		attributeMap.TryGetValue("Id", out var Id);
		//		PC.Id = Id.N.ToString();
		//	}
  //          catch
  //          {

  //          }
		//	try
		//	{
		//		attributeMap.TryGetValue("Title", out var TiTle);
		//		PC.Title = TiTle.S;
		//	}
		//	catch
		//	{

		//	}
		//	try
		//	{
		//		attributeMap.TryGetValue("ISBN", out var isbn);
		//		PC.ISBN = isbn.S;
		//	}
		//	catch
		//	{

		//	}
		//	try
		//	{
		//		attributeMap.TryGetValue("Authors", out var lekhak);
		//		PC.Authors = lekhak.SS;
		//	}
		//	catch
		//	{

		//	}
		//	try
		//	{
		//		attributeMap.TryGetValue("Name", out var name);
		//		PC.Name = name.S;
		//	}
		//	catch
		//	{

		//	}




		//	Console.WriteLine("\nPrinting item after retrieving it ............");

		//	return PC;
		//	//PrintItem();

		//}

		public static Game GetallItemsss()
		{
			var request = new GetItemRequest
			{
				TableName = tableName,
				Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { N = "201" } } },
				ProjectionExpression = "GameId, Gamename, numberofmembers",
				ConsistentRead = true
			};
			var conditions = new List<ScanCondition>();
			var response = client.ScanAsync<Item > (conditions).GetRemainingAsync();
			//var attributeList = response.Item;
			// Check the response.
			var result = response.Result;
			var attributeMap = result.Item;
			Game PC = new Game();
			try
			{
				attributeMap.TryGetValue("Gameid", out var Id);
				int s = Int32.Parse(Id.N);
				PC.GameId = s;
			}
			catch
			{

			}
			try
			{
				attributeMap.TryGetValue("GameName", out var Gamenam);
				PC.Gamename = Gamenam.S;
			}
			catch
			{

			}
			try
			{
				attributeMap.TryGetValue("Noofmembers", out var numberofmember);
				PC.numberofmembers = Int32.Parse(numberofmember.N);
			}
			catch
			{

			}
			//try
			//{
			//	attributeMap.TryGetValue("Authors", out var lekhak);
			//	PC.Authors = lekhak.SS;
			//}
			//catch
			//{

			//}
			//try
			//{
			//	attributeMap.TryGetValue("Name", out var name);
			//	PC.Name = name.S;
			//}
			//catch
			//{

			//}




			Console.WriteLine("\nPrinting item after retrieving it ............");

			return PC;
			//PrintItem();

		}
		public static string CreateItem1(string Title, string id)
		{
			var request = new PutItemRequest
			{

				TableName = tableName,
				Item = new Dictionary<string, AttributeValue>()
				{
					{ "Id", new AttributeValue { N = id }},
					{ "Title", new AttributeValue { S = Title }},
					{ "ISBN", new AttributeValue { S = "11-11-11-11" }},
					{ "Price", new AttributeValue { S = "20.00" }},
					{
					"Authors",
					new AttributeValue
					{ SS = new List<string>{"Author1", "Author2"}   }
		  }
	  }
			};

			var resp = client.PutItemAsync(request).Result.HttpStatusCode.ToString();
			return resp;

		}
        public static ProductCatalogue1 GetallItems1(string id1)
        {
            int s = Int32.Parse(id1);
            var request = new GetItemRequest
            {
                TableName = tableName,
                Key = new Dictionary<string, AttributeValue>() { { "Id", new AttributeValue { N = "id1" } } },
                ProjectionExpression = "Id, ISBN, Title, Authors",
                ConsistentRead = true
            };
            var response = client.GetItemAsync(request);
            //var attributeList = response.Item;
            // Check the response.
            var result = response.Result;
            var attributeMap = result.Item;
            ProductCatalogue1 PC = new ProductCatalogue1();
            attributeMap.TryGetValue("Id", out var Id);
            PC.Id = Id.N.ToString();
            attributeMap.TryGetValue("Title", out var TiTle);
            PC.Title = TiTle.S;
            attributeMap.TryGetValue("ISBN", out var isbn);
            PC.ISBN = isbn.S;
            attributeMap.TryGetValue("Authors", out var lekhak);
            PC.Authors = lekhak.SS;

            Console.WriteLine("\nPrinting item after retrieving it ............");

            return PC;
            //PrintItem();
        }
        //private static void PrintItem(Dictionary<string, AttributeValue> attributeMap)
        //{
        //    throw new NotImplementedException();
        //}
        // Attribute list in the response.
    }
}

