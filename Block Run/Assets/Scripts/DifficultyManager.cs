
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

	private SpawnerController spawnerController;
	private ScoreManager scoreManager;
	private PauseManager pauseManager;

	public int spawnChance;
	public int veryHardChance;
	public int hardChance;
	public int mediumChance;
	public int easychance;

	void Awake () {
		veryHardChance = 20;
		hardChance = 19;
		mediumChance = 17;
		easychance = 17;
		spawnerController = FindObjectOfType<SpawnerController> ();
		scoreManager = FindObjectOfType<ScoreManager> ();
		pauseManager = FindObjectOfType<PauseManager> ();
	}

	void Update () {
		if (pauseManager.gameStart) {
			if (scoreManager.currentScore == 0) {
				veryHardChance = 20;
				hardChance = 19;
				mediumChance = 17;
				easychance = 17;
			} else if (scoreManager.currentScore <= 2000f && (scoreManager.currentScore % 500f) == 0f) {
				veryHardChance += 0; // 20
				hardChance += -1; // 15
				mediumChance += -3; // 5
				easychance += -3; // 5
			} else if (scoreManager.currentScore <= 3500f && (scoreManager.currentScore % 500f) == 0f) {
				veryHardChance += -1; // 20
				hardChance += -2; // 15
				mediumChance += 0; // 5
				easychance += 0; // 5
			}
		}
	}

	public int SpawnChance () {
		spawnChance = Random.Range (1, 21);

		if (spawnChance >= veryHardChance) {
			return 4;
		} else if (spawnChance >= hardChance) {
			return 3;
		} else if (spawnChance >= mediumChance) {
			return 2;
		} else if (spawnChance < easychance) {
			return 1;
		} else {
			return 0;
		}
	}

}
