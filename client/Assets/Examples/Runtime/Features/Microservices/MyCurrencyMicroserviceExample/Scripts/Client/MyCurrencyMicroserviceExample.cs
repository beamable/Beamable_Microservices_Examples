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
            var activeCurrencyBefore = await _myCurrencyMicroserviceClient.GetActiveCurrency();
            Debug.Log("found1: " + activeCurrencyBefore.Key);

            // #1 - Call Microservice
            bool isSuccess1 = await _myCurrencyMicroserviceClient.AddToActiveCurrency();
            Debug.Log ($"AddToActiveCurrency() isSuccess = {isSuccess1}");
            
            var activeCurrencyDuring = await _myCurrencyMicroserviceClient.GetActiveCurrency();
            Debug.Log("found2: " + activeCurrencyDuring.Key);

            // #2 - Call Microservice
            bool isSuccess2 = await _myCurrencyMicroserviceClient.RemoveFromActiveCurrency();
            Debug.Log ($"RemoveFromActiveCurrency() isSuccess = {isSuccess2}");
            
            var activeCurrencyAfter = await _myCurrencyMicroserviceClient.GetActiveCurrency();
            Debug.Log ($"GetActiveCurrency() activeCurrencyBefore.Value = {activeCurrencyBefore.Value}");
            Debug.Log ($"GetActiveCurrency() activeCurrencyDuring.Value = {activeCurrencyDuring.Value}");
            Debug.Log ($"GetActiveCurrency() activeCurrencyAfter.Value = {activeCurrencyAfter.Key}");
        }
    }
}