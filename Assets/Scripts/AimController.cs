using UnityEngine;

public class AimController : MonoBehaviour {
	void Update() {
		transform.position = Input.mousePosition;
	}
}