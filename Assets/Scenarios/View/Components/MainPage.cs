using System;
using System.Collections.Generic;
using UnityEngine;

namespace GreenhouseUI {
  public class MainPage : MonoBehaviour
  {
    [SerializeField] private Transform rootTransform;

    [SerializeField] private GameObject sectionMain;
    [SerializeField] private GameObject sectionAnalytics;
    [SerializeField] private GameObject sectionSettings;

    private Dictionary<SectionState, GameObject> m_pages = new Dictionary<SectionState, GameObject>();
    private GameObject m_rendered;
    private SectionController m_controller;

    private void Awake()
    {
      m_pages.Add(SectionState.MAIN_SECTION, sectionMain);
      m_pages.Add(SectionState.ANALYTICS_SECTION, sectionAnalytics);
      m_pages.Add(SectionState.SETTING_SECTION, sectionSettings);
    }

    private void OnEnable()
    {
      Messenger.AddListener(UIEvent.SECTION_STATE_CHANGED, OnSectionChanged);

      m_controller = GameObject.Find("SectionController").GetComponent<SectionController>();
      RenderPage(m_pages[m_controller.State]);
    }

    private void OnDisable()
    {
      Messenger.RemoveListener(UIEvent.SECTION_STATE_CHANGED, OnSectionChanged);
    }

    private void OnSectionChanged() {
      RenderPage(m_pages[m_controller.State]);
    }

    private void RenderPage(GameObject prefab) 
    {
      var content = this.GetComponentInChildren<Content>();
      content.Render(prefab);
    }
  }
}
