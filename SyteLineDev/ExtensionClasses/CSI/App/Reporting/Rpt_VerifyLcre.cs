//PROJECT NAME: Reporting
//CLASS NAME: RPT_VerifyLcre.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RPT_VerifyLcre : IRPT_VerifyLcre
	{
		readonly IApplicationDB appDB;
		
		public RPT_VerifyLcre(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? pError,
			string pErrMsg) RPT_VerifyLcreSP(
			string pCoNum,
			decimal? pShipValue,
			int? pConverted,
			DateTime? pTransDate,
			string pCurrCode,
			int? pError,
			string pErrMsg)
		{
			CoNumType _pCoNum = pCoNum;
			AmountType _pShipValue = pShipValue;
			FlagNyType _pConverted = pConverted;
			DateType _pTransDate = pTransDate;
			CurrCodeType _pCurrCode = pCurrCode;
			FlagNyType _pError = pError;
			StringType _pErrMsg = pErrMsg;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RPT_VerifyLcreSP";
				
				appDB.AddCommandParameter(cmd, "pCoNum", _pCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShipValue", _pShipValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pConverted", _pConverted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTransDate", _pTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pError", _pError, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pErrMsg", _pErrMsg, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pError = _pError;
				pErrMsg = _pErrMsg;
				
				return (Severity, pError, pErrMsg);
			}
		}
	}
}
