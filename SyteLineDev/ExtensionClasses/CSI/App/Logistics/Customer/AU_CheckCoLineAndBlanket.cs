//PROJECT NAME: CSICustomer
//CLASS NAME: AU_CheckCoLineAndBlanket.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public interface IAU_CheckCoLineAndBlanket
    {
        int AU_CheckCoLineAndBlanketSp(CoNumType CoNum,
                                       CoLineType CoLine,
                                       ref ItemType Item,
                                       ref UMType UM,
                                       ref DescriptionType Description,
                                       ref CustItemType CustItem,
                                       ref UMType CustUM,
                                       ref InfobarType Infobar);
    }

    public class AU_CheckCoLineAndBlanket : IAU_CheckCoLineAndBlanket
    {
        readonly IApplicationDB appDB;

        public AU_CheckCoLineAndBlanket(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int AU_CheckCoLineAndBlanketSp(CoNumType CoNum,
                                              CoLineType CoLine,
                                              ref ItemType Item,
                                              ref UMType UM,
                                              ref DescriptionType Description,
                                              ref CustItemType CustItem,
                                              ref UMType CustUM,
                                              ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "AU_CheckCoLineAndBlanketSp";

                appDB.AddCommandParameter(cmd, "CoNum", CoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "CoLine", CoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "UM", UM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Description", Description, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustItem", CustItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustUM", CustUM, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
