//PROJECT NAME: Data
//CLASS NAME: DuePer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class DuePer : IDuePer
	{
		readonly IApplicationDB appDB;
		
		public DuePer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? DuePeriod) DuePerSp(
			string Item,
			string CustNum,
			int? DuePeriod,
			string CustItem)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			DuePeriodType _DuePeriod = DuePeriod;
			ItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DuePerSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DuePeriod", _DuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DuePeriod = _DuePeriod;
				
				return (Severity, DuePeriod);
			}
		}
	}
}
