using UnityEngine;

namespace MagneticFishing
{
    [System.Serializable]
    public class DataSettings : IService
    {
        public Language language;
        public float volumeSong;
        public float volumeSound;


        public DataSettings()
        {
            language = Language.Ru;
            volumeSong = 1.0f;
            volumeSound = 1.0f;
        }

        public DataSettings(Language _language, float _volumeSong = 1f, float _volumeSound = 1f)
        {
            language = _language;
            volumeSong = _volumeSong;
            volumeSound = _volumeSound;
        }
    }
}
