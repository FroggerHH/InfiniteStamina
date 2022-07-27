using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace InfiniteStats
{
    [BepInPlugin(GUID, NAME, VERSION)]
    [BepInProcess("Muck.exe")]
    public class InfiniteStats : BaseUnityPlugin
    {
        private bool isInfinite;
        public const string
            GUID = "InfiniteStats",
            NAME = "InfiniteStats",
            VERSION = "1.0.0";

        public void Awake() 
        {
           Harmony.CreateAndPatchAll(typeof(MuckPatch));
           Logger.LogMessage("Loaded InfiniteStats");
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.RightShift)) isInfinite = !isInfinite;
            if (isInfinite)
            {
                PlayerStatus.Instance.stamina = PlayerStatus.Instance.maxStamina;
                PlayerStatus.Instance.hunger = PlayerStatus.Instance.maxHunger;
                PlayerStatus.Instance.hp = PlayerStatus.Instance.maxHp;
            }
        }
    }

    public class MuckPatch { }
}