using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace MagneticFishing
{
    public class UIViewMenu : MonoBehaviour
    {
        [SerializeField] private float speedAnimations;
        [SerializeField] private Button[] buttons;
        [SerializeField] private TextMeshProUGUI textCoins;
        [SerializeField] private TextMeshProUGUI textItemsInBackpack;

        private PresenterMenu presenter;

        private void Start()
        {
            var service = FindObjectOfType<ServiceSave>().Locator;
            var settings = FindObjectOfType<SettingsGame>();

            presenter = new PresenterMenu(new ModelMenu(), this, service);
        }

        public void UpdateUI(int coins, int items)
        {
            textCoins.text = coins.ToString();
            textItemsInBackpack.text = items.ToString();
        }

        public void ButtonOpenPanel(GameObject panel)
        {
            panel.SetActive(true);
            StartCoroutine(AnimsActiveButton(false));
        }

        public void ButtonClosePanel(GameObject panel)
        {
            panel.SetActive(false);
            StartCoroutine(AnimsActiveButton(true));
        }

        private IEnumerator AnimsActiveButton(bool setActive)
        {
            foreach (var button in buttons)
            {
                button.enabled = setActive;

            }

            foreach (var button in buttons)
            {
                button.interactable = setActive;
                yield return new WaitForSeconds(speedAnimations);
            }
        } 
    }
}
