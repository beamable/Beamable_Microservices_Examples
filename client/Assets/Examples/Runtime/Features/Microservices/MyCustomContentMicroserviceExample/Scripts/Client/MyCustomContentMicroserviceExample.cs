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
            var beamContext = BeamContext.Default;
            await beamContext.OnReady;
            
            Debug.Log($"beamContext.PlayerId = {beamContext.PlayerId}");
            
            _myCustomContentMicroserviceClient = new MyCustomContentMicroserviceClient();
            
            // #1 - Call Microservice
            MyCustomData myCustomData = 
                await _myCustomContentMicroserviceClient.LoadCustomData();
                
            // Hardcoded guess. Feel free to update via Content Manager
            bool isSuccess = myCustomData.Attack == 22; 
            
            // #2 - Result 
            Debug.Log ($"LoadCustomData() myCustomData.Attack = {myCustomData.Attack}, Success={isSuccess}");
        }
    }
}