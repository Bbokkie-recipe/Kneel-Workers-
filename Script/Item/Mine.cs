using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
	public GameObject Explosion;
	public GameObject ExpLocate;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Explosion.SetActive(true);
			Instantiate(Explosion, ExpLocate.transform.position, Quaternion.identity);
			other.gameObject.SetActive(false);
			//Destroy(other.gameObject);
			Destroy(gameObject);
			//Explosion.SetActive(false);
		}
	}

	// Update is called once per frame
	void Update()
    {
        transform.Rotate(new Vector3(0, 0.35f, 0));
	}
}
