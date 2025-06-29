using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

namespace MagneticFishing
{
    public class AnimsPanel : MonoBehaviour
    {
        [Header("Настройки анимации")]
        [SerializeField] private float durationsAnims = 0.2f;
        [SerializeField] private Ease typeAnimsOnEnable = Ease.Linear;
        [SerializeField] private Ease typeAnimsOnDissable = Ease.Linear;
        [SerializeField] private RectTransform panel;

        [Header("Настройки заднего фона")]
        [SerializeField] private float fadeBackground = 0.7f;
        [SerializeField] private Image backgroundImage;

        private GameObject background;
        private Vector3 originalScale;
        private Tween animsTweenPanel;
        private Tween animsTweenBackground;

        private void Awake()
        {
            originalScale = panel.localScale;
            backgroundImage.color = new Color(backgroundImage.color.r, backgroundImage.color.g, backgroundImage.color.b, 0);
            background = backgroundImage.gameObject;
        }

        [HideInInspector]
        public void Maximize()
        {
            KillAnims();
            panel.localScale = Vector3.zero;
            panel.gameObject.SetActive(true);
            background.SetActive(true);
            animsTweenBackground = backgroundImage.DOFade(fadeBackground, durationsAnims);
            animsTweenPanel = panel.DOScale(originalScale, durationsAnims).SetEase(typeAnimsOnEnable);
        }
        [HideInInspector]
        public void Minimize()
        {
            KillAnims();
            animsTweenBackground = backgroundImage.DOFade(0f, durationsAnims).OnComplete(() => {
                background.SetActive(false);
            });
            animsTweenPanel = panel.DOScale(Vector3.zero, durationsAnims).SetEase(typeAnimsOnDissable).OnComplete(() => {
                panel.gameObject.SetActive(false);
            });
        }

        private void KillAnims()
        {
            if (animsTweenPanel != null) 
                animsTweenPanel.Kill();

            if (animsTweenBackground != null)
                animsTweenBackground.Kill();

        }

        private void OnDestroy()
        {
            KillAnims();
        }
    }
}
