using UnityEngine;
public class Spawn_EnemyAndBoss_Follow_Player : MonoBehaviour
{
    [Header("С скольки убийств появится босс")]
    public TMP_Scorekills_Enemy tMP_Scorekills_;
    public int ScoreKill;
    public int AllKill;

    public bool BossActive;
    // Минимальная точка появления
    public float minPRadius;
    // Максимальная точка появления
    public float maxPRadius;
    // Кого создает
    public GameObject enemyAND1;
    public GameObject enemyAND2;
    public GameObject boss3;

    public GameObject ObjectC;

    private Vector3 spawnPositionSapport;


    public GameObject SecuritySpawn;

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

        tMP_Scorekills_ = FindAnyObjectByType<TMP_Scorekills_Enemy>();
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
        // Назначение названия float для работы в пространстве "x" с Cosinus используя: разброс от 0 до PI * 2 и умножая на разброс от первого назначенного до второго, (без сокращений)
        float x = Mathf.Cos(angle) * distance;
        // Назначение названия float для работы в пространстве "z" с Sinus используя: разброс от 0 до PI * 2 и умножая на разброс от первого назначенного до второго, (без сокращений)
        float z = Mathf.Sin(angle) * distance;
        // Задается название для появления и равна, позиции где должен появится + смещение по x = Cosinus , y = 0, z = Sinus
        spawnPositionSapport = playerPC.position + new Vector3(x, 0f, z);

        GameObject[] Randoms = { enemyAND1, enemyAND2 };

        int IndexR = Random.Range(0, 2);

        GameObject RandomEnemy = Randoms[IndexR];
        ObjectC = RandomEnemy;

        Instantiate(SecuritySpawn, spawnPositionSapport, Quaternion.identity);
    }

    public void SpawnOthers()
    {
        if (activated)
        {
            Instantiate(ObjectC, spawnPositionSapport, Quaternion.identity);
            // Прибавление к счетчику врагов на единицу  
            amountEAB++;
        }

        if (ScoreKill >= AllKill && !BossActive)
        {
            Instantiate(boss3, spawnPositionSapport, Quaternion.identity);
            BossActive = true;
            ScoreKill = 0;
        }
    }
}
