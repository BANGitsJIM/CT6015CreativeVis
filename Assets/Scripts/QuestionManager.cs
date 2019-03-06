using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class QuestionManager : MonoBehaviour
{
    public Question[] questions;

    private static List<Question> unansweredQuestions;

    private Question currentQuestion;

    [SerializeField]
    private TMP_Text questionNumber;

    [SerializeField]
    private TMP_Text factText;

    [SerializeField]
    private TMP_Text answerA;

    [SerializeField]
    private TMP_Text answerB;

    [SerializeField]
    private TMP_Text answerC;

    public Animator animator;

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
        }

        SetRandomQuestion();
        //Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
    }

    private void SetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        float currentQuestionNumber = (questions.Length + 1 - unansweredQuestions.Count);
        questionNumber.text = "Question " + currentQuestionNumber.ToString();

        factText.text = currentQuestion.fact;
        answerA.text = currentQuestion.answerA;
        answerB.text = currentQuestion.answerB;
        answerC.text = currentQuestion.answerC;

        //Remove the question from the array.
        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }

    public void SelectAnswer(string answer)
    {
        if (currentQuestion.correctAnswer == answer)
        {
            Debug.Log("CORRECT");
            animator.SetTrigger("correct");

            GameObject gameController = GameObject.FindWithTag("GameController");
            gameController.GetComponent<Timer>().score++;
            gameController.GetComponent<Timer>().answeredQuestions++;
        }
        else
        {
            Debug.Log("INCORRECT");
            animator.SetTrigger("incorrect");

            GameObject gameController = GameObject.FindWithTag("GameController");
            gameController.GetComponent<Timer>().answeredQuestions++;
        }
    }
}