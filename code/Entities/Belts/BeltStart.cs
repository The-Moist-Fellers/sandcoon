using Sandbox;
using SandboxEditor;
using System;
using System.Linq;
using System.ComponentModel;

namespace SC 
{
	[HammerEntity, EditorModel("models/belts/beltstarttemp.vmdl")]
	[Library( "belt_start" )]
	[Title("Belt Start"), Category("Belt Parts"), Icon("exit_to_app")]
	public partial class BeltStart : ModelEntity 
	{
		public override void Spawn()
		{
			base.Spawn();

			SetModel("models/belts/beltstarttemp.vmdl");

			UsePhysicsCollision = true;
			MoveType = MoveType.None;
			CollisionGroup = CollisionGroup.Always;
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			// Have a ray cast maybe? Then check if the ent is valid and if so, velocity increases or sumn - Lokiv
		}
	}
}
