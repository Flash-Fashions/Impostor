﻿using System;
using System.Threading.Tasks;
using Impostor.Shared.Innersloth.Data;

namespace Impostor.Server.Net
{
    public static class GameMessageWriterExtensions
    {
        public static ValueTask SendToAllExceptAsync(this IGameMessageWriter writer, LimboStates states, int? id)
        {
            return id.HasValue
                ? writer.SendToAllExceptAsync(states, id.Value)
                : writer.SendToAllAsync(states);
        }
        
        public static ValueTask SendToAllExceptAsync(this IGameMessageWriter writer, LimboStates states, IClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            
            return writer.SendToAllExceptAsync(states, client.Id);
        }
        
        public static ValueTask SendToAsync(this IGameMessageWriter writer, IClient client)
        {
            if (client == null) throw new ArgumentNullException(nameof(client));
            
            return writer.SendToAsync(client.Id);
        }
    }
}