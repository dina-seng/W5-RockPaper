using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Rock - Paper - Scissors
// 1 = Rock, 2 = Paper, 3 = Scissors, 4 = Unknown ("?")
public class GameController : MonoBehaviour
{
    Image imgYou;       // your selected image (rock, paper, scissor)
    Image imgCom;       // computer selected image (rock, paper, scissor)

    Text txtYou;        // the score you win
    Text txtCom;        // the score computer win
    Text txtResult;     // the result

    int cntYou = 0;     // number you win
    int cntCom = 0;     // number computer win


    private void InitGame()
    {
        // names must match the objects in the scene exactly
        imgYou = GameObject.Find("ImgYou").GetComponent<Image>();
        imgCom = GameObject.Find("ImgCom").GetComponent<Image>();
        txtYou = GameObject.Find("TxtYou").GetComponent<Text>();
        txtCom = GameObject.Find("TxtCom").GetComponent<Text>();
        txtResult = GameObject.Find("TxtResult_").GetComponent<Text>();

        txtResult.text = "Select the button below";
    }

    void Start()
    {
        // init the game
        InitGame();
    }

    // Update is called once per frame
    void Update()
    {
        // exit if press escape key
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }

    // Slides 24-31: link this function to the On Click () event of every button.
    // Pass the button itself as the GameObject parameter.
    public void OnButtonClick(GameObject buttonObject)
    {
        Debug.Log(buttonObject.name + " clicked ");

        // button names start with 1_, 2_ or 3_
        int you = int.Parse(buttonObject.name.Substring(0, 1));
        CheckResult(you);
    }

    void CheckResult(int yourResult)
    {
        Debug.Log("Your result is: " + yourResult);

        int comResult = UnityEngine.Random.Range(1, 4);
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

        SetResult(yourResult, comResult);
    }

    void SetResult(int you, int com)
    {
        imgYou.sprite = Resources.Load("img_" + you, typeof(Sprite)) as Sprite;
        imgCom.sprite = Resources.Load("img_" + com, typeof(Sprite)) as Sprite;

        // flip the computer hand so it faces you
        imgCom.transform.localScale = new Vector3(-1, 1, 1);

        txtYou.text = cntYou.ToString();
        txtCom.text = cntCom.ToString();
    }
}
