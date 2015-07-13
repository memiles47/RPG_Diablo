using UnityEngine;
using System.Collections;

public class LocateMouse : MonoBehaviour
{
    // Declaration of private reference variables
    GameObject player;

    // Awake is called when the script instance is being loaded
    public void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public Vector3 LocatePosition()
    {
        // Located clicked position
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit, 1000))
        {
            if (hit.collider.tag != "Player")
            {
                return new Vector3(hit.point.x, hit.point.y, hit.point.z);
            }
            else
            {
                return player.transform.position;
            }
        }
        else
        {
            // If I am not clicking on an object, return the players position
            return player.transform.position;
        }
    }
}
