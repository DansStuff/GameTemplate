using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

/*
 * Look controller for pivot based cameras (first or third person)
 * Attach this script to the camera pivot object (a child of the player object)
 * 
 * For a potential first person controller this would need to work with a player controller to match character animations to look direction
 * May also need to apply world rotation instead of local for that use case
 */
public class PlayerLookController : MonoBehaviour {

    [Tooltip("If the camera transform is behind the camera pivot transform (eg. a third person camera) then controls need to be inverted by default.")]
    public bool ThirdPersonInversion = true;

    public PlayerInput playerInput = null;
    public string LookActionName = "Look";

    [Range(-85f, 85f)]
    public float TiltMin = -10;

    [Range(-85f, 85f)]
    public float TiltMax = 60f;

    [Tooltip("The target transform for the camera controller, either the pivot or a child for a third person setup")]
    public Transform CamTransform;

    //internal state
    private float tilt = 0f;
    private float rot = 0f;
    private InputAction lookAction;

    void Start() {
        lookAction = playerInput.actions.FindAction(LookActionName);

        CamMatchTransform controller = Camera.main.gameObject.AddComponent<CamMatchTransform>();
        controller.targetTransform = CamTransform;
    }

    void Update() {

        Vector2 lookInput = lookAction.ReadValue<Vector2>();

        if (!ThirdPersonInversion) { lookInput *= -1f; }

        rot += lookInput.x;

        if (rot > 360f) {
            rot -= 360f;
        }
        if (rot < -360f) {
            rot += 360f;
        }

        tilt += lookInput.y;
        tilt = Mathf.Clamp(tilt, TiltMin, TiltMax);
        transform.localRotation = Quaternion.Euler(tilt, rot, 0f);

    }

}
