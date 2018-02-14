using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogOptionBar : MonoBehaviour {

    public DialogNavigator dialogNavigator;
    public DialogOptionButton ButtonPrefab;
    private RectTransform rectTransform;

    private List<Button> currentButtons;

    [SerializeField]
    private Button continueButton;
    private TextMeshProUGUI continueButtonLabel;

    // Use this for initialization
    void Start () {
        rectTransform = GetComponent<RectTransform>();
        currentButtons = new List<Button>();
        continueButtonLabel = continueButton.GetComponentInChildren<TextMeshProUGUI>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void GenerateChoices(DialogBlock dialogBlock)
    {
        if (dialogBlock.nextBlocks.Length <= 0)
        {
            deleteButtons();
            continueButton.gameObject.SetActive(false);
        }
        else if(dialogBlock.nextBlocks.Length <= 1)
        {
            deleteButtons();

            if (dialogBlock.nextBlockButtonLabels.Length > 0)
            {
                continueButtonLabel.text = dialogBlock.nextBlockButtonLabels[0];
            }
            else
            {
                continueButtonLabel.text = "Continue";
            }

            continueButton.gameObject.SetActive(true);
        }
        else
        {
            float width = rectTransform.rect.width / dialogBlock.nextBlocks.Length;

            for (int i = 0; i < dialogBlock.nextBlocks.Length; i++)
            {
                float xPos = (i * width) - (rectTransform.rect.width / 2) + (width / 2);
                SpawnButton(dialogBlock, width, xPos, i);
            }

            continueButton.gameObject.SetActive(false);
        }
    }

    void SpawnButton(DialogBlock dialogBlock, float  width, float xPos, int index)
    {
        DialogOptionButton button = (DialogOptionButton)Instantiate(ButtonPrefab, transform.position, transform.rotation);
        button.OptionIndex = index;
        button.transform.SetParent(this.transform);

        if(dialogBlock.nextBlockButtonLabels.Length > index)
        {
            button.GetComponentInChildren<Text>().text = dialogBlock.nextBlockButtonLabels[index];
        }
        else
        {
            button.GetComponentInChildren<Text>().text = dialogBlock.nextBlocks[index].text;
        }

        RectTransform buttonRect = button.GetComponent<RectTransform>();
        buttonRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, rectTransform.rect.height);
        buttonRect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, width);
        buttonRect.gameObject.transform.localPosition = new Vector3(
            xPos,
            buttonRect.gameObject.transform.localPosition.y,
            buttonRect.gameObject.transform.localPosition.z);


        button.onClick.AddListener(delegate {
            dialogNavigator.OptionButtonPressed(button.OptionIndex);
        });

        currentButtons.Add(button);


    }

    public void deleteButtons()
    {
        foreach(Button button in currentButtons)
        {
            GameObject.Destroy(button.gameObject);
        }
        currentButtons.Clear();
        continueButton.gameObject.SetActive(false);
    }
}
