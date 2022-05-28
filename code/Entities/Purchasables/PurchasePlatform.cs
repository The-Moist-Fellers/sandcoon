using Sandbox;
using SandboxEditor;
using System.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace SC
{
	[Title("Purchase Platform"), Category("Purchasables"), Icon("add_circle")]
	[Library("purch_plat")]
	[HammerEntity, EditorModel("models/Purchase/PurchaseBaseTemp.vmdl")]
	[Model] // Just so it doesn't hide when shift+o'd in editor - Lokiv
	public class PurchasePlatform : ModelEntity
	{
		[Property, Title("Child Dropper"), Description("Changes which child dropper this is the parent to."), FGDType("target_destination")]
		public Droppers ChildDropper {get; set;} // Work this thing out and like make it work and shit - Lokiv

		[Property, Title("Price"), Description("Changes the price of this purchasable.")]
		public int Price {get; set;} // Public for potential world text UI

		public override void Spawn()
		{
			base.Spawn();

			EnableTouch = true;
			UsePhysicsCollision = true;
			MoveType = MoveType.None;
			CollisionGroup = CollisionGroup.Always;

			SetModel("models/purchase/PurchaseBaseTemp.vmdl");
		}

		public override void Simulate( Client cl )
		{
			base.Simulate( cl );

			var tr = Trace.Ray(Position, Position += Vector3.Up * 15)
				.UseHitboxes()
				.Ignore(this)
				.Size(15.0f)
				.Run();

			DebugOverlay.Sphere(Position, 15.0f, Color.Red, 0, true);

			if (tr.Entity is SCPlayer player) 
			{
				if (player.Money >= Price)
					Purchase(ChildDropper);
				
				else 
				{
					Log.Info("Get more money, now!!!");
				}
			}

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
				else
				{
					Log.Info("Get more money bitch1!!");
				}
			}
		}

		public void Purchase(Droppers dropper) 
		{
			dropper.IsPurchased = true;
			Delete();
		}
	}
}
