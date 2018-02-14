using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class finalScreenClicked : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI textBox;
    
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Greg'sDate");
        //textBox.text = "Check Back For Greg's Date <3";
    }
}
