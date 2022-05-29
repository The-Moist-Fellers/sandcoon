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

		public void DropKey() 
		{
			TimeSinceLastDrop = 0.0f;

			var drop = new KeyEnt();
			drop.Transform = GetBoneTransform("drop");
			drop.Spawn();
		}
	}
}
