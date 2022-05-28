using Sandbox;

namespace SC
{
	public partial class KeyEnt : ModelEntity 
	{
		public int SellPrice { get; private set; } = 5;
		public int KeyLevel { get; private set; } = 1;

		public override void Spawn()
		{
			base.Spawn();

			SetModel("models/keys/keymodel.vmdl");

			SetupPhysicsFromModel(PhysicsMotionType.Dynamic);
		}

		public void UpgradeKey()
		{
			KeyLevel++;
			SellPrice *= 2;
		}

		public void SellKey() 
		{
			//We need to check if the tycoon belongs to this player
			var player = Local.Pawn as SCPlayer;

			if ( player == null ) return;

			player.AddMoney( SellPrice );

			Delete();
		}
	}

	//Why are we doing an enum? if we wanted to upgrade the key level
	//we can just increment it using an integer
	/*public enum KeyLevel 
	{
		KeyLvlOne = 1,
		KeyLvlTwo,
		KeyLvlThree,
		KeyLvlFour,
		KeyLvlFive,
		KeyLvlSix
	}*/
}
