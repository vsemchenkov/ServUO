#region References
using System;

using Server.Accounting;
using Server.Network;
using Server.Services.TownCryer;
#endregion

namespace Server
{
	public class CurrentExpansion
	{
		public static readonly Expansion Expansion = Expansion.EJ;

		[CallPriority(Int32.MinValue)]
		public static void Configure()
		{
			Core.Expansion = Expansion;

			AccountGold.Enabled = true;
			AccountGold.ConvertOnBank = true;
			AccountGold.ConvertOnTrade = false;
			VirtualCheck.UseEditGump = true;

			TownCryerSystem.Enabled = true;

            Mobile.InsuranceEnabled = !Siege.SiegeShard;
			Mobile.VisibleDamageType = VisibleDamageType.Related;

			AOS.DisableStatInfluences();

			Mobile.ActionDelay = 500;
			Mobile.AOSStatusHandler = AOS.GetStatus;
		}
	}
}
