using UnityEngine;
using UnityEngine.EventSystems;

public class DefaultSelectedButton : MonoBehaviour
{
    [SerializeField] GameObject DefaultButton;
    bool changed = false;

    private void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if ((EventSystem.current.currentSelectedGameObject != DefaultButton && !changed)||Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Clear selected object
            EventSystem.current.SetSelectedGameObject(null);

            //set a new selected object
            EventSystem.current.SetSelectedGameObject(DefaultButton);

            changed = true;
        }
    }

    private void OnDisable()
    {
        changed = false;
    }
}
