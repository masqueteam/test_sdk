using MasqueSDK;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DressingScript : MonoBehaviour
{
    // public static DressingScript init;
    public GameObject button_Join;
    public GameObject dressingObj;

    public Transform respawn_Pos;

 

    public Transform hero_room_Rotation;
    public Transform parent_hero_pos;
    public List<Transform> hero_pos;

    public MasqueSDK.MasqueLogin parserLogin;
    public RawImage image_ProfileAvater;
    public TMPro.TMP_Text Text_NameAvatar;

    float yPos =-27;
    void Start()
    {
       // if (init == null) init = this;
        foreach (Transform item in parent_hero_pos)
        {
            item.gameObject.SetActive(false);
            hero_pos.Add(item);
        }
        hero_room_Rotation.transform.localRotation = Quaternion.Euler(0, yPos, 0);

    }
    bool isDo = true;
    void Update()
    {
        if (parserLogin.IndividualLoginData.Count >= 1 && isDo)
        {
            print(isDo);
            for (int i = 0; i < parserLogin.IndividualLoginData.Count; i++)
            {
                hero_pos[i].gameObject.SetActive(true);
                print(parserLogin.IndividualLoginData[i].gltf);

                hero_pos[i].transform.GetComponentInChildren<MasqueAvatarLoader>().LoadAvatar(parserLogin.IndividualLoginData[i].gltf);
                DataIDLogin dataID = hero_pos[i].GetComponent<DataIDLogin>();
                dataID.name.text = parserLogin.IndividualLoginData[i].name;
                dataID.masqueId.text = parserLogin.IndividualLoginData[i].masqueId;
                dataID.numID = i;
                StartCoroutine(StartImage(parserLogin.IndividualLoginData[i].displayPic,
                (image) =>
                {
                    dataID.rawImage.texture = image;
                }
                ));

                if (i >= parserLogin.IndividualLoginData.Count - 1)
                {
                    isDo = false;
                    print(isDo);
                }
            }

        }

    }
    void SetPosAvaterCount(int maxCount)
    {
        yPos -= (maxCount / 2) * 18;
        hero_room_Rotation.transform.localRotation = Quaternion.Euler(0, yPos, 0);
    }

    public void Click_L_Hero()
    {
        yPos -= 18;
        hero_room_Rotation.transform.localRotation = Quaternion.Euler(0, yPos, 0);
    }
    public void Click_R_Hero()
    {
        yPos += 18;
        hero_room_Rotation.transform.localRotation = Quaternion.Euler(0, yPos, 0);
    }
    string masqueId;
    public void ClickButtonBydataIDLogin(DataIDLogin dataIDLogin)
    {

        masqueId = dataIDLogin.masqueId.text;

        print(dataIDLogin.numID);
        button_Join.SetActive(true);
        respawn_Pos.GetComponent<MasqueAvatarLoader>().LoadAvatar(parserLogin.IndividualLoginData[dataIDLogin.numID].gltf);
        Text_NameAvatar.text = dataIDLogin.name.text;
        image_ProfileAvater.gameObject.SetActive(true);
        image_ProfileAvater.texture = dataIDLogin.rawImage.texture;
    }

    public void ButtonJoin()
    {
        Masque.masqueAbsoluteURL = $"https://test.com/?masqueId={masqueId}";
        LoadScene(1);
    }



    public void LoadScene(int sceneANumber)
    {
        Debug.Log("sceneBuildIndex to load: " + sceneANumber);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneANumber);
    }

    IEnumerator StartImage(string url, Action<Texture2D> action)
    {
        using (var uwr = new UnityWebRequest(url, UnityWebRequest.kHttpVerbGET))
        {

            uwr.downloadHandler = new DownloadHandlerTexture();
            yield return uwr.SendWebRequest();
            if (uwr.downloadHandler.isDone)
            {
                print("SetImage " + DownloadHandlerTexture.GetContent(uwr).name);
                action(DownloadHandlerTexture.GetContent(uwr));
            }
            else
            {
                print("404 can't Load Image");
            }

        }
    }
}
