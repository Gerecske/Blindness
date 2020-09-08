using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MouseLook : MonoBehaviour
{

    public InputAction wasd;
	public InputAction mouse;

	public float mSens = 100f;
	public Transform playerBody;

	public float speed = 12f;
	public float gravity = -9.81f;

	Vector3 velocity;

	float xRotation = 0f;

	public CharacterController controller;
	void OnEnable()
	{
        wasd.Enable();
		mouse.Enable();
	}

	void OnDisable()
	{
        wasd.Disable();
		mouse.Disable();
	}

	void Start()
	{
		Cursor.lockState = CursorLockMode.Locked;
	}

	void Update()
    {
        Vector2 inputVector = wasd.ReadValue<Vector2>();
		Vector3 finVector = new Vector3();
		finVector.x = inputVector.x * speed * -1f;
		finVector.z = inputVector.y * speed;

		Vector3 move = playerBody.right * finVector.x + playerBody.forward * finVector.z;

		controller.Move(move * speed * Time.deltaTime);

		velocity.y += gravity * Time.deltaTime;

		controller.Move(velocity * Time.deltaTime);

		Vector2 inputMVector = mouse.ReadValue<Vector2>();

		float mouseX = inputMVector.x * mSens * Time.deltaTime;
		float mouseY = inputMVector.y * mSens * Time.deltaTime;

		xRotation -= mouseY;
		xRotation = Mathf.Clamp(xRotation, -90f, 90f);

		transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
		playerBody.Rotate(Vector3.up * mouseX);
	}
}
