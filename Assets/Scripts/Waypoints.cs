using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    public float speed = 1f;

    private int waypointIndex = 0;
    private float WRadius = 1; //de kiem tra xem khoang cach giua player va waypoint
                               //la phu hop de duoc danh dau la da di qua

    private void Update()
    {
        //moi khi di qua thi tang index de di den diem moi
        if (Vector3.Distance(waypoints[waypointIndex].transform.position, transform.position) < WRadius)
        {
            waypointIndex++;
            //kiem tra xem da di qua het cac diem chua
            //neu da di qua het thi set index ve 0 de di lai tu dau
            if (waypointIndex >= waypoints.Length)
                waypointIndex = 0;
        }

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);

        transform.LookAt(waypoints[waypointIndex].transform.position);
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        if (waypoints != null && waypoints.Length > 0)
        {
            for (int i = 1; i < waypoints.Length; i++)
            {
                Gizmos.DrawLine(waypoints[i - 1].transform.position, waypoints[i].transform.position);
            }
            Gizmos.DrawLine(waypoints[0].transform.position, waypoints[waypoints.Length - 1].transform.position);
        }
    }
}

