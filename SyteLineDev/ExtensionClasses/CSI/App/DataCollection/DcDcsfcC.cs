//PROJECT NAME: DataCollection
//CLASS NAME: DcDcsfcC.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcDcsfcC : IDcDcsfcC
	{
		readonly IApplicationDB appDB;
		
		
		public DcDcsfcC(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? DcDcsfcCSp(Guid? JobtranRowPointer)
		{
			RowPointerType _JobtranRowPointer = JobtranRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcDcsfcCSp";
				
				appDB.AddCommandParameter(cmd, "JobtranRowPointer", _JobtranRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
