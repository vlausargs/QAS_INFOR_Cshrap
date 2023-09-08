//PROJECT NAME: Logistics
//CLASS NAME: CreateCoShipEsig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CreateCoShipEsig : ICreateCoShipEsig
	{
		readonly IApplicationDB appDB;
		
		public CreateCoShipEsig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CreateCoShipEsigSp(
			Guid? TmpShipRowpointer,
			int? TmpShipSequence)
		{
			RowPointerType _TmpShipRowpointer = TmpShipRowpointer;
			IntType _TmpShipSequence = TmpShipSequence;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CreateCoShipEsigSp";
				
				appDB.AddCommandParameter(cmd, "TmpShipRowpointer", _TmpShipRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TmpShipSequence", _TmpShipSequence, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
