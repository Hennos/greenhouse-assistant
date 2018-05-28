using System;

namespace GreenhouseUI {
  public static class UIEvent 
  {
    public static string REQUEST_MODEL_DATA = "REQUEST_MODEL_DATA";

    public static string START_SEARCH_DEVICES = "START_SEARCH_DEVICES";
    public static string STOP_SEARCH_DEVICES = "STOP_SEARCH_DEVICES";
    public static string PUSH_FOUND_DEVICES = "PUSH_FOUND_DEVICES";
    public static string FOUND_DEVICE_CHANGED = "FOUND_DEVICE_CHANGED";

    public static string PUSH_CHOOSE_DEVICE = "PUSH_CHOOSE_DEVICE";
    public static string REQUEST_CHOOSED_DEVICE_DATA = "REQUEST_CHOOSED_DEVICE_DATA";

    public static string APP_STATE_CHANGED = "APP_STATE_CHANGED";
    public static string SET_MODEL_DATA = "SET_MODEL_DATA";

    public static string APP_DATA_CHANGED = "APP_DATA_CHANGED";
    public static string SET_APP_STATE = "SET_APP_STATE";

    public static string SECTION_PUSH_CHOOSED = "SECTION_PUSH_CHOOSED";
    public static string SECTION_STATE_CHANGED = "SECTION_STATE_CHANGED";

    public static string ELEMENTS_SET_PUSH_CHOOSED = "ELEMENTS_SET_PUSH_CHOOSED";
    public static string ELEMENTS_SET_STATE_CHANGED = "ELEMENTS_SET_STATE_CHANGED";

    public static string CUSTOM_GROUP_PUSH_ADDED = "CUSTOM_GROUP_PUSH_ADDED";
    public static string CUSTOM_GROUP_SET_ADDED = "CUSTOM_GROUP_SET_ADDED";
    public static string CUSTOM_GROUP_PUSH_DELETED = "CUSTOM_GROUP_PUSH_DELETED";
    public static string CUSTOM_GROUP_DELETE_CHOISED = "CUSTOM_GROUP_DELETE_CHOISED";
  }
}
