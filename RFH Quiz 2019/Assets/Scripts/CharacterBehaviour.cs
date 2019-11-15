using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviour : MonoBehaviour {
	public GameObject[] characters;
	private int chosenCharacter;
	public Transform MovingWorld;
	public GameObject WinUI;
	[SerializeField]
	public Text score;
	
	private bool raceStarted = false;
	public float startTime = 3;
	private float countdownTimer;
	private bool countStarted = false;
	private bool crossFinishLine = false;
	
	private int questionsAmount= 8;
	private int questionsAnswered = 0;
	private int correctAnswers = 0;
	private bool questionTime = false;
	
	private int moveSpeed = 8;
	private Animator animator;
	
	private void Start()
	{
		WinUI.SetActive(false);
		chosenCharacter = CharacterID.Id;
		print(chosenCharacter);
		
		foreach(GameObject character in characters)
		{
			character.SetActive(false);
		}
		characters[chosenCharacter].SetActive(true);
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
		if(raceStarted == true && questionTime == false && crossFinishLine == false)
		{
			animator.SetTrigger("startRunning");
			MovingWorld.Translate(Vector2.left * moveSpeed * Time.deltaTime);
		}
		if(crossFinishLine == true)
		{
			WinUI.SetActive(true);
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
		if(col.tag == "FinishLine")
		{
			crossFinishLine = true;
		}
	}
	
	public void AnswerIs(bool isCorrect)
	{
		questionsAnswered++;
		score.text = questionsAnswered.ToString();
		if(isCorrect)
		{
			correctAnswers++;
		}
		animator.SetBool("answer", isCorrect);
		animator.SetTrigger("fallDown");
		questionTime = false;
		print(questionsAnswered);
		print(correctAnswers);
	}
	
}
