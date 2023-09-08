//PROJECT NAME: CSIProduct
//CLASS NAME: ItemChgRate.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public interface IItemChgRate
	{
		(int? ReturnCode, string Infobar) ItemChgRateSp(string JobType,
		byte? UpdFixMatlOvhd,
		byte? UpdVarMatlOvhd,
		byte? UpdFixedOvhd,
		byte? UpdVarOvhd,
		byte? UpdSetupRate,
		byte? UpdEfficiency,
		byte? UpdRunRate,
		byte? UpdFixMachRate,
		byte? UpdVarMachRate,
		string FromJob,
		string ToJob,
		short? FromSuffix,
		short? ToSuffix,
		string FromItem,
		string ToItem,
		string FromProductCode,
		string ToProductCode,
		string FromWc,
		string ToWc,
		string FromDept,
		string ToDept,
		string FromPsNum,
		string ToPsNum,
		string Infobar,
		string FromCostingAlt = null,
		string ToCostingAlt = null,
		string FromBOMAlternateID = null,
		string ToBOMAlternateID = null);
	}
	
	public class ItemChgRate : IItemChgRate
	{
		readonly IApplicationDB appDB;
		
		public ItemChgRate(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemChgRateSp(string JobType,
		byte? UpdFixMatlOvhd,
		byte? UpdVarMatlOvhd,
		byte? UpdFixedOvhd,
		byte? UpdVarOvhd,
		byte? UpdSetupRate,
		byte? UpdEfficiency,
		byte? UpdRunRate,
		byte? UpdFixMachRate,
		byte? UpdVarMachRate,
		string FromJob,
		string ToJob,
		short? FromSuffix,
		short? ToSuffix,
		string FromItem,
		string ToItem,
		string FromProductCode,
		string ToProductCode,
		string FromWc,
		string ToWc,
		string FromDept,
		string ToDept,
		string FromPsNum,
		string ToPsNum,
		string Infobar,
		string FromCostingAlt = null,
		string ToCostingAlt = null,
		string FromBOMAlternateID = null,
		string ToBOMAlternateID = null)
		{
			StringType _JobType = JobType;
			ListYesNoType _UpdFixMatlOvhd = UpdFixMatlOvhd;
			ListYesNoType _UpdVarMatlOvhd = UpdVarMatlOvhd;
			ListYesNoType _UpdFixedOvhd = UpdFixedOvhd;
			ListYesNoType _UpdVarOvhd = UpdVarOvhd;
			ListYesNoType _UpdSetupRate = UpdSetupRate;
			ListYesNoType _UpdEfficiency = UpdEfficiency;
			ListYesNoType _UpdRunRate = UpdRunRate;
			ListYesNoType _UpdFixMachRate = UpdFixMachRate;
			ListYesNoType _UpdVarMachRate = UpdVarMachRate;
			JobType _FromJob = FromJob;
			JobType _ToJob = ToJob;
			SuffixType _FromSuffix = FromSuffix;
			SuffixType _ToSuffix = ToSuffix;
			ItemType _FromItem = FromItem;
			ItemType _ToItem = ToItem;
			ProductCodeType _FromProductCode = FromProductCode;
			ProductCodeType _ToProductCode = ToProductCode;
			WcType _FromWc = FromWc;
			WcType _ToWc = ToWc;
			DeptType _FromDept = FromDept;
			DeptType _ToDept = ToDept;
			PsNumType _FromPsNum = FromPsNum;
			PsNumType _ToPsNum = ToPsNum;
			InfobarType _Infobar = Infobar;
			CostingAlternativeType _FromCostingAlt = FromCostingAlt;
			CostingAlternativeType _ToCostingAlt = ToCostingAlt;
			MO_BOMAlternateType _FromBOMAlternateID = FromBOMAlternateID;
			MO_BOMAlternateType _ToBOMAlternateID = ToBOMAlternateID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemChgRateSp";
				
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdFixMatlOvhd", _UpdFixMatlOvhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdVarMatlOvhd", _UpdVarMatlOvhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdFixedOvhd", _UpdFixedOvhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdVarOvhd", _UpdVarOvhd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdSetupRate", _UpdSetupRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdEfficiency", _UpdEfficiency, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdRunRate", _UpdRunRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdFixMachRate", _UpdFixMachRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdVarMachRate", _UpdVarMachRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromJob", _FromJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToJob", _ToJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSuffix", _FromSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSuffix", _ToSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToItem", _ToItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromProductCode", _FromProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToProductCode", _ToProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromWc", _FromWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToWc", _ToWc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromDept", _FromDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToDept", _ToDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromPsNum", _FromPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToPsNum", _ToPsNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromCostingAlt", _FromCostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToCostingAlt", _ToCostingAlt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromBOMAlternateID", _FromBOMAlternateID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToBOMAlternateID", _ToBOMAlternateID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
