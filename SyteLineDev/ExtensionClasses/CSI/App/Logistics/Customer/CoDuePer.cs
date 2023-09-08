//PROJECT NAME: Logistics
//CLASS NAME: CoDuePer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoDuePer : ICoDuePer
	{
		readonly IApplicationDB appDB;
		
		
		public CoDuePer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PDuePeriod) CoDuePerSp(string PItem,
		string PCustNum,
		int? PDuePeriod,
		string CustItem)
		{
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			DuePeriodType _PDuePeriod = PDuePeriod;
			CustItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CoDuePerSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDuePeriod", _PDuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDuePeriod = _PDuePeriod;
				
				return (Severity, PDuePeriod);
			}
		}
	}
}
