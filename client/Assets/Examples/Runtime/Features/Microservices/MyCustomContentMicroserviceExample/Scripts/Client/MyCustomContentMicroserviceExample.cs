using Beamable.Server.Clients;
using Examples.MyCustomContentMicroserviceExample.Shared.MyCustomContent;
using UnityEngine;

namespace Beamable.Examples.Features.Microservices.MyCustomContentMicroserviceExample
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/>.
    /// </summary>
    public class MyCustomContentMicroserviceExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
       private MyCustomContentMicroserviceClient  _myCustomContentMicroserviceClient;
        
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
            
            _myCustomContentMicroserviceClient = new MyCustomContentMicroserviceClient();
            
            // #1 - Call Microservice
            MyCustomContent myCustomContent = null;
            MyCustomData myCustomData = await _myCustomContentMicroserviceClient.LoadCustomData();
                
            // #2 - Result = 1
            Debug.Log ($"GetPlayerLevel() myCustomContent = {myCustomContent}");
        }
    }
}