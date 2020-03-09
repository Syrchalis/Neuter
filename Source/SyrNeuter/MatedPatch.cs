using HarmonyLib;
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
    [HarmonyPatch(typeof(PawnUtility), nameof(PawnUtility.Mated))]
    public static class MatedPatch
    {
        [HarmonyPrefix]
        public static bool Mated_Prefix(Pawn male, Pawn female)
        {
            if (!male.health.hediffSet.HasHediff(NeuterDefOf.Infertile) && !female.health.hediffSet.HasHediff(NeuterDefOf.Infertile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
