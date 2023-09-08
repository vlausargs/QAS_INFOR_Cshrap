//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSGetUnitItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSGetUnitItem
    {
        int SSSFSGetUnitItemSp(SerNumType Unit,
                               ref ItemType Item,
                               ref CustNumType CustNum,
                               ref CustSeqType CustSeq,
                               ref NameType CustName,
                               ref ListYesNoType CreditHold,
                               ref ReasonCodeType CreditHoldReason,
                               ref DescriptionType CreditHoldDesc,
                               ref InfobarType Infobar);
    }

    public class SSSFSGetUnitItem : ISSSFSGetUnitItem
    {
        readonly IApplicationDB appDB;

        public SSSFSGetUnitItem(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSGetUnitItemSp(SerNumType Unit,
                                      ref ItemType Item,
                                      ref CustNumType CustNum,
                                      ref CustSeqType CustSeq,
                                      ref NameType CustName,
                                      ref ListYesNoType CreditHold,
                                      ref ReasonCodeType CreditHoldReason,
                                      ref DescriptionType CreditHoldDesc,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSGetUnitItemSp";

                appDB.AddCommandParameter(cmd, "Unit", Unit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Item", Item, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustNum", CustNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustSeq", CustSeq, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CustName", CustName, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHold", CreditHold, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHoldReason", CreditHoldReason, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "CreditHoldDesc", CreditHoldDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}

