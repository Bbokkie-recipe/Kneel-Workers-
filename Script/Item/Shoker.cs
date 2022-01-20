using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemboxes : MonoBehaviour
{
	public bool traped = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Enemy")
		{
			//Destroy(gameObject);
			BoxCollider boxCollider = GetComponent<BoxCollider>();
			boxCollider.enabled = false;
			//other.gameObject.SetActive(false); // 애너미 삭제, 확인 후에 이 줄 삭제해주세염 
			traped = true;
		}

	}

	// Update is called once per frame
	void Update()
	{
		transform.Rotate(new Vector3(0, -0.45f, 0));

		if (traped == true)
		{
			transform.Rotate(new Vector3(0, -8.45f, 0));
		}
	}
}
