using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;
using SandboxEditor;

namespace SC
{
	//The base of tycoons

	[Title( "Tycoon Base Platform" ), Category( "Base" ), Icon( "add_circle" )]
	[Library("tycoon_base")]
	[HammerEntity]
	[Model]

	public partial class TycoonBase : ModelEntity
	{
		public SCPlayer tycoonOwner;

		[Property, Title( "Tycoon Items" ), Description("Adds an item for this tycoon")]
		public ModelEntity[] TycoonItems { get; set; }

		public void ClaimOwnership(SCPlayer newOwner)
		{
			tycoonOwner = newOwner;
		}

		public void ResetTycoon()
		{
			tycoonOwner = null;
		}
	}
}
