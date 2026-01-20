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
            Ultra
        }
        
        public EQuality graphicQuality = EQuality.High;
        [Range(0, 20)] public int brightness = 10;
        [Range(0, 20)] public int contrast = 10;
        public bool vSync = true;
        public bool frameRateLimit = false;
        [Range(20, 200)] public int customFrameRate = 60;
        public EQuality shadowQuality = EQuality.High;
        public EQuality particleDetail = EQuality.High;
        public EQuality volumeDetail = EQuality.High;
        
    }
}
