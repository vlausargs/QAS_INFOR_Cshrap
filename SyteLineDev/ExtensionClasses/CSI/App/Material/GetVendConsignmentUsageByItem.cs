//PROJECT NAME: CSIMaterial
//CLASS NAME: GetVendConsignmentUsageByItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Material
{
	public interface IGetVendConsignmentUsageByItem
	{
		int GetVendConsignmentUsageByItemSp(string pVendNum,
		                                    string pItem,
		                                    DateTime? pStartDate,
		                                    DateTime? pEndDate,
		                                    ref decimal? BeginBalance,
		                                    ref decimal? Received,
		                                    ref decimal? Consumed,
		                                    ref decimal? EndBalance,
		                                    ref string Infobar);
	}
	
	public class GetVendConsignmentUsageByItem : IGetVendConsignmentUsageByItem
	{
		readonly IApplicationDB appDB;
		
		public GetVendConsignmentUsageByItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetVendConsignmentUsageByItemSp(string pVendNum,
		                                           string pItem,
		                                           DateTime? pStartDate,
		                                           DateTime? pEndDate,
		                                           ref decimal? BeginBalance,
		                                           ref decimal? Received,
		                                           ref decimal? Consumed,
		                                           ref decimal? EndBalance,
		                                           ref string Infobar)
		{
			VendNumType _pVendNum = pVendNum;
			ItemType _pItem = pItem;
			DateType _pStartDate = pStartDate;
			DateType _pEndDate = pEndDate;
			QtyPerType _BeginBalance = BeginBalance;
			QtyPerType _Received = Received;
			QtyPerType _Consumed = Consumed;
			QtyPerType _EndBalance = EndBalance;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetVendConsignmentUsageByItemSp";
				
				appDB.AddCommandParameter(cmd, "pVendNum", _pVendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDate", _pStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDate", _pEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BeginBalance", _BeginBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Received", _Received, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Consumed", _Consumed, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EndBalance", _EndBalance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BeginBalance = _BeginBalance;
				Received = _Received;
				Consumed = _Consumed;
				EndBalance = _EndBalance;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
