using System;
using System.Collections.Generic;

using Server;
using Server.Accounting;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Points
{
	public class PvMPoints : PointsSystem
	{
        public override PointsType Loyalty { get { return PointsType.PvMPoints; } }
		public override TextDefinition Name { get { return m_Name; } }
		public override bool AutoAdd { get { return true; } }
        public override double MaxPoints { get { return double.MaxValue; } }
        public override bool ShowOnLoyaltyGump { get { return false; } }

        private TextDefinition m_Name = new TextDefinition("PvM Points");

		public PvMPoints()
		{
		}

		public override void SendMessage(PlayerMobile from, double old, double points, bool quest)
		{
		}

		public override TextDefinition GetTitle(PlayerMobile from)
		{
			return new TextDefinition("PvM Points");
        }

        public override void ProcessKill(Mobile victim, Mobile killer)
        {
            PlayerMobile pm = killer as PlayerMobile;
            BaseCreature bc = victim as BaseCreature;

            if (pm == null || bc == null || bc.NoKillAwards || !pm.Alive)
                return;

            //Make sure its a boss we killed!!
            bool boss = bc is Wyvern || bc is Impaler || bc is DemonKnight || bc is DarknightCreeper || bc is FleshRenderer || bc is ShadowKnight || bc is AbysmalHorror;

            if (!boss)
                return;

            if (pm.Region.Name == "Destard")
            {
                pm.SendMessage($"STR: {bc.Str}");
                double pvmpoints = GetPoints(pm);
                SetPoints(pm, (pvmpoints + Math.Max(0, bc.Str / 29)) );
                double resultPvM = GetPoints(pm) - pvmpoints;
                pm.SendMessage($"Вы получили {resultPvM} PvM Points");
            }
            else
            {
                pm.SendMessage($"За убийство мобов вы можете получить PvM points убив их в Dangeons!");
            }


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
