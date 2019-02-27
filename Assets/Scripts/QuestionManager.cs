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
    private float questionNum;
    private float maxQuestionCount = 2;

    private Question currentQuestion;

    [SerializeField]
    private TMP_Text questionField;

    [SerializeField]
    private TMP_Text factText;

    [SerializeField]
    private TMP_Text answerA;

    [SerializeField]
    private TMP_Text answerB;

    [SerializeField]
    private TMP_Text answerC;

    private void Start()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questions.ToList<Question>();
            questionNum = ((maxQuestionCount + 1) - unansweredQuestions.Count);
        }

        SetRandomQuestion();
        //Debug.Log(currentQuestion.fact + " is " + currentQuestion.isTrue);
    }

    private void SetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        factText.text = currentQuestion.fact;
        questionField.text = "Question " + questionNum.ToString();
        answerA.text = currentQuestion.answerA;
        answerB.text = currentQuestion.answerB;
        answerC.text = currentQuestion.answerC;

        //Remove the question from the array.
        unansweredQuestions.RemoveAt(randomQuestionIndex);
    }

    public void UserSelects(int choice)
    {
    }
}