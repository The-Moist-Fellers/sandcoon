using Sandbox;

namespace SC
{
	public partial class KeyEnt : ModelEntity 
	{
		public virtual int SellPrice {get; set;}

		public override void Spawn()
		{
			base.Spawn();

			SetModel("models/keys/keymodel.vmdl");

			SetupPhysicsFromModel(PhysicsMotionType.Dynamic, false);
		}

		public void SellKey() 
		{
			var player = Local.Pawn as SCPlayer;

			player.Money += SellPrice;

			Delete();
		}
	}

	public enum KeyLevel 
	{
		KeyLvlOne = 1,
		KeyLvlTwo,
		KeyLvlThree,
		KeyLvlFour,
		KeyLvlFive,
		KeyLvlSix
	}
}
