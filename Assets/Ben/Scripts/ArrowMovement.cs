using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    //adjust this to change speed
    public float speed;
    //adjust this to change how high it goes
    public float height = 0.5f;

    public Vector3 pos;

    private void Start()
    {
        pos = gameObject.transform.position;
    }
    void Update()
    {
        ToAndFroMovement();
    }

    public void ToAndFroMovement()
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(pos.x, newY, pos.z);
    }
}
