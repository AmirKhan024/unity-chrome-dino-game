using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftedge;

    void Start()
    {
        leftedge = Camera.main.ScreenToWorldPoint(Vector3.zero).x-2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position+= Vector3.left * GameManager.Instance.gameSpeed * Time.deltaTime;
        if(transform.position.x < leftedge){
            Destroy(gameObject);
        }
    }
}
