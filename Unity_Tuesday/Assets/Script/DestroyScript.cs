using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyScript : MonoBehaviour
{
	public bool isDest = false;

	void Start()
	{
	}
    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy")
		{
			Destroy(collision.gameObject);
			isDest = true;
		}

	}
}
