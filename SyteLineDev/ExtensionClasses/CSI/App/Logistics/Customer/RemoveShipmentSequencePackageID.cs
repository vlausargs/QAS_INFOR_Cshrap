//PROJECT NAME: CSICustomer
//CLASS NAME: RemoveShipmentSequencePackageID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IRemoveShipmentSequencePackageID
	{
		int RemoveShipmentSequencePackageIDSp(Guid? ProcessId,
		                                      ref string Infobar);
	}
	
	public class RemoveShipmentSequencePackageID : IRemoveShipmentSequencePackageID
	{
		readonly IApplicationDB appDB;
		
		public RemoveShipmentSequencePackageID(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int RemoveShipmentSequencePackageIDSp(Guid? ProcessId,
		                                             ref string Infobar)
		{
			RowPointerType _ProcessId = ProcessId;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RemoveShipmentSequencePackageIDSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
