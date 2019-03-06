using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;
using TMPro;

public class FactManager : MonoBehaviour
{
    public Fact[] facts;
    private static List<Fact> unansweredFacts;

    private Fact currentFact;

    [SerializeField]
    private TMP_Text factTitle;

    [SerializeField]
    private TMP_Text factContent;

    //Populate the unansweredFacts array, if it is empty.
    private void Start()
    {
        if (unansweredFacts == null || unansweredFacts.Count == 0)
        {
            unansweredFacts = facts.ToList<Fact>();
        }

        SetRandomFact();
        //Debug.Log(currentFact.title);
    }

    //get a random fact from the list of unansweredFacts
    private void SetRandomFact()
    {
        //Grab random fact
        int randomFactIndex = Random.Range(0, unansweredFacts.Count);
        currentFact = unansweredFacts[randomFactIndex];

        //Assign UI with correct text
        factTitle.text = currentFact.title;
        factContent.text = currentFact.fact;

        //Remove it from the unansweredFacts array
        RemoveFactFromArray(randomFactIndex);
    }

    //Remove a fact from the unansweredFacts array by its index.
    private void RemoveFactFromArray(int index)
    {
        unansweredFacts.RemoveAt(index);
    }
}