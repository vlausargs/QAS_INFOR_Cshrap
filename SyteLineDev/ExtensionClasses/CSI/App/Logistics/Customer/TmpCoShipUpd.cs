//PROJECT NAME: Logistics
//CLASS NAME: TmpCoShipUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TmpCoShipUpd : ITmpCoShipUpd
	{
		readonly IApplicationDB appDB;
		
		
		public TmpCoShipUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? TmpCoShipUpdSp(Guid? RowPointer,
		int? Selected)
		{
			RowPointerType _RowPointer = RowPointer;
			ListYesNoType _Selected = Selected;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "TmpCoShipUpdSp";
				
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Selected", _Selected, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
