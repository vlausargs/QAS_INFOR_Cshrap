//PROJECT NAME: Data
//CLASS NAME: MaskSsnByHrParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class MaskSsnByHrParms : IMaskSsnByHrParms
	{
		readonly IApplicationDB appDB;
		
		public MaskSsnByHrParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public string MaskSsnByHrParmsFn(
			string PSsn)
		{
			SsnType _PSsn = PSsn;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[MaskSsnByHrParms](@PSsn)";
				
				appDB.AddCommandParameter(cmd, "PSsn", _PSsn, ParameterDirection.Input);
				
				var Output = appDB.ExecuteScalar<string>(cmd);
				
				return Output;
			}
		}
	}
}
