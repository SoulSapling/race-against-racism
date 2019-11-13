using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour {
	
	private bool isRunning = false;
	public bool hasStarted = true;
	public float speed = 10;
	private Animator animator;
	
	private void Start()
	{
		animator = gameObject.GetComponent<Animator>();
	}
	
	private void Update()
	{
		if(hasStarted == true)
		{
			animator.SetBool("isRunning", isRunning);
			if(isRunning == true)
			{
				transform.Translate(Vector2.right * speed * Time.deltaTime);
			}
		}
	}
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		if(col.tag == "Hurdle")
		{
			isRunning = false;
			animator.SetBool("jump", true);
		}
		print("get ready to jump");
	}
}
