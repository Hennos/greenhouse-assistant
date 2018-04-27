using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  public interface IUnityElementsList
  {
    IEnumerable<string> Elements {  get; }
    bool Contains(string id);
    GameObject Get(string id);
    void Add(string id, GameObject element);
    void Remove(string id);
  }
}

