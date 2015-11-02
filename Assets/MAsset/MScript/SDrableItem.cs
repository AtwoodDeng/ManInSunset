using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class SDrableItem : UIDragDropItem {

	Vector3 oriPos;

	void Awake()
	{
		base.Awake();
		oriPos = transform.position;
	}

	protected override void OnDragDropStart ()
	{
		base.OnDragDropStart ();
		this.transform.parent = Main.Instance.GetTempRoot().transform;
		GetComponent<Rigidbody>().useGravity = false;
		GetComponent<Collider>().isTrigger = true;
	}

	protected override void OnDragDropMove (Vector2 delta)
	{
		base.OnDragDropMove (delta);
	}

	protected override void OnDragDropRelease (GameObject surface)
	{
		base.OnDragDropRelease (surface);
		this.transform.parent = Main.Instance.GetTemperImage().transform;
		GetComponent<Rigidbody>().useGravity = true;
		GetComponent<Collider>().isTrigger = false;
	}
}
