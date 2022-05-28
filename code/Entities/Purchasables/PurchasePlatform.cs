using Sandbox;
using SandboxEditor;
using System.ComponentModel;

namespace SC
{
	[Title("Purchase Platform"), Category("Purchasables"), Icon("add_circle")]
	[Library("purch_plat")]
	[HammerEntity, EditorModel("models/Purchase/PurchaseBaseTemp.vmdl")]
	[Model] // Just so it doesn't hide when shift+o'd in editor - Lokiv
	public class PurchasePlatform : ModelEntity, IUse 
	{
		[Property, Title("Child Dropper"), Description("Changes which child dropper this is the parent to."), FGDType("target_destination")]
		public Droppers ChildDropper {get; set;} // Work this thing out and like make it work and shit - Lokiv

		[Property, Title("Price"), Description("Changes the price of this purchasable.")]
		public int Price {get; set;} // Public for potential world text UI

		public bool OnUse(Entity ent) 
		{
			var player = Local.Pawn as SCPlayer;
			if (player.Money >= Price)
			{
				Purchase(ChildDropper);
				return true;
			}

			Log.Info("Get more money bitch1!!");
			return false;
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

			if (ChildDropper.IsPurchased == true) 
			{
				Delete();
			}
			else return;
		}

		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );

			if (other is SCPlayer player) 
			{
				if (player.Money >= Price)
					Purchase(ChildDropper);
				else Log.Info("Get more money bitch1!!");
			}
		}

		public void Purchase(Droppers dropper) 
		{
			dropper.IsPurchased = true;
			Delete();
		}
	}
}
