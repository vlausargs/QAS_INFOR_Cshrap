//PROJECT NAME: Data
//CLASS NAME: EstimateLinesGetItemCustItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EstimateLinesGetItemCustItem : IEstimateLinesGetItemCustItem
	{
		readonly IApplicationDB appDB;
		
		public EstimateLinesGetItemCustItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? PEnableUM) EstimateLinesGetItemCustItemSp(
			string PItem,
			int? PEnableUM)
		{
			ItemType _PItem = PItem;
			Flag _PEnableUM = PEnableUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesGetItemCustItemSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEnableUM", _PEnableUM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEnableUM = _PEnableUM;
				
				return (Severity, PEnableUM);
			}
		}
	}
}
