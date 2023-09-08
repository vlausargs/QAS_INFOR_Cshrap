//PROJECT NAME: CSICustomer
//CLASS NAME: EstimateItemChangeCustItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IEstimateItemChangeCustItem
    {
        int EstimateItemChangeCustItemSp(CustNumType PCustNum,
                                         ItemType PItem,
                                         ref ItemType PCustItem);
    }

    public class EstimateItemChangeCustItem : IEstimateItemChangeCustItem
    {
        readonly IApplicationDB appDB;

        public EstimateItemChangeCustItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EstimateItemChangeCustItemSp(CustNumType PCustNum,
                                                ItemType PItem,
                                                ref ItemType PCustItem)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EstimateItemChangeCustItemSp";

                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustItem", PCustItem, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
