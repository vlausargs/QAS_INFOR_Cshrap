//PROJECT NAME: Material
//CLASS NAME: MrpWbGetPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpWbGetPrefix : IMrpWbGetPrefix
	{
		readonly IApplicationDB appDB;
		
		
		public MrpWbGetPrefix(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PoparmsPoPrefix,
		string PoparmsPoChange,
		string PoparmsPrqPrefix,
		string InvparmsTrnPrefix,
		string SfcparmsWoPrefix,
		string SfcparmsPsPrefix) MrpWbGetPrefixSp(string PoparmsPoPrefix,
		string PoparmsPoChange,
		string PoparmsPrqPrefix,
		string InvparmsTrnPrefix,
		string SfcparmsWoPrefix,
		string SfcparmsPsPrefix)
		{
			PoPrefixType _PoparmsPoPrefix = PoparmsPoPrefix;
			ListAlwaysSometimesNeverType _PoparmsPoChange = PoparmsPoChange;
			PreqPrefixType _PoparmsPrqPrefix = PoparmsPrqPrefix;
			AlphaPrefixType _InvparmsTrnPrefix = InvparmsTrnPrefix;
			JobPrefixType _SfcparmsWoPrefix = SfcparmsWoPrefix;
			PsPrefixType _SfcparmsPsPrefix = SfcparmsPsPrefix;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpWbGetPrefixSp";
				
				appDB.AddCommandParameter(cmd, "PoparmsPoPrefix", _PoparmsPoPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoparmsPoChange", _PoparmsPoChange, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PoparmsPrqPrefix", _PoparmsPrqPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InvparmsTrnPrefix", _InvparmsTrnPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SfcparmsWoPrefix", _SfcparmsWoPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SfcparmsPsPrefix", _SfcparmsPsPrefix, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PoparmsPoPrefix = _PoparmsPoPrefix;
				PoparmsPoChange = _PoparmsPoChange;
				PoparmsPrqPrefix = _PoparmsPrqPrefix;
				InvparmsTrnPrefix = _InvparmsTrnPrefix;
				SfcparmsWoPrefix = _SfcparmsWoPrefix;
				SfcparmsPsPrefix = _SfcparmsPsPrefix;
				
				return (Severity, PoparmsPoPrefix, PoparmsPoChange, PoparmsPrqPrefix, InvparmsTrnPrefix, SfcparmsWoPrefix, SfcparmsPsPrefix);
			}
		}
	}
}
