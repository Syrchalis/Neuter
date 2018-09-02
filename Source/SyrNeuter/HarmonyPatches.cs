using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;
using System.Reflection;

namespace SyrNeuter
{
    [StaticConstructorOnStartup]
    static class HarmonyPatches
    {
        static HarmonyPatches()
        {
            var harmony = HarmonyInstance.Create("Syrchalis.Rimworld.Neuter");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
