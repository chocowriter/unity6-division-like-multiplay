using System;
using UnityEngine;

namespace DivisionLike
{
    [Serializable]
    public class GraphicsSettings
    {
        public enum EQuality
        {
            Low = 0,
            Medium,
            High,
            Ultra,
            Custom
        }
        
        public EQuality quality = EQuality.High;
        [Range(0, 20)] public int brightness = 10;
        [Range(0, 20)] public int contrast = 10;
        public bool vSync = true;
        public bool frameRateLimit = false;
        [Range(20, 200)] public int customFrameRate = 60;
        public 
    }
}
