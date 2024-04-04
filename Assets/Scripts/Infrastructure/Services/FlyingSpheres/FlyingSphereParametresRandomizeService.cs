using UnityEngine;

public class FlyingSphereParametresRandomizeService 
{ 
    private readonly SpawnPreferences _spawnPreferences;

    public FlyingSphereParametresRandomizeService(SpawnPreferences spawnPreferences)
    {
        _spawnPreferences = spawnPreferences;
    }
    public void RandomizeParametres(FlyingSphereDataHolder dataHolder)
    {
        float randomValue = Random.value;
        float sizeModif = Mathf.Lerp(_spawnPreferences.MinSize, _spawnPreferences.MaxSize, randomValue);
        Vector3 targetSize = Vector3.one * sizeModif;
        dataHolder.Transform.localScale = targetSize;
        dataHolder.Radius = sizeModif / 2;
        dataHolder.Speed = Mathf.Lerp(_spawnPreferences.MaxSpeed, _spawnPreferences.MinSpeed, randomValue);
        dataHolder.Points = Mathf.Lerp(_spawnPreferences.MaxPoints, _spawnPreferences.MinPoints, randomValue);
    }
}
