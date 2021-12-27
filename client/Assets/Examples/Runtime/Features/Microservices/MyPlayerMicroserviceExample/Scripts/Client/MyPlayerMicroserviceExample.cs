using UnityEngine;
using Beamable.Server.Clients;

namespace Beamable.Examples.Features.Microservices.MyPlayerMicroserviceExample
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/>.
    /// </summary>
    public class MyPlayerMicroserviceExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
        private MyPlayerMicroserviceClient  _myPlayerMicroserviceClient;
        
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
            
            _myPlayerMicroserviceClient = new MyPlayerMicroserviceClient();
            
            // #1 - Call Microservice
            int result = await _myPlayerMicroserviceClient.GetPlayerLevel();
            bool isSuccess = result == 1; // Hardcoded guess. Feel free to update via Content Manager
                
            // #2 - Result = 1
            Debug.Log ($"GetPlayerLevel() Result = {result}, success={isSuccess}");
        }
    }
}