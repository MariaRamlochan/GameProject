using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{

	//Animation variables
	Animator animator;


	//Chase variables
	public Transform player;
	public float playerDistance;
	//public float AIMoveSpeed;
	public float MobDistanceRun = 4.0f;

	//Patrol variables
	public Transform[] navPoint;
	private NavMeshAgent agent;
	public int destPoint = 0;

	void Start()
	{
		animator = GetComponent<Animator>();

		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.autoBraking = false;
	}

	void Update()
	{

		playerDistance = Vector3.Distance(player.transform.position, transform.position);

		if (playerDistance < MobDistanceRun)
		{
			LookAtPlayer();
			Debug.Log("Seen");

			//animator.SetBool("isDetected", true);

			if (playerDistance < MobDistanceRun)
			{
				Chase();
			}
            else
            {
				GotoNextPoint();
            }
				
		}

		if (agent.remainingDistance < 0.5f)
        {
			animator.SetBool("isChasing", false);

			GotoNextPoint();

			animator.SetBool("isPatroling", true);
		}
	}

    void LookAtPlayer()
    {
        transform.LookAt(player);
    }

    void GotoNextPoint()
	{
		if (navPoint.Length == 0)
			return;
		agent.destination = navPoint[destPoint].position;
		destPoint = (destPoint + 1) % navPoint.Length;
	}

	void Chase()
	{
		Vector3 dirToPlayer = transform.position - player.transform.position;
		Vector3 newPos = transform.position - dirToPlayer;
		agent.SetDestination(newPos);
		animator.SetBool("isChasing", true);
		//animator.SetBool("isDetected", false);
	}
}