using UnityEngine;
using System.Collections;

public class AttachOnCollision : MonoBehaviour {

	public string colliderTag = "MovingPlatform";
	public float unattachDelay = 2f; // unattach if we depart from the collider for awhile

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag (colliderTag))
		{
			CancelInvoke ();
			transform.SetParent (collision.transform);
		}
	}

	void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag (colliderTag))
		{
			Invoke ("Unattach", unattachDelay);
		}
	}

	public void Unattach()
	{
		transform.SetParent (null);
	}
}
