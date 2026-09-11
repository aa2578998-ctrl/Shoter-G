using UnityEngine;
public class Bomb_Forward_Projectile_Boss : MonoBehaviour
{
    public TMP_HP_Player playerHP;
    public float speed; // Скорость перемещения объекта
    public float speedControll; // Контролирует уменьшение скорости перемещения
    public float corrutineTime; // Через какое время уничтожится объект
    [Header("Settings Length")]
    public float distanceLaser; // Длина дистанции луча
    public bool Trigger; // Активиция и выключение луча
    public LayerMask Subject; // Слой объекта
    public LayerMask SubjectPlayer;
    private Rigidbody Rigidbody; // Физика объекта
    [Header("Settings Gravity")]
    public float gravityForce; // Скорость сила притяжения
    public int damage;

    public Transform Boom;

    private void Start()
    {
        playerHP = FindAnyObjectByType<TMP_HP_Player>();
        Rigidbody = GetComponent<Rigidbody>(); // Ищет компонент для изменений
    }
    private void FixedUpdate() // Обновляется в одинаковое время
    {
        Rigidbody.AddForce(Vector3.down * gravityForce, ForceMode.Acceleration); // Физика объекта . использующая дополнительную силу (Сила притяжения тянущая вниз * скорость сила притяжения, ускорение игнорирующую массу)
    }
    void LateUpdate()
    {
        Trigger = Physics.Raycast(transform.position, Vector3.forward, distanceLaser, Subject); // Контроль за активацией = Физика . с рисовкой (изменение позиции, смотрящую вперед, длина линии и на кого реагирует)
        if (speed > 0f) // Если скорость больше нуля
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);// Движится вперед * скорость перемещения * плавное изменение
            speed -= speedControll; // Уменьшение скорости
        }
        else // Если скорость меньше нуля
        {
            corrutineTime -= Time.deltaTime; // плавное уменьшение времени
            if (corrutineTime <= 0f) // Если время менише, равен нулю
            {
                Destroy(gameObject); // Уничтожает объект
                Instantiate(Boom, transform.position, Quaternion.identity);
            }
        }
        if (Trigger) // Если луч активен
        {
            speed = 0f; // Скрость равна нулю
        }
    }
    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerHP != null)
                speed = 0f;
            playerHP.TakeDamage(damage);
        }
    }
    private void OnDrawGizmosSelected() // Рисует вспомогательные элементы только в Scene
    {
        Gizmos.color = Color.yellow; // Цвет луча = желтый
        Gizmos.DrawWireSphere(transform.position, distanceLaser); // Луч виде сферы (изменение позиции, радиус шара);
    }
}
