using System;
using System.Drawing;
using Server.Mobiles;

namespace Server.Items
{
    [Flipable(0x2684, 0x2683)]
    public class GMRobe : BaseOuterTorso
    {
        [Constructable]
        public GMRobe()
            : this(0x455)
        {
        }

        [Constructable]

        public GMRobe(int hue)
            : base(0x2684, hue)
        {

            Weight = 3.0;
            Name = $"GM Robe";
        }

        public GMRobe(Serial serial)
            : base(serial)
        {
        }

        public override bool Dye(Mobile from, DyeTub sender)
        {
            from.SendLocalizedMessage(sender.FailMessage);
            return false;
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }

    public class GMStaff : WildStaff
    {

        [Constructable]
        public GMStaff()
        {
            Name = "GM Staff";
            Hue = 1109;
        }

        public GMStaff(Serial serial) : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);
            writer.Write(0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);
            int version = reader.ReadInt();
        }
    }


    public class GMShield : WoodenKiteShield
    {
        [Constructable]
        public GMShield()
        {
            Name = "GM Shield";
            Hue = 1109;
            Attributes.NightSight = 1;
            Attributes.CastSpeed = 10000;
        }

        public GMShield(Serial serial)
            : base(serial)
        {
        }


        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.Write((int)0);
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadInt();
        }
    }
}
