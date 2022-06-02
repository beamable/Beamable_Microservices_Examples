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
      public async Task<string> GetActiveCurrencyId()
      {
         var inventoryView = await Services.Inventory.GetCurrent();
         
         // If the games content supports a currency ...
         if (inventoryView.currencies.Count > 0)
         {
            // Change the amount of currency
            KeyValuePair<string, long> firstCurrency = inventoryView.currencies.FirstOrDefault();
            return firstCurrency.Key;
         }

         return "";
      }
      
      /// <summary>
      /// Arbitrarily choose the 'first' currency
      /// as the active currency
      /// </summary>
      [ClientCallable]
      public async Task<long> GetActiveCurrencyValue()
      {
         var inventoryView = await Services.Inventory.GetCurrent();
         
         // If the games content supports a currency ...
         if (inventoryView.currencies.Count > 0)
         {
            // Change the amount of currency
            KeyValuePair<string, long> firstCurrency = inventoryView.currencies.FirstOrDefault();
            return firstCurrency.Value;
         }

         return 0;
      }

      [ClientCallable]
      public async Task<bool> AddToActiveCurrency()
      {
         // Add Value
         long amountDelta = 1;
        
         // Change the amount of currency
         bool isSuccess = false;
         string currencyId = await GetActiveCurrencyId();
         long amountOld = await GetActiveCurrencyValue();
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
         string currencyId = await GetActiveCurrencyId();
         long amountOld = await GetActiveCurrencyValue();

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