using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    private const string Level_Number = "user_level_numbers";
    private const string Level_Sort_Mode_Number = "user_level_number_sort_mode";
    private const string Level_Hard_Mode_Number = "user_lv_number_hard";
    private const string Coins_Number = "user_coin_number";
    private const string Sound_Setting = "user_sound_setting";
    private const string Vibratiion_Setting = "user_vibration_setting";
    private const string Trail_Name = "user_car_trail";
    private const string Key_Numbers = "user_key_number";
    private const string Number_Of_HiddenBox = "number_of_hiddenbox";
    private const string Road_Makings_Name = "user_road_making";
    private const string Traffic_Light_Name = "user_traffic_light";
    private const string Trail_Name_Has_Get = "user_trail_get";
    private const string Undo_Number = "user_undo_number";
    private const string Level_Number_Prefab = "user_level_number_prefab";
    private const string Has_Rate = "user_stars_rate";
    private const string Hard_mode_user_progress = "user_hard_mode_progress";
    private const string Sort_mode_user_progress = "user_sort_mode_progress";
    private const string First_open = "user_first_open";
    private const string First_load_level_sort_1 = "user_first_load_level_sort_1";
    private const string Remove_ads = "remove_ads";

    public static int LevelNumber
    {
        get => SDKPlayerPrefs.GetInt(Level_Number, 1);
        set => SDKPlayerPrefs.SetInt(Level_Number, value);
    }

    public static int LevelNumberSortMode
    {
        get => SDKPlayerPrefs.GetInt(Level_Sort_Mode_Number, 1);
        set => SDKPlayerPrefs.SetInt(Level_Sort_Mode_Number, value);
    }

    public static int LevelNumberHardMode
    {
        get => PlayerPrefs.GetInt(Level_Hard_Mode_Number, 1);
        set => PlayerPrefs.SetInt(Level_Hard_Mode_Number, value);
    }

    public static int CoinsNumber
    {
        get => SDKPlayerPrefs.GetInt(Coins_Number, 0);
        set => SDKPlayerPrefs.SetInt(Coins_Number, value);
    }

    public static int UndoNumber
    {
        get => SDKPlayerPrefs.GetInt(Undo_Number, 3);
        set => SDKPlayerPrefs.SetInt(Undo_Number, value);
    }

    /// <summary>The level number of prefab, not user level number.
    /// This will handle load level is correct if the user level number > level number prefabs we have
    /// </summary>
    public static int LevelNumberPrefab
    {
        get => SDKPlayerPrefs.GetInt(Level_Number_Prefab, 1);
        set => SDKPlayerPrefs.SetInt(Level_Number_Prefab, value);
    }

    public static bool SoundSetting
    {
        get => SDKPlayerPrefs.GetBoolean(Sound_Setting, true);
        set => SDKPlayerPrefs.SetBoolean(Sound_Setting, value);
    }
    public static bool VibrationSetting
    {
        get => SDKPlayerPrefs.GetBoolean(Vibratiion_Setting, true);
        set => SDKPlayerPrefs.SetBoolean(Vibratiion_Setting, value);
    }

    public static string TrailName
    {
        get => SDKPlayerPrefs.GetString(Trail_Name, "None");
        set => SDKPlayerPrefs.SetString(Trail_Name, value);
    }
    public static string TrailNameHasGet
    {
        get => SDKPlayerPrefs.GetString(Trail_Name_Has_Get, "");
        set => SDKPlayerPrefs.SetString(Trail_Name_Has_Get, value);
    }

    public static int KeyNumbers
    {
        get => SDKPlayerPrefs.GetInt(Key_Numbers, 0);
        set => SDKPlayerPrefs.SetInt(Key_Numbers, value);
    }

    public static int NumberOfHiddenBox
    {
        get => SDKPlayerPrefs.GetInt(Number_Of_HiddenBox, 0);
        set => SDKPlayerPrefs.SetInt(Number_Of_HiddenBox, value);
    }

    public static int TrafficLightNumber
    {
        get => SDKPlayerPrefs.GetInt(Traffic_Light_Name, 0);
        set => SDKPlayerPrefs.SetInt(Traffic_Light_Name, value);
    }

    public static int RoadMakingNumber
    {
        get => SDKPlayerPrefs.GetInt(Road_Makings_Name, 0);
        set => SDKPlayerPrefs.SetInt(Road_Makings_Name, value);
    }

    public static int StarRateAmount
    {
        get => SDKPlayerPrefs.GetInt(Has_Rate, -1);
        set => SDKPlayerPrefs.SetInt(Has_Rate, value);
    }

    public static bool HasBuyNoAds
    {
        get => SDKPlayerPrefs.GetBoolean(Remove_ads, false);
        set => SDKPlayerPrefs.SetBoolean(Remove_ads, value);
    }

    public static string HardModeUserProgressData
    {
        get => SDKPlayerPrefs.GetString(Hard_mode_user_progress, "");
        set => SDKPlayerPrefs.SetString(Hard_mode_user_progress, value);
    }
    public static string SortModeUserProgressData
    {
        get => SDKPlayerPrefs.GetString(Sort_mode_user_progress, "");
        set => SDKPlayerPrefs.SetString(Sort_mode_user_progress, value);
    }

    public static bool FirstOpen
    {
        get => SDKPlayerPrefs.GetBoolean(First_open, true);
        set => SDKPlayerPrefs.SetBoolean(First_open, value);
    }

    public static bool FirstLoadLevelSort1
    {
        get => SDKPlayerPrefs.GetBoolean(First_load_level_sort_1, true);
        set => SDKPlayerPrefs.SetBoolean(First_load_level_sort_1, value);
    }
}