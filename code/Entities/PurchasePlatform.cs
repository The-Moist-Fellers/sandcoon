using Sandbox;
using SandboxEditor;
using System;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SC 
{
	[Title("Purchase Platform"), Category("Purchasables")]
	[Library("purch_plat")]
	[HammerEntity, EditorModel("models/Purchase/PurchaseBaseTemp.vmdl")]
	public class PurchasePlatform : ModelEntity, IUse 
	{
		[Property, Title("Child Dropper"), Category("Basics"), Description("Changes which child dropper this is the parent to.")]
		public Droppers ChildDropper {get; set;} // Work this thing out and like make it work and shit - Lokiv

		[Property, Title("Price"), Category("Basics"), Description("Changes the price of this purchasable.")]
		public int Price {get; set;}

		public bool OnUse(Entity ent) 
		{
			return true;
		}

		public bool IsUsable(Entity ent) 
		{
			return true;
		}

		public override void Spawn()
		{
			base.Spawn();

			SetModel("models/Purchase/PurchaseBaseTemp.vmdl");
		}

		public override void StartTouch( Entity other )
		{
			base.StartTouch( other );

			Purchase();
		}

		public void Purchase(/*Purchasables purchasable*/) 
		{
			// purchase.IsPurchased = true;
			// Delete();
		}
	}
}
