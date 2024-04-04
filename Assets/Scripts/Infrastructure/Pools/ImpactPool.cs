using UnityEngine;
using Infrastructure.AssetManagement;

public class ImpactPool : BasePool<GameObject, GameObject>
{
    private readonly AssetProvider _assetProvider;
    private const int DefaultPoolSize = 16;

    public ImpactPool(AssetProvider assetProvider)
    {
        _assetProvider = assetProvider;
    }

    public void Initialize()
    {
        Fill(DefaultPoolSize, _assetProvider.Load<GameObject>(AssetPath.ImpactEffect));
    }
    protected override GameObject CreateObject(GameObject prefab)
    {
        return Object.Instantiate(prefab);
    }

    protected override void Deactivate(GameObject obj)
    {
        obj.SetActive(false);
    }

    protected override void Activate(GameObject obj)
    {
        obj.SetActive(true);
    }
}
