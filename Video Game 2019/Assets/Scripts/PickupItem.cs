using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PickupItem : MonoBehaviour
{
    private bool canPickUp;

    public bool automaticPickUp;

    public GameObject key;
    public GameObject robot;
    public GameObject portfolio;
    public GameObject computer;
    public GameObject ribbon;

    bool isMainOffice = false;
    bool isRoom220 = false;
    bool isPrinterStation = false;
    bool isGymComputer = false;
    bool isGymRibbon = false;

    //public GameObject questCanvas1;

    // Start is called before the first frame update
    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Main Office")
        {
            isMainOffice = true;
        }
        if (sceneName == "Room 220")
        {
            isRoom220 = true;
        }
        if(sceneName == "Printer Station" && key.activeSelf  && robot.activeSelf)
        {
            isPrinterStation = true;
        }
        if(sceneName == "Gym" && key.activeSelf && robot.activeSelf && portfolio.activeSelf)
        {
            isGymComputer = true;
            isGymRibbon = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(canPickUp && Input.GetButtonDown("Fire1") && PlayerController.instance.canMove && !automaticPickUp)
        {
            GameManager.instance.AddItem(GetComponent<Item>().itemName);
            Destroy(gameObject);
        }

        if(canPickUp && PlayerController.instance.canMove && automaticPickUp)
        {
            GameManager.instance.AddItem(GetComponent<Item>().itemName);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Player")
        {
            canPickUp = true;
            if(isMainOffice == true)
            {
                key.SetActive(true);
            }
            if (isRoom220 == true)
            {
                robot.SetActive(true);
                //GameObject.FindWithTag("Robot").SetActive(true);
                //questCanvas1.SetActive(true);
            }

            if(isPrinterStation == true)
            {
                portfolio.SetActive(true);
            }

            if (isGymRibbon == true && isGymComputer)
            {
                computer.SetActive(true);
                ribbon.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            canPickUp = false;
        }
    }
}
