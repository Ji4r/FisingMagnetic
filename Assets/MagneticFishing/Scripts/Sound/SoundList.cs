using UnityEngine;

namespace MagneticFishing
{
    public enum ListSound
    {
        buttonClickMenu,
        buttonPointerMenu, 
        buttonMenu3, 
        buttonMenu4,
    }


    public class SoundList : MonoBehaviour
    {
        public static SoundList instance;

        public SoundAudioClip[] soundAudioSource;

        [System.Serializable]
        public class SoundAudioClip
        {
            public ListSound sound;
            public AudioClip audioClip;
        }

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);
        }
    }
}
