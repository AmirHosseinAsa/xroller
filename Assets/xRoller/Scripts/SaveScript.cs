using System.Collections;
using UnityEngine;
using XInputDotNetPure;

public class SaveScript : MonoBehaviour
{
    static bool isVibrationing = false;

    public static bool isGamePaused = false;
    public static bool isGameOver = false;
    public static bool isInFirstMenu = true;
    public static bool canJump = true;

    public static bool isIncreasingSpeed = false;

    public static PlayerIndex playerIndex;

    private void Update()
    {
        if (!isGameOver && !isGamePaused)
        {
            if (!isIncreasingSpeed)
            {
                isIncreasingSpeed = true;
                StartCoroutine("IncreaseBallSpeed");
            }
        }
        else
        {
            StopCoroutine("IncreaseBallSpeed");
        }

    }
    void FixedUpdate()
    {
        if (!isVibrationing)
        {
            GamePad.SetVibration(playerIndex, 0, 0);
        }
    }

    public static IEnumerator Viberation(float duration, float amount)
    {
        isVibrationing = true;
        GamePad.SetVibration(playerIndex, amount, amount);
        yield return new WaitForSeconds(duration);
        isVibrationing = false;
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    public static void StopViberation()
    {
        GamePad.SetVibration(playerIndex, 0, 0);
    }

    IEnumerator IncreaseBallSpeed()
    {
        while (isIncreasingSpeed)
        {
            yield return new WaitForSeconds(18f);
            if (GameManager.WAYSPEED - 7 <= -100)
                GameManager.WAYSPEED = -100;
            else
                GameManager.WAYSPEED -= 7;
        }
    }
}
