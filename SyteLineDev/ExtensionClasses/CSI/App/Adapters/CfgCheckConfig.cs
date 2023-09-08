//PROJECT NAME: Adapters
//CLASS NAME: CfgCheckConfig.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Adapters
{
	public class CfgCheckConfig : ICfgCheckConfig
	{
		readonly IApplicationDB appDB;
		
		
		public CfgCheckConfig(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? PConfigurable) CfgCheckConfigSp(string PCEP,
		string PItem,
		int? PConfigurable)
		{
			LongListType _PCEP = PCEP;
			ItemType _PItem = PItem;
			FlagNyType _PConfigurable = PConfigurable;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgCheckConfigSp";
				
				appDB.AddCommandParameter(cmd, "PCEP", _PCEP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PConfigurable", _PConfigurable, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PConfigurable = _PConfigurable;
				
				return (Severity, PConfigurable);
			}
		}

		public int? CfgCheckConfigFn(
			string pCEP,
			string pItem)
		{
			LongListType _pCEP = pCEP;
			ItemType _pItem = pItem;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[CfgCheckConfig](@pCEP, @pItem)";

				appDB.AddCommandParameter(cmd, "pCEP", _pCEP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pItem", _pItem, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<int?>(cmd);

				return Output;
			}
		}
	}
}
