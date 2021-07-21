using UnityEngine;
using Beamable.Server.Clients;

namespace Beamable.Examples.Features.Microservices.MyADBMicroserviceExample
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/>.
    /// </summary>
    public class MyADBMicroserviceExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
        private MyADBMicroserviceClient  _myAdbMicroserviceClient;
        
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
            
            _myAdbMicroserviceClient = new MyADBMicroserviceClient();
            
            // #1 - Call Microservice
            bool isSuccess = await _myAdbMicroserviceClient.ConnectToDatabase();
                
            // #2 - IsSuccess = true
            Debug.Log ($"GetPlayerLevel() IsSuccess = {isSuccess}");
        }
    }
}