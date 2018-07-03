using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class EnemyController : MonoBehaviour {

	[SerializeField]
	private float speed;

	[SerializeField]
	private float damageAmount;

	[SerializeField]
	private GameObject playerGo;

	[SerializeField]
	private Transform playerT;

	[SerializeField]
	private List<GameObject> entranceList;

	private bool attackPlayer = false;

	[SerializeField]
	private GameObject thisEntrance;

	private int randomNumber;

	// Use this for initialization
	void Start () {

		foreach (GameObject entrance in GameObject.FindGameObjectsWithTag("Entrance"))
		{
			entranceList.Add(entrance);
		}

		randomNumber = Random.Range(0, 4);
		thisEntrance = entranceList[randomNumber];


		playerGo = GameObject.FindGameObjectWithTag("Player");
		playerT = playerGo.transform;

	}
	
	// Update is called once per frame
	void Update () {

		MoveTowards();

	}

	void MoveTowards()
	{
		if (thisEntrance.GetComponent<EntranceHealth>().active == true)
		{
			transform.position = Vector3.MoveTowards(transform.position, thisEntrance.transform.position, speed * Time.deltaTime);

		}

		if(thisEntrance.GetComponent<EntranceHealth>().active == false)
		{
			transform.position = Vector3.MoveTowards(transform.position, playerT.transform.position, speed * Time.deltaTime);

		}
	}


	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Entrance")
		{
			Debug.Log("did it work?");
			thisEntrance.GetComponent<EntranceHealth>().takeDamage(damageAmount);
		}
	}

	private void OnTriggerStay2D(Collider2D other)
	{
		if (other.tag == "Entrance")
		{
			Debug.Log("did it work?");
			thisEntrance.GetComponent<EntranceHealth>().takeDamage(damageAmount);
		}
	}

	
}
