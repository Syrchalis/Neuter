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
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (thing is Pawn pawn && !pawn.health.hediffSet.HasHediff(recipe.addsHediff))
            {
                if (recipe == NeuterDefOf.MakeInfertile && pawn.health.hediffSet.HasHediff(NeuterDefOf.Neutered))
                {
                    return false;
                }
                return true;
            }
            return false;
        }
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            if (pawn.gender != Gender.None)
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
            if (recipe.removesHediff != null && pawn.health.hediffSet.HasHediff(recipe.removesHediff))
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(recipe.removesHediff));
            }
        }
    }

    internal class Recipe_AbortPregnancy : RecipeWorker
    {
        public override bool AvailableOnNow(Thing thing, BodyPartRecord part = null)
        {
            if (thing is Pawn pawn && pawn.health.hediffSet.HasHediff(recipe.removesHediff))
            {
                return true;
            }
            return false;
        }
        public override IEnumerable<BodyPartRecord> GetPartsToApplyOn(Pawn pawn, RecipeDef recipe)
        {
            if (pawn.gender != Gender.None)
            {
                yield return null;
            }
            yield break;
        }

        public override void ApplyOnPawn(Pawn pawn, BodyPartRecord part, Pawn billDoer, List<Thing> ingredients, Bill bill)
        {
            if (recipe.removesHediff != null && pawn.health.hediffSet.HasHediff(recipe.removesHediff))
            {
                pawn.health.RemoveHediff(pawn.health.hediffSet.GetFirstHediffOfDef(recipe.removesHediff));
            }
        }
    }
}
