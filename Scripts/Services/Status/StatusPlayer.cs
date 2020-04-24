using System;
using Server.ContextMenus;
using Server.Mobiles;

namespace Server.Engines.Points
{
    public class StatusPlayer : ContextMenuEntry
    {
        private PlayerMobile m_From;

        public StatusPlayer(PlayerMobile from)
            : base(1061056)
        {
            m_From = from;
        }

        public override void OnClick()
        {
            if (m_From != null)
            {
                m_From.CloseGump(typeof(StatusPlayerGump));
                m_From.SendGump(new StatusPlayerGump(m_From));
            }

        }
    }
}
