//PROJECT NAME: CSIProduct
//CLASS NAME: GetJobParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IGetJobParms
	{
		int GetJobParmsSp(ref byte? PAnyCanAdd,
		                  ref byte? PAnyCanDelete,
		                  ref byte? PAnyCanUpdate,
		                  ref string PSfcParmValue,
		                  string PSfcParmName,
		                  ref string PApsParmValue,
		                  string PApsParmName);
	}
	
	public class GetJobParms : IGetJobParms
	{
		readonly IApplicationDB appDB;
		
		public GetJobParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetJobParmsSp(ref byte? PAnyCanAdd,
		                         ref byte? PAnyCanDelete,
		                         ref byte? PAnyCanUpdate,
		                         ref string PSfcParmValue,
		                         string PSfcParmName,
		                         ref string PApsParmValue,
		                         string PApsParmName)
		{
			ListYesNoType _PAnyCanAdd = PAnyCanAdd;
			ListYesNoType _PAnyCanDelete = PAnyCanDelete;
			ListYesNoType _PAnyCanUpdate = PAnyCanUpdate;
			StringType _PSfcParmValue = PSfcParmValue;
			StringType _PSfcParmName = PSfcParmName;
			StringType _PApsParmValue = PApsParmValue;
			StringType _PApsParmName = PApsParmName;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetJobParmsSp";
				
				appDB.AddCommandParameter(cmd, "PAnyCanAdd", _PAnyCanAdd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAnyCanDelete", _PAnyCanDelete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PAnyCanUpdate", _PAnyCanUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSfcParmValue", _PSfcParmValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSfcParmName", _PSfcParmName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PApsParmValue", _PApsParmValue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PApsParmName", _PApsParmName, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PAnyCanAdd = _PAnyCanAdd;
				PAnyCanDelete = _PAnyCanDelete;
				PAnyCanUpdate = _PAnyCanUpdate;
				PSfcParmValue = _PSfcParmValue;
				PApsParmValue = _PApsParmValue;
				
				return Severity;
			}
		}
	}
}
