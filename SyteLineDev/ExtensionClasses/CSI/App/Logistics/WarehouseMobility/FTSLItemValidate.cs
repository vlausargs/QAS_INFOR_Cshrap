//PROJECT NAME: Logistics
//CLASS NAME: FTSLItemValidate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLItemValidate
	{
		(int? ReturnCode, byte? TaxFreeMatl,
		string ImportDocId,
		string InfoBar) FTSLItemValidateSp(string Item,
		byte? TaxFreeMatl,
		string ImportDocId = null,
		string InfoBar = null);
	}
	
	public class FTSLItemValidate : IFTSLItemValidate
	{
		readonly IApplicationDB appDB;
		
		public FTSLItemValidate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? TaxFreeMatl,
		string ImportDocId,
		string InfoBar) FTSLItemValidateSp(string Item,
		byte? TaxFreeMatl,
		string ImportDocId = null,
		string InfoBar = null)
		{
			ItemType _Item = Item;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			ImportDocIdType _ImportDocId = ImportDocId;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLItemValidateSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TaxFreeMatl = _TaxFreeMatl;
				ImportDocId = _ImportDocId;
				InfoBar = _InfoBar;
				
				return (Severity, TaxFreeMatl, ImportDocId, InfoBar);
			}
		}
	}
}
