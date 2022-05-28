using Sandbox;
using SandboxEditor;
using System.ComponentModel;

namespace SC
{
	[Title("Dropper"), Category("Purchasables"), Icon("logout")]
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

			// Switches the model based on the set key level
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

			// Drop keys if the dropper is purchased // NEEDS FIXING!!!! - Lokiv \\
			if (IsPurchased == true) 
			{
				if (TimeSinceDropped >= DropSpeed)
					DropKey();
			}
		}

		// KeyEnt for the key that's gonna be dropped from the dropper // Dunno if it works fully, if not find some other way to fix it or something - Lokiv \\
		public KeyEnt KeyEntit;

		public void DropKey() 
		{
			TimeSinceDropped = 0.0f;

			// var keyent = new KeyEnt(); // Old way of making a KeyEnt thing, possibly not the correct way, dunno - Lokiv

			switch (DropperKeyLevel) 
			{
				case KeyLevel.KeyLvlOne: KeyEntit = new KeyLvlOne(); break;
			}

			KeyEntit.Spawn();
			KeyEntit.Position = Position += Position.z * 15;
		}
	}
}
