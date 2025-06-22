using UnityEngine;
using UnityEngine.Localization;
using UnityEngine.Localization.Settings;
using System.Collections;
using System.Collections.Generic;

namespace MagneticFishing
{
    public enum Language{
        Ru, Eu, Kz, Tr
    }

    public class GameLocalization : MonoBehaviour
    {
        public enum Language { Ru, Eu, Kz, Tr }

        private readonly Dictionary<Language, string> languageCodes = new Dictionary<Language, string>
        {
        { Language.Ru, "ru" },
        { Language.Eu, "en" },
        { Language.Kz, "kk" },
        { Language.Tr, "tr" }
        };

        private void Start()
        {
            InitializeLanguage();
        }

        private void InitializeLanguage()
        {
            Language defaultLang = GetSystemLanguage();
            Language savedLang = (Language)PlayerPrefs.GetInt("GameLanguage", (int)defaultLang);

            SetLanguage(savedLang);
        }

        public void SetLanguage(Language language)
        {
            if (!languageCodes.ContainsKey(language)) return;

            StartCoroutine(ChangeLanguageCoroutine(language));
        }

        private IEnumerator ChangeLanguageCoroutine(Language language)
        {
            yield return LocalizationSettings.InitializationOperation;

            string localeCode = languageCodes[language];
            var locale = LocalizationSettings.AvailableLocales.Locales
                .Find(l => l.Identifier.Code == localeCode);

            if (locale != null)
            {
                LocalizationSettings.SelectedLocale = locale;
                PlayerPrefs.SetInt("GameLanguage", (int)language);
                Debug.Log($"Language changed to {language} ({localeCode})");
            }
        }

        private Language GetSystemLanguage()
        {
            SystemLanguage systemLang = Application.systemLanguage;

            switch (systemLang)
            {
                case SystemLanguage.Russian: return Language.Ru;
                //case SystemLanguage.Kazakh: return Language.Kz;
                case SystemLanguage.Turkish: return Language.Tr;
                default: return Language.Eu; // Все остальные случаи - английский
            }
        }

        // Для UI кнопок
        public void SetRussian() => SetLanguage(Language.Ru);
        public void SetEnglish() => SetLanguage(Language.Eu);
        public void SetKazakh() => SetLanguage(Language.Kz);
        public void SetTurkish() => SetLanguage(Language.Tr);
    }
}