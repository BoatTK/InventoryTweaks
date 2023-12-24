using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


namespace InventoryTweaks.Patches
{
    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class NewDropBehavior
    {

        [HarmonyPatch("DiscardHeldObject")]
        [HarmonyPostfix]
        static void MoveAllItems(PlayerControllerB __instance, object[] __args)
        {
            int itemSlot = __instance.currentItemSlot;
            if ((bool)__args[0] == false)
            {
                for (int i = __instance.currentItemSlot; i < __instance.ItemSlots.Length; ++i)
                {
                    if (__instance.ItemSlots[i] == null)
                    {
                        for (int j = i; j < __instance.ItemSlots.Length; j++)
                        {
                            if (__instance.ItemSlots[j] != null)
                            {
                                AccessTools.Method(typeof(PlayerControllerB), "SwitchToItemSlot").Invoke(__instance, new object[] { i, __instance.ItemSlots[j] });
                                __instance.ItemSlots[j] = null;
                                HUDManager.Instance.itemSlotIcons[j].enabled = false;
                                break;
                            }
                        }
                    }
                }
            }
            __instance.currentItemSlot = itemSlot;
            AccessTools.Method(typeof(PlayerControllerB), "SwitchToItemSlot").Invoke(__instance, new object[] { itemSlot, __instance.ItemSlots[itemSlot] });
        }
    }
}
