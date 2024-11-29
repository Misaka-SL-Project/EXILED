// -----------------------------------------------------------------------
// <copyright file="ChangingEmotionEventArgs.cs" company="ExMod Team">
// Copyright (c) ExMod Team. All rights reserved.
// Licensed under the CC BY-SA 3.0 license.
// </copyright>
// -----------------------------------------------------------------------

namespace Exiled.Events.EventArgs.Player
{
    using Exiled.API.Features;
    using Exiled.Events.EventArgs.Interfaces;
    using PlayerRoles.FirstPersonControl.Thirdperson.Subcontrollers;

    /// <summary>
    /// Contains all the information before the player's emotion changes.
    /// </summary>
    public class ChangingEmotionEventArgs : IDeniableEvent, IPlayerEvent
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ChangingEmotionEventArgs"/> class.
        /// </summary>
        /// <param name="hub"><inheritdoc cref="Player"/></param>
        /// <param name="emotionPresetTypeNew"><inheritdoc cref="EmotionPresetTypeNew"/></param>
        /// <param name="emotionPresetTypeOld"><inheritdoc cref="EmotionPresetTypeOld"/></param>
        /// <param name="isAllowed"><inheritdoc cref="IsAllowed"/></param>
        public ChangingEmotionEventArgs(ReferenceHub hub, EmotionPresetType emotionPresetTypeNew, EmotionPresetType emotionPresetTypeOld, bool isAllowed = true)
        {
            Player = Exiled.API.Features.Player.Get(hub);
            EmotionPresetTypeNew = emotionPresetTypeNew;
            EmotionPresetTypeOld = emotionPresetTypeOld;
            IsAllowed = isAllowed;
        }

        /// <inheritdoc/>
        public bool IsAllowed { get; set; }

        /// <summary>
        /// Gets the old player's emotion.
        /// </summary>
        public EmotionPresetType EmotionPresetTypeOld { get; }

        /// <summary>
        /// Gets or sets the new player's emotion.
        /// </summary>
        public EmotionPresetType EmotionPresetTypeNew { get; set; }

        /// <inheritdoc/>
        public Player Player { get; }
    }
}