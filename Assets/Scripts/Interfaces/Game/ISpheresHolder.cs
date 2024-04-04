using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISpheresHolder 
{
    void Add(FlyingSphereDataHolder dataHolder);
    void Remove(FlyingSphereDataHolder dataHolder);
    IEnumerable<FlyingSphereDataHolder> Get();
}
