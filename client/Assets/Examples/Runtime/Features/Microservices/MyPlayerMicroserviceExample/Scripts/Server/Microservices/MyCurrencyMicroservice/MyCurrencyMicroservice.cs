using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Beamable.Server
{
   [Microservice("MyCurrencyMicroservice")]
   public class MyCurrencyMicroservice : Microservice
   {
      [ClientCallable]
      public async Task<bool> AddCurrency()
      {
         bool isSuccess = false;
         var inventoryView = await Services.Inventory.GetCurrent();
         
         Debug.Log("inventoryView1: " + inventoryView.currencies.Count);
         
         // If game supports a currency
         if (inventoryView.currencies.Count > 0)
         {
            // Change the amount of currency
            isSuccess = true;
            long amountDelta = 1;
            var firstCurrency = inventoryView.currencies.FirstOrDefault();
           
            Debug.Log("first: " + firstCurrency.Key);
            Debug.Log("first2: " + firstCurrency.Value);
            //    /var amount = await Services.Inventory.GetCurrency(currencyId);

            //        long amountNew = amount + amountDelta;
            //      await Services.Inventory.SetCurrency(currencyId, amountNew);


         }

         return isSuccess;
      }
      
      [ClientCallable]
      public async Task<bool> RemoveCurrency()
      {
         string currencyId = "blah";
         long amountDelta = -1;
         
         var amount = await Services.Inventory.GetCurrency(currencyId);

         long amountNew = amount + amountDelta;
         await Services.Inventory.SetCurrency(currencyId, amountNew);
         
         return true;
      }
   }
}