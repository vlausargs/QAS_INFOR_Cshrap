//PROJECT NAME: Finance
//CLASS NAME: ARGetChargebackAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARGetChargebackAcct : IARGetChargebackAcct
	{
		readonly IApplicationDB appDB;
		
		public ARGetChargebackAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PChargebackAcct,
			string PChargebackAcctUnit1,
			string PChargebackAcctUnit2,
			string PChargebackAcctUnit3,
			string PChargebackAcctUnit4,
			string Infobar) ARGetChargebackAcctSp(
			string PCustNum,
			int? PCheckNum,
			string PChargebackType,
			int? PChargebackSeq,
			string PChargebackAcct,
			string PChargebackAcctUnit1,
			string PChargebackAcctUnit2,
			string PChargebackAcctUnit3,
			string PChargebackAcctUnit4,
			string Infobar)
		{
			CustNumType _PCustNum = PCustNum;
			ArCheckNumType _PCheckNum = PCheckNum;
			ChargebackTypeType _PChargebackType = PChargebackType;
			ChargebackSequenceType _PChargebackSeq = PChargebackSeq;
			AcctType _PChargebackAcct = PChargebackAcct;
			UnitCode1Type _PChargebackAcctUnit1 = PChargebackAcctUnit1;
			UnitCode2Type _PChargebackAcctUnit2 = PChargebackAcctUnit2;
			UnitCode3Type _PChargebackAcctUnit3 = PChargebackAcctUnit3;
			UnitCode4Type _PChargebackAcctUnit4 = PChargebackAcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARGetChargebackAcctSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChargebackType", _PChargebackType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChargebackSeq", _PChargebackSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PChargebackAcct", _PChargebackAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PChargebackAcctUnit1", _PChargebackAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PChargebackAcctUnit2", _PChargebackAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PChargebackAcctUnit3", _PChargebackAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PChargebackAcctUnit4", _PChargebackAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PChargebackAcct = _PChargebackAcct;
				PChargebackAcctUnit1 = _PChargebackAcctUnit1;
				PChargebackAcctUnit2 = _PChargebackAcctUnit2;
				PChargebackAcctUnit3 = _PChargebackAcctUnit3;
				PChargebackAcctUnit4 = _PChargebackAcctUnit4;
				Infobar = _Infobar;
				
				return (Severity, PChargebackAcct, PChargebackAcctUnit1, PChargebackAcctUnit2, PChargebackAcctUnit3, PChargebackAcctUnit4, Infobar);
			}
		}
	}
}
