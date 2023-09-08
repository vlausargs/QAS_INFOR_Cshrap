//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSXrefPreCreateT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSXrefPreCreateT
    {
        int SSSFSXrefPreCreateTSp(string iItem,
                                  string iToWhse,
                                  ref string oFromSite,
                                  ref string oFromWhse,
                                  ref string Infobar);
    }

    public class SSSFSXrefPreCreateT : ISSSFSXrefPreCreateT
    {
        readonly IApplicationDB appDB;

        public SSSFSXrefPreCreateT(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSXrefPreCreateTSp(string iItem,
                                         string iToWhse,
                                         ref string oFromSite,
                                         ref string oFromWhse,
                                         ref string Infobar)
        {
            ItemType _iItem = iItem;
            WhseType _iToWhse = iToWhse;
            SiteType _oFromSite = oFromSite;
            WhseType _oFromWhse = oFromWhse;
            Infobar _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSXrefPreCreateTSp";

                appDB.AddCommandParameter(cmd, "iItem", _iItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iToWhse", _iToWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "oFromSite", _oFromSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oFromWhse", _oFromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                oFromSite = _oFromSite;
                oFromWhse = _oFromWhse;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
