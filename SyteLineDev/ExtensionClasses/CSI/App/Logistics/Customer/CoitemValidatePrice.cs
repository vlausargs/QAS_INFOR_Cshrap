//PROJECT NAME: CSICustomer
//CLASS NAME: CoitemValidatePrice.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface ICoitemValidatePrice
    {
        int CoitemValidatePriceSp(CoNumType CoNum,
                                  CoLineType CoLine,
                                  ItemType CoItem,
                                  AmountType Price,
                                  CurrCodeType CurrCode,
                                  ref InfobarType Infobar);
    }

    public class CoitemValidatePrice : ICoitemValidatePrice
    {
        readonly IApplicationDB appDB;

        public CoitemValidatePrice(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoitemValidatePriceSp(CoNumType CoNum,
                                         CoLineType CoLine,
                                         ItemType CoItem,
                                         AmountType Price,
                                         CurrCodeType CurrCode,
                                         ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoitemValidatePriceSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoItem", CoItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Price", Price, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CurrCode", CurrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
