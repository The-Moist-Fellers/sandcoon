using Sandbox;

namespace SC 
{
	public partial class SCPlayer : Player 
	{
		public int Money {get; set;} = 0;

		public override void Respawn()
		{
			base.Respawn();

			SetModel("models/citizen/citizen.vmdl");

			CameraMode = new ThirdPersonCamera();
			Animator = new StandardPlayerAnimator();
			Controller = new WalkController();
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			TickPlayerUse();
		}
	}
}
