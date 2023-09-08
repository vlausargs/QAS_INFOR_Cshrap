//PROJECT NAME: Data
//CLASS NAME: GainLoss1.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GainLoss1 : IGainLoss1
	{
		readonly IApplicationDB appDB;
		
		public GainLoss1(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string rInfobar) GainLoss1Sp(
			int? pRelGl,
			int? pPostTrx,
			DateTime? pTTransDate,
			string pCurrencyCurrCode,
			int? pCurrencyPlaces,
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
			string pTUnGainAcct = null,
			string pTUnGainAcctUnit1 = null,
			string pTUnGainAcctUnit2 = null,
			string pTUnGainAcctUnit3 = null,
			string pTUnGainAcctUnit4 = null,
			string pTUnlossAcct = null,
			string pTUnlossAcctUnit1 = null,
			string pTUnlossAcctUnit2 = null,
			string pTUnlossAcctUnit3 = null,
			string pTUnlossAcctUnit4 = null,
			string pTArOffAcct = null,
			string pTArOffAcctUnit1 = null,
			string pTArOffAcctUnit2 = null,
			string pTArOffAcctUnit3 = null,
			string pTArOffAcctUnit4 = null,
			string rInfobar = null)
		{
			ListYesNoType _pRelGl = pRelGl;
			ListYesNoType _pPostTrx = pPostTrx;
			DateType _pTTransDate = pTTransDate;
			CurrCodeType _pCurrencyCurrCode = pCurrencyCurrCode;
			DecimalPlacesType _pCurrencyPlaces = pCurrencyPlaces;
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
			AcctType _pTUnGainAcct = pTUnGainAcct;
			UnitCode1Type _pTUnGainAcctUnit1 = pTUnGainAcctUnit1;
			UnitCode2Type _pTUnGainAcctUnit2 = pTUnGainAcctUnit2;
			UnitCode3Type _pTUnGainAcctUnit3 = pTUnGainAcctUnit3;
			UnitCode4Type _pTUnGainAcctUnit4 = pTUnGainAcctUnit4;
			AcctType _pTUnlossAcct = pTUnlossAcct;
			UnitCode1Type _pTUnlossAcctUnit1 = pTUnlossAcctUnit1;
			UnitCode2Type _pTUnlossAcctUnit2 = pTUnlossAcctUnit2;
			UnitCode3Type _pTUnlossAcctUnit3 = pTUnlossAcctUnit3;
			UnitCode4Type _pTUnlossAcctUnit4 = pTUnlossAcctUnit4;
			AcctType _pTArOffAcct = pTArOffAcct;
			UnitCode1Type _pTArOffAcctUnit1 = pTArOffAcctUnit1;
			UnitCode2Type _pTArOffAcctUnit2 = pTArOffAcctUnit2;
			UnitCode3Type _pTArOffAcctUnit3 = pTArOffAcctUnit3;
			UnitCode4Type _pTArOffAcctUnit4 = pTArOffAcctUnit4;
			InfobarType _rInfobar = rInfobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GainLoss1Sp";
				
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTTransDate", _pTTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrencyCurrCode", _pCurrencyCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrencyPlaces", _pCurrencyPlaces, ParameterDirection.Input);
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
				appDB.AddCommandParameter(cmd, "pTUnGainAcct", _pTUnGainAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit1", _pTUnGainAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit2", _pTUnGainAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit3", _pTUnGainAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnGainAcctUnit4", _pTUnGainAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcct", _pTUnlossAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit1", _pTUnlossAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit2", _pTUnlossAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit3", _pTUnlossAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTUnlossAcctUnit4", _pTUnlossAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTArOffAcct", _pTArOffAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTArOffAcctUnit1", _pTArOffAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTArOffAcctUnit2", _pTArOffAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTArOffAcctUnit3", _pTArOffAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTArOffAcctUnit4", _pTArOffAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "rInfobar", _rInfobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				rInfobar = _rInfobar;
				
				return (Severity, rInfobar);
			}
		}
	}
}
