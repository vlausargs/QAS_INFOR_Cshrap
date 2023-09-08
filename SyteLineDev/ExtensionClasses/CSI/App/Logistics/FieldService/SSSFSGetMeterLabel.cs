//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetMeterLabel.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetMeterLabel : ISSSFSGetMeterLabel
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetMeterLabel(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetMeterLabelFn(
			string Item = null)
		{
			ItemType _Item = Item;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetMeterLabel](@Item)";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
