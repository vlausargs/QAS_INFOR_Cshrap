//PROJECT NAME: Material
//CLASS NAME: ItemExtraInit.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemExtraInit : IItemExtraInit
	{
		readonly IApplicationDB appDB;
		
		
		public ItemExtraInit(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string LotPrefix,
		int? LotTracked,
		string IssueBy,
		int? SerialTracked,
		string SerialPrefix,
		string CostType,
		int? PreassignLots,
		int? PreassignSerials) ItemExtraInitSp(string LotPrefix,
		int? LotTracked,
		string IssueBy,
		int? SerialTracked,
		string SerialPrefix,
		string CostType,
		string PSite,
		int? PreassignLots,
		int? PreassignSerials)
		{
			LotPrefixType _LotPrefix = LotPrefix;
			ListYesNoType _LotTracked = LotTracked;
			ListLocLotType _IssueBy = IssueBy;
			ListYesNoType _SerialTracked = SerialTracked;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			CostTypeType _CostType = CostType;
			SiteType _PSite = PSite;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemExtraInitSp";
				
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IssueBy", _IssueBy, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LotPrefix = _LotPrefix;
				LotTracked = _LotTracked;
				IssueBy = _IssueBy;
				SerialTracked = _SerialTracked;
				SerialPrefix = _SerialPrefix;
				CostType = _CostType;
				PreassignLots = _PreassignLots;
				PreassignSerials = _PreassignSerials;
				
				return (Severity, LotPrefix, LotTracked, IssueBy, SerialTracked, SerialPrefix, CostType, PreassignLots, PreassignSerials);
			}
		}
	}
}
