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

    private const string User_level_number_test = "user_level_number_test";
    public static int LevelNumberTest
    {
        get => SDKPlayerPrefs.GetInt(User_level_number_test, 0);
        set => SDKPlayerPrefs.SetInt(User_level_number_test, value);
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

}