using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TeleportationSystem : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (!GlobalVariables.movementModeOn)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, 100.0f))
                {
                    //Debug.Log(hit.transform.parent.name);
                    if ((hit.transform.name == "TeleportationPod1"))
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod1").transform.position;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = false;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Stop();
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                        GlobalVariables.teleportZone = 1;
                        if (GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().text != "")
                        {
                            GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("");
                        }
                    }
                    else if (hit.transform.gameObject.name == "TeleportationPod2")
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod2").transform.position;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = false;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Stop();
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                        GlobalVariables.teleportZone = 2;
                        if (GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().text != "")
                        {
                            GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("");
                        }
                    }
                    else if (hit.transform.gameObject.name == "TeleportationPod3")
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("TeleportationPod3").transform.position;
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = false;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Stop();
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                        if (GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().text != "")
                        {
                            GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("");
                        }

                    }
                    else if (hit.transform.parent.name == "RedApple")
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("RedApple").transform.position - new Vector3(0.3f, -0.3f, 0);
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("Right Click to Exit Product Menu");
                    }
                    else if (hit.transform.parent.name == "Pineapple")
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("Pineapple").transform.position - new Vector3(0.3f, -0.3f, 0);
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("Right Click to Exit Product Menu");
                    }
                    else if (hit.transform.parent.name == "SodaGreen")
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("SodaGreen").transform.position;
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("Right Click to Exit Product Menu");
                    }
                    else if (hit.transform.parent.name == "SodaRed")
                    {
                        GameObject.Find("FirstPerson-AIO").transform.position = GameObject.Find("SodaRed").transform.position;
                        GameObject.Find("TeleportationPod3").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod1").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod2").GetComponent<SphereCollider>().enabled = true;
                        GameObject.Find("TeleportationPod3").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod1").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("TeleportationPod2").GetComponent<ParticleSystem>().Play();
                        GameObject.Find("GoBackText").GetComponent<TextMeshProUGUI>().SetText("Right Click to Exit Product Menu");
                    }
                }
            }
        }
    }
}
