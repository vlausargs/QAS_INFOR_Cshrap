//PROJECT NAME: Data
//CLASS NAME: LineAgeAptrxpAll.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class LineAgeAptrxpAll : ILineAgeAptrxpAll
	{
		readonly IApplicationDB appDB;
		
		public LineAgeAptrxpAll(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar) LineAgeAptrxpAllSp(
			Guid? TRecid,
			DateTime? AgeByDate,
			string AgeBasis,
			int? DomCurr,
			int? UseHistRate,
			string PParmsCurrCode,
			string PVendorCurrCode,
			int? PPlaces,
			decimal? NetDue,
			decimal? DiscAllowed,
			decimal? DiscTaken,
			decimal? InvAmt,
			decimal? AmtPaid,
			decimal? DiscRem,
			int? Age,
			string Infobar = null,
			decimal? AptrxpInvAmt = null,
			decimal? AptrxpAmtDisc = null,
			decimal? AptrxpDiscAmt = null,
			int? AptrxpFixedRate = null,
			DateTime? AptrxpDiscDate = null,
			decimal? AptrxpAmtPaid = null,
			decimal? AptrxpExchRate = null,
			string AptrxpType = null,
			DateTime? AptrxpDueDate = null,
			DateTime? AptrxpInvDate = null,
			string AptrxpVendNum = null,
			int? AptrxpVoucher = null,
			string AptrxpSite = null)
		{
			RowPointerType _TRecid = TRecid;
			CurrentDateType _AgeByDate = AgeByDate;
			LongListType _AgeBasis = AgeBasis;
			FlagNyType _DomCurr = DomCurr;
			FlagNyType _UseHistRate = UseHistRate;
			CurrCodeType _PParmsCurrCode = PParmsCurrCode;
			CurrCodeType _PVendorCurrCode = PVendorCurrCode;
			DecimalPlacesType _PPlaces = PPlaces;
			AmountType _NetDue = NetDue;
			AmountType _DiscAllowed = DiscAllowed;
			AmountType _DiscTaken = DiscTaken;
			AmountType _InvAmt = InvAmt;
			AmountType _AmtPaid = AmtPaid;
			AmountType _DiscRem = DiscRem;
			GenericNoType _Age = Age;
			InfobarType _Infobar = Infobar;
			AmountType _AptrxpInvAmt = AptrxpInvAmt;
			AmountType _AptrxpAmtDisc = AptrxpAmtDisc;
			AmountType _AptrxpDiscAmt = AptrxpDiscAmt;
			ListYesNoType _AptrxpFixedRate = AptrxpFixedRate;
			DateType _AptrxpDiscDate = AptrxpDiscDate;
			AmountType _AptrxpAmtPaid = AptrxpAmtPaid;
			ExchRateType _AptrxpExchRate = AptrxpExchRate;
			AptrxpTypeType _AptrxpType = AptrxpType;
			DateType _AptrxpDueDate = AptrxpDueDate;
			DateType _AptrxpInvDate = AptrxpInvDate;
			VendNumType _AptrxpVendNum = AptrxpVendNum;
			VoucherType _AptrxpVoucher = AptrxpVoucher;
			SiteType _AptrxpSite = AptrxpSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "LineAgeAptrxpAllSp";
				
				appDB.AddCommandParameter(cmd, "TRecid", _TRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeByDate", _AgeByDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgeBasis", _AgeBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurr", _DomCurr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseHistRate", _UseHistRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PParmsCurrCode", _PParmsCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorCurrCode", _PVendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPlaces", _PPlaces, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NetDue", _NetDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscAllowed", _DiscAllowed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscTaken", _DiscTaken, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvAmt", _InvAmt, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AmtPaid", _AmtPaid, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DiscRem", _DiscRem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Age", _Age, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AptrxpInvAmt", _AptrxpInvAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpAmtDisc", _AptrxpAmtDisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpDiscAmt", _AptrxpDiscAmt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpFixedRate", _AptrxpFixedRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpDiscDate", _AptrxpDiscDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpAmtPaid", _AptrxpAmtPaid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpExchRate", _AptrxpExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpType", _AptrxpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpDueDate", _AptrxpDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpInvDate", _AptrxpInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpVendNum", _AptrxpVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpVoucher", _AptrxpVoucher, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AptrxpSite", _AptrxpSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NetDue = _NetDue;
				DiscAllowed = _DiscAllowed;
				DiscTaken = _DiscTaken;
				InvAmt = _InvAmt;
				AmtPaid = _AmtPaid;
				DiscRem = _DiscRem;
				Age = _Age;
				Infobar = _Infobar;
				
				return (Severity, NetDue, DiscAllowed, DiscTaken, InvAmt, AmtPaid, DiscRem, Age, Infobar);
			}
		}
	}
}
