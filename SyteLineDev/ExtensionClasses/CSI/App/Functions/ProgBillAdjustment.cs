//PROJECT NAME: Data
//CLASS NAME: ProgBillAdjustment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ProgBillAdjustment : IProgBillAdjustment
	{
		readonly IApplicationDB appDB;
		
		public ProgBillAdjustment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? AmountPosted,
			string Infobar) ProgBillAdjustmentSp(
			string InvNum,
			int? InvSeq,
			DateTime? InvDate,
			string CustNum,
			string CustaddrCurrCode,
			string ArinvType,
			decimal? ArinvExchRate,
			string TId,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? AmountPosted,
			string Infobar,
			int? IsControlNumberCreated = 0,
			DateTime? ArinvInvDate = null)
		{
			InvNumType _InvNum = InvNum;
			InvSeqType _InvSeq = InvSeq;
			DateType _InvDate = InvDate;
			CustNumType _CustNum = CustNum;
			CurrCodeType _CustaddrCurrCode = CustaddrCurrCode;
			ArinvTypeType _ArinvType = ArinvType;
			ExchRateType _ArinvExchRate = ArinvExchRate;
			JournalIdType _TId = TId;
			JourControlPrefixType _ControlPrefix = ControlPrefix;
			SiteType _ControlSite = ControlSite;
			FiscalYearType _ControlYear = ControlYear;
			FinPeriodType _ControlPeriod = ControlPeriod;
			LastTranType _ControlNumber = ControlNumber;
			AmountType _AmountPosted = AmountPosted;
			InfobarType _Infobar = Infobar;
			ListYesNoType _IsControlNumberCreated = IsControlNumberCreated;
			DateType _ArinvInvDate = ArinvInvDate;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProgBillAdjustmentSp";
				
				appDB.AddCommandParameter(cmd, "InvNum", _InvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvSeq", _InvSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InvDate", _InvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustaddrCurrCode", _CustaddrCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvType", _ArinvType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvExchRate", _ArinvExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TId", _TId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPrefix", _ControlPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlSite", _ControlSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlYear", _ControlYear, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlPeriod", _ControlPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ControlNumber", _ControlNumber, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AmountPosted", _AmountPosted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsControlNumberCreated", _IsControlNumberCreated, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ArinvInvDate", _ArinvInvDate, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				AmountPosted = _AmountPosted;
				Infobar = _Infobar;
				
				return (Severity, AmountPosted, Infobar);
			}
		}
	}
}
