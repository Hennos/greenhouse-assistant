using System;
using System.Collections.Generic;
using UnityEngine;

using GreenhouseUI.ViewModel;

namespace GreenhouseUI {
  [RequireComponent(typeof(ViewModel.ModelReference))]
  [RequireComponent(typeof(Content))]
  public class AppEntry : MonoBehaviour
  {
    [SerializeField] private Transform rootTransform;

    private ViewModel.IGlobalStateModel m_model;

    [SerializeField] private GameObject pageMain;
    [SerializeField] private GameObject pageFoundDevice;
    [SerializeField] private GameObject pageAuthorize;

    private Dictionary<GlobalState, GameObject> m_pages = new Dictionary<GlobalState, GameObject>();

    private void OnEnable()
    {
      m_model = this.GetComponent<ViewModel.ModelReference>().Model;
      m_pages.Add(GlobalState.READY, pageMain);
      m_pages.Add(GlobalState.CHOOSE_DEVICE, pageFoundDevice);
      m_pages.Add(GlobalState.AUTHORIZE, pageAuthorize);

      Messenger.AddListener(UIEvent.APP_STATE_CHANGED, OnChangeAppState);
    }

    private void OnDisable() 
    {
      Messenger.RemoveListener(UIEvent.APP_STATE_CHANGED, OnChangeAppState);
    }

    private void Start()
    {
      RenderPage(m_pages[m_model.State]);
    }

    private void OnChangeAppState() {
      RenderPage(m_pages[m_model.State]);
    }

    private void RenderPage(GameObject prefabPage) 
    {
      var content = this.GetComponent<Content>();
      content.Render(prefabPage);
    }
  }
}
