using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class Start_Game : MonoBehaviour
{
    void LateUpdate()
    {
        if (Keyboard.current != null && Keyboard.current.enterKey.wasPressedThisFrame)
        {
            SceneManager.LoadScene("Scenes2");
        }
    }
}
