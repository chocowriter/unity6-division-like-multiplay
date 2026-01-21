using System;
using UnityEngine;

namespace DivisionLike
{
    [CreateAssetMenu(fileName = "AudioSettingsSO", menuName = "Settings/Audio Settings", order = int.MaxValue)]
    public class AudioSettings : ScriptableObject
    {
        [Range(0, 100)] public int masterVolume = 100;
        [Range(0, 100)] public int musicVolume = 100;
        [Range(0, 100)] public int sfxVolume = 100;
        [Range(0, 100)] public int dialogueVolume = 100;
        public bool boostAudio = false;
    }
}