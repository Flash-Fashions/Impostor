using System.Collections.Generic;
using Impostor.Api.Games;

namespace Impostor.Api.Net.Messages.S2C
{
    public class Message16GetGameListS2C
    {
        public static void Serialize(IMessageWriter writer, int skeldGameCount, int miraHqGameCount, int polusGameCount, IEnumerable<IGame> games)
        {
            writer.StartMessage(MessageFlags.GetGameListV2);

            // Count
            writer.StartMessage(1);
            writer.Write(skeldGameCount); // The Skeld
            writer.Write(miraHqGameCount); // Mira HQ
            writer.Write(polusGameCount); // Polus
            writer.EndMessage();

            // Listing
            writer.StartMessage(0);

            foreach (var game in games)
            {
                writer.StartMessage(0);
                writer.Write(game.PublicIp.Address);
                writer.Write((ushort)game.PublicIp.Port);
                writer.Write(game.Code);
                writer.Write(game.Host.Client.Name);
                writer.Write((byte)game.PlayerCount);
                writer.WritePacked(1); // TODO: What does Age do?
                writer.Write((byte)game.Options.MapId);
                writer.Write((byte)game.Options.NumImpostors);
                writer.Write((byte)game.Options.MaxPlayers);
                writer.EndMessage();
            }

            writer.EndMessage();
            writer.EndMessage();
        }

        public static void Deserialize(IMessageReader reader)
        {
            throw new System.NotImplementedException();
        }
    }
}