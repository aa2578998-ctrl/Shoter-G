using UnityEngine;
public class Spawn_EnemyAndBoss_Follow_Player : MonoBehaviour
{
    // Минимальная точка появления
    public float minPRadius;
    // Максимальная точка появления
    public float maxPRadius;
    // Кого создает
    public GameObject enemyANDboss;
    // Вокруг кого радиус появления
    public Transform playerPC;
    // Счетчик на количество врагов
    public float amountEAB;
    // Сколько будет равен цикл создание врага
    public float Timer;
    // Сам изменяющийся таймер
    public float currentTime;
    // Система контроля работа способности
    public bool activated;
   void Start()
    {// Изменяющийся таймер равен начальным показателям
        currentTime = Timer;
    }
    private void LateUpdate()
    {// Если изменяющийся таймер больше нуля
        if (currentTime > 0f)
        {// отнимает каждую секунду по единицы
            currentTime -= Time.deltaTime;
        }
        // Если таймер меньше нуля
        else
        {
            // Если система контроля активна
            if (activated)
            {// Запускает работу появления
                SpawnEnemyAndBoss();
            }
            // Изменяющийся таймер равен начальным показателям 
            currentTime = Timer;
        }
    }
    
    void SpawnEnemyAndBoss()
    {
        // Задается значение для работы по "x" и "z", и разброс значений от 0 до числа PI умноженная надвое, (без сокращений)
        float angle = Random.Range(0f, Mathf.PI * 2);
        // Задается значение для работы  по "x" и "z", и разброс значений от первого назначенного числа до второго назначенного, (без сокращений)
        float distance = Random.Range(minPRadius, maxPRadius);
        // Прибавление к счетчику врагов на единицу  
        amountEAB += 1f;
        // Назначение названия float для работы в пространстве "x" с Cosinus используя: разброс от 0 до PI * 2 и умножая на разброс от первого назначенного до второго, (без сокращений)
        float x = Mathf.Cos (angle) * distance;
        // Назначение названия float для работы в пространстве "z" с Sinus используя: разброс от 0 до PI * 2 и умножая на разброс от первого назначенного до второго, (без сокращений)
        float z = Mathf.Sin (angle) * distance;
        // Задается название для появления и равна, позиции где должен появится + смещение по x = Cosinus , y = 0, z = Sinus
        Vector3 spawnPosition = playerPC.position + new Vector3(x, 0f, z);
        // Создает самого врага, для позиции использует "spawnPosition" = место где должен появится,"Quaternion.identity" = значение для стандартного поворота, без поворота
        Instantiate(enemyANDboss, spawnPosition, Quaternion.identity);
    }
}
