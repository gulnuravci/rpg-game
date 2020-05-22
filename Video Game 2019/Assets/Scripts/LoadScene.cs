using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    //bool objectIsActive = false;

    private void Update()
    {
        if(gameObject.activeInHierarchy == true)
        {
            //gameObject.SetActive(false);
            SceneManager.LoadScene(sceneToLoad);
            UIFade.instance.FadeFromBlack();
            GameManager.instance.fadingBetweenAreas = false;
        }
    }
    //public string sceneName;

    //private void Update()
    //{

    //}

    //private void OnTriggerEnter2D(Collider2D other)
    //{
    //    if(other.tag == "Player")
    //    {
    //        SceneManager.LoadScene(sceneName);
    //    }
    //}
}
