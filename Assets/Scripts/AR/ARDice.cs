using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARDice : MonoBehaviour {
	[SerializeField] private GameObject placementIndicator = null;
	[SerializeField] private Die[] dice = null;

	private ARRaycastManager arRaycastManager;
	private Pose placementPose;
	private bool placementPoseIsValid = false;

	private void Start() {
		arRaycastManager = FindObjectOfType<ARRaycastManager>();
	}

	private void Update() {
		UpdatePlacementPose();
		UpdatePlacementIndicator();

		foreach (Die die in dice) {
			float distance = Mathf.Abs(placementIndicator.transform.position.y - die.transform.position.y);
			if (die.transform.position.y < placementIndicator.transform.position.y && distance > 0.5f) {
				PlaceAbove(die.transform);
			}
		}

		if (placementPoseIsValid && Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) {
			PlaceObject();
		}
	}

	private void PlaceObject() {
		foreach (Die die in dice) {
			die.Shake();
		}
	}

	private void PlaceAbove(Transform transform) {
		Vector2 offset = Random.insideUnitCircle * 4;
		transform.position = placementIndicator.transform.position + (Vector3.up * 3) + new Vector3(offset.x, 0, offset.y);
	}

	private void UpdatePlacementIndicator() {
		if (placementPoseIsValid) {
			placementIndicator.SetActive(true);
			placementIndicator.transform.SetPositionAndRotation(placementPose.position, placementPose.rotation);
			foreach (Die die in dice) {
				die.gameObject.SetActive(true);
			}
		} else {
			placementIndicator.SetActive(false);
			foreach (Die die in dice) {
				die.gameObject.SetActive(false);
			}
		}
	}

	private void UpdatePlacementPose() {
		Vector2 screenCenter = Camera.current.ViewportToScreenPoint(Vector2.one * 0.5f);
		List<ARRaycastHit> hits = new List<ARRaycastHit>();
		arRaycastManager.Raycast(screenCenter, hits, TrackableType.PlaneEstimated);

		placementPoseIsValid = hits.Count > 0;
		if (placementPoseIsValid) {
			placementPose = hits[0].pose;
		}
	}
}
