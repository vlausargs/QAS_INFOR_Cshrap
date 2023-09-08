//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesSetItemCust.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesSetItemCust : IEstimateLinesSetItemCust
	{
		readonly IApplicationDB appDB;
		
		
		public EstimateLinesSetItemCust(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? EstimateLinesSetItemCustSp(int? PSetItemCust,
		string PItem,
		string PCustNum,
		string PCustItem,
		decimal? PCostConv,
		string PCoNum,
		string PUM)
		{
			Flag _PSetItemCust = PSetItemCust;
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			CustItemType _PCustItem = PCustItem;
			CostPrcType _PCostConv = PCostConv;
			CoNumType _PCoNum = PCoNum;
			UMType _PUM = PUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesSetItemCustSp";
				
				appDB.AddCommandParameter(cmd, "PSetItemCust", _PSetItemCust, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustItem", _PCustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCostConv", _PCostConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCoNum", _PCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PUM", _PUM, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
