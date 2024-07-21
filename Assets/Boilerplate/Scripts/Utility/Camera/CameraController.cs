using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* 
 * base class for all camera controllers, implement and attach to the main scene camera, set targetTransform by any means necessary
 */
public abstract class CameraController: MonoBehaviour {

	public Transform targetTransform;

	void LateUpdate() {
		if (targetTransform != null) {
			updateCameraTransform();

		}

	}

	protected abstract void updateCameraTransform();


}
