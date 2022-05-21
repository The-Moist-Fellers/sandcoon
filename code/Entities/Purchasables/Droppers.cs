using Sandbox;
using System;
using System.Linq;
using SandboxEditor;
using System.ComponentModel;

namespace SC 
{
	[Title("Dropper"), Category("Purchasables")]
	[Library("purch_drop")]
	[HammerEntity, EditorModel("models/Droppers/DropperTemp.vmdl")]
	public partial class Droppers : ModelEntity 
	{
		public bool IsPurchased;

		[Property, Title("Drop Speed"), Category("Standard Settings"), Description("Changes the drop speed of this here dropper.")]
		public float DropSpeed {get; set;}

		[Property, Title("Dropper Model"), Category("Standard Settings"), Description("Changes the model of this dropper."), FGDType("model", "model")]
		public string DropperModel {get; set;}

		public TimeSince TimeSinceDropped;

		public override void Spawn()
		{
			base.Spawn();

			IsPurchased = false;

			SetModel(DropperModel);
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			if (IsPurchased) 
			{
				return; // Do the drop
			}
			if (!IsPurchased) 
			{
				// Alpha halved? Other things maybe tho - Lokiv
			}
		}
	}
}
