using Beamable.Server;

namespace Beamable.Examples.Features.Microservices.MyMathMicroserviceExample
{
   [Microservice("MyMathMicroservice")]
   public class MyMathMicroservice : Microservice
   {
      /// <summary>
      /// Add 2 integers and return the result.
      /// </summary>
      /// <param name="a">The first value to add</param>
      /// <param name="b">The second value to add</param>
      /// <returns>Returns the sum of the values</returns>
      [ClientCallable]
      public int AddMyValues(int a, int b)
      {
         return a + b; 
      }
   }
}