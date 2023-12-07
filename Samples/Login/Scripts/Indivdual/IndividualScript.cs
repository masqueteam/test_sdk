<<<<<<< HEAD
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IndividualScript : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int sceneANumber)
    {
        Debug.Log("sceneBuildIndex to load: " + sceneANumber);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneANumber);
    }


    public IEnumerator StartImage(string url, Action<Texture2D> action)
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
=======
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class IndividualScript : MonoBehaviour
{

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(int sceneANumber)
    {
        Debug.Log("sceneBuildIndex to load: " + sceneANumber);
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneANumber);
    }


    public IEnumerator StartImage(string url, Action<Texture2D> action)
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
>>>>>>> aca2d79 (-init)
