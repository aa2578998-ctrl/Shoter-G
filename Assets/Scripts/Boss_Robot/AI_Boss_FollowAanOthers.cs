using UnityEngine;
using UnityEngine.AI;
public class AI_Boss_FollowAanOthers : MonoBehaviour
{
    public float Speed_Y;
    public float Speed_Z;

    public Audio_Switced audio_Switced;

    // Ссылка на другой скрипт
    public Rotate_Sphere_Boss bustControllRotate;
    public HP_Slider_Boss hP_Slider_Boss;
    public Follow_Camera_Player Camera_Player;
    // Сам ИИ
    public NavMeshAgent Agent;
    // Скорость передвижения
    public float speedRun;
    // Увеличение скорости передвижения
    public float BustRun;
    // Начальное число увеличения движения
    public float SettingsBustRun;
    // Скорость поворота
    public float speedRotate;
    // Дистанция остановки ИИ
    public float DistanceStopping;
    // Система контроля увелечения перемещения
    public float DistanceBustSpeedRun;
    // Сдвиг по Vector (x, y, z) или в пространстве
    public Vector3 offsetRotation = new Vector3(0f, 0f, 0f);
    // Кого будет преследовать
    public Transform ObjectTrigger;

    public float DistanceStopFall;
    public float currentHP;

    void Start()
    {
        // Ищет компонент для ИИ
        Agent = GetComponent<NavMeshAgent>();
        // Назначение скорости передвижения
        Agent.speed = speedRun;
        // Назначение скорости вращения
        Agent.angularSpeed = speedRotate;

        ObjectTrigger = GameObject.FindWithTag("Player").transform;
        // Ищет игровой объект с таким типом 
        bustControllRotate = GameObject.FindAnyObjectByType<Rotate_Sphere_Boss>();

        hP_Slider_Boss = FindAnyObjectByType<HP_Slider_Boss>();
        hP_Slider_Boss.currentHP = 1;

        hP_Slider_Boss.Death_Boss = FindAnyObjectByType<Animation_Death_Boss>();

        Camera_Player = GameObject.FindAnyObjectByType<Follow_Camera_Player>();

        audio_Switced = FindAnyObjectByType<Audio_Switced>();
        audio_Switced.AudioBoss2();
    }

    void Update()
    {
        // Отдаление камеры по y и z
        if (Camera_Player.offset.y < 20f)
        {
            Camera_Player.offset.y += Speed_Y * Time.deltaTime;
        }

        if (Camera_Player.offset.z < 8f)
        {
            Camera_Player.offset.z += Speed_Z * Time.deltaTime;
        }

        if (Agent.enabled = true && ObjectTrigger != null) // Если игрок был найден
        {
            // Радиус для увеличения скорости = работа пространством . дистанция (изменение позиции, позиция игрока)
            float BustSpeedRun = Vector3.Distance(transform.position, ObjectTrigger.position);
            // Радиус для остановки скорости = работа пространством . дистанция (изменение позиции, позиция игрока)
            float Stopping = Vector3.Distance(transform.position, ObjectTrigger.position);
            // Если радиус меньше
            if (BustSpeedRun > DistanceBustSpeedRun)
            {
                bustControllRotate.BustSpeedRotate = 90f; // другой скрипт . увеличение скорости поворота = девяносто
                BustRun = SettingsBustRun; // Увелечение скрости = начальным значениям 
            }
            else // Если наоборот
            {
                bustControllRotate.BustSpeedRotate = 0f; // другой скрипт . увеличение скорости поворота = нулю
                BustRun = 0f; // Увелечение скрости = нулю
            }

            if (Stopping < DistanceStopping) // Если радиус больше
            {
                Agent.speed = 0f; // Скорость передвижения = нулю
                bustControllRotate.SpeedRotate = 0f; // другой скрипт . увеличение скорости = нулю
            }
            else // Если наоборот
            {
                // Другой скрипт; скорость поворота = начальному значению
                bustControllRotate.SpeedRotate = bustControllRotate.InitialSpeedRotate;
                // Сообщает координаты игрока
                Agent?.SetDestination(ObjectTrigger.position);
                // Скорость передвижения = скорости + прибавка к скорости
                Agent.speed = speedRun + BustRun;
                // Работа с пространством = позиция игрока - изменение позиции
                Vector3 direction = ObjectTrigger.position - transform.position;

                // Если позиция не равна нулю
                if (direction != Vector3.zero)
                {
                    // Смещение поворота
                    Quaternion offsetRotate = Quaternion.Euler(offsetRotation);
                    // Смотрит на игрока
                    Quaternion LookObject = Quaternion.LookRotation(direction);
                    // Нет смещения по x 
                    LookObject.x = 0f;
                    // Нет смещения по z
                    LookObject.z = 0f;
                    // Изменение вращения = работа с градусо . плавность поворота (изменение вращения, на кого смотрит * с смещением, скорость поворота * на плавное изменение)
                    transform.rotation = Quaternion.Slerp(transform.rotation, LookObject * offsetRotate, speedRotate * Time.deltaTime);
                }
            }
        }
        else
        {
            ObjectTrigger = GameObject.FindWithTag("Player").transform;
        }

        hP_Slider_Boss.enabled = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.gray; // Цвет луча = цвет . серый

        Gizmos.DrawWireSphere(transform.position, DistanceStopping); // Рисует луч остановки передвижения, виде сферы
        Gizmos.DrawWireSphere(transform.position, DistanceBustSpeedRun); // Рисует луч остановки прибавки скорости, виде сферы
    }
}
