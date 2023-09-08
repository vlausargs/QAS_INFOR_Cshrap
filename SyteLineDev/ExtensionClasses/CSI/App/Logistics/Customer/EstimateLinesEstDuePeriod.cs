//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesEstDuePeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesEstDuePeriod : IEstimateLinesEstDuePeriod
	{
		readonly IApplicationDB appDB;
		
		
		public EstimateLinesEstDuePeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PDuePeriod) EstimateLinesEstDuePeriodSp(string PItem,
		string PCustNum,
		int? PDuePeriod,
		string CustItem)
		{
			ItemType _PItem = PItem;
			CustNumType _PCustNum = PCustNum;
			IntType _PDuePeriod = PDuePeriod;
			CustItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesEstDuePeriodSp";
				
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
