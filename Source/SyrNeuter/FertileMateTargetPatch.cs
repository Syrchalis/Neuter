using Harmony;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;
using Verse.AI;

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
        }
    }
}
