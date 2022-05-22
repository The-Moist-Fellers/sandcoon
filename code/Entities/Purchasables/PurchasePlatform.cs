using Sandbox;
using SandboxEditor;
using System.ComponentModel;

namespace SC
{
	[Title("Purchase Platform"), Category("Purchasables")]
	[Library("purch_plat")]
	[HammerEntity, EditorModel("models/Purchase/PurchaseBaseTemp.vmdl")]
	public class PurchasePlatform : ModelEntity, IUse 
	{
		[Property, Title("Child Dropper"), Description("Changes which child dropper this is the parent to."), FGDType("target_destination")]
		public Droppers ChildDropper {get; set;} // Work this thing out and like make it work and shit - Lokiv

		[Property, Title("Price"), Description("Changes the price of this purchasable.")]
		public int Price {get; set;} // Public for potential world text UI

		public bool OnUse(Entity ent) 
		{
			Purchase(ChildDropper);
			return true;
		}

		public bool IsUsable(Entity ent) 
		{
			var player = Local.Pawn as SCPlayer;

			if (player.Money < Price)
				return false;

			return true;
		}

		public override void Spawn()
		{
			base.Spawn();

			EnableTouch = true;

			SetModel("models/purchase/PurchaseBaseTemp.vmdl");
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			var dropper = ChildDropper;

			if (dropper.IsPurchased) 
			{
				Delete();
			}
			else return;
		}

		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );

			Purchase(ChildDropper);
		}

		public void Purchase(Droppers dropper) 
		{
			dropper.IsPurchased = true;
			Delete();
		}
	}
}
