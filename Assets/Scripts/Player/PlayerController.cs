using UnityEngine;

namespace Player {
	public class PlayerController : MonoBehaviour {
		/// <summary> Скорость передвижения персонажа </summary>
		public float walkSpeed = 5f;
		
		// ссылки на другие компоненты gameObject
		private Rigidbody _rb;
		private Animator _animator;
		
		// камера и ее контроллер
		private Camera _camera;
		private CameraController _cameraController;

		/// <summary> Значения ввода движения с клавиатуры игроком </summary>
		private Vector3 _inputMovement;
		
		/// <summary> Место нахождения прицела </summary>
		private Vector3 _aimPosition;

		// Закэшированные параметры анимации
		private static readonly int HorSpeed = Animator.StringToHash("horSpeed");
		private static readonly int VertSpeed = Animator.StringToHash("vertSpeed");
		
		private void Start() {
			_rb = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();
			_camera = Camera.main;
			if (_camera != null) {
				_cameraController = _camera.GetComponent<CameraController>();
			}
		}
		
		private void Update() {
			_inputMovement = Vector3.zero;
			_inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized;

			Vector3 mousePos = Input.mousePosition;
			_aimPosition = _camera.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, _cameraController.angleOfView));
		}

		private void FixedUpdate() {
			Vector3 lookPos = _aimPosition - transform.position;
			lookPos.y = 0;
			var rotation = Quaternion.LookRotation(lookPos);
			_rb.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 5f);
			
			Vector3 movement = transform.TransformVector(_inputMovement * walkSpeed);
			movement.y = _rb.velocity.y;
			_rb.velocity = movement;
			_animator.SetFloat(HorSpeed, _inputMovement.x);
			_animator.SetFloat(VertSpeed, _inputMovement.z);
		}
	}
}