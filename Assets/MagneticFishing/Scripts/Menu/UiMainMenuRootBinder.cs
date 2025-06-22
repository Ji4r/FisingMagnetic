using System;
using UnityEngine;

namespace MagneticFishing
{
    public class UiMainMenuRootBinder : MonoBehaviour
    {
        public event Action GoToGameplayBuutonClicked;

        public void HandleGoToGameplayButtonClick()
        {
            GoToGameplayBuutonClicked?.Invoke();
        }
    }
}
