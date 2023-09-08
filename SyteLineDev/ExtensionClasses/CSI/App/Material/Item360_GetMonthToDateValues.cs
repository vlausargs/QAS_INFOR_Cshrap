//PROJECT NAME: CSIMaterial
//CLASS NAME: Item360_GetMonthToDateValues.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IItem360_GetMonthToDateValues
    {
        int Item360_GetMonthToDateValuesSp(ItemType Item,
                                           ref AmountType BookingAmount,
                                           ref AmountType POFundAmount,
                                           ref AmountType ToCompleteAmount);
    }

    public class Item360_GetMonthToDateValues : IItem360_GetMonthToDateValues
    {
        readonly IApplicationDB appDB;

        public Item360_GetMonthToDateValues(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int Item360_GetMonthToDateValuesSp(ItemType Item,
                                                  ref AmountType BookingAmount,
                                                  ref AmountType POFundAmount,
                                                  ref AmountType ToCompleteAmount)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "Item360_GetMonthToDateValuesSp";

                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "BookingAmount", BookingAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POFundAmount", POFundAmount, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ToCompleteAmount", ToCompleteAmount, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
