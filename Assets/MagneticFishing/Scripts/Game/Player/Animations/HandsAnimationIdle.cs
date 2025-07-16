using UnityEngine;
using UnityEngine.UI;

namespace MagneticFishing
{
    public class HandsAnimationIdle : MonoBehaviour
    {
        [SerializeField] private Transform hands;
        [SerializeField] private Image sprite; 
        [SerializeField] private float shakeSpeed = 2f; // Скорость колебаний
        [SerializeField] private float minOffset = -4f; // Минимальное положение
        [SerializeField] private float maxOffset = 9f;  // Максимальное положение
        [SerializeField] private bool shakeX = true;   
        [SerializeField] private bool shakeY = false;
        private Vector3 handsStartPosition;

        private void Start()
        {
            handsStartPosition = hands.position;   
        }

        private void OnEnable()
        {
            EventBusGame.StartCasting += StartCasting;
            EventBusGame.EndAttraction += EndCasting;
            sprite.enabled = true;
        }

        private void OnDisable()
        {
            EventBusGame.StartCasting -= StartCasting;
            EventBusGame.EndAttraction -= EndCasting;
            sprite.enabled = false;
        }

        private void Update()
        {
            if (sprite.isActiveAndEnabled)
                ShakingHands();   
        }

        private void ShakingHands()
        {
            float sinValue = Mathf.Sin(Time.time * shakeSpeed);
            float offsetValue = Mathf.Lerp(minOffset, maxOffset, (sinValue + 1f) / 2f);

            Vector3 newOffset = Vector3.zero;
            if (shakeX) newOffset.x = offsetValue;
            if (shakeY) newOffset.y = offsetValue;

            hands.position = handsStartPosition + newOffset;
        }

        private void StartCasting(Vector3 vector)
        { 
            sprite.enabled = false;
        }

        private void EndCasting()
        {
            sprite.enabled = true;
        }
    }
}
