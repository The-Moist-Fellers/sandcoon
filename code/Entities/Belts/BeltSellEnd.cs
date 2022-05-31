using Sandbox;
using SandboxEditor;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC 
{
	[HammerEntity]
	[SupportsSolid]
	[Library( "belt_sellend" )]
	[Title("Belt Sell End"), Category("Belt Parts"), Icon("file_download")]
	public partial class BeltSellEnd : ModelEntity 
	{
		public override void Spawn()
		{
			base.Spawn();
			EnableTouch = true;
			SetupPhysicsFromModel(PhysicsMotionType.Static);
		}

		public override void Touch( Entity other )
		{
			base.Touch( other );

			if(other is KeyEnt key)
				key.SellKey();
		}
	}
}
