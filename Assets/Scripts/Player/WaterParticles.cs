using Enemies;
using UnityEngine;

public class WaterParticles : MonoBehaviour {
	private void OnParticleCollision(GameObject other) {
		EnemyFire enemyFire = other.GetComponent<EnemyFire>();
		if (enemyFire != null) {
			enemyFire.HitHandler();
		}
	}
}