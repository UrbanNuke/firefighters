using UnityEngine;

public class CameraController : MonoBehaviour {
	/// <summary> Объект за которым следит камера </summary>
	public Transform followObject;

	/// <summary> Угол обзора камеры относительно объекта </summary>
	public float angleOfView;
	/// <summary> Оффсет камеры относительно объекта по оси Z </summary>
	public float cameraOffset;
	/// <summary> Оффсет центральной точки относительно объекта по оси Z </summary>
	public float centerPointOffset;

	private void LateUpdate() {
		var objectPosition = followObject.position;
		transform.position = new Vector3(objectPosition.x, objectPosition.y + angleOfView, objectPosition.z - cameraOffset);
		var lookAt = new Vector3(objectPosition.x, objectPosition.y, objectPosition.z - centerPointOffset);
		transform.LookAt(lookAt);
	}
}