using Server;
using System;
using Server.Accounting;
using Server.Mobiles;
using System.Globalization;
using Server.Engines.Shadowguard;
using Server.Network;
using Server.Items;
using Server.Items.Bank;

namespace Server.Gumps
{
    public class BankerGump : Gump
    {
        private int TextColor = 0x000F;

        public PlayerMobile User { get; set; }

        public BankerGump(PlayerMobile pm)
            : base(150, 150)
        {
            User = pm;
            AddGumpLayout();
        }

        public void AddGumpLayout()
        {
            AddBackground(0, 0, 420, 460, 9500);

            AddHtmlLocalized(0, 10, 420, 16, 1113302, "#1156076", 1, false, false); // Bank Actions

            Account acct = User.Account as Account;

            AddHtmlLocalized(15, 35, 150, 16, 1156044, false, false); // Total Gold:
            AddHtml(130, 35, 200, 16,
                acct != null ? acct.TotalGold.ToString("N0", CultureInfo.GetCultureInfo("en-US")) : "0", false, false);

            // AddHtmlLocalized(15, 55, 150, 16, 1156045, false, false); // Total Platinum:
            // AddHtml(130, 55, 200, 16,
            //     acct != null ? acct.TotalPlat.ToString("N0", CultureInfo.GetCultureInfo("en-US")) : "0", false, false);

            AddHtmlLocalized(15, 55, 150, 16, 1157003, false, false); // Secure Account:
            AddHtml(130, 55, 200, 16,
                acct != null
                    ? acct.GetSecureAccountAmount(User).ToString("N0", CultureInfo.GetCultureInfo("en-US"))
                    : "0", false, false);

            // AddHtmlLocalized(15, 95, 150, 16, 1157004, false, false); // Transfer Gold:
            // AddHtml(130, 95, 200, 16, "0", false, false);
            //
            // AddHtmlLocalized(15, 115, 150, 16, 1157005, false, false); // Transfer Platinum:
            // AddHtml(130, 115, 200, 16, "0", false, false);

            AddHtmlLocalized(270, 35, 90, 16, 1114514, "Help", 0, false, false);
            AddButton(370, 35, 4014, 4015, 7, GumpButtonType.Reply, 0);

            AddHtmlLocalized(60, 85, 360, 16, 1156064, TextColor, false,
                false); // Deposit Gold into Character Transfer Account
            AddButton(20, 85, 4005, 4006, 1, GumpButtonType.Reply, 0);
            AddTooltip(1156070); // Transfers gold from the bank to the character transfer account; capped at 1 billion gold. Any currency that
            // a players wishes to transfer to another shard must be placed in character transfer account. Upon transferring
            // the currency will be added to player's account on the shard.

            // AddHtmlLocalized(60, 180, 300, 16, 1156065, TextColor, false,
            //     false); // Deposit Platinum into Character Transfer Account
            // AddButton(20, 180, 4005, 4006, 2, GumpButtonType.Reply, 0);
            // AddTooltip(1156071); // Transfers platinum from the bank to the character transfer account; capped at 2 billion platinum. Any currency
            // // that a players wishes to transfer to another shard must be placed in character transfer account. Upon transferring
            // // the currency will be added to player's account on the shard.

            AddHtmlLocalized(60, 115, 300, 16, 1156066, TextColor, false,
                false); // Withdraw Gold from Character Transfer Account
            AddButton(20, 115, 4005, 4006, 3, GumpButtonType.Reply, 0);
            AddTooltip(1156072); // Transfers gold from the character transfer account to the bank; capped at 1 billion gold.

            // AddHtmlLocalized(60, 240, 300, 16, 1156067, TextColor, false,
            //     false); // Withdraw Platinum from Character Transfer Account
            // AddButton(20, 240, 4005, 4006, 4, GumpButtonType.Reply, 0);
            // AddTooltip(1156073); // Transfers platinum from the character transfer account to the bank; capped at 2 billion platinum. Really? Who the fuck has this much?

            AddHtmlLocalized(60, 145, 300, 16, 1156068, TextColor, false, false); // Deposit Gold into Secure Account
            AddButton(20, 145, 4005, 4006, 5, GumpButtonType.Reply, 0);
            AddTooltip(1156074); // Transfers gold from the bank to the player's secure account; capped at 100,000,000 gold. Only funds added
            // to the secure account can be added to the wall safe account.

            AddHtmlLocalized(60, 175, 300, 16, 1156069, TextColor, false, false); // Withdraw Gold from Secure Account
            AddButton(20, 175, 4005, 4006, 6, GumpButtonType.Reply, 0);
            AddTooltip(1156075); // Transfers gold from the secure account to the bank; capped at 100,0,000 gold.

            //Gump Element Guide - Value Position
            //AddBackground(X, Y, Width, Heigth, GumpID);
            //AddAlphaRegion(X, Y, Width, Heigth);
            //AddImage(X, Y, GumpID);
            //AddImageTiled(X, Y, Width, Heigth, GumpID);
            //AddLabel(X, Y, Hue, "Text");
            //AddLabelCropped(X, Y, Width, Heigth, Hue, "Text");
            //AddTextEntry(X, Y, Width, Heigth, Hue, ReplyID, "Text", Textbox.Size);
            //AddHtml(X, Y, Width, Heigth, "Text", Background(true/False), ScrollBar(True/False));
            //AddItem(X, Y, GumpID, Hue);
            //AddButton(X, Y, GumpID(Not Pressed), GumpID(Pressed), ReplyID, GumpButtonType.Reply(Page), Param);
            //AddRadio(X, Y, GumpID(Not Pressed), GumpID(Pressed), InitialState(True/False), ReplyID);
            //AddCheck(X, Y, GumpID(Not Pressed), GumpID(Pressed), InitialState(True/False), ReplyID);

            AddImage(5, 200, 1520);
            // Issue a checks
            AddHtmlLocalized(170, 295, 420, 16, 1061048, "#1156076", 1, false, false); // Bank checks
            // 1kk check
            AddButton(20, 320, 2151, 2153, 8, GumpButtonType.Reply, 0);
            AddHtmlLocalized(60, 327, 300, 16, 1061184, "1kk check", TextColor, false,
                false); // Withdraw Gold from Secure Account
            // 500k check
            AddButton(20, 350, 2151, 2153, 9, GumpButtonType.Reply, 0);
            AddHtmlLocalized(60, 357, 300, 16, 1061185, "500k check", TextColor, false,
                false); // Withdraw Gold from Secure Account
            // 200k check
            AddButton(20, 380, 2151, 2153, 10, GumpButtonType.Reply, 0);
            AddHtmlLocalized(60, 387, 300, 16, 1061186, "200k check", TextColor, false,
                false); // Withdraw Gold from Secure Account
            // 100k check
            AddButton(20, 410, 2151, 2153, 11, GumpButtonType.Reply, 0);
            AddHtmlLocalized(60, 417, 300, 16, 1061187, "100k check", TextColor, false,
                false); // Withdraw Gold from Secure Account
        }

