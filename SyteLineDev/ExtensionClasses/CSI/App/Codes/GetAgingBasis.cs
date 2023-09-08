//PROJECT NAME: CSICodes
//CLASS NAME: GetAgingBasis.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetAgingBasis
	{
		int GetAgingBasisSp(ref string ArparmInvDue,
		                    ref string ApparmInvDue);
	}
	
	public class GetAgingBasis : IGetAgingBasis
	{
		readonly IApplicationDB appDB;
		
		public GetAgingBasis(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetAgingBasisSp(ref string ArparmInvDue,
		                           ref string ApparmInvDue)
		{
			ArAgeByType _ArparmInvDue = ArparmInvDue;
			ApAgeByType _ApparmInvDue = ApparmInvDue;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAgingBasisSp";
				
				appDB.AddCommandParameter(cmd, "ArparmInvDue", _ArparmInvDue, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApparmInvDue", _ApparmInvDue, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				ArparmInvDue = _ArparmInvDue;
				ApparmInvDue = _ApparmInvDue;
				
				return Severity;
			}
		}
	}
}
