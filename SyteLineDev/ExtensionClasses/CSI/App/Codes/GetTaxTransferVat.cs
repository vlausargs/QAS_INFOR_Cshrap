//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxTransferVat.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetTaxTransferVat
    {
        int GetTaxTransferVatSp(ref byte? PTransferVat,
                                ref string Infobar);
    }

    public class GetTaxTransferVat : IGetTaxTransferVat
    {
        readonly IApplicationDB appDB;

        public GetTaxTransferVat(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetTaxTransferVatSp(ref byte? PTransferVat,
                                       ref string Infobar)
        {
            ListYesNoType _PTransferVat = PTransferVat;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTaxTransferVatSp";

                appDB.AddCommandParameter(cmd, "PTransferVat", _PTransferVat, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                PTransferVat = _PTransferVat;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
