//PROJECT NAME: Data
//CLASS NAME: GlGainLoss.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GlGainLoss : IGlGainLoss
	{
		readonly IApplicationDB appDB;
		
		public GlGainLoss(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) GlGainLossSp(
			decimal? PAmount,
			string PCurrCode,
			string PRef,
			string PId,
			DateTime? PTransDate,
			string PVendNum = null,
			string PInvNum = null,
			string PVoucher = "0",
			int? PCheckNum = 0,
			DateTime? PCheckDate = null,
			string PFromSite = null,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null,
			decimal? ExchRate = 1M,
			string BankCode = null,
			decimal? ForAmount = null)
		{
			GenericDecimalType _PAmount = PAmount;
			CurrCodeType _PCurrCode = PCurrCode;
			ReferenceType _PRef = PRef;
			JournalIdType _PId = PId;
			DateType _PTransDate = PTransDate;
			VendNumType _PVendNum = PVendNum;
			VendInvNumType _PInvNum = PInvNum;
			InvNumVoucherType _PVoucher = PVoucher;
			GlCheckNumType _PCheckNum = PCheckNum;
			DateType _PCheckDate = PCheckDate;
			SiteType _PFromSite = PFromSite;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			Infobar _Infobar = Infobar;
			ExchRateType _ExchRate = ExchRate;
			BankCodeType _BankCode = BankCode;
			AmountType _ForAmount = ForAmount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GlGainLossSp";
				
				appDB.AddCommandParameter(cmd, "PAmount", _PAmount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCurrCode", _PCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRef", _PRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PId", _PId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTransDate", _PTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PInvNum", _PInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVoucher", _PVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckNum", _PCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCheckDate", _PCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PFromSite", _PFromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BankCode", _BankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ForAmount", _ForAmount, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
