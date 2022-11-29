using UnityEngine;

public class Raycast : MonoBehaviour
{
    void Update()
    { 

        //Checks for the left mouse button being down
        if (Input.GetMouseButtonDown(0))
        {
            //Creates a ray and if it collides with an object with the LerpScript script applied to it, will activate that instance of startLerp()
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawLine(ray.origin, hit.point, Color.red, 5f);
                if (hit.transform.TryGetComponent(out LerpScript ls)) { 
                    ls.startLerp();
                }
            }
        }else if (Input.GetKeyDown(KeyCode.Escape))//Ends the program if the user presses escape
        {
            Application.Quit();
        }

    }
}
