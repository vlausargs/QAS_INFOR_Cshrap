//PROJECT NAME: CSICustomer
//CLASS NAME: OrderCreditHold.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IOrderCreditHold
	{
		(int? ReturnCode, string Infobar) OrderCreditHoldSp(string GroupID,
		byte? CreditHold,
		string StartingCustomer,
		string EndingCustomer,
		string StartingOrder,
		string EndingOrder,
		byte? SubCustomer,
		string AgingBasis,
		DateTime? AgingDate,
		string Reason,
		string Infobar,
		decimal? UserId,
		short? AgingDateOffset = null);
	}
	
	public class OrderCreditHold : IOrderCreditHold
	{
		readonly IApplicationDB appDB;
		
		public OrderCreditHold(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) OrderCreditHoldSp(string GroupID,
		byte? CreditHold,
		string StartingCustomer,
		string EndingCustomer,
		string StartingOrder,
		string EndingOrder,
		byte? SubCustomer,
		string AgingBasis,
		DateTime? AgingDate,
		string Reason,
		string Infobar,
		decimal? UserId,
		short? AgingDateOffset = null)
		{
			SiteGroupType _GroupID = GroupID;
			ListYesNoType _CreditHold = CreditHold;
			CustNumType _StartingCustomer = StartingCustomer;
			CustNumType _EndingCustomer = EndingCustomer;
			CoNumType _StartingOrder = StartingOrder;
			CoNumType _EndingOrder = EndingOrder;
			ListYesNoType _SubCustomer = SubCustomer;
			ArAgeByType _AgingBasis = AgingBasis;
			DateType _AgingDate = AgingDate;
			ReasonCodeType _Reason = Reason;
			InfobarType _Infobar = Infobar;
			TokenType _UserId = UserId;
			DateOffsetType _AgingDateOffset = AgingDateOffset;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "OrderCreditHoldSp";
				
				appDB.AddCommandParameter(cmd, "GroupID", _GroupID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CreditHold", _CreditHold, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCustomer", _StartingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCustomer", _EndingCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubCustomer", _SubCustomer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingBasis", _AgingBasis, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingDate", _AgingDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reason", _Reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AgingDateOffset", _AgingDateOffset, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
