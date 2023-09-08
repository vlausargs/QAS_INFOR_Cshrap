//PROJECT NAME: CSICustomer
//CLASS NAME: ARActDeactPostedTrans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IARActDeactPostedTrans
	{
		(int? ReturnCode, string Infobar, int? ActiveCount, int? InactiveCount) ARActDeactPostedTransSp(int? pActivate,
		string pStartCustNum,
		string pEndCustNum,
		DateTime? pStartLastActivityDate,
		DateTime? pEndLastActivityDate,
		DateTime? pStartInvDate,
		DateTime? pEndInvDate,
		string Infobar,
		decimal? UserID = null,
		int? BGTaskID = null,
		int? ReturnCounts = (byte)0,
		int? CountOnly = (byte)0,
		int? ActiveCount = 0,
		int? InactiveCount = 0);
	}
	
	public class ARActDeactPostedTrans : IARActDeactPostedTrans
	{
		readonly IApplicationDB appDB;
		
		public ARActDeactPostedTrans(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, int? ActiveCount, int? InactiveCount) ARActDeactPostedTransSp(int? pActivate,
		string pStartCustNum,
		string pEndCustNum,
		DateTime? pStartLastActivityDate,
		DateTime? pEndLastActivityDate,
		DateTime? pStartInvDate,
		DateTime? pEndInvDate,
		string Infobar,
		decimal? UserID = null,
		int? BGTaskID = null,
		int? ReturnCounts = (byte)0,
		int? CountOnly = (byte)0,
		int? ActiveCount = 0,
		int? InactiveCount = 0)
		{
			ListYesNoType _pActivate = pActivate;
			HighLowCharType _pStartCustNum = pStartCustNum;
			HighLowCharType _pEndCustNum = pEndCustNum;
			DateType _pStartLastActivityDate = pStartLastActivityDate;
			DateType _pEndLastActivityDate = pEndLastActivityDate;
			DateType _pStartInvDate = pStartInvDate;
			DateType _pEndInvDate = pEndInvDate;
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
				cmd.CommandText = "ARActDeactPostedTransSp";
				
				appDB.AddCommandParameter(cmd, "pActivate", _pActivate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartCustNum", _pStartCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndCustNum", _pEndCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartLastActivityDate", _pStartLastActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndLastActivityDate", _pEndLastActivityDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartInvDate", _pStartInvDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndInvDate", _pEndInvDate, ParameterDirection.Input);
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
