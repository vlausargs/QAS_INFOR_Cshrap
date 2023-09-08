//PROJECT NAME: Material
//CLASS NAME: PhyInvChkEmpItem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class PhyInvChkEmpItem : IPhyInvChkEmpItem
	{
		readonly IApplicationDB appDB;
		
		
		public PhyInvChkEmpItem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string tEmpName,
		string tItemDesc) PhyInvChkEmpItemSP(Guid? PhyInvRowPointer,
		string tEmpName,
		string tItemDesc)
		{
			RowPointerType _PhyInvRowPointer = PhyInvRowPointer;
			StringType _tEmpName = tEmpName;
			StringType _tItemDesc = tItemDesc;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PhyInvChkEmpItemSP";
				
				appDB.AddCommandParameter(cmd, "PhyInvRowPointer", _PhyInvRowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "tEmpName", _tEmpName, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "tItemDesc", _tItemDesc, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				tEmpName = _tEmpName;
				tItemDesc = _tItemDesc;
				
				return (Severity, tEmpName, tItemDesc);
			}
		}
	}
}
