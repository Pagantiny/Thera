using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
using Ink.Runtime;
using System.Runtime.CompilerServices;
using UnityEditor;
using System.Runtime.ConstrainedExecution;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour

{
    //DialogueManager utilizzabile per tutti i dialoghi

    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private GameObject sprite;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [Header("Choice UI")]
    [SerializeField] private GameObject[] choices;

    private TextMeshProUGUI[] choicesText; 
    

    private static DialogueManager instance;

    private Story currentStory;
    public bool dialogueIsPlaying { get; private set; }



    private void Awake()

    {
        if (instance != null)
        {
            Debug.LogWarning("Found more than one Dialogue Manager in Scene");
        }
        instance = this;
    }
    public static DialogueManager GetInstance()
    {
        return instance;
    }
    private void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        sprite.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }    
    }

    private void Update()
    {   
        
        if(!dialogueIsPlaying)
        {
            return;
        }

        //prosegue il dialogo se si preme il pulsante
        if (InputManager.GetInstance().GetInteractPressed())
        {
            ContinueStory();
        }
    }
    public void EnterDialogueMode(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        sprite.SetActive(true);
      
        ContinueStory();
    }

    private void ExitDialogueMode()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        sprite.SetActive(false);
        dialogueText.text = "";
    }
    private void ContinueStory ()
    {
        if (currentStory.canContinue)
        {
            //set text for the current dialogue line
            dialogueText.text = currentStory.Continue();
            //display choices, if any, for this dialogue line
            DisplayChoices();


        }
        else
        {
            ExitDialogueMode();
        }
        
    }
    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        if (currentChoices.Count > choices.Length)
        {
           //Debug.LogError("More choices were given than the UI can Support. Number of choice:" + currentChoices.Count);
        }

        int index = 0;
        foreach(Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        for (int i = index; i< choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }
        StartCoroutine(SelectFirstChoice());
    }
    private IEnumerator SelectFirstChoice()
    {
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    } 
    public void MakeChoice(int choiceIndex)
    {
    
        currentStory.ChooseChoiceIndex(choiceIndex);
       
    }
}
