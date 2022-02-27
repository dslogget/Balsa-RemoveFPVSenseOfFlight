using UnityEngine;
using BalsaCore;
using IO;
using UI;
using UI.MMX.Data;
using System.Collections.Generic;
using System.Reflection;
using System;
using System.IO;

namespace CloverTech
{
    public class RemoveFPVSenseOfFlight : MonoBehaviour
    {
        public void Start()
        {
            DontDestroyOnLoad(this);
            LogW("Test");
#if DEBUG
            Debug.LogError("Init");
#endif
            HarmonyContainer.DoPatches();
        }

        public void LogI(string message)
        {
            Debug.Log($"[RemoveFPVSenseOfFlight] {message}");
        }
        public void LogW(string message)
        {
            Debug.LogWarning($"[RemoveFPVSenseOfFlight] {message}");
        }
        public void LogE(string message)
        {
            Debug.LogError($"[RemoveFPVSenseOfFlight] {message}");
        }
    }
    

    [BalsaAddon]
    public class Loader
    {
        private static GameObject go = null;
        private static bool initialised = false;

        [BalsaAddonInit]
        public static void BalsaInit()
        {
            if (!initialised)
            {
                Debug.Log("[RemoveFPVSenseOfFlight] Creating GameObject");
                go = new GameObject("CloverTech::RemoveFPVSenseOfFlight");
                go.AddComponent<RemoveFPVSenseOfFlight>();
                initialised = true;
            }
        }

        [BalsaAddonInit(invokeTime = AddonInvokeTime.Flight)]
        public static void BalsaInitFlight()
        {

        }

        [BalsaAddonFinalize(invokeTime = AddonInvokeTime.Flight)]
        public static void BalsaFinalizeFlight()
        {

        }
        //Game exit
        [BalsaAddonFinalize]
        public static void BalsaFinalize()
        {
            go.DestroyGameObject();
        }

    }
}
