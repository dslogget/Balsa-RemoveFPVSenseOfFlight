using BalsaCore;
using HarmonyLib;
using IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using UnityEngine;

namespace CloverTech
{
    class HarmonyContainer
    {
        public static Harmony harmony = new Harmony("Balsa.CloverTech.RemoveFPVSenseOfFlight");

        public static void DoPatches()
        {
#if DEBUG
            Harmony.DEBUG = true;
#endif
            harmony.PatchAll();
        }

        [HarmonyPatch(typeof(FloatingCameraFX.Modules.FPVSenseOfFlight), "UpdateLocalPosition")]
        class RemoveFPVSenseOfFlightPosPatch
        {
            static bool Prefix(Vector3 defaultPos,
                               Vector3 currPos,
                               float m,
                               Vector3 wpos,
                               ref Vector3 __result)
            {
                __result = currPos;
                return false;
            }
        }
        [HarmonyPatch(typeof(FloatingCameraFX.Modules.FPVSenseOfFlight), "UpdateLocalRotation")]
        class RemoveFPVSenseOfFlightRotPatch
        {
            static bool Prefix(Quaternion defaultRot,
                               Quaternion currRot,
                               float m,
                               Quaternion wRot,
                               ref Quaternion __result)
            {
                __result = currRot;
                return false;
            }
        }

    }
}