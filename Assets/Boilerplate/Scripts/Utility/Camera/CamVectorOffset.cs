using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* basic camera behaviour to view an object from an offset position
 * example use case: ARPG top-down view
 */

public class CamVectorOffset: CameraController {

	public Vector3 Offset = new Vector3(0f, -10f, -4.5f);

	protected override void updateCameraTransform() {

		transform.position = this.targetTransform.position + Offset;
		transform.LookAt(this.targetTransform, Vector3.up);


	}
}
