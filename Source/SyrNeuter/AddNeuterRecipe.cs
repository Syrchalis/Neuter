using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;

namespace SyrNeuter
{
    [StaticConstructorOnStartup]
    public static class AddNeuterRecipe
    {
        static AddNeuterRecipe()
        {
            NeuterRecipeUsers();
        }
        public static void NeuterRecipeUsers()
        {
            NeuterDefOf.Neuter.recipeUsers = new List<ThingDef>();
            foreach (ThingDef item in DefDatabase<ThingDef>.AllDefs.Where((ThingDef d) => d.category == ThingCategory.Pawn && d.race.IsFlesh && !d.race.Humanlike))
            {
                NeuterDefOf.Neuter.recipeUsers.Add(item);
            }
        }
    }
}
