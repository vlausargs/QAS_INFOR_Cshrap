//PROJECT NAME: CSIFSPlusUnit
//CLASS NAME: SSSFSContLineItemChange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSContLineItemChange
	{
		int SSSFSContLineItemChangeSp(string Contract,
		                              int? ContLine,
		                              string Item,
		                              ref string InfoBar);
	}
	
	public class SSSFSContLineItemChange : ISSSFSContLineItemChange
	{
		readonly IApplicationDB appDB;
		
		public SSSFSContLineItemChange(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSContLineItemChangeSp(string Contract,
		                                     int? ContLine,
		                                     string Item,
		                                     ref string InfoBar)
		{
			FSContractType _Contract = Contract;
			FSContLineType _ContLine = ContLine;
			ItemType _Item = Item;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSContLineItemChangeSp";
				
				appDB.AddCommandParameter(cmd, "Contract", _Contract, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ContLine", _ContLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InfoBar = _InfoBar;
				
				return Severity;
			}
		}
	}
}
