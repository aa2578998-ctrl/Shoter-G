using UnityEngine;
public class ObservationRotateSphere : MonoBehaviour
{
    public float speedG = 1f; // Скорость поворота

    public float CONspeedR = 0f; // Изначальное число контроля
    public float currentCONspeedR = 0f; // Для контроля скорости поворота

    public Shot_MiniBot con; // Ссылка на другой скрипт
   public void LateUpdate()
    {
        transform.Rotate(Vector3.right * (speedG - currentCONspeedR) * Time.deltaTime); // Вращается вперед * (скорость поворота - контроль скорости) * плавное изменение

        if (con.StartS == false) // Если атакка бота не активна
        {currentCONspeedR = CONspeedR; } // Контроль скорости = начальным значениям
        else // Если атаккующий режим не на перезарядке
        { currentCONspeedR = 0f; } // Контроль скорости = нулю
    }
}