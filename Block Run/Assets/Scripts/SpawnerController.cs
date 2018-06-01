
using UnityEngine;
using System.Collections;

public class SpawnerController : MonoBehaviour {

	private float spawnCooldown = 0f;
	private Vector3 spawnPos;
	private PauseManager pauseManager;
	private DifficultyManager difficultyManager;

	public int spawnWhat;
	public GameObject[] easyPrefabs;
	public GameObject[] mediumPrefabs;
	public GameObject[] hardPrefabs;
	public GameObject[] veryHardPrefabs;
	public bool canSpawn = true;

	void Awake () {
		spawnPos = transform.position;
		pauseManager = FindObjectOfType<PauseManager> ();
		difficultyManager = FindObjectOfType<DifficultyManager> ();
	}

	void Update () {
		if (pauseManager.gameStart) {
			spawnCooldown -= Time.deltaTime;

			if (spawnCooldown <= 0 && canSpawn) {
				spawnWhat = difficultyManager.SpawnChance ();

				if (spawnWhat == 1) {
					StartCoroutine ("SpawnEasyBlock");
				} else if (spawnWhat == 2) {
					StartCoroutine ("SpawnMediumBlock");
				} else if (spawnWhat == 3) {
					StartCoroutine ("SpawnHardBlock");
				} else if (spawnWhat == 4) {
					StartCoroutine ("SpawnVeryHardBlock");
				} 

				spawnCooldown = 2f;
			}
		}
	}

	IEnumerator SpawnEasyBlock () {
		int spawnChance = Random.Range (0, easyPrefabs.Length);

		GameObject blockObj = Instantiate (easyPrefabs[spawnChance], spawnPos, Quaternion.identity);
		blockObj.transform.position = spawnPos;

		if (blockObj.activeSelf) {
			canSpawn = false;
		}

		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator SpawnMediumBlock () {
		int spawnChance = Random.Range (0, mediumPrefabs.Length);

		GameObject blockObj = Instantiate (mediumPrefabs[spawnChance], spawnPos, Quaternion.identity);
		blockObj.transform.position = spawnPos;

		if (blockObj.activeSelf) {
			canSpawn = false;
		}

		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator SpawnHardBlock () {
		int spawnChance = Random.Range (0, hardPrefabs.Length);

		GameObject blockObj = Instantiate (hardPrefabs[spawnChance], spawnPos, Quaternion.identity);
		blockObj.transform.position = spawnPos;

		if (blockObj.activeSelf) {
			canSpawn = false;
		}

		yield return new WaitForSeconds (0.1f);
	}

	IEnumerator SpawnVeryHardBlock () {
		int spawnChance = Random.Range (0, veryHardPrefabs.Length);

		GameObject blockObj = Instantiate (veryHardPrefabs[spawnChance], spawnPos, Quaternion.identity);
		blockObj.transform.position = spawnPos;

		if (blockObj.activeSelf) {
			canSpawn = false;
		}

		yield return new WaitForSeconds (0.1f);
	}

}
