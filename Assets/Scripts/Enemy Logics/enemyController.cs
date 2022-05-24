using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{

	public Transform player;
	public float playerDistance;
	public float AIMoveSpeed;
	public float MobDistanceRun = 4.0f;

	public Transform[] navPoint;
	private NavMeshAgent agent;
	public int destPoint = 0;
	//public Transform goal;

	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		//agent.destination = goal.position;

		agent.autoBraking = false;

	}

	void Update()
	{

		playerDistance = Vector3.Distance(player.transform.position, transform.position);

		if (playerDistance < MobDistanceRun)
		{
			//LookAtPlayer();
			Debug.Log("Seen");

			if (playerDistance < MobDistanceRun)
			{
				Chase();
			}
			else
				GotoNextPoint();
		}

		if (agent.remainingDistance < 0.5f)
			GotoNextPoint();

		//if (playerDistance < awareAI)
		//{
		//	if (playerDistance < 2f)
		//	{
		//		Chase();
		//	}
		//	else
		//		GotoNextPoint();
		//}
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
		//transform.Translate(Vector3.forward * AIMoveSpeed * Time.deltaTime);

		Vector3 dirToPlayer = transform.position - player.transform.position;
		Vector3 newPos = transform.position - dirToPlayer;
		agent.SetDestination(newPos);
	}
}