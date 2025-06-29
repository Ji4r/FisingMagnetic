using UnityEngine;

namespace MagneticFishing
{
    [RequireComponent(typeof(AnimsPanel))]
    public class HandlerPanelAnims : MonoBehaviour
    {
        AnimsPanel animsPanel;

        private void Start()
        {
            animsPanel = GetComponent<AnimsPanel>();
        }

        public void TogglePanel(bool show)
        {
            if (show) 
                animsPanel.Maximize();
            else
                animsPanel.Minimize();
        }
    }
}
