using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace DivisionLike
{
    public class TooltipController : MonoBehaviour
    {
        public enum TextAlign
        {
            Left = 0,
            Right,
            Center
        };

        private Image m_Panel;
        private TextMeshProUGUI m_ToolTipTextLeft;
        private TextMeshProUGUI m_ToolTipTextRight;
        private TextMeshProUGUI m_ToolTipTextCenter;
        private RectTransform m_Rect;
        private int m_ShowInFrames = -1;
        private bool m_ShowNow = false;
        
        private void Awake()
        {
            var tmps = GetComponentsInChildren<TextMeshProUGUI>();
            for(int i = 0; i < tmps.Length; i++)
            {
                if (tmps[i].name == "Text_Left")
                    m_ToolTipTextLeft = tmps[i];

                if (tmps[i].name == "Text_Right")
                    m_ToolTipTextRight = tmps[i];
                
                if (tmps[i].name == "Text_Center")
                    m_ToolTipTextCenter = tmps[i];
            }

            // Keep a reference for the panel image and transform
            m_Panel = GetComponent<Image>();
            m_Rect = GetComponent<RectTransform>();

            // Hide at the start
            HideTooltip();
        }

        void Update()
        {
            ResizeToMatchText();
            UpdateShow();
        }

        private void ResizeToMatchText()
        {
            // Find the biggest height between both text layers
            var bounds = m_ToolTipTextLeft.textBounds;
            float biggestY = m_ToolTipTextLeft.textBounds.size.y;
            float rightY = m_ToolTipTextRight.textBounds.size.y;
            if (rightY > biggestY)
                biggestY = rightY;

            // Dont forget to add the margins
            var margins = m_ToolTipTextLeft.margin.y * 2;

            // Update the height of the tooltip panel
            m_Rect.sizeDelta = new Vector2(m_Rect.sizeDelta.x, biggestY + margins);
        }

        private void UpdateShow()
        {
            if (m_ShowInFrames == -1)
                return;

            if (m_ShowInFrames == 0)
                m_ShowNow = true;

            if (m_ShowNow == true)
            {
                m_Rect.anchoredPosition = Input.mousePosition;
            }

            m_ShowInFrames -= 1;
        }

        public void SetRawText(string text, TextAlign align = TextAlign.Left)
        {
            // Doesn't change style, just the text
            if(align == TextAlign.Left)
                m_ToolTipTextLeft.text = text;
            if (align == TextAlign.Right)
                m_ToolTipTextRight.text = text;
            if (align == TextAlign.Center)
                m_ToolTipTextCenter.text = text;
            
            ResizeToMatchText();
        }

        public void SetCustomStyledText(string text, SimpleTooltipStyle style, TextAlign align = TextAlign.Left)
        {
            // Update the panel sprite and color
            m_Panel.sprite = style.slicedSprite;
            m_Panel.color = style.color;

            // Update the font asset, size and default color
            m_ToolTipTextLeft.font = style.fontAsset;
            m_ToolTipTextLeft.color = style.defaultColor;
            m_ToolTipTextRight.font = style.fontAsset;
            m_ToolTipTextRight.color = style.defaultColor;
            m_ToolTipTextCenter.font = style.fontAsset;
            m_ToolTipTextCenter.color = style.defaultColor;

            // Convert all tags to TMPro markup
            var styles = style.fontStyles;
            for(int i = 0; i < styles.Length; i++)
            {
                string addTags = "</b></i></u></s>";
                addTags += "<color=#" + ColorToHex(styles[i].color) + ">";
                if (styles[i].bold) addTags += "<b>";
                if (styles[i].italic) addTags += "<i>";
                if (styles[i].underline) addTags += "<u>";
                if (styles[i].strikethrough) addTags += "<s>";
                text = text.Replace(styles[i].tag, addTags);
            }
            if (align == TextAlign.Left)
                m_ToolTipTextLeft.text = text;
            if (align == TextAlign.Right)
                m_ToolTipTextRight.text = text;
            if (align == TextAlign.Center)
                m_ToolTipTextCenter.text = text;
            
            ResizeToMatchText();
        }

        public string ColorToHex(Color color)
        {
            int r = (int)(color.r * 255);
            int g = (int)(color.g * 255);
            int b = (int)(color.b * 255);
            return r.ToString("X2") + g.ToString("X2") + b.ToString("X2");
        }

        public void ShowTooltip()
        {
            // After 2 frames, showNow will be set to TRUE
            // after that the frame count wont matter
            if (m_ShowInFrames == -1)
                m_ShowInFrames = 2;
        }

        public void HideTooltip()
        {
            m_ShowInFrames = -1;
            m_ShowNow = false;
            m_Rect.anchoredPosition = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        }
    }
}