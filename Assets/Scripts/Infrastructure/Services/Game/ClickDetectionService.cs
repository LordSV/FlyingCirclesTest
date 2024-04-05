using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class ClickDetectionService 
{
    private readonly FlyingSphereDestroyService _sphereDestroyService;
    private const float MaxRayDistance = 10f;
    private readonly Camera _camera;
    private readonly RaycastHit[] _raycastHits = new RaycastHit[20];
    private readonly CompositeDisposable _compositeDisposable = new();

    public ClickDetectionService(FlyingSphereDestroyService sphereDestroyService)
    {
        _sphereDestroyService = sphereDestroyService;
        _camera = Camera.main;
    }

    public void StartDetection()
    {
        Observable
            .EveryUpdate()
            .Subscribe(detect => Detect())
            .AddTo(_compositeDisposable);
    }
    public void StopDetection()
    {
        _compositeDisposable.Clear();
    }

    private void Detect()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            int size = Physics.RaycastNonAlloc(ray, _raycastHits, MaxRayDistance);
            for(int i = 0; i < size; i++)
            {
                RaycastHit hit = _raycastHits[i];
                if(hit.collider.TryGetComponent(out FlyingSphere sphere))
                {
                    _sphereDestroyService.FlyingSphereDestroy(sphere);
                }
            }
        }
    }
}
