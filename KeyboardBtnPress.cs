using UnityEngine;
using TMPro;

public class KeyboardBtnPress : MonoBehaviour
{
    //public KeyCode enableDisableMenus;
    public KeyCode clearBasket;
    public KeyCode quitApp;
    public KeyCode movementModeOn;
    public KeyCode mute;

    void Update()
    {
        // Enable/disable global trigger for product menus
        /*if (Input.GetKeyUp(enableDisableMenus))
        {
            if (GlobalVariables.triggerOn == true)
            {
                GameObject.Find("ProductMenuText").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            }
            else
            {
                GameObject.Find("ProductMenuText").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            }
            GlobalVariables.triggerOn = !GlobalVariables.triggerOn;
        }*/

        // Destroy all objects in shopping cart 
        if (Input.GetKeyUp(clearBasket))
        {
            try
            {
                int childCount = GameObject.Find("CartProducts").transform.childCount;
                if (childCount > 0)
                {
                    for (int count = 0; count < childCount; count++)
                    {
                        Destroy(GameObject.Find("CartProducts").transform.GetChild(count).gameObject);
                    }
                }
            }
            catch { }
        }

        if (Input.GetKeyUp(quitApp))
        {
            Application.Quit();
        }

        if (Input.GetKeyUp(movementModeOn))
        {
            GlobalVariables.movementModeOn = !GlobalVariables.movementModeOn;
            if (!GlobalVariables.movementModeOn)
            {
                GameObject.Find("FirstPerson-AIO").GetComponent<FirstPersonAIO>().playerCanMove = false;
                GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod1").transform.position;
                GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                GlobalVariables.teleportZone = 1;
            }
            else
            {
                GameObject.Find("FirstPerson-AIO").GetComponent<FirstPersonAIO>().playerCanMove = true;
                GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = false;
                GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Stop();
                GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Stop();
                if (GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().text != "")
                {
                    GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("");
                }
            }

            if (GlobalVariables.teleportationMode == true)
            {
                GameObject.Find("TeleportationMode").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
                GameObject.Find("TeleportationModeMessage").GetComponent<TextMeshProUGUI>().SetText("* Teleportation mode disables user movement. Please click on teleporters and product shelves to navigate");
            }
            else
            {
                GameObject.Find("TeleportationMode").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
                GameObject.Find("TeleportationModeMessage").GetComponent<TextMeshProUGUI>().text = "";
            }
            GlobalVariables.teleportationMode = !GlobalVariables.teleportationMode;

        }

        if (Input.GetKeyUp(mute))
        {
            AudioListener.pause = !AudioListener.pause;
            if (GlobalVariables.mute == false)
            {
                GameObject.Find("MuteText").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Bold;
            }
            else
            {
                GameObject.Find("MuteText").GetComponent<TextMeshProUGUI>().fontStyle = FontStyles.Normal;
            }
            GlobalVariables.mute = !GlobalVariables.mute;
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (!GlobalVariables.movementModeOn)
            {
                if (GlobalVariables.teleportZone == 1)
                {
                    GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = false;
                    GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                    GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                    GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Stop();
                    GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                    GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                    GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod1").transform.position;

                }
                else if (GlobalVariables.teleportZone == 2)
                {
                    GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = false;
                    GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                    GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                    GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Stop();
                    GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                    GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                    GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod2").transform.position;
                }
            }
            GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("");
        }

    }
}
