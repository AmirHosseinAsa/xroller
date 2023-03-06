using System.Collections;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool isPused = false;
    [SerializeField] GameObject PauseMenuOP;

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.JoystickButton7)) && !SaveScript.isGameOver && !SaveScript.isInFirstMenu)
        {
            isPused = !isPused;
            PauseMenuOP.SetActive(isPused);

            if (isPused)
                SaveScript.canJump = false;
            else StartCoroutine(EnableCanJump());


            Time.timeScale = isPused ? 0f : 1f;
            SaveScript.isGamePaused = isPused;
        }
    }
    public void Resume()
    {
        Time.timeScale = 1f;
        PauseMenuOP.SetActive(false);
        isPused = false;
        SaveScript.isGamePaused = false;

        StartCoroutine(EnableCanJump());
    }

    IEnumerator EnableCanJump()
    {
        yield return new WaitForEndOfFrame();
        SaveScript.canJump = true;
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
