using Sandbox;
using SandboxEditor;
using System.ComponentModel;

namespace SC
{
	[Title("Dropper"), Category("Purchasables")]
	[Library("purch_drop")]
	[HammerEntity, EditorModel("models/droppers/DropperTemp.vmdl")]
	public partial class Droppers : ModelEntity 
	{
		public bool IsPurchased;

		[Property, Title("Drop Speed"), Category("Standard Settings"), Description("Changes the drop speed of this here dropper.")]
		public float DropSpeed {get; set;}

		[Property, Title("Dropper Model"), Category("Standard Settings"), Description("Changes the model of this dropper.")]
		public string DropperModel {get; set;}

		public TimeSince TimeSinceDropped;

		public override void Spawn()
		{
			base.Spawn();

			IsPurchased = false;

			SetModel(DropperModel);
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
			if (!IsPurchased) 
			{
				RenderColor.WithAlpha(0.5f);
				// Alpha halved? Other things too maybe - Lokiv
			}
		}

		public void DropKey() 
		{
			TimeSinceDropped = 0;

			var key = new ModelEntity();
			key.SetModel("models/keys/Key.vmdl");
			key.Position = Position += Position.z * 15;
		}
	}
}
