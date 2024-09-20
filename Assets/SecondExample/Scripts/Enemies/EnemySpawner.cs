using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : IPause
{
    private float _spawnCooldown;

    private List<Transform> _spawnPoints;

    private EnemyFactory _enemyFactory;

    private Coroutine _spawn;

    private bool _isPaused;

    private MonoBehaviour _monoBehaviourObject;

    [Inject]
    private void Construct(SpawnSettingConfig spawnConfig, List<Transform> spawnPoints, EnemyFactory enemyFactory, PauseHandler pauseHandler, Bootstrap monoBehaviourObject)
    {
        _spawnCooldown = spawnConfig.SpawnCooldown;
        _spawnPoints = spawnPoints;
        _enemyFactory = enemyFactory;
        pauseHandler.Add(this);
        _monoBehaviourObject = monoBehaviourObject;
    }

    public void Initialize(List<Transform> spawnPoints)
    {
        _spawnPoints = spawnPoints;
    }
    public void StartWork()
    {
        StopWork();

        _spawn = _monoBehaviourObject.StartCoroutine(Spawn());
    }

    public void StopWork()
    {
        if (_spawn != null)
            _monoBehaviourObject.StopCoroutine(_spawn);
    }

    private IEnumerator Spawn()
    {
        float time = 0;

        while (true)
        {
            while (time < _spawnCooldown)
            {
                if (_isPaused == false)
                    time += Time.deltaTime;

                yield return null;
            }

            Enemy enemy = _enemyFactory.Get((EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length));
            enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
            time = 0;
        }
    }

    public void SetPause(bool isPaused) => _isPaused = isPaused;
}
