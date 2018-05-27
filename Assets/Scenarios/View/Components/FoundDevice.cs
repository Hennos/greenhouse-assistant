using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

namespace GreenhouseUI.Components {
  [RequireComponent(typeof(Button))]
  public class FoundDevice : MonoBehaviour
  {
    private IFoundDevice _data;

    [SerializeField] private Text title;
    [SerializeField] private Button button;

    public void Render(IFoundDevice data)
    {
      _data = data;
      title.text = data.Name;
    }

    private void OnEnable()
    {
      button.onClick.AddListener(OnChoose);
    }

    private void OnDisable()
    {
      button.onClick.RemoveListener(OnChoose);
    }

    private void OnChoose()
    {
      Messenger<IFoundDevice>.Broadcast(UIEvent.PUSH_CHOOSE_DEVICE, _data);
    }
  }
}
