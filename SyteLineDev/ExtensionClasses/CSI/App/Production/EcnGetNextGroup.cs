//PROJECT NAME: CSIProduct
//CLASS NAME: EcnGetNextGroup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
	public interface IEcnGetNextGroup
	{
		int EcnGetNextGroupSp(int? SelEcnNum,
		                      ref string NextGroup);
	}
	
	public class EcnGetNextGroup : IEcnGetNextGroup
	{
		readonly IApplicationDB appDB;
		
		public EcnGetNextGroup(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int EcnGetNextGroupSp(int? SelEcnNum,
		                             ref string NextGroup)
		{
			EcnNumType _SelEcnNum = SelEcnNum;
			EcnGroupType _NextGroup = NextGroup;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnGetNextGroupSp";
				
				appDB.AddCommandParameter(cmd, "SelEcnNum", _SelEcnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NextGroup", _NextGroup, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				NextGroup = _NextGroup;
				
				return Severity;
			}
		}
	}
}
