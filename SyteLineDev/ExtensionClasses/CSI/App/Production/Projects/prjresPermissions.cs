//PROJECT NAME: CSIProjects
//CLASS NAME: prjresPermissions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IprjresPermissions
	{
		int prjresPermissionsSp(ref byte? CanAdd,
		                        ref byte? CanUpdate,
		                        ref byte? CanDelete);
	}
	
	public class prjresPermissions : IprjresPermissions
	{
		readonly IApplicationDB appDB;
		
		public prjresPermissions(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int prjresPermissionsSp(ref byte? CanAdd,
		                               ref byte? CanUpdate,
		                               ref byte? CanDelete)
		{
			ListYesNoType _CanAdd = CanAdd;
			ListYesNoType _CanUpdate = CanUpdate;
			ListYesNoType _CanDelete = CanDelete;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "prjresPermissionsSp";
				
				appDB.AddCommandParameter(cmd, "CanAdd", _CanAdd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanUpdate", _CanUpdate, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanDelete", _CanDelete, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanAdd = _CanAdd;
				CanUpdate = _CanUpdate;
				CanDelete = _CanDelete;
				
				return Severity;
			}
		}
	}
}
