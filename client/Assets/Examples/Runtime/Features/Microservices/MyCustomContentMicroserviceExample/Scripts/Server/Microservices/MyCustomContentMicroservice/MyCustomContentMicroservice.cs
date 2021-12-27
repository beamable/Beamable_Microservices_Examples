using System.Threading.Tasks;
using Examples.MyCustomContentMicroserviceExample.Shared.MyCustomContent;
using UnityEngine;

namespace Beamable.Server
{
   [Microservice("MyCustomContentMicroservice")]
   public class MyCustomContentMicroservice : Microservice
   {
      [ClientCallable]
      public async Task<MyCustomData> LoadCustomData()
      {
         Debug.Log("Working...!");
         
         return new MyCustomData();
      }
   }
}