//PROJECT NAME: Data
//CLASS NAME: GainLossValidateAccts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLossValidateAccts : IGainLossValidateAccts
	{
		readonly IApplicationDB appDB;
		
		public GainLossValidateAccts(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) GainLossValidateAcctsSp(
			string pAcctType,
			int? pRelGl,
			DateTime? pTTransDate,
			string pSCurrCode,
			string pECurrCode,
			string rInfobar = null)
		{
			StringType _pAcctType = pAcctType;
			ListYesNoType _pRelGl = pRelGl;
			DateType _pTTransDate = pTTransDate;
			CurrCodeType _pSCurrCode = pSCurrCode;
			CurrCodeType _pECurrCode = pECurrCode;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLossValidateAcctsSp";
				
				appDB.AddCommandParameter(cmd, "pAcctType", _pAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTTransDate", _pTTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSCurrCode", _pSCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pECurrCode", _pECurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
