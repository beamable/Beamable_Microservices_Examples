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
            
            // #1a - Call Microservice with (10, 5)
            int myValues = await _myMicroserviceClient.AddMyValues(10, 5);
                
            // #1b - Result:15
            Debug.Log ($"AddMyValues() Result = {myValues}");
            
            // #2a - Call Microservice
            int playerLevel = await _myMicroserviceClient.GetPlayerLevel();
                
            // #3b - Result:1
            Debug.Log ($"GetPlayerLevel() Result = {playerLevel}");
        }
    }
}