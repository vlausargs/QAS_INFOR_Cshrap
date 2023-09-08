//PROJECT NAME: CSICustomer
//CLASS NAME: CheckNeedDeletedShipment.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICheckNeedDeletedShipment
	{
		(int? ReturnCode, byte? DeleteEmptyShipment, string Infobar) CheckNeedDeletedShipmentSp(Guid? ProcessId,
		byte? DeleteEmptyShipment = (byte)0,
		string Infobar = null);
	}
	
	public class CheckNeedDeletedShipment : ICheckNeedDeletedShipment
	{
		readonly IApplicationDB appDB;
		
		public CheckNeedDeletedShipment(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? DeleteEmptyShipment, string Infobar) CheckNeedDeletedShipmentSp(Guid? ProcessId,
		byte? DeleteEmptyShipment = (byte)0,
		string Infobar = null)
		{
			RowPointerType _ProcessId = ProcessId;
			ListYesNoType _DeleteEmptyShipment = DeleteEmptyShipment;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CheckNeedDeletedShipmentSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DeleteEmptyShipment", _DeleteEmptyShipment, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				DeleteEmptyShipment = _DeleteEmptyShipment;
				Infobar = _Infobar;
				
				return (Severity, DeleteEmptyShipment, Infobar);
			}
		}
	}
}
