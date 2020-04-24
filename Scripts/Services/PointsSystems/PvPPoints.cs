using System;
using System.Collections.Generic;

using Server;
using Server.Accounting;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;
using Server.Network;

namespace Server.Engines.Points
{
	public class PvPPoints : PointsSystem
	{
        public override PointsType Loyalty { get { return PointsType.PvPPoints; } }
		public override TextDefinition Name { get { return m_Name; } }
		public override bool AutoAdd { get { return true; } }
        public override double MaxPoints { get { return double.MaxValue; } }
        public override bool ShowOnLoyaltyGump { get { return false; } }

        private TextDefinition m_Name = new TextDefinition("PvP Points");

		public PvPPoints()
		{
		}

		public override void SendMessage(PlayerMobile from, double old, double points, bool quest)
		{
		}

		public override TextDefinition GetTitle(PlayerMobile from)
		{
			return new TextDefinition("PvP Points");
        }

        public override void ProcessKill(Mobile victim, Mobile killer)
        {
            PlayerMobile pm = killer as PlayerMobile;
            PlayerMobile v = victim as PlayerMobile;

            if (victim.Account == null)
            {
                return;
            }

            if (victim.Account != null && victim.Region.Name == "Destard")
            {
                double pvpbc = GetPoints(victim);
                double pvppm = GetPoints(pm);
                if (pvpbc <= 0)
                {
                    pm.SendMessage($"Вы не получите PvP points убивая новичков.");
                } else if (pvpbc >= 1 && pvpbc <= 14)
                {
                    pm.SendMessage($"Вы получили 1 PvP point.");
                    SetPoints(pm, (pvppm + 1) );
                    SetPointsBC(v, (pvpbc - 1));
                } else if (pvpbc >= 15 && pvpbc <= 44)
                {
                    pm.SendMessage($"Вы получили 2 PvP points.");
                    SetPoints(pm, (pvppm + 2) );
                    SetPointsBC(v, (pvpbc - 2));
                } else if (pvpbc >= 45 && pvpbc <= 89)
                {
                    pm.SendMessage($"Вы получили 3 PvP points.");
                    SetPoints(pm, (pvppm + 3) );
                    SetPointsBC(v, (pvpbc - 3));
                } else if (pvpbc >= 90 && pvpbc <= 149)
                {
                    pm.SendMessage($"Вы получили 4 PvP points.");
                    SetPoints(pm, (pvppm + 4) );
                    SetPointsBC(v, (pvpbc - 4));
                } else if (pvpbc >= 150 && pvpbc <= 224)
                {
                    pm.SendMessage($"Вы получили 5 PvP points.");
                    SetPoints(pm, (pvppm + 5) );
                    SetPointsBC(v, (pvpbc - 5));
                } else if (pvpbc >= 225 && pvpbc <= 314)
                {
                    pm.SendMessage($"Вы получили 6 PvP points.");
                    SetPoints(pm, (pvppm + 6) );
                    SetPointsBC(v, (pvpbc - 6));
                } else if (pvpbc >= 315 && pvpbc <= 419)
                {
                    pm.SendMessage($"Вы получили 7 PvP points.");
                    SetPoints(pm, (pvppm + 7) );
                    SetPointsBC(v, (pvpbc - 7));
                } else if (pvpbc >= 420 && pvpbc <= 539)
                {
                    pm.SendMessage($"Вы получили 8 PvP points.");
                    SetPoints(pm, (pvppm + 8) );
                    SetPointsBC(v, (pvpbc - 8));
                } else if (pvpbc >= 540 && pvpbc <= 674)
                {
                    pm.SendMessage($"Вы получили 9 PvP points.");
                    SetPoints(pm, (pvppm + 9) );
                    SetPointsBC(v, (pvpbc - 9));
                } else if (pvpbc >= 675 && pvpbc <= 999)
                {
                    pm.SendMessage($"Вы получили 10 PvP points.");
                    SetPoints(pm, (pvppm + 10) );
                    SetPointsBC(v, (pvpbc - 10));
                } else if (pvpbc >= 1000)
                {
                    pm.SendMessage($"Вы получили 20 PvP points.");
                    SetPoints(pm, (pvppm + 20) );
                    SetPointsBC(v, (pvpbc - 20));
                }

                pm.SendMessage($"Account not null");
                pm.SendMessage($"BC:{pvpbc} PM:{pvppm}");
                victim.SendMessage($"Hello");
            }
        }


        public virtual double GetPoints(Mobile from)
        {
            PointsEntry entry = GetEntry(from);

            if (entry != null)
                return entry.Points;

            return 0.0;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            reader.ReadInt();
        }
	}
}
