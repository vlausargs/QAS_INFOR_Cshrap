//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PRa1rpDoChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PRa1rpDoChecks : IRpt_PRa1rpDoChecks
	{
		readonly IApplicationDB appDB;
		
		public Rpt_PRa1rpDoChecks(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) Rpt_PRa1rpDoChecksSp(
			Guid? pPrtrxRowPointer,
			string pTName,
			string pTSsn,
			int? pTDirDep,
			decimal? pTYtd,
			decimal? pTFwt,
			decimal? pTFica,
			decimal? pTSwt,
			decimal? pTOst,
			decimal? pTCwt,
			decimal? pTMed,
			Guid? pSessionID,
			string Infobar)
		{
			RowPointerType _pPrtrxRowPointer = pPrtrxRowPointer;
			EmpNameType _pTName = pTName;
			SsnType _pTSsn = pTSsn;
			ListYesNoType _pTDirDep = pTDirDep;
			PrYtdAmountType _pTYtd = pTYtd;
			PrYtdAmountType _pTFwt = pTFwt;
			PrYtdAmountType _pTFica = pTFica;
			PrYtdAmountType _pTSwt = pTSwt;
			PrYtdAmountType _pTOst = pTOst;
			PrYtdAmountType _pTCwt = pTCwt;
			PrYtdAmountType _pTMed = pTMed;
			RowPointerType _pSessionID = pSessionID;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PRa1rpDoChecksSp";
				
				appDB.AddCommandParameter(cmd, "pPrtrxRowPointer", _pPrtrxRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTName", _pTName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTSsn", _pTSsn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTDirDep", _pTDirDep, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTYtd", _pTYtd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTFwt", _pTFwt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTFica", _pTFica, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTSwt", _pTSwt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTOst", _pTOst, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTCwt", _pTCwt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTMed", _pTMed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSessionID", _pSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
