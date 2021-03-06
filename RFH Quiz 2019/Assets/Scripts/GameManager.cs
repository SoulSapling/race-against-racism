﻿using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
// Variable Assignment
	[SerializeField]
	public GameObject playerGameObject;
	public GameObject questionTextGO;
	private Button[] buttons;
	
	private CharacterBehaviour answerReference;

    public Question[] questions;
    private static List<Question> unansweredQuestions;
//	private bool answered = false;
	
    public CharacterSprites[] charSets;

    private Question currentQuestion;

    [SerializeField]
    private Text questionText;
	
	private bool isAnswerable;
    [SerializeField]
    private Text ansAText;
    [SerializeField]
    private Text ansBText;
    [SerializeField]
    private Text ansCText;
    [SerializeField]
    private Text ansDText;

    [SerializeField]
    private float timeBetweenQuestions = 1f;

    void Start()
    {
		buttons = questionTextGO.GetComponentsInChildren<Button>();
		answerReference = playerGameObject.GetComponent<CharacterBehaviour>();
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }
		SetCurrentQuestion();
    }
// Question Functions
    void SetCurrentQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;
        ansAText.text = currentQuestion.ansA;
        ansBText.text = currentQuestion.ansB;
        ansCText.text = currentQuestion.ansC;
        ansDText.text = currentQuestion.ansD;
        Debug.Log("questions left: " + unansweredQuestions.Count);
		foreach(Button butt in buttons)
		{
			butt.GetComponent<Image>().color = Color.white;
		}
		SetButtonInteractable(true);
    }
    
    IEnumerator TransitionToNexQuestion()
    {
		SetButtonInteractable(false);
        yield return new WaitForSeconds(timeBetweenQuestions);
		unansweredQuestions.Remove(currentQuestion);
		SetCurrentQuestion();
    }
	
	private void SetButtonInteractable(bool isInteractable)
	{	
		foreach(Button butt in buttons)
		{
			butt.interactable = isInteractable;
		}
	}
	
    // Answer Functions
	// References to CharacterBehaviour script to preform relevant action based on answer
	public void ChangeColour(Button btn, bool isGreen)
	{
		if(isGreen)
		{
			btn.GetComponent<Image>().color = Color.green;
		}
		else
		{
			btn.GetComponent<Image>().color = Color.red;
		}
	}
	public void UserSelectA()
    {
		ChangeColour(buttons[0], currentQuestion.ansAIsTrue);
		answerReference.AnswerIs(currentQuestion.ansAIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }

    public void UserSelectB()
    {
		ChangeColour(buttons[1], currentQuestion.ansBIsTrue);
		answerReference.AnswerIs(currentQuestion.ansBIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }
	
    public void UserSelectC()
    {
		ChangeColour(buttons[2], currentQuestion.ansCIsTrue);
		answerReference.AnswerIs(currentQuestion.ansCIsTrue);
		StartCoroutine(TransitionToNexQuestion());
	}

    public void UserSelectD()
    {
		ChangeColour(buttons[3], currentQuestion.ansDIsTrue);
		answerReference.AnswerIs(currentQuestion.ansDIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }
	public void PlayAgain()
	{
		SceneManager.LoadScene("Home");
	}
}
