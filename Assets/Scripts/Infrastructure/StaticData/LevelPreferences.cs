using UnityEngine;

[CreateAssetMenu(fileName = "LevelPreferences", menuName = "Preferences/Create Level Preferences")]
public class LevelPreferences : ScriptableObject
{
    public float RoundDuration = 30f;
    public float SpeedIncreaser = 1.2f;
    public float SpeedUpDelay = 1f;
}
