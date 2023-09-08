//PROJECT NAME: CSIMaterial
//CLASS NAME: ProcessTaxFreeImportUtility.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
    public interface IProcessTaxFreeImportUtility
    {
        int ProcessTaxFreeImportUtilitySp(ItemType StartingItem,
                                          ItemType EndingItem,
                                          ProductCodeType StartingProductCode,
                                          ProductCodeType EndingProductCode,
                                          ref InfobarType Infobar);
    }

    public class ProcessTaxFreeImportUtility : IProcessTaxFreeImportUtility
    {
        readonly IApplicationDB appDB;

        public ProcessTaxFreeImportUtility(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ProcessTaxFreeImportUtilitySp(ItemType StartingItem,
                                                 ItemType EndingItem,
                                                 ProductCodeType StartingProductCode,
                                                 ProductCodeType EndingProductCode,
                                                 ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ProcessTaxFreeImportUtilitySp";

                appDB.AddCommandParameter(cmd, "StartingItem", StartingItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingItem", EndingItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingProductCode", StartingProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingProductCode", EndingProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
