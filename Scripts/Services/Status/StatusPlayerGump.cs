using System;
using Server.Gumps;
using Server.Mobiles;
using System.Linq;
using Server.Network;
using Server.Engines.CityLoyalty;

namespace Server.Engines.Points
{
    public class StatusPlayerGump : Gump
    {
        public StatusPlayerGump(PlayerMobile pm)
            : base(120, 120)
        {
            // AddImage(0, 0, 8000);
            // AddImage(20, 37, 8001);
            // AddImage(20, 107, 8002);
            // AddImage(20, 177, 8001);
            // AddImage(20, 247, 8002);
            // AddImage(20, 317, 8001);
            // AddImage(20, 387, 8003);

            AddBackground(0,0, 500, 500, 83);
            AddHtmlLocalized(0, 8, 500, 20, 1061057, false, false); // <center>Your statistics</center>

            AddItem(20, 25, 0x20cd);
            AddItem(20, 69, 0x20d6);
            // PvP and PvM Points
            AddHtmlLocalized(65, 25, 150, 50, 1061058, pm.PointSystems.PvPPoints.ToString(), 2050, false, false); // PvM Points:
            AddHtmlLocalized(65, 69, 150, 20, 1061059, pm.PointSystems.PvMPoints.ToString(), 2050, false, false); // PvP Points:




            //
            //
            // int y = 40;
            //
            // foreach (var sys in PointsSystem.Systems.Where(sys => sys.ShowOnLoyaltyGump))
            // {
            //     if (sys.Name.Number > 0)
            //         AddHtmlLocalized(50, y, 150, 20, sys.Name.Number, false, false);
            //     else if (sys.Name.String != null)
            //         AddHtml(50, y, 150, 20, sys.Name.String, false, false);
            //
            //     TextDefinition title = sys.GetTitle(pm);
            //
            //     if (title != null)
            //     {
            //         if (title.Number > 0)
            //             AddHtmlLocalized(68, y + 20, 100, 20, title.Number, false, false);
            //         else if (title.String != null)
            //             AddHtml(68, y + 20, 100, 20, title.String, false, false);
            //     }
            //
            //     AddHtmlLocalized(175, y + 20, 100, 20, 1095171, ((int)sys.GetPoints(pm)).ToString(), 0, false, false); // (~1_AMT~ points)
            //
            //     y += 45;
            // }
            //
            // // P
            // AddHtmlLocalized(50, 285, 150, 20, 1115129, pm.Fame.ToString(), 0, false, false); // Fame: ~1_AMT~
            // AddHtmlLocalized(50, 305, 150, 20, 1115130, pm.Karma.ToString(), 0, false, false); // Karma: ~1_AMT~}
            // // PvP and PvM Points
            // AddHtmlLocalized(50, 325, 150, 50, 1061055, pm.PointSystems.PvPPoints.ToString(), 0, false, false); // PvM Points:
            // AddHtmlLocalized(50, 345, 150, 20, 1061051, pm.PointSystems.PvMPoints.ToString(), 0, false, false); // PvP Points:
            //
            // if (CityLoyaltySystem.Enabled && CityLoyaltySystem.Cities != null)
            // {
            //     AddHtmlLocalized(60, 395, 150, 20, 1152190, false, false);  // City Loyalty
            //     AddButton(40, 400, 2103, 2104, 1, GumpButtonType.Reply, 0);
            // }
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            PlayerMobile pm = state.Mobile as PlayerMobile;

            if (CityLoyaltySystem.Enabled && CityLoyaltySystem.Cities != null && pm != null && info.ButtonID == 1)
                BaseGump.SendGump(new CityLoyaltyGump(pm));
        }
    }
}
