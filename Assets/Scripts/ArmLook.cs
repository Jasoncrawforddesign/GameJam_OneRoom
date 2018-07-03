using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmLook : MonoBehaviour {

	[SerializeField]
	private GameObject playerSprite;

	[SerializeField]
	private GameObject armSprite;
	
	
	// Update is called once per frame
	void Update () {
		ArmLookAt();
		ArmSpriteFlip();

	}

	void ArmLookAt()
	{
		Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
		diff.Normalize();

		float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.Euler(0f, 0f, rot_z);


	}

	void ArmSpriteFlip()
	{
		Vector3 CheckMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
		if (CheckMousePos.x < .5f)
		{
			armSprite.GetComponent<SpriteRenderer>().flipY = true;
			playerSprite.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (CheckMousePos.x > .5f)
		{
			armSprite.GetComponent<SpriteRenderer>().flipY = false;
			playerSprite.GetComponent<SpriteRenderer>().flipX = false;
		}


	}
}
