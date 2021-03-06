using System;
using System.Collections.Generic;
using System.Xml;
using Server.Engines.Points;
using Server.Spells.Chivalry;
using Server.Spells.Fourth;
using Server.Spells.Seventh;
using Server.Spells.Sixth;
using Server.Engines.Quests;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Misc;


namespace Server.Regions
{

    public class PvPArenaRegion : DungeonRegion
    {
        private bool m_PvPPointsEnable = false;

        public virtual bool PvPPointsEnable
        {
            get { return m_PvPPointsEnable; }
            set { m_PvPPointsEnable = value; }
        }



        public PvPArenaRegion(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public override void AlterLightLevel(Mobile m, ref int global, ref int personal)
        {
            global = LightCycle.DayLevel;
        }

        public override void OnEnter(Mobile m)
        {
            Map.Rules = MapRules.FeluccaRules;
            m.LocalOverheadMessage(MessageType.Emote, 2050, true, "Welcome to PvP Arena!");
            m.LocalOverheadMessage(MessageType.Emote, 2050, true, "Сражение начинается!");
        }

        public override bool OnBeginSpellCast(Mobile m, ISpell s)
        {
            if (m.IsPlayer())
            {
                if (s is MarkSpell)
                {
                    m.SendLocalizedMessage(501802); // Thy spell doth not appear to work...
                    return false;
                }
                else if (s is GateTravelSpell || s is RecallSpell || s is SacredJourneySpell)
                {
                    m.SendLocalizedMessage(501035); // You cannot teleport from here to the destination.
                    return false;
                }
            }

            return base.OnBeginSpellCast(m, s);
        }
    }
}
