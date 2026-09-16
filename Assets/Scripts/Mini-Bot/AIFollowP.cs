using System;
using UnityEngine;
using UnityEngine.AI;
public class AIFollowP : MonoBehaviour
{// Сам ИИ для автомических действий
    public NavMeshAgent Agent;
    // Скорость передвижения
    public float speed;
    // Скорость поворота
    public float speedR;
    // За кем преследует
    private Transform Player;
    // Ссылка на другой скрипт
    public Shot_MiniBot con;

    public TMP_Scorekills_Enemy Scorekills_Enemy;

    public TMP_HP_Player tMP_HP_Player;

    // Первоначальные значения управлением скорости движения
    public float CONspeed = 0f;
    // Управление скорости движения
    private float currentCONspeed = 0f;
    // Дистанция остановки
    public float StopDistance = 1f;
    public float DeathZone = 2f;
    // Ссылка на другой скрипт
    public MonoBehaviour ObservationRotateSphere;

    public Spawn_EnemyAndBoss_Follow_Player spawn_EnemyAndBoss_Follow_Player;

    void Start()
    {// Каким методом будет преследовать
        Player = GameObject.FindWithTag("Player").transform;
        // Ищет у объекта компонент
        Agent = GetComponent<NavMeshAgent>();
        // Назначение ИИ скорость вращения
        Agent.angularSpeed = speedR;
        // Устанавливает дистанцию остановки для робота (в навигации)*
        Agent.stoppingDistance = StopDistance;

        Scorekills_Enemy = FindAnyObjectByType<TMP_Scorekills_Enemy>();

        tMP_HP_Player = FindAnyObjectByType<TMP_HP_Player>();

        spawn_EnemyAndBoss_Follow_Player = FindAnyObjectByType<Spawn_EnemyAndBoss_Follow_Player>();
    }

    void Update()
    {
        if (transform.position.y <= DeathZone)
        {
            Destroy(gameObject);
            spawn_EnemyAndBoss_Follow_Player.amountEAB--;
        }
        // Если преследуемый был найден
        if (Player != null)
        {
            // Дистанция от цели с точки объекта
            float DIS = Vector3.Distance(transform.position, Player.position);
            // Если дистанция меньше чем радиус остановления
            if (DIS < StopDistance)
            {// Скорость передвижения ИИ равно нулю
                Agent.speed = 0f;
                // Если был найден другой скрипт, то отлючает его работу-способность
                if (ObservationRotateSphere != null) { ObservationRotateSphere.enabled = false; }
            }// Если не выполняется условие, (дистанция больше чем радиус остановления теперь)
            else
            { // Назначение ИИ скорость передвижения и контроль скорости от "currentCONspeed"
                Agent.speed = speed - currentCONspeed;
                // Если был найден другой скрипт, то включает его работу-способность
                if (ObservationRotateSphere != null) { ObservationRotateSphere.enabled = true; }
            }// Вычесляет направление цель и ИИ или Vector, от объекта к игроку* 

            // Сообщает координаты цели
            Agent?.SetDestination(Player.position);

            Vector3 direction = Player.position - transform.position;
            // Если субъект и объект не находятся друг друге или Vector не равен нулю*
            if (direction != Vector3.zero)
            {
                // Поворачивает к цели модель объекта
                Quaternion rotation = Quaternion.LookRotation(direction);
                // Плавный поворот и смещение на 90° по X
                transform.rotation = Quaternion.Lerp(transform.rotation, rotation * Quaternion.Euler(0f, 0f, 0f), speedR * Time.deltaTime);
            }
            // Если у другого скрипта заданный bool отключен
            if (con.StartS == false)
            {
                // Управление скорости будет равна первоначальной
                currentCONspeed = CONspeed;
            }
            // Если  у другого скрипта заданный bool включен
            else
            {
                // Управление скорости равен нулю
                currentCONspeed = 0f;
            }

        }
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("Projectile Pl"))
        {
            Destroy(gameObject);

            Scorekills_Enemy.ScoreKills();
        }
    }

    private void OnDrawGizmosSelected()
    {// Цвет линии - жёлтый
        Gizmos.color = Color.yellow;
        // Линия виде сферы
        Gizmos.DrawWireSphere(transform.position, StopDistance);
    }
}
