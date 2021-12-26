using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

namespace Beamable.Server
{
   [Microservice("MyCurrencyMicroservice")]
   public class MyCurrencyMicroservice : Microservice
   {
      /// <summary>
      /// Arbitrarily choose the 'first' currency
      /// as the active currency
      /// </summary>
      [ClientCallable]
      public async Task<KeyValuePair<string, long>> GetActiveCurrency()
      {
         var inventoryView = await Services.Inventory.GetCurrent();
         
         // If the games content supports a currency ...
         if (inventoryView.currencies.Count > 0)
         {
            // Change the amount of currency
            KeyValuePair<string, long> firstCurrency = inventoryView.currencies.FirstOrDefault();
            Debug.Log("Returning: " + firstCurrency.Key + " with " + firstCurrency.Value);
            return firstCurrency;
         }

         Debug.Log("FAILING");
         return new KeyValuePair<string, long>();
      }

      [ClientCallable]
      public async Task<bool> AddToActiveCurrency()
      {
         // Add Value
         long amountDelta = 1;
        
         // Change the amount of currency
         bool isSuccess = false;
         var activeCurrency = await GetActiveCurrency();
         string currencyId = activeCurrency.Key;
         long amountOld = activeCurrency.Value;
         Debug.Log("about to add: " + currencyId + " and " + amountOld);

         if (!string.IsNullOrEmpty(currencyId))
         {
            long amountNew = amountOld + amountDelta;
            await Services.Inventory.SetCurrency(currencyId, amountNew);

            // Validate
            long amountConfirmed = await Services.Inventory.GetCurrency(currencyId);
            isSuccess = amountConfirmed == amountNew;
         }

         return isSuccess;
      }
      
      [ClientCallable]
      public async Task<bool> RemoveFromActiveCurrency()
      {
         // Remove Value
         long amountDelta = -1;

         // Change the amount of currency
         bool isSuccess = false;
         var activeCurrency = await GetActiveCurrency();
         string currencyId = activeCurrency.Key;
         long amountOld = activeCurrency.Value;

         if (!string.IsNullOrEmpty(currencyId))
         {
            long amountNew = amountOld + amountDelta;
            await Services.Inventory.SetCurrency(currencyId, amountNew);

            // Validate
            long amountConfirmed = await Services.Inventory.GetCurrency(currencyId);
            isSuccess = amountConfirmed == amountNew;
         }

         return isSuccess;
      }
   }
}