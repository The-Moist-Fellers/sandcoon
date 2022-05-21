using Sandbox;

namespace SC
{
	public partial class SCGame : Game
	{
		public SCGame()
		{
		}
		
		public override void ClientJoined( Client client )
		{
			base.ClientJoined( client );

			var pawn = new SCPlayer();
			client.Pawn = pawn;

			pawn.Respawn();
		}
	}
}
