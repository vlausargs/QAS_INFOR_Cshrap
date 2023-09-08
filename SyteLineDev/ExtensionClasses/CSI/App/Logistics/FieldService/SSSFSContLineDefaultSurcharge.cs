//PROJECT NAME: Logistics
//CLASS NAME: SSSFSContLineDefaultSurcharge.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSContLineDefaultSurcharge : ISSSFSContLineDefaultSurcharge
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContLineDefaultSurcharge(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string InfoBar) SSSFSContLineDefaultSurchargeSp(
			string Contract,
			int? ContLine,
			string Item,
			string InfoBar)
		{
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			ItemType _Item = Item;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContLineDefaultSurchargeSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return (Severity, InfoBar);
			}
		}
	}
}
