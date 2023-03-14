//----------------------------------------------
//            Realistic Car Controller
//
// Copyright © 2014 - 2020 BoneCracker Games
// http://www.bonecrackergames.com
// Buğra Özdoğanlar
//
//----------------------------------------------

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BCG_FPSController : MonoBehaviour {

	#region Controller

	public float speed = 10.0f;

	private float inputMovementY;
	private float inputMovementX;

	#endregion

	#region Camera
	public Camera characterCamera;
	public float sensitivity = 5.0f;
	public float smoothing = 2.0f;

	private Vector2 mouseInputVector;

	// smooth the mouse moving
	private Vector2 smoothV;
	#endregion

	void Start () {

		if(!characterCamera)
			characterCamera = GetComponentInChildren<Camera> ();

	}

	void Update(){

		Inputs ();
		Controller ();
		Camera ();

	}

	private void Inputs(){

		//if (RCC_Settings.Instance.controllerType != RCC_Settings.ControllerType.Mobile) {

		//	inputMovementY = Input.GetAxis ("Vertical") * speed * Time.deltaTime;
		//	inputMovementX = Input.GetAxis ("Horizontal") * speed * Time.deltaTime;

		//	// Mouse delta
		//	var mouseDelta = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
		//	mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

		//	// the interpolated float result between the two float values
		//	smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
		//	smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);

		//	// incrementally add to the camera look
		//	mouseInputVector += smoothV;
		//	mouseInputVector = new Vector3 (mouseInputVector.x, Mathf.Clamp(mouseInputVector.y, -75f, 75f));

		//} else {

			inputMovementY = BCG_MobileCharacterController.move.y * speed * Time.deltaTime;
			inputMovementX = BCG_MobileCharacterController.move.x * speed * Time.deltaTime;

			// Mouse delta
			var mouseDelta = new Vector2(BCG_MobileCharacterController.mouse.x, BCG_MobileCharacterController.mouse.y);
			mouseDelta = Vector2.Scale(mouseDelta, new Vector2(sensitivity * smoothing, sensitivity * smoothing));

			// the interpolated float result between the two float values
			smoothV.x = Mathf.Lerp(smoothV.x, mouseDelta.x, 1f / smoothing);
			smoothV.y = Mathf.Lerp(smoothV.y, mouseDelta.y, 1f / smoothing);

			// incrementally add to the camera look
			mouseInputVector += smoothV;
			mouseInputVector = new Vector3 (mouseInputVector.x, Mathf.Clamp(mouseInputVector.y, -75f, 75f));

		//}

	}

	private void Controller(){

		transform.Translate(inputMovementX, 0, inputMovementY);

		// turn on the cursor
		if (Input.GetKeyDown("escape"))
			Cursor.lockState = CursorLockMode.None;

	}

	private void Camera () {

		characterCamera.transform.localRotation = Quaternion.AngleAxis(-mouseInputVector.y, Vector3.right);
		transform.localRotation = Quaternion.AngleAxis(mouseInputVector.x, transform.up);

	}

}