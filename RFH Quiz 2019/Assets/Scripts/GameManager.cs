using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GameManager : MonoBehaviour {
// Variable Assignment
	[SerializeField]
	public GameObject playerGameObject;
	private CharacterBehaviour answerReference;

    public Question[] questions;
    private static List<Question> unansweredQuestions;

    public CharacterSprites[] charSets;

    private Question currentQuestion;

    [SerializeField]
    private Text questionText;

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
        Debug.Log(unansweredQuestions.Count);
    }
    
    IEnumerator TransitionToNexQuestion()
    {
        yield return new WaitForSeconds(timeBetweenQuestions);
        
		unansweredQuestions.Remove(currentQuestion);
        SetCurrentQuestion();
    }

    // Answer Functions
	// References to CharacterBehaviour script to preform relevant action based on answer
    public void UserSelectA()
    {
		answerReference.AnswerIs(currentQuestion.ansAIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }

    public void UserSelectB()
    {
		answerReference.AnswerIs(currentQuestion.ansBIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }

    public void UserSelectC()
    {
		answerReference.AnswerIs(currentQuestion.ansCIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }

    public void UserSelectD()
    {
		answerReference.AnswerIs(currentQuestion.ansDIsTrue);
		StartCoroutine(TransitionToNexQuestion());
    }
}
