using System;
using UnityEngine;

namespace MagneticFishing
{
    public class UiGameplayRootBinder : MonoBehaviour
    {
        public event Action GoToMainMenuBuutonClicked;


        public void HandleGoToMenuButtonClick()
        {
            GoToMainMenuBuutonClicked?.Invoke();
        }
    }
}
