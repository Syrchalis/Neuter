using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;
using System.IO;

namespace SyrNeuter
{
    [HarmonyPatch(typeof(PawnUtility), "FertileMateTarget")]
    public static class FertileMateTargetPatch
    {
        [HarmonyPostfix]
        public static void FertileMateTarget_Postfix(ref bool __result, Pawn male, Pawn female)
        {
            if (male.health.hediffSet.HasHediff(NeuterDefOf.Neutered) || female.health.hediffSet.HasHediff(NeuterDefOf.Neutered))
            {
                __result = false;
            }
            if (WildAnimalSexActive)
            {
                if (male.health.hediffSet.HasHediff(NeuterDefOf.Infertile) || female.health.hediffSet.HasHediff(NeuterDefOf.Infertile))
                {
                    __result = false;
                }
            }
        }
        public static bool WildAnimalSexActive => ModsConfig.ActiveModsInLoadOrder.Any(m => m.Name.Contains("Wild Animal Sex"));
    }
}
