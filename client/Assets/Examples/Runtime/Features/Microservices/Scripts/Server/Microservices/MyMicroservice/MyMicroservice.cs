using Beamable.Server;

namespace Beamable.Examples.Features.Microservices
{
   [Microservice("MyMicroservice")]
   public class MyMicroservice : Microservice
   {
      [ClientCallable]
      public int AddMyValues(int a, int b)
      {
         return a + b;
      }
   }
}