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
    // Дистанция остановки
    public float StopDistance = 1f;
    // Ссылка на другой скрипт
    public MonoBehaviour ObservationRotateSphere;
    void Start()
    {// Каким методом будет преследовать
        Player =GameObject.FindWithTag("Player").transform;
        // Назначение ИИ скорость передвижения
        Agent.speed = speed;
        // Назначение ИИ скорость вращения
        Agent.angularSpeed = speedR;
        // Ищет у объекта компонент
        Agent = GetComponent<NavMeshAgent>();
        // Устанавливает дистанцию остановки для робота (в навигации)*
        Agent.stoppingDistance = StopDistance;
    }
    void LateUpdate()
    {
       // Если преследуемый был найден
        if (Player != null)
        {// Дистанция от цели с точки объекта
            float DIS = Vector3.Distance(transform.position, Player.position);
            // Если дистанция меньше чем радиус остановления
            if (DIS < StopDistance)
            {// Скорость передвижения ИИ равно нулю
                Agent.speed = 0f;
                // Перестаёт сообщать координаты передвижения
                Agent.ResetPath();
                // Если был найден другой скрипт, то отлючает его работу-способность
                if (ObservationRotateSphere != null) { ObservationRotateSphere.enabled = false; }
            }// Если не выполняется условие, (дистанция больше чем радиус остановления теперь)
            else
            { // Назначение ИИ скорость передвижения
                Agent.speed = speed;
                // Сообщает координаты цели
            Agent.SetDestination(Player.position);
                // Если был найден другой скрипт, то включает его работу-способность
                if (ObservationRotateSphere != null) { ObservationRotateSphere.enabled = true; }
            }// Вычесляет направление цель и ИИ или Vector, от объекта к игроку* 
            Vector3 direction = Player.position - transform.position;
            // Если субъект и объект не надятся друг друге или Vector не равен нулю*
                if (direction != Vector3.zero)
                {
                // Поворачивает к цели модель объекта
                    Quaternion rotation = Quaternion.LookRotation(direction);
                // Плавный поворот и смещение на 90° по X
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotation * Quaternion.Euler(0f, 0f, 0f), speedR * Time.deltaTime);
                }
        }
    }
    private void OnDrawGizmosSelected()
    {// Цвет линии - жёлтый
        Gizmos.color = Color.yellow;
        // Линия виде сферы
        Gizmos.DrawWireSphere(transform.position, StopDistance);
    }
}
