// -----------------------------------------------------------------------
// <copyright file="Emotion.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.Patches.Events.Player
{
    using Exiled.Events.Attributes;
    using Exiled.Events.EventArgs.Player;
    using HarmonyLib;
    using PlayerRoles.FirstPersonControl.Thirdperson.Subcontrollers;

    /// <summary>
    /// Patches <see cref="EmotionSync.ServerSetEmotionPreset"/>.
    /// Adds the <see cref="Handlers.Player.ChangingEmotion" /> event and
    /// <see cref="Handlers.Player.ChangedEmotion" /> event.
    /// </summary>
    [EventPatch(typeof(Handlers.Player), nameof(Handlers.Player.ChangingEmotion))]
    [EventPatch(typeof(Handlers.Player), nameof(Handlers.Player.ChangedEmotion))]
    [HarmonyPatch(typeof(EmotionSync), nameof(EmotionSync.ServerSetEmotionPreset))]
    internal static class Emotion
    {
        private static bool Prefix(this ReferenceHub hub, EmotionPresetType preset)
        {
            ChangingEmotionEventArgs ev = new(hub, preset, EmotionSync.GetEmotionPreset(hub));
            Handlers.Player.OnChangingEmotion(ev);
            return ev.IsAllowed;
        }

        private static void Postfix(this ReferenceHub hub, EmotionPresetType preset)
        {
            ChangedEmotionEventArgs ev = new(hub, EmotionSync.GetEmotionPreset(hub));
            Handlers.Player.OnChangedEmotion(ev);
        }
    }
}
