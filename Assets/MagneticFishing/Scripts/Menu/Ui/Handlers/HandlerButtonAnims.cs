using UnityEngine;
using UnityEngine.EventSystems;

namespace MagneticFishing
{
    [RequireComponent(typeof(ButtonAnims))]
    public class HandlerButtonAnims : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerDownHandler, IPointerUpHandler
    {
        private ButtonAnims buttonAnims;

        private void Start()
        {
           buttonAnims = GetComponent<ButtonAnims>();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            buttonAnims.ClickDown();
            SoundTransmitter.instance.PlayClip(ListSound.buttonClickMenu);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
           buttonAnims.PointerEnter();
           SoundTransmitter.instance.PlayClip(ListSound.buttonPointerMenu);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
           buttonAnims.PointerExit();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            buttonAnims.ClickUp();
        }  
    }
}
