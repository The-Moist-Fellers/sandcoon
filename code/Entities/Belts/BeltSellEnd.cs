using Sandbox;
using SandboxEditor;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SC 
{
	[HammerEntity]
	[Library( "belt_sellend" )]
	[Model]
	[Title("Belt Sell End"), Category("Belt Parts"), Icon("file_download")]
	public partial class BeltSellEnd : ModelEntity 
	{
		public override void Spawn()
		{
			base.Spawn();
		}

		public override void Touch( Entity other )
		{
			base.Touch( other );

			Log.Info( other );

			if(other is KeyEnt key)
				key.SellKey();
		}
	}
}
