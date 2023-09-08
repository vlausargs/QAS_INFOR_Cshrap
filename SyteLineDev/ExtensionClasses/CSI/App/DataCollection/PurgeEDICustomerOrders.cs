//PROJECT NAME: DataCollection
//CLASS NAME: PurgeEDICustomerOrders.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IPurgeEDICustomerOrders
	{
		(int? ReturnCode, string Message) PurgeEDICustomerOrdersSp(string optexBegEdiCo_Num = null,
		string optexEndEdiCo_Num = null,
		DateTime? optexBegOrder_date = null,
		DateTime? optexEndOrder_date = null,
		string optexBegCust_num = null,
		string optexEndCust_num = null,
		string optexBegTrx_code = null,
		string optexEndTrx_code = null,
		short? TrxDateStartingOffset = null,
		short? TrxDateEndingOffset = null,
		string Message = null);
	}
	
	public class PurgeEDICustomerOrders : IPurgeEDICustomerOrders
	{
		readonly IApplicationDB appDB;
		
		public PurgeEDICustomerOrders(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Message) PurgeEDICustomerOrdersSp(string optexBegEdiCo_Num = null,
		string optexEndEdiCo_Num = null,
		DateTime? optexBegOrder_date = null,
		DateTime? optexEndOrder_date = null,
		string optexBegCust_num = null,
		string optexEndCust_num = null,
		string optexBegTrx_code = null,
		string optexEndTrx_code = null,
		short? TrxDateStartingOffset = null,
		short? TrxDateEndingOffset = null,
		string Message = null)
		{
			CoNumType _optexBegEdiCo_Num = optexBegEdiCo_Num;
			CoNumType _optexEndEdiCo_Num = optexEndEdiCo_Num;
			DateType _optexBegOrder_date = optexBegOrder_date;
			DateType _optexEndOrder_date = optexEndOrder_date;
			CustNumType _optexBegCust_num = optexBegCust_num;
			CustNumType _optexEndCust_num = optexEndCust_num;
			EdiTrxCodeType _optexBegTrx_code = optexBegTrx_code;
			EdiTrxCodeType _optexEndTrx_code = optexEndTrx_code;
			DateOffsetType _TrxDateStartingOffset = TrxDateStartingOffset;
			DateOffsetType _TrxDateEndingOffset = TrxDateEndingOffset;
			InfobarType _Message = Message;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PurgeEDICustomerOrdersSp";
				
				appDB.AddCommandParameter(cmd, "optexBegEdiCo_Num", _optexBegEdiCo_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexEndEdiCo_Num", _optexEndEdiCo_Num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexBegOrder_date", _optexBegOrder_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexEndOrder_date", _optexEndOrder_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexBegCust_num", _optexBegCust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexEndCust_num", _optexEndCust_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexBegTrx_code", _optexBegTrx_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "optexEndTrx_code", _optexEndTrx_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxDateStartingOffset", _TrxDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrxDateEndingOffset", _TrxDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Message", _Message, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Message = _Message;
				
				return (Severity, Message);
			}
		}
	}
}
