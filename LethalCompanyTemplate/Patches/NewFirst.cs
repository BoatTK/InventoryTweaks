using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryTweaks.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class NewFirst
    {

        [HarmonyPatch("FirstEmptyItemSlot")]
        [HarmonyPostfix]
        static void ForceToStart(ref GrabbableObject[] ___ItemSlots, ref int __result)
        {
            int result = -1;
            for (int i = 0; i < ___ItemSlots.Length; i++)
            {
                if (___ItemSlots[i] == null)
                {
                    result = i;
                    break;
                }
            }
            __result = result;
        }
    }
}
