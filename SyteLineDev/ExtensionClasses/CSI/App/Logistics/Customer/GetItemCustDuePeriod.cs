//PROJECT NAME: Logistics
//CLASS NAME: GetItemCustDuePeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetItemCustDuePeriod : IGetItemCustDuePeriod
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemCustDuePeriod(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? IcDuePeriod) GetItemCustDuePeriodSp(string CustNum,
		string Item,
		int? IcDuePeriod,
		string CustItem)
		{
			CustNumType _CustNum = CustNum;
			ItemType _Item = Item;
			DuePeriodType _IcDuePeriod = IcDuePeriod;
			CustItemType _CustItem = CustItem;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemCustDuePeriodSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IcDuePeriod", _IcDuePeriod, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				IcDuePeriod = _IcDuePeriod;
				
				return (Severity, IcDuePeriod);
			}
		}
	}
}
