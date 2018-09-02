using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using RimWorld;
using Verse;

namespace SyrNeuter
{
    [DefOf]
    public static class NeuterDefOf
    {
        static NeuterDefOf()
        {
            DefOfHelper.EnsureInitializedInCtor(typeof(RecipeDefOf));
        }
        public static RecipeDef Neuter;
        public static HediffDef Neutered;
    }
}
