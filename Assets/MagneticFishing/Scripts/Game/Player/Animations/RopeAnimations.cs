using UnityEngine;
using UnityEngine.UI;

namespace MagneticFishing
{
    public class RopeAnimations : MonoBehaviour
    {
        [SerializeField] private Image rope;
        [SerializeField] private MagneticController magneticController;

        private void Awake()
        {
            rope = GameObject.FindWithTag("Rope").GetComponent<Image>();
        }

        private void OnEnable()
        {
            EventBusGame.StartCasting += CastingRope;
        }

        private void OnDisable()
        {
            EventBusGame.StartCasting -= CastingRope;
        }

        private void CastingRope(Vector3 pointClick)
        {
            magneticController.EndCastingRope(pointClick);
            EventBusGame.EndCasting?.Invoke(pointClick);
        }
    }
}
