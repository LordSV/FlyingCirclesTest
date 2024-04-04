using UnityEngine;

[CreateAssetMenu(fileName = "SpawnPreferences", menuName = "Preferences/Create Spawn Preferences")]
public class SpawnPreferences : ScriptableObject
{
    public float MinSize;
    public float MaxSize;
    public float MinSpeed;
    public float MaxSpeed;
    public float MinPoints;
    public float MaxPoints;
    public int SpawnAmount;
}
