using System.Collections;
using UnityEngine;

public class KeysTutorial : MonoBehaviour
{
    [SerializeField] GameObject Tutorial;

    [SerializeField] GameObject TextsForGamePad;
    [SerializeField] GameObject TextsForKeyboard;

    bool showedKeyBindings = false;
    bool isShowing = false;

    void Update()
    {
        if (SaveScript.isGameOver)
        {
            showedKeyBindings = false;
            StopCoroutine("HideKeyBindiingsAfterSeccounds");
        }

        if (!SaveScript.isInFirstMenu && !SaveScript.isGameOver)
        {
            if (showedKeyBindings == false)
            {
                isShowing = true;
                StartCoroutine("HideKeyBindiingsAfterSeccounds");
            }
            else if (SaveScript.isGamePaused)
                isShowing = true;
            else if (showedKeyBindings)
                isShowing = false;
        }
        else if (SaveScript.isGameOver)
            isShowing = false;

        Tutorial.SetActive(isShowing);
        TextsForGamePad.SetActive(Input.GetJoystickNames().Length > 0);
        TextsForKeyboard.SetActive(Input.GetJoystickNames().Length == 0);
    }
    IEnumerator HideKeyBindiingsAfterSeccounds()
    {
        yield return new WaitForSeconds(15f);
        Tutorial.SetActive(false);
        showedKeyBindings = true;
        isShowing = false;
    }
}
