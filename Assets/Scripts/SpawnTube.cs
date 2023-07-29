using UnityEngine;

public class SpawnTube : MonoBehaviour {
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private GameObject tube;
    [SerializeField] private float waitForSpawn;

    private float _spawnTimer;

    private void Update() {
        _spawnTimer += Time.deltaTime;

        if (_spawnTimer > waitForSpawn)
            Spawn();
    }

    private void Spawn() {
        Instantiate(tube, spawnPoint);
        _spawnTimer = 0f;
    }
}