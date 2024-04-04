using UnityEngine;

public class FlyingSphereDataHolder 
{
    public readonly GameObject GameObject;
    public readonly Transform Transform;
    public float Speed;
    public float Radius;
    public float Points;

    public FlyingSphereDataHolder(FlyingSphere sphere)
    {
        GameObject = sphere.gameObject;
        Transform = sphere.transform;
    }
}
