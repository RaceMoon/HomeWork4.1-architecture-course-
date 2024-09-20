using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu (menuName =  "Configs/SpawnConfig", fileName = "SpawnConfig")]
public class SpawnSettingConfig : ScriptableObject
{
    [field: SerializeField, Range(0.1f, 10f)] public float SpawnCooldown { get; private set; }
}
