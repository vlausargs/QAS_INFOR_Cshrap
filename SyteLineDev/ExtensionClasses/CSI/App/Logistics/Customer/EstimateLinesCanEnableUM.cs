//PROJECT NAME: Logistics
//CLASS NAME: EstimateLinesCanEnableUM.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class EstimateLinesCanEnableUM : IEstimateLinesCanEnableUM
	{
		readonly IApplicationDB appDB;
		
		
		public EstimateLinesCanEnableUM(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PEnableUM) EstimateLinesCanEnableUMSp(string PItem,
		int? PEnableUM)
		{
			ItemType _PItem = PItem;
			Flag _PEnableUM = PEnableUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EstimateLinesCanEnableUMSp";
				
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEnableUM", _PEnableUM, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PEnableUM = _PEnableUM;
				
				return (Severity, PEnableUM);
			}
		}
	}
}
