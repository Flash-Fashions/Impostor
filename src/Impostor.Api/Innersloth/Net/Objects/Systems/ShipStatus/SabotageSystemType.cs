﻿using Impostor.Api.Net.Messages;

namespace Impostor.Api.Innersloth.Net.Objects.Systems.ShipStatus
{
    public class SabotageSystemType : ISystemType
    {
        private readonly IActivatable[] _specials;

        public SabotageSystemType(IActivatable[] specials)
        {
            _specials = specials;
        }

        public float Timer { get; set; }

        public void Serialize(IMessageWriter writer, bool initialState)
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(IMessageReader reader, bool initialState)
        {
            Timer = reader.ReadSingle();
        }
    }
}