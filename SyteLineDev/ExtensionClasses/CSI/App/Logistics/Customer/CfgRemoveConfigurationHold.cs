//PROJECT NAME: Logistics
//CLASS NAME: CfgRemoveConfigurationHold.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CfgRemoveConfigurationHold : ICfgRemoveConfigurationHold
	{
		readonly IApplicationDB appDB;
		
		
		public CfgRemoveConfigurationHold(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? CfgRemoveConfigurationHoldSp(string SourceRefType,
		string RefNum,
		int? RefLineSuf,
		int? ConfigHold)
		{
			StringType _SourceRefType = SourceRefType;
			CoNumJobType _RefNum = RefNum;
			CoLineSuffixType _RefLineSuf = RefLineSuf;
			ListYesNoType _ConfigHold = ConfigHold;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "CfgRemoveConfigurationHoldSp";
				
				appDB.AddCommandParameter(cmd, "SourceRefType", _SourceRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefNum", _RefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefLineSuf", _RefLineSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConfigHold", _ConfigHold, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
