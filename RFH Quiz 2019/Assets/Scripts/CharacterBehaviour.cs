using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterBehaviour : MonoBehaviour {
	public GameObject[] characters;
	private int chosenCharacter;
	public Transform MovingWorld;
	
	public GameObject QuestionUI;
	private Animator questioncharAnimator;

	public GameObject WinUI;
	[SerializeField]
	public Text medal;
	public Text finishMessage;
	public string[] finishTexts;
	
	private bool raceStarted = false;
	public float startTime = 3;
	private float countdownTimer;
	private bool countStarted = false;
	private bool crossFinishLine = false;
	
	private int correctAnswers;
	private bool questionTime = false;
	
	private int moveSpeed = 8;
	private Animator charAnimator;
	
	public AudioClip startingGun;
	
	public AudioClip cheerHappy;
	public AudioClip cheerSad;
	
	private void Awake()
	{
		correctAnswers = 0;
	}
	private void Start()
	{
		AudioSource audio = GetComponent<AudioSource>();
		
		questioncharAnimator = QuestionUI.GetComponent<Animator>();
		WinUI.SetActive(false);
		chosenCharacter = CharacterID.Id;
		print(chosenCharacter);	
		foreach(GameObject character in characters)
		{
			character.SetActive(false);
		}
		characters[chosenCharacter].SetActive(true);
		charAnimator = gameObject.GetComponentInChildren<Animator>();
		StartCountdown(startTime);
	}
	
	private void Update()
	{
		if(countdownTimer > 0 && countStarted == true)
		{
			countdownTimer -= Time.deltaTime;
		}
		if(countdownTimer <= 0)
		{
			raceStarted = true;
			countStarted = false;
		}
		//moving controller
		if(raceStarted == true && questionTime == false && crossFinishLine == false)
		{
			charAnimator.SetTrigger("startRunning");
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
			charAnimator.SetTrigger("jumpUp");
		}
		if(col.tag == "QuestionTrigger")
		{
			questioncharAnimator.SetTrigger("slideBox");
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
			WinUI.GetComponent<Animator>().SetTrigger("WinIn");
			if(correctAnswers == 8)
			{
				finishMessage.text = finishTexts[0];
			}	
			if(correctAnswers == 7)
			{
				finishMessage.text = finishTexts[1];
				medal.text = "GOLD!";
			}
			if(correctAnswers == 6)
			{
				finishMessage.text = finishTexts[2];
				medal.text = "Silver!";
			}
			if(correctAnswers == 3)
			{
				medal.text = "Bronze";
			}
			if(correctAnswers == 3 || correctAnswers == 4 || correctAnswers == 5)
			{
				finishMessage.text = finishTexts[3];
				medal.text = "Better luck next time!";
			}
			if(correctAnswers == 1 || correctAnswers == 2)
			{
				finishMessage.text = finishTexts[4];
				medal.text = "Better luck next time!";
			}
			crossFinishLine = true;
		}
	}
	public void AnswerIs(bool isCorrect)
	{
		if(isCorrect)
		{
			correctAnswers++;
			GetComponent<AudioSource>().clip = cheerHappy;
			GetComponent<AudioSource>().Play();
		}
		if(!isCorrect)
		{
			GetComponent<AudioSource>().clip = cheerSad;
			GetComponent<AudioSource>().Play();
		}
		charAnimator.SetBool("answer", isCorrect);
		charAnimator.SetTrigger("fallDown");
		questionTime = false;
		questioncharAnimator.SetTrigger("slideBox");
	}
}
