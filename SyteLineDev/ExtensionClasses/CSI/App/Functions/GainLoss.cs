//PROJECT NAME: Data
//CLASS NAME: GainLoss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLoss : IGainLoss
	{
		readonly IApplicationDB appDB;
		
		public GainLoss(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) GainLossSp(
			int? pRelGl,
			int? pPostTrx,
			string pSCurrCode,
			string pECurrCode,
			int? pRcvAcctType,
			int? pPayAcctType,
			int? pVouchPayAcctType,
			DateTime? pTTransDate,
			string pInvAdjAcct = null,
			string pInvAdjAcctUnit1 = null,
			string pInvAdjAcctUnit2 = null,
			string pInvAdjAcctUnit3 = null,
			string pInvAdjAcctUnit4 = null,
			int? DateOffset = null,
			int? TaskId = null,
			string rInfobar = null)
		{
			ListYesNoType _pRelGl = pRelGl;
			ListYesNoType _pPostTrx = pPostTrx;
			CurrCodeType _pSCurrCode = pSCurrCode;
			CurrCodeType _pECurrCode = pECurrCode;
			ListYesNoType _pRcvAcctType = pRcvAcctType;
			ListYesNoType _pPayAcctType = pPayAcctType;
			ListYesNoType _pVouchPayAcctType = pVouchPayAcctType;
			DateType _pTTransDate = pTTransDate;
			AcctType _pInvAdjAcct = pInvAdjAcct;
			UnitCode1Type _pInvAdjAcctUnit1 = pInvAdjAcctUnit1;
			UnitCode2Type _pInvAdjAcctUnit2 = pInvAdjAcctUnit2;
			UnitCode3Type _pInvAdjAcctUnit3 = pInvAdjAcctUnit3;
			UnitCode4Type _pInvAdjAcctUnit4 = pInvAdjAcctUnit4;
			DateOffsetType _DateOffset = DateOffset;
			TaskNumType _TaskId = TaskId;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLossSp";
				
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSCurrCode", _pSCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pECurrCode", _pECurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRcvAcctType", _pRcvAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPayAcctType", _pPayAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVouchPayAcctType", _pVouchPayAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTTransDate", _pTTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcct", _pInvAdjAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit1", _pInvAdjAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit2", _pInvAdjAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit3", _pInvAdjAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit4", _pInvAdjAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
