using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class Bootstrap : MonoBehaviour
{
    private EnemySpawner _spawner;

    private PauseHandler _pauseHandler;

    [SerializeField] public List<Transform> _spawnPoints;

    [Inject]
    private void Construct(EnemySpawner enemySpawner, PauseHandler pauseHandler)
    {
        _spawner = enemySpawner;
        
        _pauseHandler = pauseHandler;
    }

    private void Awake()
    {
        _spawner.Initialize(_spawnPoints);
        _spawner.StartWork();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            _pauseHandler.SetPause(true);

        if (Input.GetKeyDown(KeyCode.F))
            _pauseHandler.SetPause(false);
    }
}
