using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class AssetProvider 
{
    public List<T> LoadAll<T>(string path) where T : Object
    {
        return Resources.LoadAll<T>(path).ToList();
    }

    public T Load<T>(string path) where T: Object
    {
        return Resources.Load<T>(path);
    }
}
