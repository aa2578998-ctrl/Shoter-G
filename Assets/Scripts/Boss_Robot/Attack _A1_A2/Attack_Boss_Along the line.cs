using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
public class Attack_Boss_Alongtheline : MonoBehaviour
{
    float Timers = 0;

    public Vector3 offset = new Vector3(0f, 0f, 0f); // Смещение в пространстве, (использован для вращения)
    public NavMeshAgent Agent; // Сам ИИ
    public float speedReatreat; // Скорость отступления
    public float speedRotation; // Скорость поворота
    public float attack1; // Для переходной фазы в пассивную
    public float attack1Active; // Сама аттака
    public float SpeedForward1A; // Скорость тарана
    public float distance; // Изменяющая расстояние для ограничения нападения
    public float DistanceComplete; // Ограничивает расстояние для тарана
    public AI_Boss_FollowAanOthers indent; // 1 ссылка на другой скрипт
    public Rotate_Sphere_Boss MaxPatrons; // 2 ссылка на другой скрипт
    public Object Attack_1_Area;
    public Transform Subject; // От кого отсупает
    public bool PreparationForAttack1; // Система запуска отступления

    public Sound_Manager sound_Manager;

    public bool GroundAnalis = false;
    int s_M = 0
    ;
    void Start()
    {
        Attack_1_Area.GetComponent<MeshRenderer>().enabled = false;

        sound_Manager = FindAnyObjectByType<Sound_Manager>();


        indent = FindAnyObjectByType<AI_Boss_FollowAanOthers>(); // 1 ищет объект с таким типом
        MaxPatrons = FindAnyObjectByType<Rotate_Sphere_Boss>(); // 2 ищет объект с таким типом
        Agent = GetComponent<NavMeshAgent>(); // Ищет для ИИ компонент
        Agent.speed = speedReatreat; // Задает скорость передвижения
        Agent.angularSpeed = speedRotation; // Задает скорость поворота
        Subject = GameObject.FindWithTag("Player").transform; // Transform = игровой объект с таким тегом . изменяем в тег
    }

    void Update()
    {
        if (PreparationForAttack1) // Если запуск активен
        {
            attack1 += Time.deltaTime; // Подготовка к атакке, увеличивает плавно
            if (Agent.enabled = true && Subject != null) // Если игрок найден
            {
                Attack_1_Area.GetComponent<MeshRenderer>().enabled = false;
                Vector3 PositionReatreat = Subject.position + transform.position; // Позиция игрока + изменения . позиции
                Agent.SetDestination(PositionReatreat); // Сообщает координаты игрока
                if (PositionReatreat != Vector3.zero) // Если позиции; игрока и ИИ, не находятся в друг друге
                {
                    Quaternion offsetRotate = Quaternion.Euler(offset); // Смещение градуса
                    Quaternion LookSubject = Quaternion.LookRotation(PositionReatreat); // На кого смотрит
                    transform.rotation = Quaternion.Slerp(transform.rotation, LookSubject * offsetRotate, speedRotation * Time.deltaTime); // Изменение вращения = работа с поворотами (изменение поворота, смотрит на игрока * на смещение, скорость поворота * на плавное изменение)
                }
            }
        }
        if (attack1 >= 3f) // Если переходная атакка => трем
        {
            if (s_M == 0)
            {
                s_M++;
                sound_Manager.Reproducte(4, gameObject, 0.5f);
            }

            PreparationForAttack1 = false; // Отключает отступление
            Agent.speed = 0f; // Скорость передвижения = нулю


            Vector3 PositionReatreat = Subject.position - transform.position; // Позиция игрока + изменения . позиции

            Attack_1_Area.GetComponent<MeshRenderer>().enabled = true;

            Quaternion offsetRotate = Quaternion.Euler(offset); // Смещение градуса
            Quaternion LookSubject = Quaternion.LookRotation(PositionReatreat); // На кого смотрит
            LookSubject.x = 0f;
            LookSubject.z = 0f;
            transform.rotation = Quaternion.Slerp(transform.rotation, LookSubject * offsetRotate, speedRotation * Time.deltaTime); // Изменение вращения = работа с поворотами (изменение поворота, смотрит на игрока * на смещение, скорость поворота * на плавное изменение)
            attack1Active += Time.deltaTime; // Сама атакка увеличевается плавно
        }

        if (attack1Active >= 1f) // Если атакка >= 1
        {
            Attack_1_Area.GetComponent<MeshRenderer>().enabled = false;
            attack1 = 0f;
            if (s_M == 1)
            {
                s_M++;
                sound_Manager.Reproducte(10, gameObject, 1f);
            }

            Agent.enabled = false;
            Agent.angularSpeed = 0f; // Скорость поворота равна нулю

            transform.Translate(Vector3.forward * SpeedForward1A * Time.deltaTime); // Перемещается вперед * скорость перемещения * плавное изменение
            distance += Time.deltaTime;

            if (distance >= DistanceComplete) //
            {
                GroundAnalis = true;
                Timers += Time.deltaTime;
                if (Timers > 4)
                {

                    attack1Active = 0f;
                    distance = 0f;

                    MaxPatrons.QuanityAttack1 = 0;

                    indent.enabled = true; //
                    Agent.enabled = false;

                    GroundAnalis = false;
                }
            }
        }
    }

    public void Attack1() //
    {
        if (indent != null) //
        {
            distance = 0f;
            GroundAnalis = false;

            Agent.enabled = true;
            Agent.speed = speedReatreat; //
            Agent.angularSpeed = speedRotation; //
            indent.enabled = false; //
            PreparationForAttack1 = true;
            s_M = 0;
        }
    }
}
