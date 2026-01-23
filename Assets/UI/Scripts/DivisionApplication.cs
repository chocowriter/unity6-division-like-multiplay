using System;
using UnityEngine;


namespace DivisionLike
{
    public class DivisionApplication : MonoBehaviour
    {
        private void Awake()
        {
            Application.targetFrameRate = 60;
            Screen.SetResolution(Screen.currentResolution.width, Screen.currentResolution.height, true);
        }
    }    
}