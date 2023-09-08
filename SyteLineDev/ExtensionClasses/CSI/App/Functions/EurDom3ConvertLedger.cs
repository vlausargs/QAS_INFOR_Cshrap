//PROJECT NAME: Data
//CLASS NAME: EurDom3ConvertLedger.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EurDom3ConvertLedger : IEurDom3ConvertLedger
	{
		readonly IApplicationDB appDB;
		
		public EurDom3ConvertLedger(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EurDom3ConvertLedgerSp(
			decimal? ConvRate,
			int? ConvPlaces,
			string TEuroCurr,
			string OrigCurrCode,
			string InAcct,
			string InAcctUnit1,
			string InAcctUnit2,
			string InAcctUnit3,
			string InAcctUnit4,
			string Infobar)
		{
			GenericDecimalType _ConvRate = ConvRate;
			DecimalPlacesType _ConvPlaces = ConvPlaces;
			CurrCodeType _TEuroCurr = TEuroCurr;
			CurrCodeType _OrigCurrCode = OrigCurrCode;
			AcctType _InAcct = InAcct;
			UnitCode1Type _InAcctUnit1 = InAcctUnit1;
			UnitCode2Type _InAcctUnit2 = InAcctUnit2;
			UnitCode3Type _InAcctUnit3 = InAcctUnit3;
			UnitCode4Type _InAcctUnit4 = InAcctUnit4;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EurDom3ConvertLedgerSp";
				
				appDB.AddCommandParameter(cmd, "ConvRate", _ConvRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConvPlaces", _ConvPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEuroCurr", _TEuroCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrigCurrCode", _OrigCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InAcct", _InAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InAcctUnit1", _InAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InAcctUnit2", _InAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InAcctUnit3", _InAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InAcctUnit4", _InAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
