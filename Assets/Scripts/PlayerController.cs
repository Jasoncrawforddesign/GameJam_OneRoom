using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {



	[Header("Player Variables")]
	[SerializeField]
	private float movementSpeed;
	[SerializeField]
	private GameObject gm;
	[SerializeField]
	private GameObject audioSource;

	[Header("Health Variables")]
	public float startHealth = 100f;
	public float health;
	[SerializeField]
	Image healthBar;



	

	// Use this for initialization
	void Start () {
		gm = GameObject.FindGameObjectWithTag("GameController");

		health = startHealth;

	}
	
	// Update is called once per frame
	void Update () {

		MovePlayer();
		CheckHealth();


	}

	#region CheckHealth Function
	public void CheckHealth()
	{

		// if health is greater to equal to 100, health equals 100 //
		if (health >= 100)
		{
			health = 100;
		}

		// if health is less than or equal to 0, health equals //

		if(health <= 0)
		{
			health = 0;
		}
	}

	#endregion

	#region TakeDamage Function

	public void TakeDamage (float amount)
	{

		health -= amount;

		healthBar.fillAmount = health / startHealth;

		if (health <= 0)
		{
			Die();
		}


	}

	#endregion


	void Die()
	{
		//ENTER END SCENARIO HERE
	}

	#region MovePlayer Function
	public void MovePlayer()
	{


		// LEFT MOVEMENT //
		if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left.normalized * movementSpeed * Time.deltaTime;
		}

		// Right Movement //
		if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right.normalized * movementSpeed * Time.deltaTime;
		}


		// UPWARD MOVEMENT //
		if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up.normalized * movementSpeed * Time.deltaTime;
		}

		// DOWNWARD MOVEMENT //
		if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down.normalized * movementSpeed * Time.deltaTime;
		}

	}

	#endregion
}
