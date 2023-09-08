//PROJECT NAME: Logistics
//CLASS NAME: RmaReplUM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplUM : IRmaReplUM
	{
		readonly IApplicationDB appDB;
		
		
		public RmaReplUM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, decimal? RQtyConv,
		decimal? RUnitPrice,
		string Infobar) RmaReplUMSp(string POldUM,
		string PNewUM,
		string PItem,
		string PCustNum,
		decimal? RQtyConv,
		decimal? RUnitPrice,
		string Infobar)
		{
			UMType _POldUM = POldUM;
			UMType _PNewUM = PNewUM;
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			QtyUnitNoNegType _RQtyConv = RQtyConv;
			CostPrcNoNegType _RUnitPrice = RUnitPrice;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RmaReplUMSp";
				
				appDB.AddCommandParameter(cmd, "POldUM", _POldUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PNewUM", _PNewUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RQtyConv", _RQtyConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RUnitPrice", _RUnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				RQtyConv = _RQtyConv;
				RUnitPrice = _RUnitPrice;
				Infobar = _Infobar;
				
				return (Severity, RQtyConv, RUnitPrice, Infobar);
			}
		}
	}
}
