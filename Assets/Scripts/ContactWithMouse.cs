using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactWithMouse : MonoBehaviour
{
    private Waypoints playerWaypoint;

    private void Start()
    {
        playerWaypoint = GameObject.Find("GameObject").GetComponent<Waypoints>();
    }

    private void OnMouseEnter()
    {
        playerWaypoint.SetMouseCurrentOn(gameObject.transform.parent.name);
    }

    private void OnMouseExit()
    {
        playerWaypoint.SetMouseCurrentOn("Empty");
    }
}
