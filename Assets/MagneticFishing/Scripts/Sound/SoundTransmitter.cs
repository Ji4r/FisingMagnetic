using Unity.VisualScripting;
using UnityEngine;

namespace MagneticFishing
{
    public class SoundTransmitter : MonoBehaviour
    {
        public static SoundTransmitter instance;

        private AudioSource audioSource;

        private void Awake()
        {
            if (instance == null)
                instance = this;
            else
                Destroy(this);

            audioSource = GetComponent<AudioSource>();
        }

        public void PlayClip(ListSound soundType, float value = 1f)
        {
            audioSource.PlayOneShot(GetClip(soundType), value);
        }

        private AudioClip GetClip(ListSound soundType)
        {
            foreach (var soundAudioClip in SoundList.instance.soundAudioSource)
            {
                if (soundAudioClip.sound == soundType)
                    return soundAudioClip.audioClip;
            }
            Debug.Log("Sound " + soundType + "not found!");
            return null;
        }
    }
}
