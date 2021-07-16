using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using UnityEngine;

namespace Beamable.Server.MyADBMicroservice.MyADBMicroserviceExample
{
   [Microservice("MyADBMicroservice")]
   public class MyADBMicroservice : Microservice
   {

      [ClientCallable]
      public async Task<int> ConnectToDB()
      {
         Debug.Log($"ConnectToDB()");
         
         // I created this from amazon.com. Works?
         // CognitoCachingCredentialsProvider credentialsProvider = new CognitoCachingCredentialsProvider(
         //    getApplicationContext(),
         //    "us-east-2:c111bb57-5e02-482d-b179-60d18f0ea259", // Identity pool ID
         //    Regions.US_EAST_2 // Region
         // );
         
         // I created this from
         // (https://console.aws.amazon.com/iam/home#/security_credentials$access_key). Works?
            
         //Access Key:
         //       AKIAQJGZKKP3ZBMH6WA5
         //Secret Key:
         //       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
         
         try
         {
            Debug.Log($"1");
            
            var c = new BasicAWSCredentials(
               "AKIAQJGZKKP3ZBMH6WA5",
               "gmbd4KZRs6TKAGgS+KxMRmyKB6xY/I2+vvE8AGGd");
            
            Debug.Log($"2");
            
            // THROWS EXCEPTION: The type initializer for 'Amazon.AWSConfigs' threw an exception.
            var x = new AmazonDynamoDBStreamsClient(c);
            
            Debug.Log($"3");
            
         }
         catch (Exception e)
         {
            Debug.Log($"GetPlayerLevel() Message = {e.Message}");
            return -1;
         }
         
         return 1;
      }
   }
}