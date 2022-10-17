using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class UserData
{
    private const string Level_Number = "user_level_numbers";
    private const string Coins_Number = "user_coin_number";
    private const string Sound_Setting = "user_sound_setting";
    private const string Vibratiion_Setting = "user_vibration_setting";

    private const string Remove_ads = "remove_ads";

    public static int LevelNumber
    {
        get => SDKPlayerPrefs.GetInt(Level_Number, 1);
        set => SDKPlayerPrefs.SetInt(Level_Number, value);
    }

    public static int CoinsNumber
    {
        get => SDKPlayerPrefs.GetInt(Coins_Number, 0);
        set => SDKPlayerPrefs.SetInt(Coins_Number, value);
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