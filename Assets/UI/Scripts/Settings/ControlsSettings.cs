using System;
using UnityEngine;

namespace DivisionLike
{
    [CreateAssetMenu(fileName = "ControlSettingsSO", menuName = "Settings/Control Settings", order = int.MaxValue)]
    public class ControlsSettings : ScriptableObject
    {
        [Range(0, 100)]public int mouseSensivity = 10;
        [Range(0, 100)] public int mouseAimSensivity = 30;
        public bool mouseAcceleration = false;
        [Range(0, 100)] public int mouseSmoothing = 5;
    }    
}