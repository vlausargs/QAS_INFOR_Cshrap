//PROJECT NAME: Material
//CLASS NAME: ecniPermissions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IecniPermissions
	{
		(int? ReturnCode, byte? CanEstDel, byte? CanEstIns, byte? CanEstUpd, byte? CanEstViewCosts, byte? CanJobDel, byte? CanJobIns, byte? CanJobUpd, byte? CanJobViewCosts, byte? CanStdDel, byte? CanStdIns, byte? CanStdUpd, byte? CanStdViewCosts, byte? CanAnyDel, byte? CanAnyIns, byte? CanAnyUpd, byte? CanAnyViewCosts, byte? CanApprove, byte? CanItemUpd, byte? CanItemMfrIns, byte? CanItemMfrUpd, byte? CanItemMfrDel) ecniPermissionsSp(byte? CanEstDel,
		byte? CanEstIns,
		byte? CanEstUpd,
		byte? CanEstViewCosts,
		byte? CanJobDel,
		byte? CanJobIns,
		byte? CanJobUpd,
		byte? CanJobViewCosts,
		byte? CanStdDel,
		byte? CanStdIns,
		byte? CanStdUpd,
		byte? CanStdViewCosts,
		byte? CanAnyDel,
		byte? CanAnyIns,
		byte? CanAnyUpd,
		byte? CanAnyViewCosts,
		byte? CanApprove,
		byte? CanItemUpd,
		byte? CanItemMfrIns,
		byte? CanItemMfrUpd,
		byte? CanItemMfrDel);
	}
	
	public class ecniPermissions : IecniPermissions
	{
		readonly IApplicationDB appDB;
		
		public ecniPermissions(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, byte? CanEstDel, byte? CanEstIns, byte? CanEstUpd, byte? CanEstViewCosts, byte? CanJobDel, byte? CanJobIns, byte? CanJobUpd, byte? CanJobViewCosts, byte? CanStdDel, byte? CanStdIns, byte? CanStdUpd, byte? CanStdViewCosts, byte? CanAnyDel, byte? CanAnyIns, byte? CanAnyUpd, byte? CanAnyViewCosts, byte? CanApprove, byte? CanItemUpd, byte? CanItemMfrIns, byte? CanItemMfrUpd, byte? CanItemMfrDel) ecniPermissionsSp(byte? CanEstDel,
		byte? CanEstIns,
		byte? CanEstUpd,
		byte? CanEstViewCosts,
		byte? CanJobDel,
		byte? CanJobIns,
		byte? CanJobUpd,
		byte? CanJobViewCosts,
		byte? CanStdDel,
		byte? CanStdIns,
		byte? CanStdUpd,
		byte? CanStdViewCosts,
		byte? CanAnyDel,
		byte? CanAnyIns,
		byte? CanAnyUpd,
		byte? CanAnyViewCosts,
		byte? CanApprove,
		byte? CanItemUpd,
		byte? CanItemMfrIns,
		byte? CanItemMfrUpd,
		byte? CanItemMfrDel)
		{
			ListYesNoType _CanEstDel = CanEstDel;
			ListYesNoType _CanEstIns = CanEstIns;
			ListYesNoType _CanEstUpd = CanEstUpd;
			ListYesNoType _CanEstViewCosts = CanEstViewCosts;
			ListYesNoType _CanJobDel = CanJobDel;
			ListYesNoType _CanJobIns = CanJobIns;
			ListYesNoType _CanJobUpd = CanJobUpd;
			ListYesNoType _CanJobViewCosts = CanJobViewCosts;
			ListYesNoType _CanStdDel = CanStdDel;
			ListYesNoType _CanStdIns = CanStdIns;
			ListYesNoType _CanStdUpd = CanStdUpd;
			ListYesNoType _CanStdViewCosts = CanStdViewCosts;
			ListYesNoType _CanAnyDel = CanAnyDel;
			ListYesNoType _CanAnyIns = CanAnyIns;
			ListYesNoType _CanAnyUpd = CanAnyUpd;
			ListYesNoType _CanAnyViewCosts = CanAnyViewCosts;
			ListYesNoType _CanApprove = CanApprove;
			ListYesNoType _CanItemUpd = CanItemUpd;
			ListYesNoType _CanItemMfrIns = CanItemMfrIns;
			ListYesNoType _CanItemMfrUpd = CanItemMfrUpd;
			ListYesNoType _CanItemMfrDel = CanItemMfrDel;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ecniPermissionsSp";
				
				appDB.AddCommandParameter(cmd, "CanEstDel", _CanEstDel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanEstIns", _CanEstIns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanEstUpd", _CanEstUpd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanEstViewCosts", _CanEstViewCosts, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanJobDel", _CanJobDel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanJobIns", _CanJobIns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanJobUpd", _CanJobUpd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanJobViewCosts", _CanJobViewCosts, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanStdDel", _CanStdDel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanStdIns", _CanStdIns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanStdUpd", _CanStdUpd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanStdViewCosts", _CanStdViewCosts, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyDel", _CanAnyDel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyIns", _CanAnyIns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyUpd", _CanAnyUpd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanAnyViewCosts", _CanAnyViewCosts, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanApprove", _CanApprove, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanItemUpd", _CanItemUpd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanItemMfrIns", _CanItemMfrIns, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanItemMfrUpd", _CanItemMfrUpd, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CanItemMfrDel", _CanItemMfrDel, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanEstDel = _CanEstDel;
				CanEstIns = _CanEstIns;
				CanEstUpd = _CanEstUpd;
				CanEstViewCosts = _CanEstViewCosts;
				CanJobDel = _CanJobDel;
				CanJobIns = _CanJobIns;
				CanJobUpd = _CanJobUpd;
				CanJobViewCosts = _CanJobViewCosts;
				CanStdDel = _CanStdDel;
				CanStdIns = _CanStdIns;
				CanStdUpd = _CanStdUpd;
				CanStdViewCosts = _CanStdViewCosts;
				CanAnyDel = _CanAnyDel;
				CanAnyIns = _CanAnyIns;
				CanAnyUpd = _CanAnyUpd;
				CanAnyViewCosts = _CanAnyViewCosts;
				CanApprove = _CanApprove;
				CanItemUpd = _CanItemUpd;
				CanItemMfrIns = _CanItemMfrIns;
				CanItemMfrUpd = _CanItemMfrUpd;
				CanItemMfrDel = _CanItemMfrDel;
				
				return (Severity, CanEstDel, CanEstIns, CanEstUpd, CanEstViewCosts, CanJobDel, CanJobIns, CanJobUpd, CanJobViewCosts, CanStdDel, CanStdIns, CanStdUpd, CanStdViewCosts, CanAnyDel, CanAnyIns, CanAnyUpd, CanAnyViewCosts, CanApprove, CanItemUpd, CanItemMfrIns, CanItemMfrUpd, CanItemMfrDel);
			}
		}
	}
}
