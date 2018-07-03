using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceHealth : MonoBehaviour {

	[SerializeField]
	private float entranceHealth = 100;


	public bool active;
	// Use this for initialization
	void Start () {
		active = true;
	}

	// Update is called once per frame
	void Update()
	{
		if (entranceHealth <= 0)
		{
			this.gameObject.SetActive(false);
			active = false;
		}

	}

	public void takeDamage(float damageAmount)
	{
		entranceHealth -= damageAmount;
		
	}



}
