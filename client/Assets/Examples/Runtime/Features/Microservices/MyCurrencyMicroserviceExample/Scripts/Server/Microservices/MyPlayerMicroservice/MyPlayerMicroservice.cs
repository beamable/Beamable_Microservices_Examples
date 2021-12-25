using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Beamable.Server;

namespace Beamable.Examples.Features.Microservices.MyPlayerMicroserviceExample
{
   [Microservice("MyPlayerMicroservice")]
   public class MyPlayerMicroservice : Microservice
   {
      private const string PlayerLevelKey = "PLAYER_LEVEL";
      private const int PlayerLevelDefaultValue = 1;
      
      /// <summary>
      /// Get the current user's progression level
      /// </summary>
      /// <returns>Returns the current value of playerLevel</returns>
      [ClientCallable]
      public async Task<int> GetPlayerLevel()
      {
         long dbid = Context.UserId;
         string access = "public";
         string domain = "client";
         string type = "player";
         
         Dictionary<string, string> getStats = await Services.Stats.GetStats(domain, access, type, dbid);

         // Return value, if it was present
         if (getStats.ContainsKey(PlayerLevelKey))
         {
            return Int32.Parse(getStats[PlayerLevelKey]);
         }
         
         // Set, then get value, if it was not present
         await SetPlayerLevel(PlayerLevelDefaultValue);
         return await GetPlayerLevel();
      }
      
      /// <summary>
      /// Set the current user's progression level
      /// </summary>
      /// <param name="playerLevel">The new value of playerLevel</param>
      /// <returns>Returns success</returns>
      [AdminOnlyCallable]
      public async Task<bool> SetPlayerLevel(int playerLevel)
      {
         // Validate parameters, if needed
         if (playerLevel < 0)
         {
            return false;
         }
         
         string access = "public";
         Dictionary<string, string> setStats = 
            new Dictionary<string, string>() { { PlayerLevelKey, playerLevel.ToString() } };

         await Services.Stats.SetStats(access, setStats);

         return true;
      }
   }
}