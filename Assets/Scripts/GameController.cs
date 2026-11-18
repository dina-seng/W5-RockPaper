
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Rock - Paper - Scissors
// 1 = Rock, 2 = Paper, 3 = Scissors, 4 = Unknown ("?")

public class GameController : MonoBehaviour
{
    // UI Image references
    [Header("Player Images")]
    [SerializeField] private Image imgYou;
    [SerializeField] private Image imgCom;

    // UI Text references
    [Header("Score and Result")]
    [SerializeField] private TMP_Text txtYou;
    [SerializeField] private TMP_Text txtCom;
    [SerializeField] private TMP_Text txtResult;

    // Scores
    private int cntYou = 0;
    private int cntCom = 0;

    private void InitGame()
    {
        // Display initial question mark images
        imgYou.sprite = Resources.Load<Sprite>("img_4");
        imgCom.sprite = Resources.Load<Sprite>("img_4");

        // Initialize scores
        cntYou = 0;
        cntCom = 0;

        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();

        // Initial message
        txtResult.text = "Select the button below";
    }

    private void Start()
    {
        InitGame();
    }

    private void Update()
    {
        // Exit game when pressing Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Called when player clicks Rock, Paper, or Scissors
    public void OnButtonClick(GameObject buttonObject)
    {
        Debug.Log(buttonObject.name + " clicked");
        int you = 0;

        // Extract the first character
        string firstCharacter = buttonObject.name.Substring(0, 1);
        switch (buttonObject.name)
        {
            case "Rock_Button":
                you = 1;
                break;

            case "Paper_Button":
                you = 2;
                break;

            case "Scissors_Button":
                you = 3;
                break;

            default:
                Debug.LogError("Invalid button name: " + buttonObject.name);
                return;
        }


        CheckResult(you);


    }

    private void CheckResult(int yourResult)
    {
        // Generate computer choice (1, 2, or 3)
        int comResult = Random.Range(1, 4);

        // Compare player and computer choices
        int k = yourResult - comResult;

        if (k == 0)
        {
            txtResult.text = "Draw.";
        }
        else if (k == 1 || k == -2)
        {
            txtResult.text = "You win.";
            cntYou++;
        }
        else
        {
            txtResult.text = "Computer win.";
            cntCom++;
        }

        // Update images and scores
        SetResult(yourResult, comResult);
    }

    private void SetResult(int you, int com)
    {
        // Display player's selected image
        imgYou.sprite = Resources.Load<Sprite>("img_" + you);

        // Display computer's selected image
        imgCom.sprite = Resources.Load<Sprite>("img_" + com);

        // Flip computer image horizontally
        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        // Update scores
        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();
    }
}
