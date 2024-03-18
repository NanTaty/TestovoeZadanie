﻿using UnityEngine;
using IsoTools.Physics;

namespace IsoTools.Examples.Kenney {
	[RequireComponent(typeof(IsoRigidbody))]
	public class PlayerController : MonoBehaviour {

		public float speed = 2.0f;

		IsoRigidbody _isoRigidbody = null;

		void OnIsoCollisionEnter(IsoCollision iso_collision) {
			Debug.Log(iso_collision.gameObject.name);
			if ( iso_collision.gameObject ) {
				var alient = iso_collision.gameObject.GetComponent<AlienBallController>();
				Debug.Log(iso_collision.gameObject.name);
				if ( alient ) {
					Destroy(alient.gameObject);
					Debug.Log("Destroyed alien");
				}
			}
		}

		void Start() {
			_isoRigidbody = GetComponent<IsoRigidbody>();
			if ( !_isoRigidbody ) {
				throw new UnityException("PlayerController. IsoRigidbody component not found!");
			}
		}

		void Update () {
			if ( Input.GetKey(KeyCode.A) ) {
				var velocity = _isoRigidbody.velocity;
				velocity.x = -speed;
				_isoRigidbody.velocity = velocity;
			}
			else if ( Input.GetKey(KeyCode.D) ) {
				var velocity = _isoRigidbody.velocity;
				velocity.x = speed;
				_isoRigidbody.velocity = velocity;
			}
			else if ( Input.GetKey(KeyCode.S) ) {
				var velocity = _isoRigidbody.velocity;
				velocity.y = -speed;
				_isoRigidbody.velocity = velocity;
			}
			else if ( Input.GetKey(KeyCode.W) ) {
				var velocity = _isoRigidbody.velocity;
				velocity.y = speed;
				_isoRigidbody.velocity = velocity;
			}
			//Debug.Log(_isoRigidbody.velocity);
		}
	}
}