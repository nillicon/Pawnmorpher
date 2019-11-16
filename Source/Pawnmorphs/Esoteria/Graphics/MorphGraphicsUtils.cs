﻿// MorphGraphicsUtils.cs created by Iron Wolf for Pawnmorph on 09/13/2019 9:50 AM
// last updated 09/13/2019  9:51 AM

using System;
using AlienRace;
using JetBrains.Annotations;
using RimWorld;
using UnityEngine;
using Verse;

namespace Pawnmorph.GraphicSys
{
    /// <summary>
    /// collection of useful graphics related utility functions on morphs 
    /// </summary>
    public static class MorphGraphicsUtils
    {
        /// <summary>
        /// refresh the graphics associated with this pawn, including the portraits if it's a colonist 
        /// </summary>
        /// <param name="pawn"></param>
        public static void RefreshGraphics([NotNull] this Pawn pawn)
        {
            pawn.Drawer.renderer.graphics.ResolveAllGraphics();
            if (pawn.IsColonist)
            {
                PortraitsCache.SetDirty(pawn);
            }
        }
        /// <summary>Gets the skin color override.</summary>
        /// <param name="def">The definition.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">def</exception>
        public static Color? GetSkinColorOverride([NotNull] this MorphDef def)
        {
            if (def == null) throw new ArgumentNullException(nameof(def));
            if (def.explicitHybridRace == null)
            {
                return def.raceSettings?.graphicsSettings?.skinColorOverride;
            }
            else
            {
                var hRace = def.explicitHybridRace as ThingDef_AlienRace;
                return hRace?.alienRace?.generalSettings?.alienPartGenerator?.alienskincolorgen?.NewRandomizedColor();
            }
        }
        /// <summary>Gets the hair color override.</summary>
        /// <param name="def">The definition.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">def</exception>
        public static Color? GetHairColorOverride([NotNull] this MorphDef def)
        {
            if (def == null) throw new ArgumentNullException(nameof(def));

            if(def.explicitHybridRace == null)
                return def.raceSettings?.graphicsSettings?.hairColorOverride ?? GetSkinColorOverride(def);

            var hRace = def.explicitHybridRace as ThingDef_AlienRace;
            return hRace?.alienRace?.generalSettings?.alienPartGenerator?.alienhaircolorgen?.NewRandomizedColor() ?? GetSkinColorOverride(def); 
        }
        /// <summary>Gets the hair color override second.</summary>
        /// <param name="def">The definition.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">def</exception>
        public static Color? GetHairColorOverrideSecond([NotNull] this MorphDef def)
        {
            if (def == null) throw new ArgumentNullException(nameof(def));
            if(def.explicitHybridRace == null)
                return def.raceSettings?.graphicsSettings?.hairColorOverrideSecond ?? GetSkinColorSecondOverride(def);
            var hRace = def.explicitHybridRace as ThingDef_AlienRace;
            return hRace?.alienRace?.generalSettings?.alienPartGenerator?.alienhairsecondcolorgen?.NewRandomizedColor() ?? GetSkinColorSecondOverride(def); 
        }
        /// <summary>Gets the skin color second override.</summary>
        /// <param name="def">The definition.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">def</exception>
        public static Color? GetSkinColorSecondOverride([NotNull] this MorphDef def)
        {
            if (def == null) throw new ArgumentNullException(nameof(def));
            if(def.explicitHybridRace == null)
                return def.raceSettings?.graphicsSettings?.skinColorOverrideSecond;
            var hRace = def.explicitHybridRace as ThingDef_AlienRace;
            return hRace?.alienRace?.generalSettings?.alienPartGenerator?.alienskinsecondcolorgen?.NewRandomizedColor(); 
        }
    }
}