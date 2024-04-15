using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveProjectile : MonoBehaviour
{

	public Rigidbody2D dodgeball;

	public float moveSpeed = 10.0f;

	
	void Start()
	{
		dodgeball = this.gameObject.GetComponent<Rigidbody2D>();
	}

	
	void Update()
	{
		dodgeball.velocity = new Vector2(0, 1) * moveSpeed;
	}

	
	void OnCollisionEnter2D(Collision2D col)
	{
		
		if (col.gameObject.name == "Enemy")
		{
			col.gameObject.SetActive(false);
		}
		
		if (col.gameObject.name == "Top")
		{
			DestroyObject(this.gameObject);
		}
	}
}