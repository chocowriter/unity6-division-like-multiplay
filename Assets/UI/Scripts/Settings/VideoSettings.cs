using System;
using UnityEngine;

namespace DivisionLike
{
    [Serializable]
    public class VideoSettings
    {
        public enum EWindowedMode
        {
            FullScreen = 0,
            Windowed,
            WindowedAndFullScreen
        }

        public enum EResolution
        {
            X1024x768 = 0,
            X1152x864,
            X1280x728,
            X1280x800,
            X1280x960,
            X1280x1024,
            X1360x768,
            X1366x768,
            X1440x1080,
            X1600x900,
            X1600x1024,
            X1680x1050,
            X1920x1080
        }

        public enum ERefreshRate
        {
            R60 = 0,
            R75
        }
        
        
        
        public EWindowedMode windowedMode = EWindowedMode.FullScreen;
        public EResolution resolution = EResolution.X1024x768;
        public ERefreshRate refreshRate = ERefreshRate.R60;
        public bool reducedLatency = false;
        public bool HDR = false;

    }
}