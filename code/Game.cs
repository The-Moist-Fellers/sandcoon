using Sandbox;

namespace SC
{
	public partial class SCGame : Game
	{
		public SCGame()
		{
			// if (IsServer) 
			// {
				// _ = new SCHud();
			// } Uncomment when Hud is coded / being coded on - Lokiv
		}
		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var pawn = new SCPlayer(client);
			client.Pawn = pawn;

			pawn.Respawn();
		}
	}
}
