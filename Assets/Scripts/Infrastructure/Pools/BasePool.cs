using System.Linq;
using System.Collections.Generic;
using TMPro;
using TMPro.EditorUtilities;
using Zenject;

public abstract class BasePool <TPrefab, TObject> 
{
    private readonly Stack<TObject> _pool = new();
    private TPrefab _prefab;

    public TObject Get()
    {
        if(_pool.Any() == false)
        {
            return CreateObject(_prefab);
        }
        TObject obj = _pool.Pop();
        Activate(obj);
        return obj;
    }

    public void Return(TObject obj)
    {
        Deactivate(obj);
        _pool.Push(obj);
    }

    protected void Fill(int size, TPrefab prefab)
    {
        _prefab = prefab;
        for(int i = 0; i < size; i++)
        {
            TObject obj = CreateObject(_prefab);
            Deactivate(obj);
            _pool.Push(obj);
        }
    }

    protected abstract TObject CreateObject(TPrefab prefab);
    protected abstract void Deactivate(TObject obj);
    protected abstract void Activate(TObject obj);
}
