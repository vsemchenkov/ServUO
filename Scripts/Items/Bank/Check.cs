using System;
using System.Windows.Forms;
using Server.Network;

namespace Server.Items.Bank
{
    [FlipableAttribute(0x14f1, 0x14f2)]
    public class Check : Item
    {
        [Constructable]
        public Check()
            : this(1)
        {
        }

        [Constructable]
        public Check(int amount)
            : base(0x14f1)
        {
            Stackable = true;
            Amount = amount;
            Hue = 2075;
        }

        public Check(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 3000286;
            }
        }// abyssal cloth


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

        public bool Scissor(Mobile from, Scissors scissors)
        {
            if (Deleted || !from.CanSee(this))
                return false;

            base.ScissorHelper(from, new Bandage(), 1);

            return true;
        }
    }

    [FlipableAttribute(0x14f1, 0x14f2)]
    public class Check1kk : Item
    {
        [Constructable]
        public Check1kk()
            : this(1)
        {
        }

        [Constructable]
        public Check1kk(int amount)
            : base(0x14f1)
        {
            Name = "1kk check";
            Amount = amount;
            Hue = 0x0494;
        }

        public Check1kk(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 3000286;
            }
        }// 1kk check

        public override void OnDoubleClick(Mobile @from)
        {
            if (from.Backpack.FindItemByType<Check1kk>(true) == null)
            {
                from.SendMessage("Положите чек в рюкзак.");
            } else if (from.Backpack.FindItemByType<Check1kk>(true) != null)
            {

                for (var i = 0; i <= 19; i++)
                {
                    var golds = new Gold();
                    golds.Amount = 50000;
                    from.Backpack.AddItem(golds);
                }
                this.Delete();


                from.SendMessage("Вы обналичили чек.");
            };
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

    [FlipableAttribute(0x14f1, 0x14f2)]
    public class Check500k : Item
    {
        [Constructable]
        public Check500k()
            : this(1)
        {
        }

        [Constructable]
        public Check500k(int amount)
            : base(0x14f1)
        {
            Name = "500k check";
            Amount = amount;
            Hue = 0x0492;
        }

        public Check500k(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 3000286;
            }
        }// 1kk check

        public override void OnDoubleClick(Mobile @from)
        {
            if (from.Backpack.FindItemByType<Check500k>(true) == null)
            {
                from.SendMessage("Положите чек в рюкзак.");
            } else if (from.Backpack.FindItemByType<Check500k>(true) != null)
            {

                for (var i = 0; i <= 9; i++)
                {
                    var golds = new Gold();
                    golds.Amount = 50000;
                    from.Backpack.AddItem(golds);
                }

               this.Delete();

                from.SendMessage("Вы обналичили чек.");
            };
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

    [FlipableAttribute(0x14f1, 0x14f2)]
    public class Check200k : Item
    {
        [Constructable]
        public Check200k()
            : this(1)
        {
        }

        [Constructable]
        public Check200k(int amount)
            : base(0x14f1)
        {
            Name = "200k check";
            Amount = amount;
            Hue = 0x0513;
        }

        public Check200k(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 3000286;
            }
        }// 1kk check

        public override void OnDoubleClick(Mobile @from)
        {
            if (from.Backpack.FindItemByType<Check200k>(true) == null)
            {
                from.SendMessage("Положите чек в рюкзак.");
            } else if (from.Backpack.FindItemByType<Check200k>(true) != null)
            {

                for (var i = 0; i <= 3; i++)
                {
                    var golds = new Gold();
                    golds.Amount = 50000;
                    from.Backpack.AddItem(golds);
                }

                this.Delete();

                from.SendMessage("Вы обналичили чек.");
            };
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

    [FlipableAttribute(0x14f1, 0x14f2)]
    public class Check100k : Item
    {

        [Constructable]
        public Check100k()
            : base(0x14f1)
        {
            Name = "100k check";
            Amount = 1;
            Hue = 0x0482;
        }

        public Check100k(Serial serial)
            : base(serial)
        {
        }

        public override int LabelNumber
        {
            get
            {
                return 3000286;
            }
        }// 1kk check

        public override void OnDoubleClick(Mobile @from)
        {
            if (from.Backpack.FindItemByType<Check100k>(true) == null)
            {
                from.SendMessage("Положите чек в рюкзак.");
            } else if (from.Backpack.FindItemByType<Check100k>(true) != null)
            {

                for (var i = 0; i <= 1; i++)
                {
                    var golds = new Gold();
                    golds.Amount = 50000;
                    from.Backpack.AddItem(golds);

                }
                this.Delete();


                from.SendMessage("Вы обналичили чек.");
            };
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


}
