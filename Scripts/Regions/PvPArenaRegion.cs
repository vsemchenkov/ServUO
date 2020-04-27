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

        public PvPArenaRegion(XmlElement xml, Map map, Region parent)
            : base(xml, map, parent)
        {
        }

        public override void AlterLightLevel(Mobile m, ref int global, ref int personal)
        {
            global = LightCycle.DayLevel;
        }

        public override bool OnBeginSpellCast(Mobile m, ISpell s)
        {
            m.HarmfulCheck(m);
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
