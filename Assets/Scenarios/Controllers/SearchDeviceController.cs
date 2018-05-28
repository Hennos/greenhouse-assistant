using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GreenhouseUI.Services.SearchDevice;
using GreenhouseUI.Utils.Stream;

namespace GreenhouseUI {
  public enum SearchDeviceState {
    RUN_SERVICE,
    START_SEARCHING,
    STOP_SEARCHING,
    STOP_SERVICE
  }

  public class SearchDeviceController : MonoBehaviour
  {
    private ISearchDeviceService _service = new TestSearchDeviceService();
    private IStream<SearchDeviceState> _stream;

    private Coroutine _watchFoundDevice;

    [SerializeField] MainController mainController;

    private void Awake()
    {
      _stream = CreateStateStream();
    }

    private void OnEnable()
    {
      PushNextState(SearchDeviceState.RUN_SERVICE);

      Messenger.AddListener(UIEvent.START_SEARCH_DEVICES, OnStartSearching);
      Messenger.AddListener(UIEvent.STOP_SEARCH_DEVICES, OnStopSearching);
    }

    private void OnDisable()
    {
      if (_watchFoundDevice != null) {
        StopCoroutine(_watchFoundDevice);
        _watchFoundDevice = null;
      }

      PushNextState(SearchDeviceState.STOP_SERVICE);

      Messenger.RemoveListener(UIEvent.START_SEARCH_DEVICES, OnStartSearching);
      Messenger.RemoveListener(UIEvent.STOP_SEARCH_DEVICES, OnStopSearching);
    }

    private void OnStartSearching()
    {
      PushNextState(SearchDeviceState.START_SEARCHING);

      if (_watchFoundDevice == null) {
        _watchFoundDevice = StartCoroutine("WatchFoundDevice");
      }
    }

    private void OnStopSearching()
    {
      PushNextState(SearchDeviceState.STOP_SEARCHING);

      StopCoroutine(_watchFoundDevice);
      _watchFoundDevice = null;
    }

    private IEnumerator WatchFoundDevice()
    {
      for (;;)
      {
        mainController.SetFoundDevices(_service.Devices);
        yield return new WaitForSeconds(10f);
      }
    }

    private IStream<SearchDeviceState> CreateStateStream()
    {
      if (_stream != null) { return _stream; }

      var taskRunService = Task.Create(_service.RunService);
      var taskStartSearching = Task.Create(_service.StartSearching);
      var taskStopSearching = Task.Create(_service.StopSearching);
      var taskStopService = Task.Create(_service.StopService);

      var resolveRunService = 
        Resolver.Create<SearchDeviceState>(previous => previous == SearchDeviceState.STOP_SERVICE);
      var resolveStartSearching =
        Resolver.Create<SearchDeviceState>(
          (previous) => {
            return (previous == SearchDeviceState.RUN_SERVICE) || (previous == SearchDeviceState.STOP_SEARCHING);
          });
      var resolveStopSearching =
        Resolver.Create<SearchDeviceState>(
          previous => previous == SearchDeviceState.START_SEARCHING
        );
      var resolveStopService =
        Resolver.Create<SearchDeviceState>(
          previous => previous != SearchDeviceState.STOP_SERVICE
        );

      var transitions = TransitionPool.Create(
        new Dictionary<SearchDeviceState, ITransition<SearchDeviceState>> {{
            SearchDeviceState.RUN_SERVICE,
            Transition.Create<SearchDeviceState>(
              SearchDeviceState.RUN_SERVICE, taskRunService, resolveRunService
            )
          }, {  
            SearchDeviceState.START_SEARCHING,
            Transition.Create<SearchDeviceState>(
              SearchDeviceState.START_SEARCHING, taskStartSearching, resolveStartSearching
            )
          }, {
            SearchDeviceState.STOP_SEARCHING,
            Transition.Create<SearchDeviceState>(
              SearchDeviceState.STOP_SEARCHING, taskStopSearching, resolveStopSearching
            )
          }, {
            SearchDeviceState.STOP_SERVICE,
            Transition.Create<SearchDeviceState>(
              SearchDeviceState.STOP_SERVICE, taskStopService, resolveStopService
            )
          }
        }
      );

      return Stream.Create(SearchDeviceState.RUN_SERVICE, transitions);
    }

    private void PushNextState(SearchDeviceState state)
    {
      _stream.Next(state);
    }
  }
}
