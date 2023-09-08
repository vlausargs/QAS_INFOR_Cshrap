//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSROGetFirstOpenLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
    public interface ISSSFSSROGetFirstOpenLine
    {
        int SSSFSSROGetFirstOpenLineSp(string iSroNum,
                                       int? iSroLine,
                                       ref int? oSroLine,
                                       ref int? oSroOper,
                                       ref string Infobar);
    }

    public class SSSFSSROGetFirstOpenLine : ISSSFSSROGetFirstOpenLine
    {
        readonly IApplicationDB appDB;

        public SSSFSSROGetFirstOpenLine(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSSROGetFirstOpenLineSp(string iSroNum,
                                              int? iSroLine,
                                              ref int? oSroLine,
                                              ref int? oSroOper,
                                              ref string Infobar)
        {
            FSSRONumType _iSroNum = iSroNum;
            FSSROLineType _iSroLine = iSroLine;
            FSSROLineType _oSroLine = oSroLine;
            FSSROOperType _oSroOper = oSroOper;
            InfobarType _Infobar = Infobar;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSSROGetFirstOpenLineSp";

                appDB.AddCommandParameter(cmd, "iSroNum", _iSroNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iSroLine", _iSroLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "oSroLine", _oSroLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oSroOper", _oSroOper, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                oSroLine = _oSroLine;
                oSroOper = _oSroOper;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}

