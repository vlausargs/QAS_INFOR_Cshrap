//PROJECT NAME: Data
//CLASS NAME: ItemCc2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemCc2 : IItemCc2
	{
		readonly IApplicationDB appDB;
		
		public ItemCc2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? Tot,
			Guid? MatltranRowPointer,
			string Infobar,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			int? last_seq,
			decimal? TransNum,
			int? TransSeq) ItemCc2Sp(
			int? Ccp,
			Guid? RowPointer,
			string Item,
			decimal? Tot,
			decimal? MatlAdj,
			decimal? LbrAdj,
			decimal? FovhdAdj,
			decimal? VovhdAdj,
			decimal? OutAdj,
			Guid? MatltranRowPointer,
			string Infobar,
			string RefStr = "INV CHGM",
			string Lot = null,
			int? ParmsPostJour = null,
			int? CurrencyPlaces = null,
			string DomCurrCode = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			int? AccountsValidated = 0,
			string CurUserCode = null,
			int? last_seq = null,
			string ProcName = null,
			decimal? TransNum = null,
			int? TransSeq = null)
		{
			ListYesNoType _Ccp = Ccp;
			RowPointerType _RowPointer = RowPointer;
			ItemType _Item = Item;
			AmountType _Tot = Tot;
			AmountType _MatlAdj = MatlAdj;
			AmountType _LbrAdj = LbrAdj;
			AmountType _FovhdAdj = FovhdAdj;
			AmountType _VovhdAdj = VovhdAdj;
			AmountType _OutAdj = OutAdj;
			RowPointerType _MatltranRowPointer = MatltranRowPointer;
			InfobarType _Infobar = Infobar;
			StringType _RefStr = RefStr;
			LotType _Lot = Lot;
			ListYesNoType _ParmsPostJour = ParmsPostJour;
			DecimalPlacesType _CurrencyPlaces = CurrencyPlaces;
			CurrCodeType _DomCurrCode = DomCurrCode;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			ListYesNoType _AccountsValidated = AccountsValidated;
			UserCodeType _CurUserCode = CurUserCode;
			JournalSeqType _last_seq = last_seq;
			StringType _ProcName = ProcName;
			MatlTransNumType _TransNum = TransNum;
			DateSeqType _TransSeq = TransSeq;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCc2Sp";
				
				appDB.AddCommandParameter(cmd, "Ccp", _Ccp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Tot", _Tot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlAdj", _MatlAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LbrAdj", _LbrAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FovhdAdj", _FovhdAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VovhdAdj", _VovhdAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutAdj", _OutAdj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatltranRowPointer", _MatltranRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefStr", _RefStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Lot", _Lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ParmsPostJour", _ParmsPostJour, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrencyPlaces", _CurrencyPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccountsValidated", _AccountsValidated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUserCode", _CurUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "last_seq", _last_seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ProcName", _ProcName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TransSeq", _TransSeq, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Tot = _Tot;
				MatltranRowPointer = _MatltranRowPointer;
				Infobar = _Infobar;
				ControlPrefix = _ControlPrefix;
				ControlSite = _ControlSite;
				ControlYear = _ControlYear;
				ControlPeriod = _ControlPeriod;
				ControlNumber = _ControlNumber;
				last_seq = _last_seq;
				TransNum = _TransNum;
				TransSeq = _TransSeq;
				
				return (Severity, Tot, MatltranRowPointer, Infobar, ControlPrefix, ControlSite, ControlYear, ControlPeriod, ControlNumber, last_seq, TransNum, TransSeq);
			}
		}
	}
}
