//PROJECT NAME: CSICodes
//CLASS NAME: GetTaxSystemParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
    public interface IGetTaxSystemParm
    {
        int GetTaxSystemParmSp(byte? TaxSystem,
                               ref string TaxMode,
                               ref byte? ActiveForPurch,
                               ref byte? RecordZero);
    }

    public class GetTaxSystemParm : IGetTaxSystemParm
    {
        readonly IApplicationDB appDB;

        public GetTaxSystemParm(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetTaxSystemParmSp(byte? TaxSystem,
                                      ref string TaxMode,
                                      ref byte? ActiveForPurch,
                                      ref byte? RecordZero)
        {
            TaxSystemType _TaxSystem = TaxSystem;
            TaxModeType _TaxMode = TaxMode;
            ListYesNoType _ActiveForPurch = ActiveForPurch;
            ListYesNoType _RecordZero = RecordZero;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetTaxSystemParmSp";

                appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "TaxMode", _TaxMode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "ActiveForPurch", _ActiveForPurch, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "RecordZero", _RecordZero, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                TaxMode = _TaxMode;
                ActiveForPurch = _ActiveForPurch;
                RecordZero = _RecordZero;

                return Severity;
            }
        }
    }
}
