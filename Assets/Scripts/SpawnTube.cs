using UnityEngine;

public class SpawnTube : MonoBehaviour {
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject tube;
    [SerializeField] private float waitForSpawn;

    private float _spawnTimer;

    private void Update() {
        if (!Player.stopGame)
            SpawnPipe();
    }

    private void Spawn() {
        Instantiate(tube, spawnPoint);
        _spawnTimer = 0f;
    }

    private void SpawnPipe() {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer > waitForSpawn)
            Spawn();
    }
}