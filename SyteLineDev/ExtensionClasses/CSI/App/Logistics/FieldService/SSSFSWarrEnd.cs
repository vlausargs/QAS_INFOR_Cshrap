//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSWarrEnd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
    public interface ISSSFSWarrEnd
    {
        int SSSFSWarrEndSp(string iWarrCode,
                           ref DateTime? iStartDate,
                           ref int? iStartMeter,
                           ref DateTime? oEndDate,
                           ref int? oEndMeter,
                           ref string Infobar,
                           int? DefaultMeter);
    }

    public class SSSFSWarrEnd : ISSSFSWarrEnd
    {
        readonly IApplicationDB appDB;

        public SSSFSWarrEnd(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int SSSFSWarrEndSp(string iWarrCode,
                                  ref DateTime? iStartDate,
                                  ref int? iStartMeter,
                                  ref DateTime? oEndDate,
                                  ref int? oEndMeter,
                                  ref string Infobar,
                                  int? DefaultMeter)
        {
            FSWarrCodeType _iWarrCode = iWarrCode;
            DateTimeType _iStartDate = iStartDate;
            FSMeterAmtType _iStartMeter = iStartMeter;
            DateTimeType _oEndDate = oEndDate;
            FSMeterAmtType _oEndMeter = oEndMeter;
            InfobarType _Infobar = Infobar;
            FSMeterAmtType _DefaultMeter = DefaultMeter;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSFSWarrEndSp";

                appDB.AddCommandParameter(cmd, "iWarrCode", _iWarrCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "iStartDate", _iStartDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "iStartMeter", _iStartMeter, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oEndDate", _oEndDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "oEndMeter", _oEndMeter, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "DefaultMeter", _DefaultMeter, ParameterDirection.Input);

                var Severity = appDB.ExecuteNonQuery(cmd);

                iStartDate = _iStartDate;
                iStartMeter = _iStartMeter;
                oEndDate = _oEndDate;
                oEndMeter = _oEndMeter;
                Infobar = _Infobar;

                return Severity;
            }
        }
    }
}
