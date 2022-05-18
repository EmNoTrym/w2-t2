using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Waypoints : MonoBehaviour
{
    public List<GameObject> waypoints;
    public float speed = 1f;

    private string mouseCurrentOn = "Empty";
    private int waypointIndex = 0;
    private float WRadius = 1; //de kiem tra xem khoang cach giua player va waypoint
                               //la phu hop de duoc danh dau la da di qua
    
    private void Update()
    {
        if (waypoints.Count >= 1) {
            //moi khi di qua thi tang index de di den diem moi
            if (Vector3.Distance(waypoints[waypointIndex].transform.position, transform.position) < WRadius)
            {
                if(waypointIndex + 1 <= waypoints.Count)
                {
                    waypointIndex++;
                }
                
                //kiem tra xem da di qua het cac diem chua
                //neu da di qua het thi set index ve 0 de di lai tu dau
                if (waypointIndex >= waypoints.Count)
                    waypointIndex = 0;
            }

            transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);
            transform.LookAt(waypoints[waypointIndex].transform.position);
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            int objectIndex = waypoints.FindIndex(gameObject => string.Equals(mouseCurrentOn, gameObject.name));

            waypoints.RemoveAt(objectIndex);
            if (waypointIndex - 1 >= 0)
            {
                waypointIndex--;
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (waypoints != null && waypoints.Count > 0)
        {
            for (int i = 1; i < waypoints.Count; i++)
            {
                if (waypoints.Count <= 1)
                {
                    break;
                }
                else
                {
                    Gizmos.DrawLine(waypoints[i - 1].transform.position, waypoints[i].transform.position);
                }

            }
            Gizmos.DrawLine(waypoints[0].transform.position, waypoints[waypoints.Count - 1].transform.position);
        }
    }

    public void SetMouseCurrentOn(string current)
    {
        mouseCurrentOn = current;
    }
}

