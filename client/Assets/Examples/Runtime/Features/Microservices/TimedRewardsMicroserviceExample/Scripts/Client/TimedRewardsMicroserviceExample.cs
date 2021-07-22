using UnityEngine;
using Beamable.Server.Clients;

namespace Beamable.Examples.Features.Microservices.TimedRewardsMicroserviceExample
{
    /// <summary>
    /// Demonstrates <see cref="Microservices"/>.
    /// </summary>
    public class TimedRewardsMicroserviceExample : MonoBehaviour
    {
        //  Properties  -----------------------------------
        
        //  Fields  ---------------------------------------
        [SerializeField] 
        private TimeRewardRef _timeRewardRef = null;
        
        private TimedRewardServiceClient  _timedRewardServiceClient;
        
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
            
            _timedRewardServiceClient = new TimedRewardServiceClient();
            
            // #1 - Call Microservice
            bool isSuccess = await _timedRewardServiceClient.Claim(_timeRewardRef);
                
            // #2 - Result = true
            Debug.Log ($"AddMyValues() isSuccess = {isSuccess}");
        }
    }
}