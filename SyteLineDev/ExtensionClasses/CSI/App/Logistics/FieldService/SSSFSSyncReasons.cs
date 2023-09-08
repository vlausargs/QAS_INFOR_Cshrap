//PROJECT NAME: Logistics
//CLASS NAME: SSSFSSyncReasons.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSSyncReasons : ISSSFSSyncReasons
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSyncReasons(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SSSFSSyncReasonsSp(
			string iUpdateFrom,
			string iIncSroNum,
			Guid? iReasonRowPointer)
		{
			StringType _iUpdateFrom = iUpdateFrom;
			FSSRONumType _iIncSroNum = iIncSroNum;
			RowPointerType _iReasonRowPointer = iReasonRowPointer;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSyncReasonsSp";
				
				appDB.AddCommandParameter(cmd, "iUpdateFrom", _iUpdateFrom, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iIncSroNum", _iIncSroNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "iReasonRowPointer", _iReasonRowPointer, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
