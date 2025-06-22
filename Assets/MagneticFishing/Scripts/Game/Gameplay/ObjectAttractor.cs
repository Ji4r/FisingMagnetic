using UnityEngine;

namespace MagneticFishing
{
    public class ObjectAttractor : MonoBehaviour
    {
        [SerializeField] private UiViewGame uiView;
        [SerializeField] private ScreenLoot screenLoot;
        [SerializeField] private Transform positionObjectAttractor;
        [SerializeField] private float speedAttractor;

        public Transform ottudovaPull { get; set; }

        private bool isButtonPressed;

        private void Awake()
        {
            this.enabled = false;
        }

        private void OnEnable()
        {
            if (ottudovaPull == null)
            {
                uiView.SetDistanceTextZero();
                return;
            }

            uiView.SetDistanceText(positionObjectAttractor.position, ottudovaPull.position);
        }

        private void Update()
        {
            if (Input.GetKey(KeyCode.Space) || isButtonPressed)
            {
                Attenshion();
            }
        }

        private void Attenshion()
        {
            if (Vector3.Distance(positionObjectAttractor.position, ottudovaPull.position) == 0)
            {
                ottudovaPull.gameObject.SetActive(false);
                EventBusGame.AttractedAMagnet?.Invoke(false);
                screenLoot.SetActivePanel();
                return;
            }

            ottudovaPull.position = Vector2.MoveTowards(ottudovaPull.position, positionObjectAttractor.position, speedAttractor * Time.deltaTime);
            uiView.SetDistanceText(positionObjectAttractor.position, ottudovaPull.position);
        }

        public void OnButtonClick()
        {
            isButtonPressed = true;
        }

        public void OnButtonRelease()
        {
            isButtonPressed = false;
        }
    }
}
