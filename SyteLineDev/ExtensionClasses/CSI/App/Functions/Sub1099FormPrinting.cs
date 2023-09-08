//PROJECT NAME: Data
//CLASS NAME: Sub1099FormPrinting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Sub1099FormPrinting : ISub1099FormPrinting
	{
		readonly IApplicationDB appDB;
		
		public Sub1099FormPrinting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			decimal? TvPayYtd,
			decimal? TvPayLstYr,
			int? AnyPrinted,
			decimal? TMinPayments) Sub1099FormPrintingSp(
			string PVendNum = null,
			decimal? TvPayYtd = null,
			decimal? TvPayLstYr = null,
			int? AnyPrinted = null,
			int? TUseLstYrPayRec = null,
			decimal? TMinPayments = null,
			string TSite = null)
		{
			VendNumType _PVendNum = PVendNum;
			AmountType _TvPayYtd = TvPayYtd;
			AmountType _TvPayLstYr = TvPayLstYr;
			FlagNyType _AnyPrinted = AnyPrinted;
			ListYesNoType _TUseLstYrPayRec = TUseLstYrPayRec;
			AmountType _TMinPayments = TMinPayments;
			SiteType _TSite = TSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Sub1099FormPrintingSp";
				
				appDB.AddCommandParameter(cmd, "PVendNum", _PVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TvPayYtd", _TvPayYtd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TvPayLstYr", _TvPayLstYr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AnyPrinted", _AnyPrinted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TUseLstYrPayRec", _TUseLstYrPayRec, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TMinPayments", _TMinPayments, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TSite", _TSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TvPayYtd = _TvPayYtd;
				TvPayLstYr = _TvPayLstYr;
				AnyPrinted = _AnyPrinted;
				TMinPayments = _TMinPayments;
				
				return (Severity, TvPayYtd, TvPayLstYr, AnyPrinted, TMinPayments);
			}
		}
	}
}
