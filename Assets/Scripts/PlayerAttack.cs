using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAttack : MonoBehaviour {

	private GameObject gm;
	private GameObject audioSource;

	private bool countDownOn = false;

	[SerializeField]
	private AudioSource audio;

	[SerializeField]
	private AudioClip[] reloadSounds;

	private bool shootAllowed = true;


	//Fire Rate Counter //
	private float countDownStart;
	private float countDown;

	[SerializeField]
	private GameObject weapon;

	[SerializeField]
	private float weaponSpeed;

	//Life time of the weapon until destroyed
	[SerializeField]
	private float weaponLifeTime;

	// End of the arm, where the bullet is spawned from//
	[SerializeField]
	private GameObject endOfArm;

	[SerializeField]
	private float fireRate;


	// Use this for initialization
	void Start() {
		countDown = fireRate + 1;
	}

	// Update is called once per frame
	void Update() {
		countDown += Time.deltaTime;

		
		//ShootGun();
		

		if (shootAllowed == true)
		{
			ShootGun();
		}
	}

	public void ShootGun()
	{
		if (Input.GetMouseButtonDown(0))
		{

			SpawnWeapon();
			Debug.Log("Thrown");
			countDown = countDownStart;

		}

		if (Input.GetMouseButton(0))
		{

			if (countDown >= fireRate)
			{
				SpawnWeapon();
				Debug.Log("Thrown");
				countDown = countDownStart;

			}

		}

	}

	void SpawnWeapon()
	{

		Debug.Log("Weapon Moves....");

		GameObject Weapon = Instantiate(weapon, endOfArm.transform.position, endOfArm.transform.rotation) as GameObject;
		Weapon.GetComponent<Rigidbody2D>().AddForce(endOfArm.transform.right * weaponSpeed, ForceMode2D.Impulse);

		//destroy weapon after weaponLifeTime;
		Destroy(Weapon, weaponLifeTime);

		
	}

	public void ShootIsAllowed()
	{

		if (shootAllowed == false)
		{
			shootAllowed = true;
		}
		else if (shootAllowed == true)
		{
			shootAllowed = false;
		}
	}

}
