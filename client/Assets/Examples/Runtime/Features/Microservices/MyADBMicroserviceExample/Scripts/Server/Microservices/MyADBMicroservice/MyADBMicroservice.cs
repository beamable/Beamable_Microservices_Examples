using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using UnityEngine;

namespace Beamable.Server.MyADBMicroservice.MyADBMicroserviceExample
{
   [Microservice("MyADBMicroservice")]
   public class MyADBMicroservice : Microservice
   {
      [ClientCallable]
      public async Task<bool> CallADB()
      {
         try
         {
            // TODO: Create your own account with https://aws.amazon.com/dynamodb/ 
            // And add your credentials here
            AmazonDynamoDBConfig amazonDynamoDBConfig = new AmazonDynamoDBConfig();
            Debug.Log($"CallADB() Success!");
            
         }
         catch (Exception e)
         {
            Debug.Log($"CallADB() Failure! Message = {e.Message}");
            return false;
         }

         return true;
      }
   }
}