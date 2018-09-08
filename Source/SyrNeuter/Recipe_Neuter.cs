using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;

namespace SyrNeuter
{
    internal class Recipe_Neuter : RecipeWorker
    {
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            if (pawn.gender == Gender.Male || pawn.gender == Gender.Female)
            {
                yield return null;
            }
            yield break;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (recipe.addsHediff != null)
            {
                pawn.health.AddHediff(recipe.addsHediff);
            }
            if (recipe.removesHediff != null)
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(recipe.removesHediff));
            }
        }
    }
}
