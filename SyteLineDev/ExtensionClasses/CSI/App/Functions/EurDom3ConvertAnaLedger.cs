//PROJECT NAME: Data
//CLASS NAME: EurDom3ConvertAnaLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EurDom3ConvertAnaLedger : IEurDom3ConvertAnaLedger
	{
		readonly IApplicationDB appDB;
		
		public EurDom3ConvertAnaLedger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EurDom3ConvertAnaLedgerSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			string AnaInAcct,
			string AnaInAcctUnit1,
			string AnaInAcctUnit2,
			string AnaInAcctUnit3,
			string AnaInAcctUnit4,
			string Infobar)
		{
			GenericDecimalType _ConvRate = ConvRate;
			DecimalPlacesType _ConvPlaces = ConvPlaces;
			CurrCodeType _TEuroCurr = TEuroCurr;
			CurrCodeType _OrigCurrCode = OrigCurrCode;
			AcctType _AnaInAcct = AnaInAcct;
			UnitCode1Type _AnaInAcctUnit1 = AnaInAcctUnit1;
			UnitCode2Type _AnaInAcctUnit2 = AnaInAcctUnit2;
			UnitCode3Type _AnaInAcctUnit3 = AnaInAcctUnit3;
			UnitCode4Type _AnaInAcctUnit4 = AnaInAcctUnit4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EurDom3ConvertAnaLedgerSp";
				
				appDB.AddCommandParameter(cmd, "ConvRate", _ConvRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvPlaces", _ConvPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroCurr", _TEuroCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigCurrCode", _OrigCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnaInAcct", _AnaInAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnaInAcctUnit1", _AnaInAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnaInAcctUnit2", _AnaInAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnaInAcctUnit3", _AnaInAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AnaInAcctUnit4", _AnaInAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
