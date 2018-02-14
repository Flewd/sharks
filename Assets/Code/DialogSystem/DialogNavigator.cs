using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogNavigator : MonoBehaviour {

    [SerializeField]
    private TextMeshProUGUI TextBox;

    [SerializeField]
    private DialogOptionBar optionBar;

    [SerializeField] private Image DialogBoxImage;
    
    public DialogBlock StartingBlock;
    private DialogBlock CurrentBlock;

    Coroutine currentTextAppearTask;

    
    
	// Use this for initialization
	void Start () {
        clearButtons();
        CurrentBlock = StartingBlock;
        updateTextBox();
        playDialogLogic();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ContinueButtonPressed()
    {
        nextBlock(0);
    }

    private void nextBlock(int index)
    {
        clearButtons();
        CurrentBlock = CurrentBlock.GetNextBlock(index);
        if (CurrentBlock != null)
        {
            updateTextBox();
            playDialogLogic();
        }
    }

    private void playDialogLogic()
    {
        CurrentBlock.ExecuteLogics();
    }

    private void showAllText()
    {
        TextBox.text = CurrentBlock.text;
        updateOptionButtons();
    }

    private void updateTextBox()
    {
        if (currentTextAppearTask == null)
        {
            DialogBoxImage.sprite = CurrentBlock.textBoxImage;
            currentTextAppearTask = StartCoroutine(incrementText(CurrentBlock));
        }
    }

    IEnumerator incrementText(DialogBlock block)
    {
        TextBox.text = "";

        for(int i = 0; i < block.text.Length; i++)
        {
            TextBox.text += block.text[i];
            yield return new WaitForSeconds(block.getTextSpeed());
        }
        currentTextAppearTask = null;
        updateOptionButtons();
    }

    private void updateOptionButtons()
    {
        optionBar.GenerateChoices(CurrentBlock);   
    }

    private void clearButtons() {
        optionBar.deleteButtons();
    }

    public void OptionButtonPressed(int index)
    {
        nextBlock(index);
    }

    public void TextBoxClicked()
    {
        if (currentTextAppearTask != null)
        {
            StopCoroutine(currentTextAppearTask);
            currentTextAppearTask = null;
            showAllText();
        }
    }
}
