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
         MyCustomData myCustomData = null;

         // Check All Content
         var clientManifest = await Services.Content.GetManifest();
         foreach (var entry in clientManifest.entries)
         {
            // Find Matching Type
            if (entry.contentId.Contains("my_custom_content"))
            {
               // Load MyCustomContent
               MyCustomContent myCustomContent =
                  await Services.Content.GetContent<MyCustomContent>(entry.ToContentRef());

               myCustomData = myCustomContent.MyCustomData;
            }
            
         }
         
         // Return data
         return myCustomData;
      }
   }
}