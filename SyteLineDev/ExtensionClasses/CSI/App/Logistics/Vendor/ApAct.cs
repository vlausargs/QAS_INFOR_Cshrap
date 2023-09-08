//PROJECT NAME: CSIVendor
//CLASS NAME: ApAct.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface IApAct
	{
		(int? ReturnCode, string Infobar, int? ActiveCount, int? InactiveCount) ApActSp(byte? ActivateDeactivate,
		string StartingVendor,
		string EndingVendor,
		DateTime? StartingLastActDate,
		DateTime? EndingLastActDate,
		DateTime? StartingInvoiceDate,
		DateTime? EndingInvoiceDate,
		byte? AffectNonAPPayments,
		string Infobar,
		decimal? UserID = null,
		int? BGTaskID = null,
		byte? ReturnCounts = (byte)0,
		byte? CountOnly = (byte)0,
		int? ActiveCount = 0,
		int? InactiveCount = 0);
	}
	
	public class ApAct : IApAct
	{
		readonly IApplicationDB appDB;
		
		public ApAct(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, int? ActiveCount, int? InactiveCount) ApActSp(byte? ActivateDeactivate,
		string StartingVendor,
		string EndingVendor,
		DateTime? StartingLastActDate,
		DateTime? EndingLastActDate,
		DateTime? StartingInvoiceDate,
		DateTime? EndingInvoiceDate,
		byte? AffectNonAPPayments,
		string Infobar,
		decimal? UserID = null,
		int? BGTaskID = null,
		byte? ReturnCounts = (byte)0,
		byte? CountOnly = (byte)0,
		int? ActiveCount = 0,
		int? InactiveCount = 0)
		{
			FlagNyType _ActivateDeactivate = ActivateDeactivate;
			VendNumType _StartingVendor = StartingVendor;
			VendNumType _EndingVendor = EndingVendor;
			DateType _StartingLastActDate = StartingLastActDate;
			DateType _EndingLastActDate = EndingLastActDate;
			DateType _StartingInvoiceDate = StartingInvoiceDate;
			DateType _EndingInvoiceDate = EndingInvoiceDate;
			FlagNyType _AffectNonAPPayments = AffectNonAPPayments;
			InfobarType _Infobar = Infobar;
			TokenType _UserID = UserID;
			TaskNumType _BGTaskID = BGTaskID;
			ListYesNoType _ReturnCounts = ReturnCounts;
			ListYesNoType _CountOnly = CountOnly;
			IntType _ActiveCount = ActiveCount;
			IntType _InactiveCount = InactiveCount;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ApActSp";
				
				appDB.AddCommandParameter(cmd, "ActivateDeactivate", _ActivateDeactivate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingVendor", _StartingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingVendor", _EndingVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingLastActDate", _StartingLastActDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingLastActDate", _EndingLastActDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingInvoiceDate", _StartingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingInvoiceDate", _EndingInvoiceDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AffectNonAPPayments", _AffectNonAPPayments, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserID", _UserID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGTaskID", _BGTaskID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReturnCounts", _ReturnCounts, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CountOnly", _CountOnly, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveCount", _ActiveCount, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InactiveCount", _InactiveCount, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				ActiveCount = _ActiveCount;
				InactiveCount = _InactiveCount;
				
				return (Severity, Infobar, ActiveCount, InactiveCount);
			}
		}
	}
}
