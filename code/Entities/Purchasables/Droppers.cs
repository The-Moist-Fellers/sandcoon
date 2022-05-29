using Sandbox;
using SandboxEditor;
using System.ComponentModel;

namespace SC
{
	[Title("Dropper"), Category("Purchasables"), Icon("logout")]
	[Library( "purch_drop" )]
	[HammerEntity]
	[Model]
	[RenderFields]
	public partial class Droppers : ModelEntity 
	{
		[Property, Title("Starts Purchased?"), Description("Should this dropper start purchased?")]
		public bool IsPurchased { get; set; } = false;

		[Property, Title("Drop Speed"), Description("Changes the drop speed of this here dropper.")]
		public float DropSpeed { get; set; }

		[Property, Title( "Key Level" ), Description( "Changes the level of the keys that this dropper drops." )]
		public int DropperKeyLevel { get; set; } = 1;

		public TimeSince TimeSinceLastDrop;

		public override void Spawn()
		{
			base.Spawn();

			// Switches the model based on the set key level
			// We don't need enums to do this, its just doesn't seem right - Rifter 
			// I tried using if statements, iirc it both didn't work and didn't look good, a switch was the best way - Lokiv
			switch(DropperKeyLevel)
			{
				case 1:
					SetModel( "models/droppers/droppertemp.vmdl" );
					break;

				case 2:

					break;

				case 3:

					break;

				case 4:

					break;

				case 5:

					break;

				default:
					SetModel( "models/droppers/droppertemp.vmdl" ); 
					break;
			}

			UsePhysicsCollision = true;
			MoveType = MoveType.None;
			CollisionGroup = CollisionGroup.Always;
		}

		[Event.Tick.Server]
		public void TickDrops()
		{
			if (IsPurchased == true) 
			{
				if ( TimeSinceLastDrop >= DropSpeed )
					DropKey();
			}
		}

		// KeyEnt for the key that's gonna be dropped from the dropper // Dunno if it works fully, if not find some other way to fix it or something - Lokiv \\
		//public KeyEnt KeyEntity;

		public void DropKey() 
		{
			TimeSinceLastDrop = 0.0f;

			// var keyent = new KeyEnt(); // Old way of making a KeyEnt thing, possibly not the correct way, dunno - Lokiv

			/*switch (DropperKeyLevel) 
			{
				case KeyLevel.KeyLvlOne: KeyEntit = new KeyLvlOne(); break;
			}*/

			var drop = new KeyEnt();

			//WTF, you're adding to the position of the dropper as well as setting the key - Rifter // Bro I thought it'd just set the position of the key thing!! - Lokiv
			//drop.Position = Position += Position.z * 15;

			// var droppos = GetAttachment("drop"); // Set the key position on the "drop" attachment when it spawns - Lokiv

			drop.Position = /*droppos*/ Position.z * 5;
			drop.Spawn();
		}
	}
}
