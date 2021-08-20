using System;
using System.Threading.Tasks;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using UnityEngine;

namespace Beamable.Server.MyADBMicroservice.MyADBMicroserviceExample
{
   [Microservice("MyADBMicroservice")]
   public class MyADBMicroservice : Microservice
   {
      [ClientCallable]
      public bool ConnectToDatabase()
      {
         // TODO: Create an account with https://aws.amazon.com/dynamodb/ 
         // TODO: And add your keys here
         string accessKey = "replace-with-your-access-key";
         string secretKey = "replace-with-your-secret-key";
         
         try
         {
            // Credentials
            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            
            // Configuration
            var config = new AmazonDynamoDBConfig()
            {
               RegionEndpoint = RegionEndpoint.USWest2
            };
            
            // Client
            AmazonDynamoDBClient client = 
               new AmazonDynamoDBClient(credentials, config);
            
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