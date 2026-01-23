using System;
using UnityEngine;
using WanzyeeStudio;
using TMPro;

namespace DivsionLike
{
    public class Tooltip : BaseSingleton<Tooltip>
    {
        [SerializeField] private TextMeshProUGUI m_Text;

        protected override void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            
        }
    }    
}