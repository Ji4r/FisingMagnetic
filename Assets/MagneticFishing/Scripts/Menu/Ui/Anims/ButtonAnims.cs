using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MagneticFishing
{
    public class ButtonAnims : MonoBehaviour
    {
        [SerializeField] private float durationAnims = 0.2f;
        [SerializeField, Range(0f, 1f),
            Tooltip("Увеличивать размер кнопки на")]
        float sizeOnClick = 0.1f;
        [SerializeField, Range(0f, 1f),
    Tooltip("Увеличивать размер кнопки на")]
        float sizeForPointer = 0.16f;
        [SerializeField] private Color colorOnClick;

        private Color baseColor;
        private Transform tButton;
        private Button bButton;
        private Vector3 baseSize;
        private Tween animationsScale;

        private void Awake()
        {
            tButton = GetComponent<Transform>();
            baseSize = tButton.localScale;
            baseColor = colorOnClick;
        }

        public void ClickDown()
        {
            if (animationsScale == null)
                StopAnimations(animationsScale);
            float newSize = (sizeOnClick * baseSize.x);
            var newSizeVector = tButton.localScale - new Vector3(newSize, newSize, newSize);

            animationsScale = tButton.DOScale(newSizeVector, durationAnims);
        }

        public void PointerEnter()
        {
            if (animationsScale == null)
                StopAnimations(animationsScale);
            float newSize = (sizeForPointer * baseSize.x);
            var newSizeVector = new Vector3(newSize, newSize, newSize) + tButton.localScale;
            animationsScale = tButton.DOScale(newSizeVector, durationAnims);
        }

        public void PointerExit()
        {
            if (animationsScale == null)
                StopAnimations(animationsScale);

            animationsScale = tButton.DOScale(baseSize, durationAnims);
        }

        public void ClickUp()
        {
            if (animationsScale == null)
                StopAnimations(animationsScale);
            animationsScale = tButton.DOScale(baseSize, durationAnims);
        }

        private void StopAnimations(Tween animations)
        {
            animations.Kill();
        }
    }
}
