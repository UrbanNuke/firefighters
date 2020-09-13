using UnityEngine;

public class CameraController : MonoBehaviour {
	/// <summary> Объект за которым следит камера </summary>
	public Transform followObject;
	
	/// <summary> Угол обзора камеры относительно объекта </summary>
	public float angleOfView = 10f;
	/// <summary> Оффсет камеры относительно объекта по оси Z </summary>
	public float cameraOffset;

	private void LateUpdate() {
		var objectPosition = followObject.position;
		transform.position = new Vector3(objectPosition.x, objectPosition.y + angleOfView, objectPosition.z - cameraOffset);
		transform.LookAt(objectPosition);
	}
}