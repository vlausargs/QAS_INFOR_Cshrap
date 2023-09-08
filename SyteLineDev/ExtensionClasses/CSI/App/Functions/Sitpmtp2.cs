//PROJECT NAME: Data
//CLASS NAME: Sitpmtp2.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Sitpmtp2 : ISitpmtp2
	{
		readonly IApplicationDB appDB;
		
		public Sitpmtp2(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? CorpAmountPosted,
			decimal? DomPaidAmount,
			decimal? ForPaidAmount,
			int? Success,
			int? TOpenIsDone,
			string Infobar) Sitpmtp2Sp(
			Guid? TSessionId,
			string TVVchpckSite,
			int? TVVchpckVoucher,
			string TOVchpckSite,
			int? TOVchpckVoucher,
			Guid? RowidAppmt,
			decimal? WireExchangeRate,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? CorpAmountPosted,
			decimal? DomPaidAmount,
			decimal? ForPaidAmount,
			int? Success,
			int? TOpenIsDone,
			string Infobar)
		{
			RowPointerType _TSessionId = TSessionId;
			SiteType _TVVchpckSite = TVVchpckSite;
			VoucherType _TVVchpckVoucher = TVVchpckVoucher;
			SiteType _TOVchpckSite = TOVchpckSite;
			VoucherType _TOVchpckVoucher = TOVchpckVoucher;
			RowPointerType _RowidAppmt = RowidAppmt;
			GenericDecimalType _WireExchangeRate = WireExchangeRate;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			GenericDecimalType _CorpAmountPosted = CorpAmountPosted;
			GenericDecimalType _DomPaidAmount = DomPaidAmount;
			GenericDecimalType _ForPaidAmount = ForPaidAmount;
			ListYesNoType _Success = Success;
			ListYesNoType _TOpenIsDone = TOpenIsDone;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Sitpmtp2Sp";
				
				appDB.AddCommandParameter(cmd, "TSessionId", _TSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TVVchpckSite", _TVVchpckSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TVVchpckVoucher", _TVVchpckVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOVchpckSite", _TOVchpckSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TOVchpckVoucher", _TOVchpckVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowidAppmt", _RowidAppmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WireExchangeRate", _WireExchangeRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CorpAmountPosted", _CorpAmountPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DomPaidAmount", _DomPaidAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ForPaidAmount", _ForPaidAmount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Success", _Success, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TOpenIsDone", _TOpenIsDone, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CorpAmountPosted = _CorpAmountPosted;
				DomPaidAmount = _DomPaidAmount;
				ForPaidAmount = _ForPaidAmount;
				Success = _Success;
				TOpenIsDone = _TOpenIsDone;
				Infobar = _Infobar;
				
				return (Severity, CorpAmountPosted, DomPaidAmount, ForPaidAmount, Success, TOpenIsDone, Infobar);
			}
		}
	}
}
