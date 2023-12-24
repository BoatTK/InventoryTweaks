using BepInEx;
using HarmonyLib;
using InventoryTweaks.Patches;

namespace InventoryTweaks
{
    [BepInPlugin(PluginInfo.PLUGIN_GUID, PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
    public class InventoryTweaksCore : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony(PluginInfo.PLUGIN_GUID);
        private void Awake()
        {
            // Plugin startup logic
            Logger.LogInfo($"Plugin {PluginInfo.PLUGIN_GUID} is loaded!");
            harmony.PatchAll(typeof(InventoryTweaksCore));
            harmony.PatchAll(typeof(FasterScroll));
            harmony.PatchAll(typeof(NewDropBehavior));
            harmony.PatchAll(typeof(NewFirst));
        }
    }
}