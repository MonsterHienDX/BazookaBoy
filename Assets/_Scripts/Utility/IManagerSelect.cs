using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IManagerSelect<T>
{
    public T Select(int id);
    public void UnSelectAll();
}
