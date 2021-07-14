using UnityEngine;
using Beamable.Server.Clients;

namespace Beamable.Examples.Features.Microservices
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/> including
    /// a method with [ClientCallable] and [AdminOnlyCallable].
    ///
    /// NOTE: This is an intermediate example and a good
    /// example to see after learning from
    /// <see cref="MyMathMicroserviceExample"/>.
    /// 
    /// </summary>
    public class MyPlayerLevelMicroserviceExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
        private MyPlayerLevelMicroserviceClient  _myPlayerLevelMicroserviceClient;
        
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
            
            _myPlayerLevelMicroserviceClient = new MyPlayerLevelMicroserviceClient();
            
            // #1 - Call Microservice
            int playerLevel = await _myPlayerLevelMicroserviceClient.GetPlayerLevel();
                
            // #2 - Result = 1
            Debug.Log ($"GetPlayerLevel() Result = {playerLevel}");
        }
    }
}