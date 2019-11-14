using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviour : MonoBehaviour {
	public Transform MovingWorld;
	
	private bool raceStarted = false;
	public float runSpeed = 1;
	public float jumpDistance = 1;
	public float startTime = 3;
	private float countdownTimer;
	private bool countStarted = false;
	private bool questionTime = false;
	
	private Animator animator;
	
	private void Start()
	{
		animator = gameObject.GetComponentInChildren<Animator>();
		StartCountdown(startTime);
	}
	
	private void Update()
	{
		if(countdownTimer > 0 && countStarted == true)
		{
			countdownTimer -= Time.deltaTime;
			print(countdownTimer);
		}
		if(countdownTimer <= 0)
		{
			raceStarted = true;
			countStarted = false;
		}
		//moving controller
		if(raceStarted == true && questionTime == false)
		{
			animator.SetTrigger("startRunning");
			MovingWorld.Translate(Vector2.left * runSpeed * Time.deltaTime);
		}
	}
	//jump when getting to collider
	private void StartCountdown(float countdown)
	{
		countdownTimer = countdown;
		countStarted = true;
	}
	
	private void OnTriggerEnter2D(Collider2D col)
	{
		
		if(col.tag == "Hurdle")
		{
			animator.SetTrigger("jumpUp");
		}
	}
	private void OnTriggerExit2D(Collider2D col)
	{
		if(col.tag == "Hurdle")
		{
			questionTime = true;
		}
	}
	
	public void AnswerIs(bool isCorrect)
	{
		animator.SetBool("answer", isCorrect);
		animator.SetTrigger("fallDown");
		questionTime = false;
	}
}
