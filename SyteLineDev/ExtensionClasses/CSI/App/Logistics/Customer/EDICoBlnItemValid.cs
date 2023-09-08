//PROJECT NAME: CSICustomer
//CLASS NAME: EDICoBlnItemValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEDICoBlnItemValid
    {
        int EDICoBlnItemValidSp(string CoNum,
                                ref string Item,
                                string CustNum,
                                string CurrCode,
                                ref string CustItem,
                                ref string FeatStr,
                                ref string ItemUM,
                                ref string ItemDesc,
                                ref string Infobar);
    }

    public class EDICoBlnItemValid : IEDICoBlnItemValid
    {
        readonly IApplicationDB appDB;

        public EDICoBlnItemValid(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EDICoBlnItemValidSp(string CoNum,
                                       ref string Item,
                                       string CustNum,
                                       string CurrCode,
                                       ref string CustItem,
                                       ref string FeatStr,
                                       ref string ItemUM,
                                       ref string ItemDesc,
                                       ref string Infobar)
        {
            CoNumType _CoNum = CoNum;
            ItemType _Item = Item;
            CustNumType _CustNum = CustNum;
            CurrCodeType _CurrCode = CurrCode;
            CustItemType _CustItem = CustItem;
            FeatStrType _FeatStr = FeatStr;
            UMType _ItemUM = ItemUM;
            DescriptionType _ItemDesc = ItemDesc;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EDICoBlnItemValidSp";

                appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ItemDesc", _ItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                Item = _Item;
                CustItem = _CustItem;
                FeatStr = _FeatStr;
                ItemUM = _ItemUM;
                ItemDesc = _ItemDesc;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
