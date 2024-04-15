using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float movespeed = 10.0f;

    public Rigidbody2D player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
    }


    public void MovePlayer()
    {
        this.transform.Translate(Input.GetAxis("Horizontal"),0, 0);
    }



}
