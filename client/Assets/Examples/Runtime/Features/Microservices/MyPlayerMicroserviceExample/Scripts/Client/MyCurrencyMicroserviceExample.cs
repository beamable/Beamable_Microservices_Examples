using UnityEngine;
using Beamable.Server.Clients;

namespace Beamable.Examples.Features.Microservices.MyCurrencyMicroserviceExample
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/>.
    /// </summary>
    public class MyCurrencyMicroserviceExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
        private MyCurrencyMicroserviceClient  _myCurrencyMicroserviceClient;
        
        //  Unity Methods  --------------------------------

        protected void Start()
        {
            Debug.Log("Start() Instructions...\n" + 
            "* Complete docker setup per https://docs.beamable.com/docs/microservices-feature\n" +
            "* Start the server per https://docs.beamable.com/docs/microservices-feature\n" +
            "* Play This Scene\n" + 
            "* Enjoy!\n\n\n");
            
            SetupBeamable();
        }
        
        //  Methods  --------------------------------------
        private async void SetupBeamable()
        {
            var beamableAPI = await Beamable.API.Instance;

            Debug.Log($"beamableAPI.User.id = {beamableAPI.User.id}");
            
            _myCurrencyMicroserviceClient = new MyCurrencyMicroserviceClient();
            
            // #1 - Call Microservice
            bool isSuccess = await _myCurrencyMicroserviceClient.AddCurrency();
                
            // #2 - Result = 1
            //Debug.Log ($"GetPlayerLevel() Result = {playerLevel}");
        }
    }
}