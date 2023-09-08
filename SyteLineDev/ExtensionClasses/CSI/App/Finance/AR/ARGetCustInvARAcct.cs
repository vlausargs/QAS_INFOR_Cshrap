//PROJECT NAME: Finance
//CLASS NAME: ARGetCustInvARAcct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance.AR
{
	public class ARGetCustInvARAcct : IARGetCustInvARAcct
	{
		readonly IApplicationDB appDB;
		
		public ARGetCustInvARAcct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string PArAcct,
			string PArAcctUnit1,
			string PArAcctUnit2,
			string PArAcctUnit3,
			string PArAcctUnit4,
			string Infobar) ARGetCustInvARAcctSp(
			string PCustNum,
			int? PCustSeq = 0,
			string PInvNum = null,
			int? PInvSeq = 0,
			string PArAcct = null,
			string PArAcctUnit1 = null,
			string PArAcctUnit2 = null,
			string PArAcctUnit3 = null,
			string PArAcctUnit4 = null,
			string Infobar = null)
		{
			CustNumType _PCustNum = PCustNum;
			CustSeqType _PCustSeq = PCustSeq;
			InvNumType _PInvNum = PInvNum;
			InvSeqType _PInvSeq = PInvSeq;
			AcctType _PArAcct = PArAcct;
			UnitCode1Type _PArAcctUnit1 = PArAcctUnit1;
			UnitCode2Type _PArAcctUnit2 = PArAcctUnit2;
			UnitCode3Type _PArAcctUnit3 = PArAcctUnit3;
			UnitCode4Type _PArAcctUnit4 = PArAcctUnit4;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ARGetCustInvARAcctSp";
				
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustSeq", _PCustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvSeq", _PInvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PArAcct", _PArAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArAcctUnit1", _PArAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArAcctUnit2", _PArAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArAcctUnit3", _PArAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PArAcctUnit4", _PArAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PArAcct = _PArAcct;
				PArAcctUnit1 = _PArAcctUnit1;
				PArAcctUnit2 = _PArAcctUnit2;
				PArAcctUnit3 = _PArAcctUnit3;
				PArAcctUnit4 = _PArAcctUnit4;
				Infobar = _Infobar;
				
				return (Severity, PArAcct, PArAcctUnit1, PArAcctUnit2, PArAcctUnit3, PArAcctUnit4, Infobar);
			}
		}
	}
}
