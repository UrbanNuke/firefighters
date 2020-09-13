using System;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary> Перечисление типов противника </summary>
internal enum FireTypes {
	FireSmall = 3,
	FireMiddle = 5,
	FireBig = 10
}

namespace Enemies {
	public class EnemyFire : MonoBehaviour {

		/// <summary> Тип противника "Огонь" </summary>
		private FireTypes _fireType;

		/// <summary> Кол-во жизней </summary>
		private byte _lives;

		/// <summary> Задержка для анимации </summary>
		private float _animationDelay;

		/// <summary> Префаб следующего типа противника "Огонь" после уничтожения </summary>
		public GameObject nextFirePrefab;

		// ссылки на компоненты gameObject
		private Animator _anim;
		private static readonly int Delay = Animator.StringToHash("delayAnimation");

		private void Start() {
			_anim = GetComponent<Animator>();
			foreach (Transform child in transform) {
				Enum.TryParse(child.name, out _fireType);
			}
			_animationDelay = Random.Range(0f, 2f);
			_anim.SetFloat(Delay, _animationDelay);
			_anim.SetBool(_fireType.ToString(), true);
			_lives = (byte) _fireType;
		}

		private void Update() {
			if (_lives == 0) {
				Destroy(gameObject);
			}
		}

		private void OnDestroy() {
			if (nextFirePrefab == null || _lives != 0) {
				return;
			}

			Vector3 rotation = new Vector3(0f, Random.Range(0, 360), 0f);
			Instantiate(nextFirePrefab, transform.position, Quaternion.Euler(rotation));
		}

		/// <summary> Обработка нанесения урона </summary>
		public void HitHandler() {
			if (_lives == 0) {
				return;
			}

			_lives -= 1;
		}
	}
}