using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class InputManager : MonoBehaviour {
	/// <summary> CharacterController, которым будем управлять </summary>
	[SerializeField]
	private CharacterController charController = default;
	
	/// <summary> Скорость передвижения персонажа </summary>
	[SerializeField]
	private float movSpeed = 5f;
	
	

	private void Update() {
		Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

		charController.Move(move * (Time.deltaTime * movSpeed));
	}
}