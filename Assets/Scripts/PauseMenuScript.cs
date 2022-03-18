    using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseMenuScript : MonoBehaviour
{

    public void returnToMainMenu()
    {
        reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene("MainMenuScene");
    }

    public void restart()
    {
        reset();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void resume()
    {
        PlayerInputScript.locked = false;
        TimerScript.paused = false;
    }

    public void reset() {
        PlayerInputScript.locked = false;
        TimerScript.paused = false;
        GUIScript.blueScore = 0;
        LoadingZoneScript.resetBalls();
        TimerScript.currentTime = 150f;
        TimerScript.climbPoints = true;
        BallController.index = true;
        ShooterController.reset();
        EndScene.hideEndScene();
    }
}
