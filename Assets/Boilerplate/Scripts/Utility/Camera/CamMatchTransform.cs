using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* basic camera behaviour to perfectly match a target transform
 * example use case: First person game where the camera matches the position of the character's head
 */

public class CamMatchTransform: CameraController {

	protected override void updateCameraTransform() {

		transform.position = this.targetTransform.position;
		transform.rotation = this.targetTransform.rotation;


	}

}
