//PROJECT NAME: Material
//CLASS NAME: ItemCopyData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class ItemCopyData : IItemCopyData
	{
		readonly IApplicationDB appDB;
		
		
		public ItemCopyData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) ItemCopyDataSp(string FromItem,
		string NewItem,
		int? CopyUDF,
		int? CopyLoc,
		int? CopyBOM,
		string CopyBOMType,
		DateTime? EffectDate,
		int? PlanFlag,
		string FeatStr,
		string Process = "C",
		string Infobar = null,
		int? CopyUetValues = 0)
		{
			ItemType _FromItem = FromItem;
			StringType _NewItem = NewItem;
			ListYesNoType _CopyUDF = CopyUDF;
			ListYesNoType _CopyLoc = CopyLoc;
			ListYesNoType _CopyBOM = CopyBOM;
			ShortDescType _CopyBOMType = CopyBOMType;
			DateType _EffectDate = EffectDate;
			ListYesNoType _PlanFlag = PlanFlag;
			FeatStrType _FeatStr = FeatStr;
			StringType _Process = Process;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CopyUetValues = CopyUetValues;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemCopyDataSp";
				
				appDB.AddCommandParameter(cmd, "FromItem", _FromItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewItem", _NewItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyUDF", _CopyUDF, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyLoc", _CopyLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyBOM", _CopyBOM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CopyBOMType", _CopyBOMType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanFlag", _PlanFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Process", _Process, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CopyUetValues", _CopyUetValues, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
