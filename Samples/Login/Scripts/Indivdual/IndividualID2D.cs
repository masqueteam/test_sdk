<<<<<<< HEAD
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IndividualID2D : MonoBehaviour
{


    public Transform masgueList;

    public List<DataIDLogin> dataList;
    public MasqueSDK.MasqueLogin masqueLogin;
    public IndividualScript individualScript;
    public TMPro.TMP_Text Text_NameAvatar;
    public Transform respawn_Pos;

    public GameObject insDataListGO;
    public ScrollRect scrollView;
    public Scrollbar scrollbar;
    bool isDo = true;
    void Start()
    {
        foreach (Transform item in masgueList)
        {
            //item.gameObject.SetActive(false);
            dataList.Add(item.GetComponent<DataIDLogin>());
        }

 
        

    }
    private void AddItem()
    {

        GameObject itemData = Instantiate(insDataListGO);
        itemData.transform.SetParent(masgueList.transform, false);
        dataList.Add(itemData.GetComponent<DataIDLogin>());
        itemData.GetComponent<Button>().onClick.AddListener(() =>
        {
            ClickButtonBydataIDLogin(itemData.GetComponent<DataIDLogin>());

        });
        StartCoroutine(IEWait());
    }

    IEnumerator IEWait()
    {
        yield return null;
        scrollView.verticalNormalizedPosition = 1;
        scrollbar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (masqueLogin.IndividualLoginData.Count >= 1 && isDo)
        {
            if (dataList.Count < masqueLogin.IndividualLoginData.Count)
            {
                AddItem();
            }
            else
            {

                for (int i = 0; i < masqueLogin.IndividualLoginData.Count; i++)
                {


                    DataIDLogin dataID = dataList[i];
                    dataID.gameObject.SetActive(true);
                    dataID.name.text = masqueLogin.IndividualLoginData[i].name;
                    dataID.masqueId.text = masqueLogin.IndividualLoginData[i].masqueId;
                    dataID.numID = i;
                    StartCoroutine(individualScript.StartImage(masqueLogin.IndividualLoginData[i].displayPic,
                         (image) =>
                         {
                             dataID.rawImage.texture = image;
                         }
                    ));

                    if (i >= masqueLogin.IndividualLoginData.Count - 1)
                    {
                        isDo = false;
                        print(isDo);
                    }
                }
            }
        }
    }
    string masqueId;
    public List<Transform> transformsasdh;
    public void ClickButtonBydataIDLogin(DataIDLogin dataIDLogin)
    {
        foreach (Transform item in respawn_Pos)
        {
            transformsasdh.Add(item);
          //  Destroy(item);
        }


            masqueId = dataIDLogin.masqueId.text;

            print(dataIDLogin.numID);

            string url = masqueLogin.IndividualLoginData[dataIDLogin.numID].gltf;

             respawn_Pos.GetComponent<MasqueSDK.MasqueAvatarLoader>().LoadAvatar(url);
            Text_NameAvatar.text = dataIDLogin.name.text;

            MasqueSDK.Masque.masqueName = dataIDLogin.name.text;
            MasqueSDK.Masque.masqueAvatarUrl = url;

   

        
    }
    public void ButtonJoin()
    {
        if (string.IsNullOrEmpty(masqueId))
            return;

        MasqueSDK.Masque.masqueAbsoluteURL = $"https://test.com/?masqueId={masqueId}";
        individualScript.LoadScene(1);
    }
    void GetMasgueList()
    {




    }
}
=======
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class IndividualID2D : MonoBehaviour
{


    public Transform masgueList;

    public List<DataIDLogin> dataList;
    public MasqueSDK.MasqueLogin masqueLogin;
    public IndividualScript individualScript;
    public TMPro.TMP_Text Text_NameAvatar;
    public Transform respawn_Pos;

    public GameObject insDataListGO;
    public ScrollRect scrollView;
    public Scrollbar scrollbar;
    bool isDo = true;
    void Start()
    {
        foreach (Transform item in masgueList)
        {
            //item.gameObject.SetActive(false);
            dataList.Add(item.GetComponent<DataIDLogin>());
        }

 
        

    }
    private void AddItem()
    {

        GameObject itemData = Instantiate(insDataListGO);
        itemData.transform.SetParent(masgueList.transform, false);
        dataList.Add(itemData.GetComponent<DataIDLogin>());
        itemData.GetComponent<Button>().onClick.AddListener(() =>
        {
            ClickButtonBydataIDLogin(itemData.GetComponent<DataIDLogin>());

        });
        StartCoroutine(IEWait());
    }

    IEnumerator IEWait()
    {
        yield return null;
        scrollView.verticalNormalizedPosition = 1;
        scrollbar.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (masqueLogin.IndividualLoginData.Count >= 1 && isDo)
        {
            if (dataList.Count < masqueLogin.IndividualLoginData.Count)
            {
                AddItem();
            }
            else
            {

                for (int i = 0; i < masqueLogin.IndividualLoginData.Count; i++)
                {


                    DataIDLogin dataID = dataList[i];
                    dataID.gameObject.SetActive(true);
                    dataID.name.text = masqueLogin.IndividualLoginData[i].name;
                    dataID.masqueId.text = masqueLogin.IndividualLoginData[i].masqueId;
                    dataID.numID = i;
                    StartCoroutine(individualScript.StartImage(masqueLogin.IndividualLoginData[i].displayPic,
                         (image) =>
                         {
                             dataID.rawImage.texture = image;
                         }
                    ));

                    if (i >= masqueLogin.IndividualLoginData.Count - 1)
                    {
                        isDo = false;
                        print(isDo);
                    }
                }
            }
        }
    }
    string masqueId;
    public List<Transform> transformsasdh;
    public void ClickButtonBydataIDLogin(DataIDLogin dataIDLogin)
    {
        foreach (Transform item in respawn_Pos)
        {
            transformsasdh.Add(item);
          //  Destroy(item);
        }


            masqueId = dataIDLogin.masqueId.text;

            print(dataIDLogin.numID);

            string url = masqueLogin.IndividualLoginData[dataIDLogin.numID].gltf;

             respawn_Pos.GetComponent<MasqueSDK.MasqueAvatarLoader>().LoadAvatar(url);
            Text_NameAvatar.text = dataIDLogin.name.text;

            MasqueSDK.Masque.masqueName = dataIDLogin.name.text;
            MasqueSDK.Masque.masqueAvatarUrl = url;

   

        
    }
    public void ButtonJoin()
    {
        if (string.IsNullOrEmpty(masqueId))
            return;

        MasqueSDK.Masque.masqueAbsoluteURL = $"https://test.com/?masqueId={masqueId}";
        individualScript.LoadScene(1);
    }
    void GetMasgueList()
    {




    }
}
>>>>>>> aca2d79 (-init)
