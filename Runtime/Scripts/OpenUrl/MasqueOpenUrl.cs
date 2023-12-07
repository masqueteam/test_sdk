using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

    public class MasqueOpenUrl : MonoBehaviour
    {
        public Text verse_name;
        public string verseName = "NEXTClan Verse";
        public string verseUrl = "https://masque-lab.adldigitalservice.com:5001/m-avenue/v0.4.5/index.html";
        [DllImport("__Internal")]
        private static extern void OpenURLWithCallback(string url);


        private void OnEnable()
        {
            verse_name.text = verseName;
        }
        public void OpenUrl()
        {
            string url = GetPassURL();
#if UNITY_WEBGL && !UNITY_EDITOR
            OpenUrl(url);
#else
            Application.OpenURL(url);
#endif
        }
        string GetPassURL()
        {
            /*
            if (string.IsNullOrEmpty(Masque.masqueId))
                return string.Format("{0}?name={1}&url={2}", verseUrl, Masque.masqueName, Masque.masqueAvatarUrl);
            else
                return string.Format("{0}?masqueId={1}", verseUrl, Masque.masqueId);
            */

            return string.Format("https://masque-lab.adldigitalservice.com/citizen/citizen/?verseName={0}&verseUri={1}", verseName, verseUrl);
        }

        public void OpenUrl(string url)
        {
            OpenURLWithCallback(url);
        }
    }
