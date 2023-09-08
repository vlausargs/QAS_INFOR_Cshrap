//PROJECT NAME: Logistics
//CLASS NAME: SSSFSCustItemCreate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSCustItemCreate
	{
		(int? ReturnCode, string Infobar) SSSFSCustItemCreateSp(string Item,
		string CustNum,
		string CustItem,
		string UM,
		string Infobar);
	}
	
	public class SSSFSCustItemCreate : ISSSFSCustItemCreate
	{
		readonly IApplicationDB appDB;
		
		public SSSFSCustItemCreate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) SSSFSCustItemCreateSp(string Item,
		string CustNum,
		string CustItem,
		string UM,
		string Infobar)
		{
			ItemType _Item = Item;
			CustNumType _CustNum = CustNum;
			CustItemType _CustItem = CustItem;
			UMType _UM = UM;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSCustItemCreateSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustItem", _CustItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
