using System;
using Beamable.Common.Content;

namespace Beamable.Microservices
{
    [ContentType("my_custom_content")]
    
    public class MyCustomContent : ContentObject
    {
        public MyCustomData MyCustomData = new MyCustomData();
    }
    
    [Serializable]
    public class MyCustomData 
    {
        public int Attack;
        public int Damage;
    }
}