using System;
using UnityEngine;
using WanzyeeStudio;

namespace DivisionLike
{
    public class MouseCursor : BaseSingleton<MouseCursor>
    {
        public Texture2D m_TextureCursor;
        
        private void Start()
        {
            Cursor.SetCursor(m_TextureCursor, Vector2.zero, CursorMode.Auto);
        }

        private void OnDisable()
        {
            Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
        }
    }    
}