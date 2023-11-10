using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyFSM : MonoBehaviour
{
    // Start is called before the first frame update
    public Sight sightSensor;
    public Transform baseTransform;
    public float BaseAttackDistance;
    public float playerAttackDistance = 2f;
    private NavMeshAgent agent;
    private float lastShotTime;
    public float fireRate = 1f;
    public GameObject checkpoints;
    public enum State
    {
        Patrol,
        Chase,
        Attack,
        Dead,
        BaseAttack
    }
    public State currentState;
    void Start()
    {
        
    }
    private void Awake()
    {
        currentState = State.BaseAttack;
        baseTransform = GameObject.Find("PlayerBase").transform;
        checkpoints = GameObject.Find("PatrolPoints");
        agent = GetComponentInParent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(currentState == State.Patrol){
            Patrol();
        }
        else if(currentState == State.Chase){
            Chase();
        }
        else if(currentState == State.Attack){
            Attack();
        }
        else if(currentState == State.BaseAttack){
            BaseAttack();
        }

    }
    void Patrol(){
        Debug.Log("Patrolling");
        if(checkpoints.transform.childCount == 0){
            currentState = State.BaseAttack;
            return;
        }
        if(sightSensor.detectedObject != null){
            if(sightSensor.detectedObject.tag == "Player"){
                currentState = State.Chase;
            }
        }
        // if the enemy is close enough to the next checkpoint, move to the next checkpoint
        float distanceToCheckpoint = Vector3.Distance(transform.position, checkpoints.transform.GetChild(0).transform.position);
        if(distanceToCheckpoint < 1f){
            // move to the next checkpoint
            Destroy(checkpoints.transform.GetChild(0).gameObject);
        }
        // move to the next checkpoint
        agent.SetDestination(checkpoints.transform.GetChild(0).transform.position);

    }
    void Chase(){
        Debug.Log("Chasing");
        agent.isStopped = false;
        if(sightSensor.detectedObject == null){
            currentState = State.Patrol;
            return;
        }
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer <= playerAttackDistance){
            currentState = State.Attack;
            return;
        }   
        agent.SetDestination(sightSensor.detectedObject.transform.position);
    }
    void Attack(){
        Debug.Log("Attacking");
        agent.isStopped = true;
        // if the player is close enough to attack, attack
        if(sightSensor.detectedObject == null){
            currentState = State.BaseAttack;
            return;
        }
        // look at the player
        transform.parent.LookAt(sightSensor.detectedObject.transform.GetChild(0).transform.position);
        transform.LookAt(sightSensor.detectedObject.transform.GetChild(0).transform.position);
        Shoot();
        float distanceToPlayer = Vector3.Distance(transform.position, sightSensor.detectedObject.transform.position);
        if(distanceToPlayer > playerAttackDistance){
            currentState = State.Chase;
        }
        
    }
    void BaseAttack(){
        Debug.Log("BaseAttack");
        if(sightSensor.detectedObject != null){
            if(sightSensor.detectedObject.tag == "Player"){
                currentState = State.Chase;
            }
        }
        float distanceToBase = Vector3.Distance(transform.position, baseTransform.position);
        if(distanceToBase > BaseAttackDistance){
            agent.SetDestination(baseTransform.position);
        }
    }
    void Shoot(){
        Debug.Log("Shoot");
        // if enough time has passed since the last shot, shoot
        float timeSinceLastShot = Time.time - lastShotTime;
        if(timeSinceLastShot < fireRate){
            
            return;
        }
        lastShotTime = Time.time;
        Instantiate(Resources.Load("Prefabs/EnemyEgg"), transform.position, transform.rotation);
    }

}
