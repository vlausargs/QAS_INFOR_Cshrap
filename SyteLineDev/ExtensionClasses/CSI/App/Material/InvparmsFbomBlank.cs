//PROJECT NAME: Material
//CLASS NAME: InvparmsFbomBlank.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class InvparmsFbomBlank : IInvparmsFbomBlank
	{
		readonly IApplicationDB appDB;
		
		
		public InvparmsFbomBlank(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string InvparmsFbomBlank) InvparmsFbomBlankSp(string InvparmsFbomBlank)
		{
			FeatBlankType _InvparmsFbomBlank = InvparmsFbomBlank;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "InvparmsFbomBlankSp";
				
				appDB.AddCommandParameter(cmd, "InvparmsFbomBlank", _InvparmsFbomBlank, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				InvparmsFbomBlank = _InvparmsFbomBlank;
				
				return (Severity, InvparmsFbomBlank);
			}
		}
	}
}
