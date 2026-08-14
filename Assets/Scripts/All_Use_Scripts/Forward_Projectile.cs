using UnityEngine;
public class Forward_Projectile : MonoBehaviour
{
    public float speed; // Скорость движения
    public float timeCorrutine; // Изменяющаяся время 
void LateUpdate()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime); // Перемещается вперед * скорость * плавное изменение
        if (timeCorrutine > 0f ) // Если время больше нуля
        {
            timeCorrutine -= Time.deltaTime; // плавно уменьшает время каждую секунду по одному
        }    
        else // Если время меньше нуля
        {
            Destroy(gameObject); // Уничтожает объект
        }
    }
}
