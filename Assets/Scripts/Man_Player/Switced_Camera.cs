using UnityEngine;
using UnityEngine.InputSystem;

public class Switced_Camera : MonoBehaviour
{
    public Sound_Manager sound_Manager;
    public Camera camera1;
    public Camera camera2;

    void Start()
    {
        camera1.gameObject.SetActive(camera1.gameObject.activeSelf);
        camera2.gameObject.SetActive(!camera2.gameObject.activeSelf);
    }

    void LateUpdate()
    {
        if (Keyboard.current != null && Keyboard.current.uKey.wasPressedThisFrame)
        {
            sound_Manager.Reproducte(12, gameObject, 0.2f);
            camera1.gameObject.SetActive(camera2.gameObject.activeSelf);
            camera2.gameObject.SetActive(!camera1.gameObject.activeSelf);
        }
    }
}
