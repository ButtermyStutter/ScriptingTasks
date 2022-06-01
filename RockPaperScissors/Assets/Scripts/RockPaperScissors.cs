using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RockPaperScissors : MonoBehaviour
{
    private int playerLives;
    private int enemyLives;
    private int randomNumber;

    public Text gameOutputText;
    public Text playerLifeCounter;
    public Text enemyLifeCounter;

    public Button rockButton;
    public Button paperButton;
    public Button scissorsButton;
    public Button restartButton;

    private void Awake()
    {
        rockButton.gameObject.SetActive(true);
        paperButton.gameObject.SetActive(true);
        scissorsButton.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(false);
    }
    void Start()
    {
        SetUpGame();

        
    }
    private void SetUpGame()
    {
        playerLives = 3;
        enemyLives = 3;

        // Change the text of the textbox 
        gameOutputText.text = "Make a choice human! Rock, Paper or Scissors?!";

        playerLifeCounter.text = playerLives.ToString();
        enemyLifeCounter.text = enemyLives.ToString();
    }
    public void ClickButton(int buttonClicked)
    {
        if (buttonClicked == 1)
        {
            gameOutputText.text = "You chose Rock";
        }
        else if (buttonClicked == 2)
        {
            gameOutputText.text = "You chose Paper";
        }
        else if (buttonClicked == 3)
        {
            gameOutputText.text = "You chose Scissors";
        }
        else if (buttonClicked == 4)
        {
            SceneManager.LoadScene(0);
        }

        // Random range returns a random number between min[inclusive] and max[exclusive]
        randomNumber = Random.Range(1, 4);

        DoBattle(buttonClicked, randomNumber);
    }

    private void DoBattle(int playerChoice, int enemyChoice)
    {
        if (playerChoice == enemyChoice)
        {
            gameOutputText.text += "\nThe enemy chose the same and you have drawn. Funny Customs is better than this shit."; 
        }
        else if (playerChoice == 2 && enemyChoice == 1)
        {
            gameOutputText.text += "\nThe enemy chose Rock and you have won! Bingley Mega Chippy!";
            enemyLives--;
        }
        else if (playerChoice == 1 && enemyChoice == 2)
        {
            gameOutputText.text += "\nThe enemy chose Paper and you have lost. Cry.";
            playerLives--;
        }
        else if (playerChoice == 2 && enemyChoice == 3)
        {
            gameOutputText.text += "\nThe enemy chose Scissors and you have lost. Git Gud.";
            playerLives--;
        }
        else if (playerChoice == 1 && enemyChoice == 3)
        {
            gameOutputText.text += "\nThe enemy chose Scissors and you have won! Les Gooooooooooooo!";
            enemyLives--;
        }
        else if (playerChoice == 3 && enemyChoice == 1)
        {
            gameOutputText.text += "\nThe enemy chose Rock and you died. Sucks to suck.";
            playerLives--;
        }
        else if (playerChoice == 3 && enemyChoice == 2)
        {
            gameOutputText.text += "\nThe enemy chose Paper and fucking lost. Holy shit call Doctor T!";
            enemyLives--;
        }

        //Update UI to reflect the new values 
        playerLifeCounter.text = playerLives.ToString();
        enemyLifeCounter.text = enemyLives.ToString();

        if (playerLives == 0)
        {
            gameOutputText.text += "\nThou hast Losteth the match!";
            rockButton.gameObject.SetActive(false);
            paperButton.gameObject.SetActive(false);
            scissorsButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
        if (enemyLives == 0)
        {
            gameOutputText.text += "\nThou hast Won the match!";
            rockButton.gameObject.SetActive(false);
            paperButton.gameObject.SetActive(false);
            scissorsButton.gameObject.SetActive(false);
            restartButton.gameObject.SetActive(true);
        }
    }

}
