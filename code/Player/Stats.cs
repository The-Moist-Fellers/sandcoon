using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sandbox;

namespace SC
{
	public partial class SCPlayer
	{
		//This needs to be networked so the client can see it - Rifter
		[Net]
		public int Money { get; private set; } = 0;

		//This could be optional if we decide to do this, remove if not wanted - Rifter
		[Net]
		public int Rebirths { get; private set; } = 0;

		public void AddMoney(int newAmt)
		{
			Money += newAmt;
		}

		public void TakeMoney(int subAmt)
		{
			Money -= subAmt;
		}

		public void SetMoney(int setAmt)
		{
			Money = setAmt;
		}
	}
}
