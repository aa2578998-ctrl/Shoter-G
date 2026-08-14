using UnityEngine;
public class Observation : MonoBehaviour
{
    public float speedR = 1f; // 

    public GameObject Player; // 
    public Vector3 offsetRotate = new Vector3(0f, 0f, 0f); // 
    private void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player"); // 
    }
    void LateUpdate()
    {
        Vector3 direction = Player.transform.position - transform.position; // 
        Quaternion rotation = Quaternion.LookRotation(direction); // 
        
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation * Quaternion.Euler(offsetRotate), speedR * Time.deltaTime); //
    }
}
