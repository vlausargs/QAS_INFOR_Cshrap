//PROJECT NAME: Data
//CLASS NAME: EXTSSSCCIInvPrint.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSCCIInvPrint : IEXTSSSCCIInvPrint
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSCCIInvPrint(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TcAmtPrepaidAmt,
			string Item_1,
			string Infobar) EXTSSSCCIInvPrintSp(
			string InvNum,
			string InvCred,
			int? CurrencyPlaces,
			string CurrparmsCurrCode,
			decimal? TcAmtPrepaidAmt,
			string Item_1,
			string Infobar)
		{
			InvNumType _InvNum = InvNum;
			StringType _InvCred = InvCred;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			CurrCodeType _CurrparmsCurrCode = CurrparmsCurrCode;
			AmountType _TcAmtPrepaidAmt = TcAmtPrepaidAmt;
			WideTextType _Item1 = Item_1;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSCCIInvPrintSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvCred", _InvCred, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrparmsCurrCode", _CurrparmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcAmtPrepaidAmt", _TcAmtPrepaidAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Item1", _Item1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcAmtPrepaidAmt = _TcAmtPrepaidAmt;
				Item_1 = _Item1;
				Infobar = _Infobar;
				
				return (Severity, TcAmtPrepaidAmt, Item_1, Infobar);
			}
		}
	}
}
