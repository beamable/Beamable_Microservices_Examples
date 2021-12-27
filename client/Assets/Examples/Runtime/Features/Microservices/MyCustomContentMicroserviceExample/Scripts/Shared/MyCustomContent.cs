using System;
using Beamable.Common.Content;

namespace Examples.MyCustomContentMicroserviceExample.Shared.MyCustomContent
{
    [ContentType("my_custom_content")]
    public class MyCustomContent : ContentObject
    {
        public MyCustomData MyCustomData = new MyCustomData();
    }
    
    [Serializable]
    public class MyCustomData : System.Object
    {
        public string Attack;
        public string Damage;
    }
}