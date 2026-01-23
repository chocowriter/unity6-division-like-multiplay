using System;
using UnityEditor;
using UnityEngine;

namespace DivisionLike
{
    public class KeyMapping : MonoBehaviour
    {
        public SimpleTooltipStyle m_DynamicTooltipStyle;
        public string m_TooltipText = "";

        private void Start()
        {
            //AddTooltip();
        }

        public void AddTooltip()
        {
            // So first lets check if we already have a tooltip
            var tooltip = GetComponent<Tooltip>();
            if (tooltip)
            {
                tooltip.m_InfoLeft = "You can also change the text after. Remember that ~tags `still !work";

                // Forces to start showing instead of waiting for the mouse to enter the collider
                tooltip.ShowTooltip(); 
            }

            // We don't have a tooltip so lets add a new one!
            else
            {
                tooltip = gameObject.AddComponent<Tooltip>();
                tooltip.m_InfoLeft = m_TooltipText;
                tooltip.ShowTooltip(); // Force

                // If you wish, you may also change the style too, or else it will use the default one
                if (m_DynamicTooltipStyle)
                    tooltip.m_SimpleTooltipStyle = m_DynamicTooltipStyle;
            }
        }
    }    
}