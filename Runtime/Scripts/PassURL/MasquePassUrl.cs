using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MasqueSDK
{
    public class MasquePassUrl : MonoBehaviour
    {
        public static MasquePassUrl instance;
        //public string testURL = "https://masque-lab.adldigitalservice.com:5001/m-avenue/v0.4.5/index.html?masqueId=yachto";
        public void Start()
        {
            instance = this;
            LoginScript.instance.gameObject.SetActive(false);
            if (!string.IsNullOrEmpty(Application.absoluteURL))
                PassURL(Application.absoluteURL, () => {
                    if (!string.IsNullOrEmpty(Masque.masqueindividualId))
                    {
                        LoginScript.instance.gameObject.SetActive(false);
                        LoginScript.instance.characterSelection.SetActive(true);
                        return;
                    }
                    else if (!string.IsNullOrEmpty(Masque.masqueAvatarUrl))
                    {
                        LoginScript.instance.gameObject.SetActive(false);
                        LoginScript.instance.LoadScene(1);
                        return;
                    }
                });
            LoginScript.instance.gameObject.SetActive(true);
        }
        public void PassURL(string url, Action complete)
        {
            Debug.Log(url);

            Uri myUri = new Uri(url);
            MasqueLogin masqueLogin = GetComponent<MasqueLogin>();
            string masqueId = HttpUtility.ParseQueryString(myUri.Query).Get("masqueId");
            if (!string.IsNullOrEmpty(masqueId))
            {
                print("masqueId  = " + masqueId);
                masqueLogin.GetApiLoginDataByMasqueId(masqueId, (loginData) =>
                {
                    Masque.masqueId = loginData.masqueId;
                    Masque.masqueName = loginData.name;
                    Masque.masqueAvatarUrl = loginData.gltf;
                    complete?.Invoke();
                });
            }
            else
            {
                string masqueAvatarUrl = HttpUtility.ParseQueryString(myUri.Query).Get("url");
                if (!string.IsNullOrEmpty(masqueAvatarUrl))
                {
                    string masqueName = HttpUtility.ParseQueryString(myUri.Query).Get("name");
                    Debug.Log(masqueName);
                    if (!string.IsNullOrEmpty(masqueName))
                    Masque.masqueName = masqueName;
                    Masque.masqueAvatarUrl = masqueAvatarUrl;
                    complete?.Invoke();
                    return;
                }
                //Debug.Log("masqueName : "+masqueUrl + "\nmasqueUrl : "+ masqueUrl); 
                string individualId = HttpUtility.ParseQueryString(myUri.Query).Get("individualId");
                if (!string.IsNullOrEmpty(individualId))
                {
                    masqueLogin.GetApiLoginDataByIndividualId(individualId, (loginData) =>
                    {
                        Masque.masqueindividualId = individualId;
                        print(loginData[0].masqueId);
                        complete?.Invoke();
                    });
                }
            }
        }
    }
}