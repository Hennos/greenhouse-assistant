using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace GreenhouseUI {
  // TODO: Стоит переписать, выглядит убого
  public class ElementsArea : MonoBehaviour
  {
    [SerializeField] private Transform rootTransform;

    [SerializeField] private GameObject prefabSensorsSet;
    [SerializeField] private GameObject prefabRegulatorsSet;
    [SerializeField] private GameObject prefabCustomGroupsSet;
    [SerializeField] private GameObject prefabDevicesSet;

    private ElementsController m_controller;
    private Dictionary<ElementsAreaState, string> m_elementsNameSets = new Dictionary<ElementsAreaState, string>
    {
      { ElementsAreaState.SENSORS, "SENSORS" },
      { ElementsAreaState.REGULATORS, "REGULATORS" },
      { ElementsAreaState.CUSTOM_GROUPS, "CUSTOM GROUPS" },
      { ElementsAreaState.DEVICES, "DEVICES" },
    };
    private Dictionary<ElementsAreaState, GameObject> m_elementsSets = new Dictionary<ElementsAreaState, GameObject>();

    private void Awake() 
    {
      m_elementsSets.Add(ElementsAreaState.SENSORS, prefabSensorsSet);
      m_elementsSets.Add(ElementsAreaState.REGULATORS, prefabRegulatorsSet);
      m_elementsSets.Add(ElementsAreaState.CUSTOM_GROUPS, prefabCustomGroupsSet);
      m_elementsSets.Add(ElementsAreaState.DEVICES, prefabDevicesSet);

      // TODO: Возможно, добавление контроллера с состоянием следует сделать отдельным подключаемым компонентом
      // Это позволит сделать его наличие обязательным для объекта
      m_controller = GameObject.Find("ElementsController").GetComponent<ElementsController>();

      Messenger.AddListener(UIEvent.ELEMENTS_SET_STATE_CHANGED, OnElementsSetChanged);
    }

    private void OnDestroy()
    {
      Messenger.RemoveListener(UIEvent.ELEMENTS_SET_STATE_CHANGED, OnElementsSetChanged);
    }

    private void Start() 
    {
      RenderWithState(m_controller.State);
    }

    private void OnElementsSetChanged()
    {
      RenderWithState(m_controller.State);
    }

    private void RenderWithState(ElementsAreaState state)
    {
      this.GetComponentInChildren<Header>().Title = m_elementsNameSets[state];
      this.GetComponentInChildren<Content>().Render(m_elementsSets[state]);
    }
  }
}
