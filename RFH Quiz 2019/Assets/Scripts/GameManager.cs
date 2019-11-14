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
/*
    [SerializeField]
    private GameObject playerObject;

    [SerializeField]
    private float runTime;
    private float runCounter;
    
    [SerializeField]
    private float runSpeed;

    [SerializeField]
    private float jumpTime;
    private float jumpCounter;

    [SerializeField]
    private float jumpSpeed;

    [SerializeField]
    private float landTime;
    private float landCounter;

    [SerializeField]
    private float landSpeed;

    [SerializeField]
    private float fallTime;
    private float fallCounter;

    [SerializeField]
    private float celebrateTime;
    private float celebrateCounter;

    public Animator animator;
*/
    // At the Start of the level
    void Start()
    {
		answerReference = playerGameObject.GetComponent<CharacterBehaviour>();
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetCurrentQuestion();
/*
        runCounter = runTime;
        jumpCounter = jumpTime;
        landCounter = 0;
        fallCounter = 0;
        celebrateCounter = 0;
*/
    }

// Running each Frame
    private void Update()
    {
/*

        if (landCounter > 0)
        {
            playerObject.transform.Translate(0.5f * landSpeed * Time.deltaTime, -landSpeed * Time.deltaTime, 0);
            landCounter -= Time.deltaTime;
        }
        else if (fallCounter > 0)
        {
            playerObject.transform.Translate(0, 0, 0);
            fallCounter -= Time.deltaTime;
            animator.SetFloat("Fall", fallCounter);
        }
        else if (celebrateCounter > 0)
        {
            playerObject.transform.Translate(0, 0, 0);
            celebrateCounter -= Time.deltaTime;
            animator.SetFloat("Celebrate", celebrateCounter);
        }
        else if (runCounter > 0)
        {
            playerObject.transform.Translate(runSpeed * Time.deltaTime, 0, 0);
            runCounter -= Time.deltaTime;
            animator.SetFloat("Run", runCounter);
        }
        else if (jumpCounter > 0)
        {
            playerObject.transform.Translate(0.5f * jumpSpeed * Time.deltaTime, jumpSpeed * Time.deltaTime, 0);
            jumpCounter -= Time.deltaTime;
            animator.SetFloat("Jump", jumpCounter);
        }
*/
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

//        player.sprite = charSets[0].neutralPose;

        Debug.Log(unansweredQuestions.Count);
    }
    
    IEnumerator TransitionToNexQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);

        yield return new WaitForSeconds(timeBetweenQuestions);

        SetCurrentQuestion();
    }

// Animation Functions
/*
    public void RunAnim()
    {

        if (runCounter > 0)
        {
            playerObject.transform.Translate(runSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            playerObject.transform.Translate(0, 0, 0);
            jumpCounter = jumpTime;
        }
    }

    public void JumpAnim()
    {
        jumpCounter -= Time.deltaTime;
        if (jumpCounter > 0)
        {
            playerObject.transform.Translate(0.5f * jumpSpeed * Time.deltaTime, jumpSpeed * Time.deltaTime, 0);
        }
        else
        {
            playerObject.transform.Translate(0, 0, 0);
        }
    }

*/
    // Answer Functions
	// References to CharacterBehaviour script to preform relevant action based on answer
    public void UserSelectA()
    {
		answerReference.AnswerIs(currentQuestion.ansAIsTrue);
    }

    public void UserSelectB()
    {
		answerReference.AnswerIs(currentQuestion.ansBIsTrue);
    }

    public void UserSelectC()
    {
		answerReference.AnswerIs(currentQuestion.ansCIsTrue);
    }

    public void UserSelectD()
    {
		answerReference.AnswerIs(currentQuestion.ansDIsTrue);
    }
}
