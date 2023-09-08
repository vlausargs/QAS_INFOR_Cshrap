//PROJECT NAME: Logistics
//CLASS NAME: CpSoCopyCpO.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CpSoCopyCpO : ICpSoCopyCpO
	{
		readonly IApplicationDB appDB;
		
		public CpSoCopyCpO(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) CpSoCopyCpOSp(
			string pCpFOrdType,
			string pCpTOrdType,
			string pCpFOrdRef,
			string pCpTOrdRef,
			int? pCpOrdStart,
			int? pCpOrdEnd,
			string pCopyChoice,
			string pFCurr,
			string pTCurr,
			int? HasCfg,
			string CurWhse,
			int? pRecalcDueDate,
			string Infobar,
			int? ShipmentApprovalRequired = 0)
		{
			StringType _pCpFOrdType = pCpFOrdType;
			StringType _pCpTOrdType = pCpTOrdType;
			CoNumType _pCpFOrdRef = pCpFOrdRef;
			CoNumType _pCpTOrdRef = pCpTOrdRef;
			CoLineType _pCpOrdStart = pCpOrdStart;
			CoLineType _pCpOrdEnd = pCpOrdEnd;
			StringType _pCopyChoice = pCopyChoice;
			CurrCodeType _pFCurr = pFCurr;
			CurrCodeType _pTCurr = pTCurr;
			Flag _HasCfg = HasCfg;
			WhseType _CurWhse = CurWhse;
			ListYesNoType _pRecalcDueDate = pRecalcDueDate;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ShipmentApprovalRequired = ShipmentApprovalRequired;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CpSoCopyCpOSp";
				
				appDB.AddCommandParameter(cmd, "pCpFOrdType", _pCpFOrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCpTOrdType", _pCpTOrdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCpFOrdRef", _pCpFOrdRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCpTOrdRef", _pCpTOrdRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCpOrdStart", _pCpOrdStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCpOrdEnd", _pCpOrdEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCopyChoice", _pCopyChoice, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pFCurr", _pFCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTCurr", _pTCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HasCfg", _HasCfg, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurWhse", _CurWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRecalcDueDate", _pRecalcDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipmentApprovalRequired", _ShipmentApprovalRequired, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
