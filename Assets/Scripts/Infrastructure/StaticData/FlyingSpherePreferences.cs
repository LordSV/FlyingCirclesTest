using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FlyingSpherePreferences", menuName = "Preferences/Create FlyingSphere Preferences")]
public class FlyingSpherePreferences : ScriptableObject
{
    public FlyingSphere SpherePrefab;
    public int PoolSize;
}
