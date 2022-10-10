using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public static class CommonFunctions
{
    public static List<int> CountSubString(string subString, string dataString)
    {
        List<int> positions = new List<int>();
        int pos = 0;
        while ((pos < dataString.Length) && (pos = dataString.IndexOf(subString, pos)) != -1)
        {
            positions.Add(pos);
            pos += subString.Length;
        }
        return positions;
    }

    public static void EnableButton(Button button, bool enable)
    {
        button.interactable = enable;
    }

    public static void PlayOneShotASound(AudioSource audioSource, AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }

    public static float CalculateDistance(List<Vector3> pathList)
    {
        float totalDis = 0f;
        for (int i = 0; i < pathList.Count; i++)
        {
            if (i < pathList.Count - 1)
            {
                totalDis += Vector3.Distance(pathList[i], pathList[i + 1]);
            }
        }
        return totalDis;
    }

    public static float CalculateDistance(Vector3[] pathList)
    {
        float totalDis = 0f;
        for (int i = 0; i < pathList.Length; i++)
        {
            if (i < pathList.Length - 1)
            {
                totalDis += Vector3.Distance(pathList[i], pathList[i + 1]);
            }
        }
        return totalDis;
    }
    public static bool CheckPerpendicular(Vector3 forwardObj1, Vector3 forwardObj2)
    {
        forwardObj1 = forwardObj1.normalized;
        forwardObj2 = forwardObj2.normalized;

        return (int)Vector3.Angle(forwardObj1, forwardObj2) == 90;
    }

    public static float GetRandomPercentRate()
    {
        return RandomRange(0f, 100f);
    }

    public static int RandomRange(int min, int max)
    {
        return (int)RandomRange((float)min, (float)max);
    }

    public static float RandomRange(float min, float max)
    {
        return UnityEngine.Random.Range(min, max);
    }

    public static float CalculateForceRateByDistanceToCenter(Vector2 center, Vector2 objectPos, float radius)
    {
        float distance = Vector2.Distance(center, objectPos);
        return distance / radius;
    }
}
