//PROJECT NAME: Logistics
//CLASS NAME: ShipLcr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class ShipLcr : IShipLcr
    {
        readonly IApplicationDB appDB;

        public ShipLcr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }
        
        public (int? ReturnCode, string PromptMsg,
        string PromptButtons,
        string Infobar) ShipLcrSp(string PCoNum,
        DateTime? PTransDate,
        string PMText,
        string PromptMsg,
        string PromptButtons,
        string Infobar)
        {
            CoNumType _PCoNum = PCoNum;
            DateType _PTransDate = PTransDate;
            ObjectNameType _PMText = PMText;
            InfobarType _PromptMsg = PromptMsg;
            InfobarType _PromptButtons = PromptButtons;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ShipLcrSp";

                appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PMText", _PMText, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", _PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PromptMsg = _PromptMsg;
                PromptButtons = _PromptButtons;
                Infobar = _Infobar;

                return (Severity, PromptMsg, PromptButtons, Infobar);
            }
        }
    }
}
