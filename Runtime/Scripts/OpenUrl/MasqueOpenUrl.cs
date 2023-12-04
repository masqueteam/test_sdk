using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

namespace MasqueSDK
{
    public class MasqueOpenUrl : MonoBehaviour
    {
        public string verseUrl = "https://masque-lab.adldigitalservice.com:5001/m-avenue/v0.4.5/index.html";
        [DllImport("__Internal")]
        private static extern void OpenURL(string url);

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
            if (string.IsNullOrEmpty(Masque.masqueId))
                return string.Format("{0}?name={1}&url={2}", verseUrl, Masque.masqueName, Masque.masqueAvatarUrl);
            else
                return string.Format("{0}?masqueId={1}", verseUrl, Masque.masqueId);
        }

        public void OpenUrl(string url)
        {
            OpenURL(url);
        }
    }
}