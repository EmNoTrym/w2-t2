using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public GameObject[] waypoints;
    int waypointIndex = 0;
    public float speed = 1f;
    public float rotSpeed = 5f;
    float WRadius = 1; //de kiem tra xem khoang cach giua player va waypoint
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

        Debug.Log(waypointIndex);

        transform.position = Vector3.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, Time.deltaTime * speed);

        transform.LookAt(waypoints[waypointIndex].transform);
    }
}

