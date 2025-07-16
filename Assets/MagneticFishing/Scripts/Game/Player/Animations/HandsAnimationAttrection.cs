using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace MagneticFishing
{
    public class HandsAnimationAttrection : MonoBehaviour
    {
        [Header("Transform")]
        [SerializeField] private RectTransform fullObject;
        [SerializeField] private RectTransform leftHandTransform;
        [SerializeField] private RectTransform rightHandTransform;
        [Header("Image")]
        [SerializeField] private Image leftHandSprite;
        [SerializeField] private Image rightHandSprite;
        [Header("ѕараметры анимации по€влени€/затухани€")]
        [SerializeField] private float speedAnins;
        [SerializeField] private float positionHandsOnY = 100;
        [SerializeField] private float durationAppearanceOfHands = 0.5f;
        [Header("ѕараметры анимации ст€гивани€")]
        [SerializeField] private float turnDownPositionOnYHands = 100f;
        [SerializeField] private float addPositionOnYHands = 100f;

        private float minPositionOnYRightHand;
        private float maxPositionOnYRightHand;
        private float minPositionOnYLeftHand;
        private float maxPositionOnYLeftHand;
        private bool moveIsUpLeftHands;
        private bool moveIsUpRightHands;

        private void OnEnable()
        {
            maxPositionOnYLeftHand = leftHandTransform.localPosition.y + addPositionOnYHands;
            minPositionOnYLeftHand = leftHandTransform.localPosition.y - turnDownPositionOnYHands;

            maxPositionOnYRightHand = rightHandTransform.localPosition.y + addPositionOnYHands;
            minPositionOnYRightHand = rightHandTransform.localPosition.y - turnDownPositionOnYHands;

            moveIsUpLeftHands = false;
            moveIsUpRightHands = true;

            EventBusGame.EndCasting += EnableSprite;
            EventBusGame.EndAttraction += DissableSprite;
            EventBusGame.AnimationOfAttraction += AnimationOfAttraction;
        }

        private void OnDisable()
        {
            EventBusGame.EndCasting -= EnableSprite;
            EventBusGame.EndAttraction -= DissableSprite;
            EventBusGame.AnimationOfAttraction -= AnimationOfAttraction;
        }

        private void EnableSprite(Vector3 position)
        {
            leftHandSprite.enabled = true;
            rightHandSprite.enabled = true;

            Vector3 pos = new Vector3(position.x, -100, fullObject.position.z);
            fullObject.position = pos;
            AppearanceOfHands(ref pos);
        }

        private void DissableSprite()
        {
            leftHandSprite.enabled = false;
            rightHandSprite.enabled = false;
        }

        private void AppearanceOfHands(ref Vector3 position)
        {
            position.y = positionHandsOnY;
            fullObject.DOMove(position, durationAppearanceOfHands);
        }

        private void AnimationOfAttraction()
        {
            AnimateHand(leftHandTransform, ref moveIsUpLeftHands, minPositionOnYLeftHand, maxPositionOnYLeftHand);
            AnimateHand(rightHandTransform, ref moveIsUpRightHands, minPositionOnYRightHand, maxPositionOnYRightHand);
        }

        private void AnimateHand(RectTransform hand, ref bool isMovingUp, float minY, float maxY)
        {
            float direction = isMovingUp ? 1 : -1;
            float newY = hand.localPosition.y + (speedAnins * Time.deltaTime * direction);

            if ((direction > 0 && newY >= maxY) || (direction < 0 && newY <= minY))
            {
                isMovingUp = !isMovingUp;
                newY = Mathf.Clamp(newY, minY, maxY);
            }

            hand.localPosition = new Vector3(hand.localPosition.x, newY, hand.localPosition.z);
        }
    }
}
