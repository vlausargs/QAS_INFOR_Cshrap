//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTSLGetDefaultWCLocation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLGetDefaultWCLocation
	{
		(int? ReturnCode, string ReceiptLoc) FTSLGetDefaultWCLocationSp(string Inputworkcenter,
		string DefaultWhseRecLoc = null,
		string ReceiptLoc = null);
	}
	
	public class FTSLGetDefaultWCLocation : IFTSLGetDefaultWCLocation
	{
		readonly IApplicationDB appDB;
		
		public FTSLGetDefaultWCLocation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string ReceiptLoc) FTSLGetDefaultWCLocationSp(string Inputworkcenter,
		string DefaultWhseRecLoc = null,
		string ReceiptLoc = null)
		{
			EmpNameType _Inputworkcenter = Inputworkcenter;
			EmpNameType _DefaultWhseRecLoc = DefaultWhseRecLoc;
			InfobarType _ReceiptLoc = ReceiptLoc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLGetDefaultWCLocationSp";
				
				appDB.AddCommandParameter(cmd, "Inputworkcenter", _Inputworkcenter, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DefaultWhseRecLoc", _DefaultWhseRecLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReceiptLoc", _ReceiptLoc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ReceiptLoc = _ReceiptLoc;
				
				return (Severity, ReceiptLoc);
			}
		}
	}
}
