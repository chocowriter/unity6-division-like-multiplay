using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace DivisionLike
{
    /// <summary>
    /// 툴팁을 보여줄 대상
    /// </summary>
    [DisallowMultipleComponent]
    public class Tooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
    {
        public SimpleTooltipStyle m_SimpleTooltipStyle;
        public GameObject m_PrefabTooltip;
        [TextArea] public string m_InfoLeft = "Left";
        [TextArea] public string m_InfoRight = "Right";
        [TextArea] public string m_InfoCenter = "Center";
        private TooltipController m_TooltipController;
        private EventSystem m_EventSystem;
        private bool m_CursorInside = false;
        private bool m_IsUIObject = false;
        private bool m_Showing = false;

        private void Awake()
        {
            m_EventSystem = FindFirstObjectByType<EventSystem>();
            m_TooltipController = FindFirstObjectByType<TooltipController>();

            if (!m_TooltipController)
            {
                m_TooltipController = AddTooltipPrefabToScene();
            }
            if (!m_TooltipController)
            {
                Debug.LogWarning("Could not find the Tooltip prefab");
                Debug.LogWarning("Make sure you don't have any other prefabs named `Tooltip`");
            }

            if (GetComponent<RectTransform>())
                m_IsUIObject = true;

            if (!m_SimpleTooltipStyle)
                m_SimpleTooltipStyle = Resources.Load<SimpleTooltipStyle>("TooltipTheme/Light");
        }

        private void Update()
        {
            if (!m_CursorInside)
                return;

            m_TooltipController.ShowTooltip();
        }

        public TooltipController AddTooltipPrefabToScene()
        {
            return Instantiate(m_PrefabTooltip.transform.GetComponentInChildren<TooltipController>());
        }

        private void OnMouseOver()
        {
            if (m_IsUIObject)
                return;

            if (m_EventSystem)
            {
                if (m_EventSystem.IsPointerOverGameObject())
                {
                    HideTooltip();
                    return;
                }
            }
            ShowTooltip();
        }

        private void OnMouseExit()
        {
            if (m_IsUIObject)
                return;
            HideTooltip();
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!m_IsUIObject)
                return;
            ShowTooltip();
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!m_IsUIObject)
                return;
            HideTooltip();
        }

        public void ShowTooltip()
        {
            m_Showing = true;
            m_CursorInside = true;

            m_TooltipController.SetCustomStyledText(m_InfoLeft, m_SimpleTooltipStyle, TooltipController.TextAlign.Left);
            m_TooltipController.SetCustomStyledText(m_InfoRight, m_SimpleTooltipStyle, TooltipController.TextAlign.Right);
            m_TooltipController.SetCustomStyledText(m_InfoCenter, m_SimpleTooltipStyle, TooltipController.TextAlign.Center);

            m_TooltipController.ShowTooltip();
        }

        public void HideTooltip()
        {
            if (!m_Showing)
                return;
            m_Showing = false;
            m_CursorInside = false;
            m_TooltipController.HideTooltip();
        }

        private void Reset()
        {
            if (!m_SimpleTooltipStyle)
                m_SimpleTooltipStyle = Resources.Load<SimpleTooltipStyle>("TooltipTheme/Light");

            if (GetComponent<RectTransform>())
                return;

            if (GetComponent<Collider>())
                return;

            gameObject.AddComponent<BoxCollider>();
        }
    }
}