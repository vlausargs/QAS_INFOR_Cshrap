//PROJECT NAME: Logistics
//CLASS NAME: GenerateOrderPickListCo14sR.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GenerateOrderPickListCo14sR : IGenerateOrderPickListCo14sR
	{
		readonly IApplicationDB appDB;
		
		public GenerateOrderPickListCo14sR(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? GenerateOrderPickListCo14sRSp(
			Guid? PSessionID)
		{
			RowPointerType _PSessionID = PSessionID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GenerateOrderPickListCo14sRSp";
				
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
