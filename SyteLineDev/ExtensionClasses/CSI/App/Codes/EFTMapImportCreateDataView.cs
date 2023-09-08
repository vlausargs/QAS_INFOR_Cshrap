//PROJECT NAME: CSICodes
//CLASS NAME: EFTMapImportCreateDataView.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IEFTMapImportCreateDataView
    {
        int EFTMapImportCreateDataViewSp(EFTTypeType EFTType,
                                         ref InfobarType InfoBar);
    }

    public class EFTMapImportCreateDataView : IEFTMapImportCreateDataView
    {
        readonly IApplicationDB appDB;

        public EFTMapImportCreateDataView(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int EFTMapImportCreateDataViewSp(EFTTypeType EFTType,
                                                ref InfobarType InfoBar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "EFTMapImportCreateDataViewSp";

                appDB.AddCommandParameter(cmd, "EFTType", EFTType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InfoBar", InfoBar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
