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

		[Property, Title("Dropper Level"), Description("Changes the current level of the dropper (changes the key level too).")]
		public DropperLevel CurrDropLevel {get; set;} = DropperLevel.LevelOne;

		public KeyEnt KeyEnt {get; set;} = new KeyEnt();

		public TimeSince TimeSinceDropped;

		public override void Spawn()
		{
			base.Spawn();

			switch (CurrDropLevel) 
			{
				case DropperLevel.LevelOne: SetModel("models/droppers/droppertemp.vmdl"); break; // Add more models and change them for each level - Lokiv
				default: SetModel("models/droppers/droppertemp.vmdl"); break;
			}

			EnableAllCollisions = true;
			UsePhysicsCollision = true;
			CollisionGroup = CollisionGroup.Prop;
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
				RenderColor.WithAlpha(1.0f);

				if (TimeSinceDropped >= DropSpeed)
					DropKey(KeyEnt);
			}
			if (!IsPurchased) 
			{
				RenderColor.WithAlpha(0.5f);
				// Alpha halved? Other things too maybe - Lokiv
			}
		}

		public void DropKey(KeyEnt keyent) 
		{
			TimeSinceDropped = 0;

			switch (CurrDropLevel) 
			{
				case DropperLevel.LevelOne: keyent = new KeyLvlOne(); break;
			}

			keyent.Spawn();
			keyent.Position = Position += Position.z * 15;
		}
	}

	public enum DropperLevel 
	{
		LevelOne = 1,
		LevelTwo,
		LevelThree,
		LevelFour,
		LevelFive,
		LevelSix
	}
}
