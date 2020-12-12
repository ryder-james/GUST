using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Die : MonoBehaviour {
	private Rigidbody rb;

	private void Awake() {
		rb = GetComponent<Rigidbody>();
	}

	public void Stop() {
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
	}

	public void Shake() {
		Vector3 vel = Random.insideUnitSphere;
		vel.y += 1;
		vel.y *= 0.5f;
		rb.AddForce(vel * 15, ForceMode.Impulse);
	}
}
