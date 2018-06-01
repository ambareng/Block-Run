
using UnityEngine;

public class DestroyerController : MonoBehaviour {

	private SpawnerController spawnController;

	void Awake () {
		spawnController = FindObjectOfType<SpawnerController> ();
	}

	void OnTriggerEnter2D (Collider2D col) {
		if (col.tag == "Spawn Point Block") {
			spawnController.canSpawn = true;
			Destroy (col.gameObject);
		}
	}

}
