//PROJECT NAME: Logistics
//CLASS NAME: SSSFSGetInspectionResponses.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.FieldService
{
	public class SSSFSGetInspectionResponses : ISSSFSGetInspectionResponses
	{
		readonly IApplicationDB appDB;
		
		public SSSFSGetInspectionResponses(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string SSSFSGetInspectionResponsesFn(
			string MeasType)
		{
			FSMeasTypeType _MeasType = MeasType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[SSSFSGetInspectionResponses](@MeasType)";
				
				appDB.AddCommandParameter(cmd, "MeasType", _MeasType, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
