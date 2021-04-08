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
            Debug.Log("Start()");

            SetupBeamable();
        }
        
        //  Methods  --------------------------------------
        private async void SetupBeamable()
        {
            var beamableAPI = await Beamable.API.Instance;

            Debug.Log($"beamableAPI.User.id = {beamableAPI.User.id}");
            
            _myMicroserviceClient = new MyMicroserviceClient();
            
            // #1 - Call Microservice with (10, 5)
            var result = await _myMicroserviceClient.AddMyValues(10, 5);
                
            // #2 - "Result:15"
            Debug.Log ($"Result:{result}");
        }
    }
}