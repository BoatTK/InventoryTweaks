using System;
using System.Collections.Generic;
using System.Text;
using HarmonyLib;
using GameNetcodeStuff;

namespace InventoryTweaks.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class FasterScroll
    {
        [HarmonyPatch("ScrollMouse_performed")]
        [HarmonyPrefix]
        static void ResetScrollTime(ref float ___timeSinceSwitchingSlots)
        {
            if(___timeSinceSwitchingSlots > .07f)
            ___timeSinceSwitchingSlots = 1f;
        }
    }
}