        public override void OnResponse(NetState state, RelayInfo info)
        {
            Account acct = User.Account as Account;

            switch (info.ButtonID)
            {
                case 0: break;
                case 1:
                    User.SendLocalizedMessage(1155866); // Enter amount to withdraw:
                    User.BeginPrompt(
                        (from, text, ac) =>
                        {
                            int v = 0;
                            double z = 0;

                            if (ac != null)
                            {
                                if (text != null && !String.IsNullOrEmpty(text))
                                {
                                    v = Utility.ToInt32(text);

                                    if (ac != null)
                                    {
                                        if (v <= 0 || v > from.TotalGold)
                                            from.SendLocalizedMessage(
                                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                                        else
                                        {
                                            Item[] gold, checks;
                                            var balance = Banker.GetBalance(from, out gold, out checks);
                                            Gold Golds = new Gold();
                                            var golds = from.Backpack.FindItemsByType<Gold>(true);



                                            Console.WriteLine(golds.Count);
                                            Console.WriteLine(golds);


                                            if (balance < v)
                                            {
                                                from.SendLocalizedMessage(3000285);
                                            }

                                            Banker.Deposit(from, v, true);
                                            // ((PlayerMobile) from).AccountSovereigns;

                                            for (var i = 0; v > 0 && i < golds.Count; ++i)
                                            {
                                                if (golds[i].Amount <= v)
                                                {
                                                    v -= golds[i].Amount;
                                                    golds[i].Delete();
                                                }
                                                else
                                                {
                                                    golds[i].Amount -= v;
                                                    v = 0;
                                                }
                                            }

                                            from.SendLocalizedMessage(1153188); // Transaction successful:
                                        }

                                        Timer.DelayCall(TimeSpan.FromSeconds(2), SendGump);
                                    }
                                }
                                else
                                    from.SendLocalizedMessage(
                                        1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            }
                        },
                        (from, text, act) =>
                        {
                            User.SendLocalizedMessage(
                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            User.SendGump(new BankerGump(User));
                        }, acct);
                    break;
                case 2: break;
                case 3:
                    User.SendLocalizedMessage(1155866); // Enter amount to withdraw:
                    User.BeginPrompt(
                        (from, text, ac) =>
                        {
                            int v = 0;
                            double z = 0;

                            if (ac != null)
                            {
                                if (text != null && !String.IsNullOrEmpty(text))
                                {
                                    v = Utility.ToInt32(text);

                                    if (ac != null)
                                    {
                                        if (v <= 0 || v > Banker.GetBalance(from))
                                            from.SendLocalizedMessage(
                                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                                        else
                                        {
                                            Banker.Withdraw(from, v, true);

                                            Item backpack = from.FindItemOnLayer(Layer.Backpack);
                                            Gold gold = new Gold();
                                            gold.Amount = v;

                                            backpack.AddItem(gold);


                                            from.SendLocalizedMessage(1153188); // Transaction successful:
                                        }

                                        Timer.DelayCall(TimeSpan.FromSeconds(2), SendGump);
                                    }
                                }
                                else
                                    from.SendLocalizedMessage(
                                        1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            }
                        },
                        (from, text, act) =>
                        {
                            User.SendLocalizedMessage(
                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            User.SendGump(new BankerGump(User));
                        }, acct);
                    break;
                case 4:
                    break;
                case 5:
                    User.SendLocalizedMessage(1155865); // Enter amount to deposit:
                    User.BeginPrompt<Account>(
                        (from, text, account) =>
                        {
                            int v = 0;

                            if (account != null)
                            {
                                int canHold = Account.MaxSecureAmount - account.GetSecureAccountAmount(from);

                                if (text != null && !String.IsNullOrEmpty(text))
                                {
                                    v = Utility.ToInt32(text);

                                    if (v <= 0 || v > canHold || v > Banker.GetBalance(from))
                                        from.SendLocalizedMessage(
                                            1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                                    else if (account != null)
                                    {
                                        if (v > canHold)
                                            v = canHold;

                                        Banker.Withdraw(from, v, true);
                                        account.DepositToSecure(from, v);

                                        from.SendLocalizedMessage(1153188); // Transaction successful:

                                        Timer.DelayCall(TimeSpan.FromSeconds(2), SendGump);
                                    }
                                }
                                else
                                    from.SendLocalizedMessage(
                                        1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            }
                        },
                        (from, text, a) =>
                        {
                            User.SendLocalizedMessage(
                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            User.SendGump(new BankerGump(User));
                        }, acct);
                    break;
                case 6:
                    User.SendLocalizedMessage(1155866); // Enter amount to withdraw:
                    User.BeginPrompt(
                        (from, text, ac) =>
                        {
                            int v = 0;

                            if (ac != null)
                            {
                                if (text != null && !String.IsNullOrEmpty(text))
                                {
                                    v = Utility.ToInt32(text);

                                    if (ac != null)
                                    {
                                        if (v <= 0 || v > acct.GetSecureAccountAmount(from))
                                            from.SendLocalizedMessage(
                                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                                        else
                                        {
                                            Banker.Deposit(from, v, true);
                                            ac.WithdrawFromSecure(from, v);

                                            from.SendLocalizedMessage(1153188); // Transaction successful:
                                        }

                                        Timer.DelayCall(TimeSpan.FromSeconds(2), SendGump);
                                    }
                                }
                                else
                                    from.SendLocalizedMessage(
                                        1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            }
                        },
                        (from, text, act) =>
                        {
                            User.SendLocalizedMessage(
                                1155867); // The amount entered is invalid. Verify that there are sufficient funds to complete this transaction.
                            User.SendGump(new BankerGump(User));
                        }, acct);
                    break;
                case 7:
                    User.CloseGump(typeof(NewCurrencyHelpGump));
                    User.SendGump(new NewCurrencyHelpGump());
                    Refresh();
                    break;
                // 1kk check
                case 8:
                    if (Banker.GetBalance(User) >= 1000000)
                    {
                        Banker.Withdraw(User, 1000000, true);

                        Item backpack = User.FindItemOnLayer(Layer.Backpack);
                        Check1kk check1kk = new Check1kk();
                        check1kk.Amount = 1;
                        backpack.AddItem(check1kk);

                        User.SendMessage("Вы получили чек.");
                    }
                    else
                    {
                        User.SendMessage("Вам не хватает gold.");
                    }
                    Refresh();
                    break;
                // 500k check
                case 9:
                    if (Banker.GetBalance(User) >= 500000)
                    {
                        Banker.Withdraw(User, 500000, true);

                        Item backpack = User.FindItemOnLayer(Layer.Backpack);
                        Check500k check500k = new Check500k();
                        check500k.Amount = 1;
                        backpack.AddItem(check500k);

                        User.SendMessage("Вы получили чек.");
                    }
                    else
                    {
                        User.SendMessage("Вам не хватает gold.");
                    }
                    Refresh();
                    break;
                // 200k check
                case 10:
                    if (Banker.GetBalance(User) >= 200000)
                    {
                        Banker.Withdraw(User, 200000, true);

                        Item backpack = User.FindItemOnLayer(Layer.Backpack);
                        Check200k check200k = new Check200k();
                        check200k.Amount = 1;
                        backpack.AddItem(check200k);

                        User.SendMessage("Вы получили чек.");
                    }
                    else
                    {
                        User.SendMessage("Вам не хватает gold.");
                    }
                    Refresh();
                    break;
                // 100k check
                case 11:
                    if (Banker.GetBalance(User) >= 100000)
                    {
                        Banker.Withdraw(User, 100000, true);

                        Item backpack = User.FindItemOnLayer(Layer.Backpack);
                        Check100k check100k = new Check100k();
                        check100k.Amount = 1;
                        backpack.AddItem(check100k);

                        User.SendMessage("Вы получили чек.");
                    }
                    else
                    {
                        User.SendMessage("Вам не хватает gold.");
                    }
                    Refresh();
                    break;
            }
        }


        private void SendGump()
        {
            User.SendGump(new BankerGump(User));
        }

        public void Refresh(bool recompile = true)
        {
            if (recompile)
            {
                Entries.Clear();
                Entries.TrimExcess();
                AddGumpLayout();
            }

            User.CloseGump(this.GetType());
            User.SendGump(this, false);
        }
    }

    public class NewCurrencyHelpGump : Gump
    {
        public NewCurrencyHelpGump() : base(50, 75)
        {
            AddBackground(0, 0, 875, 480, 5170);
            AddHtmlLocalized(50, 40, 775, 440, 1156048, Engines.Quests.BaseQuestGump.C32216(0x6495ED), false, false);
        }
    }
}
