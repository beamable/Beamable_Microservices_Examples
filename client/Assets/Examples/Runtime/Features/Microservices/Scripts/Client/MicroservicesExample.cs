using UnityEngine;
using Beamable.Server.Clients;

namespace Beamable.Examples.Features.Microservices
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/>.
    /// </summary>
    public class MicroservicesExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
        private MyMicroserviceClient  _myMicroserviceClient;
        
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
            
            _myMicroserviceClient = new MyMicroserviceClient();
            
            // #1 - Call Microservice with (10, 5)
            bool result = await _myMicroserviceClient.AddMyValues(10, 5);
                
            // #2 - "Result:15"
            Debug.Log ($"Result:{result}");
        }
    }
}