//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnShipLocValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface ITrnShipLocValid
    {
        int TrnShipLocValidSp(string Item,
                              string Whse,
                              string Site,
                              ref string Loc,
                              ref byte? ItemLocQuestionAsked,
                              ref string PromptMsg,
                              ref string PromptButtons,
                              ref string Infobar);
    }

    public class TrnShipLocValid : ITrnShipLocValid
    {
        readonly IApplicationDB appDB;

        public TrnShipLocValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int TrnShipLocValidSp(string Item,
                                     string Whse,
                                     string Site,
                                     ref string Loc,
                                     ref byte? ItemLocQuestionAsked,
                                     ref string PromptMsg,
                                     ref string PromptButtons,
                                     ref string Infobar)
        {
            ItemType _Item = Item;
            WhseType _Whse = Whse;
            SiteType _Site = Site;
            LocType _Loc = Loc;
            FlagNyType _ItemLocQuestionAsked = ItemLocQuestionAsked;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "TrnShipLocValidSp";

                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Loc", _Loc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemLocQuestionAsked", _ItemLocQuestionAsked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Loc = _Loc;
                ItemLocQuestionAsked = _ItemLocQuestionAsked;
                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
