//PROJECT NAME: Data
//CLASS NAME: GainLoss3.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLoss3 : IGainLoss3
	{
		readonly IApplicationDB appDB;
		
		public GainLoss3(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) GainLoss3Sp(
			int? pRelGl,
			int? pPostTrx,
			DateTime? pTTransDate,
			string pCurrparmsCurrCode,
			int? pTDomInEuro,
			string pCurrencyCurrCode,
			string pTLossAcct,
			string pTLossAcctUnit1 = null,
			string pTLossAcctUnit2 = null,
			string pTLossAcctUnit3 = null,
			string pTLossAcctUnit4 = null,
			string pTGainAcct = null,
			string pTGainAcctUnit1 = null,
			string pTGainAcctUnit2 = null,
			string pTGainAcctUnit3 = null,
			string pTGainAcctUnit4 = null,
			string pTUngainAcct = null,
			string pTUngainAcctUnit1 = null,
			string pTUngainAcctUnit2 = null,
			string pTUngainAcctUnit3 = null,
			string pTUngainAcctUnit4 = null,
			string pTUnlossAcct = null,
			string pTUnlossAcctUnit1 = null,
			string pTUnlossAcctUnit2 = null,
			string pTUnlossAcctUnit3 = null,
			string pTUnlossAcctUnit4 = null,
			string pTVchoffAcct = null,
			string pTVchoffAcctUnit1 = null,
			string pTVchoffAcctUnit2 = null,
			string pTVchoffAcctUnit3 = null,
			string pTVchoffAcctUnit4 = null,
			string pTApOffAcct = null,
			string pTApOffAcctUnit1 = null,
			string pTApOffAcctUnit2 = null,
			string pTApOffAcctUnit3 = null,
			string pTApOffAcctUnit4 = null,
			string rInfobar = null)
		{
			ListYesNoType _pRelGl = pRelGl;
			ListYesNoType _pPostTrx = pPostTrx;
			DateType _pTTransDate = pTTransDate;
			CurrCodeType _pCurrparmsCurrCode = pCurrparmsCurrCode;
			ListYesNoType _pTDomInEuro = pTDomInEuro;
			CurrCodeType _pCurrencyCurrCode = pCurrencyCurrCode;
			AcctType _pTLossAcct = pTLossAcct;
			UnitCode1Type _pTLossAcctUnit1 = pTLossAcctUnit1;
			UnitCode2Type _pTLossAcctUnit2 = pTLossAcctUnit2;
			UnitCode3Type _pTLossAcctUnit3 = pTLossAcctUnit3;
			UnitCode4Type _pTLossAcctUnit4 = pTLossAcctUnit4;
			AcctType _pTGainAcct = pTGainAcct;
			UnitCode1Type _pTGainAcctUnit1 = pTGainAcctUnit1;
			UnitCode2Type _pTGainAcctUnit2 = pTGainAcctUnit2;
			UnitCode3Type _pTGainAcctUnit3 = pTGainAcctUnit3;
			UnitCode4Type _pTGainAcctUnit4 = pTGainAcctUnit4;
			AcctType _pTUngainAcct = pTUngainAcct;
			UnitCode1Type _pTUngainAcctUnit1 = pTUngainAcctUnit1;
			UnitCode2Type _pTUngainAcctUnit2 = pTUngainAcctUnit2;
			UnitCode3Type _pTUngainAcctUnit3 = pTUngainAcctUnit3;
			UnitCode4Type _pTUngainAcctUnit4 = pTUngainAcctUnit4;
			AcctType _pTUnlossAcct = pTUnlossAcct;
			UnitCode1Type _pTUnlossAcctUnit1 = pTUnlossAcctUnit1;
			UnitCode2Type _pTUnlossAcctUnit2 = pTUnlossAcctUnit2;
			UnitCode3Type _pTUnlossAcctUnit3 = pTUnlossAcctUnit3;
			UnitCode4Type _pTUnlossAcctUnit4 = pTUnlossAcctUnit4;
			AcctType _pTVchoffAcct = pTVchoffAcct;
			UnitCode1Type _pTVchoffAcctUnit1 = pTVchoffAcctUnit1;
			UnitCode2Type _pTVchoffAcctUnit2 = pTVchoffAcctUnit2;
			UnitCode3Type _pTVchoffAcctUnit3 = pTVchoffAcctUnit3;
			UnitCode4Type _pTVchoffAcctUnit4 = pTVchoffAcctUnit4;
			AcctType _pTApOffAcct = pTApOffAcct;
			UnitCode1Type _pTApOffAcctUnit1 = pTApOffAcctUnit1;
			UnitCode2Type _pTApOffAcctUnit2 = pTApOffAcctUnit2;
			UnitCode3Type _pTApOffAcctUnit3 = pTApOffAcctUnit3;
			UnitCode4Type _pTApOffAcctUnit4 = pTApOffAcctUnit4;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLoss3Sp";
				
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTTransDate", _pTTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrparmsCurrCode", _pCurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTDomInEuro", _pTDomInEuro, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrencyCurrCode", _pCurrencyCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcct", _pTLossAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit1", _pTLossAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit2", _pTLossAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit3", _pTLossAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTLossAcctUnit4", _pTLossAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcct", _pTGainAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit1", _pTGainAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit2", _pTGainAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit3", _pTGainAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTGainAcctUnit4", _pTGainAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcct", _pTUngainAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit1", _pTUngainAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit2", _pTUngainAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit3", _pTUngainAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUngainAcctUnit4", _pTUngainAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcct", _pTUnlossAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit1", _pTUnlossAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit2", _pTUnlossAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit3", _pTUnlossAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit4", _pTUnlossAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcct", _pTVchoffAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit1", _pTVchoffAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit2", _pTVchoffAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit3", _pTVchoffAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTVchoffAcctUnit4", _pTVchoffAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApOffAcct", _pTApOffAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApOffAcctUnit1", _pTApOffAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApOffAcctUnit2", _pTApOffAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApOffAcctUnit3", _pTApOffAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTApOffAcctUnit4", _pTApOffAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
