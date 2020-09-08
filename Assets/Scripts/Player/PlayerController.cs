using UnityEngine;

namespace Player {
	public class PlayerController : MonoBehaviour {
		/// <summary> Скорость передвижения персонажа </summary>
		public float walkSpeed = 5f;
		
		// ссылки на другие компоненты gameObject
		private Rigidbody _rb;
		private Animator _animator;

		/// <summary> Значения ввода с клавиатуры игроком </summary>
		private Vector3 _inputMovement;
		
		// Закэшированные параметры анимации
		private static readonly int HorSpeed = Animator.StringToHash("horSpeed");
		private static readonly int VertSpeed = Animator.StringToHash("vertSpeed");
		
		private void Start() {
			_rb = GetComponent<Rigidbody>();
			_animator = GetComponent<Animator>();
		}
		
		private void Update() {
			_inputMovement = Vector3.zero;
			_inputMovement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
		}

		private void FixedUpdate() {
			_rb.velocity = _inputMovement * walkSpeed;
			_animator.SetFloat(HorSpeed, _inputMovement.x);
			_animator.SetFloat(VertSpeed, _inputMovement.z);
		}
	}
}