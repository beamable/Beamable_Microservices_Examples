using System.Collections.Generic;
using Beamable.Server;

namespace Beamable.Examples.Features.Microservices
{
   [Microservice("MyMicroservice")]
   public class MyMicroservice : Microservice
   {
      [ClientCallable]
      public bool AddMyValues(int a, int b)
      {
         Services.Inventory.AddCurrencies(
            new Dictionary<string, long> {{"currencies.gold", 100}});

         return true;
      }
   }
}