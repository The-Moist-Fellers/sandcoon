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

			var pawn = new SCPlayer();
			client.Pawn = pawn;

			pawn.Respawn();
		}

		[ConCmd.Client("sandcoon_givemoney")]
		public void GiveMoneyCommand(int amount) 
		{
			var caller = ConsoleSystem.Caller;

			if (caller == null) return;

			if (caller.Pawn is SCPlayer player)
			{
				Log.Info("Old money amount: " + player.Money);

				player.Money += amount;

				Log.Info("New money amount: " + player.Money);
			}
		}
	}
}
