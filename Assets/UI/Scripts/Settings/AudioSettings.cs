using System;
using UnityEngine;

namespace DivisionLike
{
    [Serializable]
    public class AudioSettings
    {
        public int masterVolume = 100;
        public int musicVolume = 100;
        public int sfxVolume = 100;
        public int dialogueVolume = 100;
        public bool boostAudio = false;
    }    
}