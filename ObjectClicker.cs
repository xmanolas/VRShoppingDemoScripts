using UnityEngine;

public class ObjectClicker : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 100.0f))
        {
            if (hit.transform != null && hit.transform.CompareTag("Button"))
            {
                PrintName(hit.transform.gameObject);
            } 
        }
    }

    private void PrintName(GameObject go)
    {
        //print(go.name);
    }
}
