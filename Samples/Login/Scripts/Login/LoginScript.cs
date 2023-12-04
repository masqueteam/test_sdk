using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using MasqueSDK;

public class LoginScript : MonoBehaviour
{
    public TMP_InputField login_name;
    public TMP_InputField login_url;
    public TMP_InputField login_MasqueID;
    public TMP_InputField login_IndividualId;
    public GameObject characterSelection;
    public static LoginScript instance;

    private void Awake()
    {
        instance = this;
    }
    public void ButtonLoginV0()
    {
        //Masque.masqueName = login_name.text;
        //Masque.masqueAvatarUrl = GetUrlV0(login_url.text);
        Masque.masqueAbsoluteURL = $"https://test.com/?name={login_name.text}&url={GetUrlV0(login_url.text)}";
        MasquePassUrl.instance.PassURL(Masque.masqueAbsoluteURL, null);
        LoadScene(1);
    }
    string GetUrlV0(string text_url)
    {
        return $"https://masque-lab.adldigitalservice.com/api/media-services/3D/masque-gltf/{text_url}.gltf";
    }
    public void ButtonLoginMasqueID()
    {
        Masque.masqueAbsoluteURL = $"https://test.com/?masqueId={login_MasqueID.text}";
        MasquePassUrl.instance.PassURL(Masque.masqueAbsoluteURL, () => LoadScene(1));
    }
    public void ButtonLoginIndividualId()
    {
        Masque.masqueAbsoluteURL = $"https://test.com/?individualId={login_IndividualId.text}";
        MasquePassUrl.instance.PassURL(Masque.masqueAbsoluteURL, () => characterSelection.SetActive(true));

        /*
        MasqueSDK.MasqueLogin.GetApiLoginDataByIndividualId(login_MasqueID.text , (dataAPI) =>
        {
            print("ok");


        });*/

        // Masque.masqueId = login_MasqueID.text;
        // LoadScene(1);
    }

    public void RegisterMasquel()
    {

        StartCoroutine(RestAPI.PostData("https://masque-dev.adldigitalservice.com/api/v3/masque-be/requestUrl/create", (info) =>
        {
            print(info);
            DataRegResu dataRegResu = JsonUtility.FromJson<DataRegResu>(info);
            print("url    " + dataRegResu.data.url);

            Application.OpenURL(dataRegResu.data.url);


        }));
    }


    public void LoadScene(int sceneANumber)
    {
        Debug.Log("sceneBuildIndex to load: " + sceneANumber);
        SceneManager.LoadScene(sceneANumber);
    }

    [System.Serializable]
    private class DataRegResu
    {
        public string resultCode;
        public string resultDescription;

        public DataRegResuUrl data;
    }
    [System.Serializable]
    private class DataRegResuUrl
    {
        public string requestId;
        public string url;

    }


    }