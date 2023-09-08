//PROJECT NAME: Data
//CLASS NAME: PrLogC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class PrLogC : IPrLogC
	{
		readonly IApplicationDB appDB;
		
		public PrLogC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) PrLogCSp(
			string Oper,
			string EmpNum,
			int? Seq,
			DateTime? WorkDate,
			string HrType,
			decimal? Hrs,
			decimal? PayRate,
			string Infobar,
			string PrlogAcct = null,
			string PrlogAcctUnit1 = null,
			string PrlogAcctUnit2 = null,
			string PrlogAcctUnit3 = null,
			string PrlogAcctUnit4 = null)
		{
			GenericCodeType _Oper = Oper;
			EmpNumType _EmpNum = EmpNum;
			PrLogSeqType _Seq = Seq;
			DateType _WorkDate = WorkDate;
			PrlogHrTypeType _HrType = HrType;
			TotalHoursType _Hrs = Hrs;
			PayRatePreciseType _PayRate = PayRate;
			InfobarType _Infobar = Infobar;
			AcctType _PrlogAcct = PrlogAcct;
			UnitCode1Type _PrlogAcctUnit1 = PrlogAcctUnit1;
			UnitCode2Type _PrlogAcctUnit2 = PrlogAcctUnit2;
			UnitCode3Type _PrlogAcctUnit3 = PrlogAcctUnit3;
			UnitCode4Type _PrlogAcctUnit4 = PrlogAcctUnit4;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PrLogCSp";
				
				appDB.AddCommandParameter(cmd, "Oper", _Oper, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNum", _EmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Seq", _Seq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WorkDate", _WorkDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HrType", _HrType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Hrs", _Hrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PayRate", _PayRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrlogAcct", _PrlogAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrlogAcctUnit1", _PrlogAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrlogAcctUnit2", _PrlogAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrlogAcctUnit3", _PrlogAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrlogAcctUnit4", _PrlogAcctUnit4, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
