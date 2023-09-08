//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateLinesValidCustItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEstimateLinesValidCustItem
    {
        int EstimateLinesValidCustItemSp(ItemType PCustItem,
                                         CustNumType PCustNum,
                                         ItemType PItem,
                                         ref ItemType PNewItem,
                                         ref UMType PNewUM,
                                         ref Infobar PQuestion,
                                         ref Infobar Infobar);
    }

    public class EstimateLinesValidCustItem : IEstimateLinesValidCustItem
    {
        readonly IApplicationDB appDB;

        public EstimateLinesValidCustItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EstimateLinesValidCustItemSp(ItemType PCustItem,
                                                CustNumType PCustNum,
                                                ItemType PItem,
                                                ref ItemType PNewItem,
                                                ref UMType PNewUM,
                                                ref Infobar PQuestion,
                                                ref Infobar Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EstimateLinesValidCustItemSp";

                appDB.AddCommandParameter(cmd, "PCustItem", PCustItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNewItem", PNewItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PNewUM", PNewUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PQuestion", PQuestion, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
