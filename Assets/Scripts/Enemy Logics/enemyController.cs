using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyController : MonoBehaviour
{
	//Animation components
	Animator animator;

	//Chase components
	public Transform player;
	public float playerDistance;
	public float MobDistanceRun = 4.0f;

	//Patroling components
	public Transform[] navPoint;
	private NavMeshAgent agent;
	public int destPoint = 0;

	public AudioSource audioSource;
	//public AudioClip screamAudio;
	//public AudioClip intenseChaseAudio;

	void Start()
	{
		agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		animator = GetComponent<Animator>();
		agent.autoBraking = false;

		audioSource = GetComponent<AudioSource>();
	}

	void Update()
	{

		playerDistance = Vector3.Distance(player.transform.position, transform.position);

		if (playerDistance < MobDistanceRun)
		{
			LookAtPlayer();
			audioSource.Play();
			//audioSource.PlayOneShot(screamAudio);
			Debug.Log("Seen");
			
			if (playerDistance < MobDistanceRun)
			{
				Chase();
			}
            else
            {
				GotoNextPoint();
			}
		}

		if (playerDistance > MobDistanceRun)
        {
			animator.SetBool("isDetected", false);
			animator.SetBool("isChasing", false);
			animator.SetBool("isPatroling", true);
		}

		if (agent.remainingDistance < 0.5f)
        {
			//animator.SetBool("isDetected", false);
			//animator.SetBool("isChasing", false);
			animator.SetBool("isPatroling", true);
			GotoNextPoint();
		}			
	}

    void LookAtPlayer()
    {
        transform.LookAt(player);
		animator.SetBool("isDetected", true);
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
		animator.SetBool("isPatroling", false);
	}
}