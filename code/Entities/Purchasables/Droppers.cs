using Sandbox;
using SandboxEditor;
using System.ComponentModel;

namespace SC
{
	[Title("Dropper"), Category("Purchasables")]
	[Library("purch_drop")]
	[HammerEntity]
	[Model]
	[RenderFields]
	public partial class Droppers : ModelEntity 
	{
		[Property, Title("Starts Purchased?"), Description("Should this dropper start purchased?")]
		public bool IsPurchased {get; set;} = false;

		[Property, Title("Drop Speed"), Description("Changes the drop speed of this here dropper.")]
		public float DropSpeed {get; set;}

		[Property, Title("Key Level"), Description("Changes the level of the keys that this dropper drops.")]
		public KeyLevel DropperKeyLevel {get; set;} = KeyLevel.KeyLvlOne;

		public TimeSince TimeSinceDropped;

		public override void Spawn()
		{
			base.Spawn();

			switch(DropperKeyLevel)
			{
				case KeyLevel.KeyLvlOne: SetModel("models/droppers/droppertemp.vmdl"); break;
				default: SetModel("models/droppers/droppertemp.vmdl"); break;
			}

			UsePhysicsCollision = true;
			MoveType = MoveType.None;
			CollisionGroup = CollisionGroup.Always;
		}

		// public void CreatePreviews() 
		// {
				// Thought this was the way to make the alpha halved lol (just needed RenderColor.WithAlpha(0.5f), but I was dummi) - Lokiv
		// }

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			if (IsPurchased) 
			{
				if (TimeSinceDropped >= DropSpeed)
					DropKey();
			}
		}

		public void DropKey() 
		{
			TimeSinceDropped = 0.0f;

			var keyent = new KeyEnt();

			switch (DropperKeyLevel) 
			{
				case KeyLevel.KeyLvlOne: keyent = new KeyLvlOne(); break;
			}

			keyent.Spawn();
			keyent.Position = Position *= Position.z * 15;
		}
	}
}
