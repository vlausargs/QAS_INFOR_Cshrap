//PROJECT NAME: Finance
//CLASS NAME: FinRptLineGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinRptLineGen : IFinRptLineGen
	{
		readonly IApplicationDB appDB;
		
		
		public FinRptLineGen(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? EndSeq,
		string Infobar) FinRptLineGenSp(string ReportId,
		string CopyType,
		string StartingAcct,
		string EndingAcct,
		string AccountTypes,
		int? DelExisting,
		int? InsertAfterLine,
		int? EndSeq,
		string Infobar)
		{
			RptIdType _ReportId = ReportId;
			StringType _CopyType = CopyType;
			AcctType _StartingAcct = StartingAcct;
			AcctType _EndingAcct = EndingAcct;
			StringType _AccountTypes = AccountTypes;
			ListYesNoType _DelExisting = DelExisting;
			FinStmtSeqType _InsertAfterLine = InsertAfterLine;
			FinStmtSeqType _EndSeq = EndSeq;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinRptLineGenSp";
				
				appDB.AddCommandParameter(cmd, "ReportId", _ReportId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyType", _CopyType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingAcct", _StartingAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingAcct", _EndingAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AccountTypes", _AccountTypes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DelExisting", _DelExisting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InsertAfterLine", _InsertAfterLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndSeq", _EndSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				EndSeq = _EndSeq;
				Infobar = _Infobar;
				
				return (Severity, EndSeq, Infobar);
			}
		}
	}
}
