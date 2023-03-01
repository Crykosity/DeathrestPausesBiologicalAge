using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

using UnityEngine;
using Verse;
using Verse.AI;
using Verse.AI.Group;
using Verse.Sound;
using Verse.Noise;
using Verse.Grammar;
using RimWorld;
using RimWorld.Planet;

using System.Reflection;
using HarmonyLib;

namespace Template
{

    [StaticConstructorOnStartup]
    public static class Start
    {
        static Start()
        {
            var harmony = new Harmony("com.username.modname");
			harmony.PatchAll(Assembly.GetExecutingAssembly());
        }

        [HarmonyPatch(typeof(Pawn_AgeTracker))]
        [HarmonyPatch("BiologicalTicksPerTick", MethodType.Getter)]
        class Patch {
            static void Postfix(ref Pawn ___pawn, ref float __result)
            {
                if (___pawn.Deathresting) {
                    __result = 0f;
                }
            }
        }
    }

}
