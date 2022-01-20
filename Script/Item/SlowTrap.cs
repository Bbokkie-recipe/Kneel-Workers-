using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTrap : MonoBehaviour
{
	public bool traped = false;
	private BoxCollider boxCollider;

	private void Start()
    {
		BoxCollider boxCollider = GetComponent<BoxCollider>();
	}
    private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			Destroy(gameObject);
		}
	}

	// Update is called once per frame
	void Update()
    {
		transform.Rotate(new Vector3(0.1f, -0.45f, 0.3f));

		if (traped == true)
		{
			transform.Rotate(new Vector3(200f, -0.85f, 3f));
		}
	}

}
