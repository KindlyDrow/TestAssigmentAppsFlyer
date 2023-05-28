using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Saver
{
    public const string MUSICVOLUMEPLAYERPREFS = "MusicVolumePlayerPrefs";
    public const string SOUNDEFFECTSVOLUMEPLAYERPREFS = "SoundEffectsVolumePlayerPrefs";
    public const string DIFFICULTYPLAYERPREFS = "DifficaltyPlayerPrefs";

    public static bool HasData(string key)
    {
        return PlayerPrefs.HasKey(key);
    }

    public static void SaveData(string key, int value)
    {
        PlayerPrefs.SetInt(key, value);
    }

    public static int LoadData(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
}
