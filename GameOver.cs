using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text timerText;
    public Text finalTimerText;

    //game manager has two methods, game over win and game over lose
    //depending on which one is triggered the game will be paused while the 
    //game over animation starts and triggers the game over screen to drop
    //down off the screen with several options to end hte game.

    void Awake(){
        finalTimerText.text = "Your final time was " + timerText.text;
    }
    //THE BLOODY GAME IS AUTO LOADING RESTART LEVEL AS SOON AS THE ANIMATION IS LOADED ON THE GAME
    //I HAVE TO SOMEHOW PAUSE EVERYTHING IN GAME EXCEPT THE ANIMATION ONTHE BACKGROUND IN THE BACKGROUND WHEN THE 

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitTheGame()
	{
		Debug.Log ("Has Quit the game");
		Application.Quit();
	}
}
