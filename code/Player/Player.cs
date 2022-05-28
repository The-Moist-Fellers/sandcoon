using Sandbox;

namespace SC 
{
	public partial class SCPlayer : Player 
	{

		public ClothingContainer Clothing = new();

		public SCPlayer() 
		{

		}

		public SCPlayer(Client cl) : this() 
		{
			Clothing.LoadFromClient(cl);
		}

		public override void Respawn()
		{
			base.Respawn();

			SetModel("models/citizen/citizen.vmdl");

			CameraMode = new ThirdPersonCamera();
			Animator = new StandardPlayerAnimator();
			Controller = new WalkController();

			Clothing.DressEntity(this);
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			TickPlayerUse();
		}
	}
}
