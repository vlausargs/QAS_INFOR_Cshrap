//PROJECT NAME: Data
//CLASS NAME: GetTaxParms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class GetTaxParms : IGetTaxParms
	{
		readonly IApplicationDB appDB;
		
		public GetTaxParms(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? Tax_Enabled,
			string Tax_DefTaxCode,
			string Tax_TaxCodeLabel,
			string Tax_TaxIdLabel,
			int? Tax_PromptOnLine,
			string Tax_TaxMode,
			string Tax_TaxAmtLabel,
			string Tax_TaxAmtAccumLabel,
			string Tax_TaxItemLabel,
			int? Tax_ActiveForPurch,
			string Tax_TaxIdPromptLoc,
			string Tax_DefItemTaxCode,
			string Tax_DefMiscTaxCode,
			string Tax_DefFrtTaxCode,
			string Tax_TaxCodeDescLabel,
			string Tax_TaxItemDescLabel,
			string Tax_FrtCodeLabel,
			string Tax_FrtCodeDescLabel,
			string Tax_MiscCodeLabel,
			string Tax_MiscCodeDescLabel,
			string Infobar) GetTaxParmsSp(
			int? TaxSystem,
			int? Tax_Enabled,
			string Tax_DefTaxCode,
			string Tax_TaxCodeLabel,
			string Tax_TaxIdLabel,
			int? Tax_PromptOnLine,
			string Tax_TaxMode,
			string Tax_TaxAmtLabel,
			string Tax_TaxAmtAccumLabel,
			string Tax_TaxItemLabel,
			int? Tax_ActiveForPurch,
			string Tax_TaxIdPromptLoc,
			string Tax_DefItemTaxCode,
			string Tax_DefMiscTaxCode,
			string Tax_DefFrtTaxCode,
			string Tax_TaxCodeDescLabel,
			string Tax_TaxItemDescLabel,
			string Tax_FrtCodeLabel,
			string Tax_FrtCodeDescLabel,
			string Tax_MiscCodeLabel,
			string Tax_MiscCodeDescLabel,
			string Infobar)
		{
			TaxSystemType _TaxSystem = TaxSystem;
			ListYesNoType _Tax_Enabled = Tax_Enabled;
			TaxCodeType _Tax_DefTaxCode = Tax_DefTaxCode;
			TaxCodeLabelType _Tax_TaxCodeLabel = Tax_TaxCodeLabel;
			TaxCodeLabelType _Tax_TaxIdLabel = Tax_TaxIdLabel;
			ListYesNoType _Tax_PromptOnLine = Tax_PromptOnLine;
			TaxModeType _Tax_TaxMode = Tax_TaxMode;
			TaxCodeLabelType _Tax_TaxAmtLabel = Tax_TaxAmtLabel;
			LabelType _Tax_TaxAmtAccumLabel = Tax_TaxAmtAccumLabel;
			TaxCodeLabelType _Tax_TaxItemLabel = Tax_TaxItemLabel;
			ListYesNoType _Tax_ActiveForPurch = Tax_ActiveForPurch;
			TaxIdPromptType _Tax_TaxIdPromptLoc = Tax_TaxIdPromptLoc;
			TaxCodeType _Tax_DefItemTaxCode = Tax_DefItemTaxCode;
			TaxCodeType _Tax_DefMiscTaxCode = Tax_DefMiscTaxCode;
			TaxCodeType _Tax_DefFrtTaxCode = Tax_DefFrtTaxCode;
			LabelType _Tax_TaxCodeDescLabel = Tax_TaxCodeDescLabel;
			LabelType _Tax_TaxItemDescLabel = Tax_TaxItemDescLabel;
			TaxCodeLabelType _Tax_FrtCodeLabel = Tax_FrtCodeLabel;
			LabelType _Tax_FrtCodeDescLabel = Tax_FrtCodeDescLabel;
			TaxCodeLabelType _Tax_MiscCodeLabel = Tax_MiscCodeLabel;
			LabelType _Tax_MiscCodeDescLabel = Tax_MiscCodeDescLabel;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTaxParmsSp";
				
				appDB.AddCommandParameter(cmd, "TaxSystem", _TaxSystem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Tax_Enabled", _Tax_Enabled, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_DefTaxCode", _Tax_DefTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxCodeLabel", _Tax_TaxCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxIdLabel", _Tax_TaxIdLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_PromptOnLine", _Tax_PromptOnLine, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxMode", _Tax_TaxMode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxAmtLabel", _Tax_TaxAmtLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxAmtAccumLabel", _Tax_TaxAmtAccumLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxItemLabel", _Tax_TaxItemLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_ActiveForPurch", _Tax_ActiveForPurch, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxIdPromptLoc", _Tax_TaxIdPromptLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_DefItemTaxCode", _Tax_DefItemTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_DefMiscTaxCode", _Tax_DefMiscTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_DefFrtTaxCode", _Tax_DefFrtTaxCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxCodeDescLabel", _Tax_TaxCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_TaxItemDescLabel", _Tax_TaxItemDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_FrtCodeLabel", _Tax_FrtCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_FrtCodeDescLabel", _Tax_FrtCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_MiscCodeLabel", _Tax_MiscCodeLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Tax_MiscCodeDescLabel", _Tax_MiscCodeDescLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Tax_Enabled = _Tax_Enabled;
				Tax_DefTaxCode = _Tax_DefTaxCode;
				Tax_TaxCodeLabel = _Tax_TaxCodeLabel;
				Tax_TaxIdLabel = _Tax_TaxIdLabel;
				Tax_PromptOnLine = _Tax_PromptOnLine;
				Tax_TaxMode = _Tax_TaxMode;
				Tax_TaxAmtLabel = _Tax_TaxAmtLabel;
				Tax_TaxAmtAccumLabel = _Tax_TaxAmtAccumLabel;
				Tax_TaxItemLabel = _Tax_TaxItemLabel;
				Tax_ActiveForPurch = _Tax_ActiveForPurch;
				Tax_TaxIdPromptLoc = _Tax_TaxIdPromptLoc;
				Tax_DefItemTaxCode = _Tax_DefItemTaxCode;
				Tax_DefMiscTaxCode = _Tax_DefMiscTaxCode;
				Tax_DefFrtTaxCode = _Tax_DefFrtTaxCode;
				Tax_TaxCodeDescLabel = _Tax_TaxCodeDescLabel;
				Tax_TaxItemDescLabel = _Tax_TaxItemDescLabel;
				Tax_FrtCodeLabel = _Tax_FrtCodeLabel;
				Tax_FrtCodeDescLabel = _Tax_FrtCodeDescLabel;
				Tax_MiscCodeLabel = _Tax_MiscCodeLabel;
				Tax_MiscCodeDescLabel = _Tax_MiscCodeDescLabel;
				Infobar = _Infobar;
				
				return (Severity, Tax_Enabled, Tax_DefTaxCode, Tax_TaxCodeLabel, Tax_TaxIdLabel, Tax_PromptOnLine, Tax_TaxMode, Tax_TaxAmtLabel, Tax_TaxAmtAccumLabel, Tax_TaxItemLabel, Tax_ActiveForPurch, Tax_TaxIdPromptLoc, Tax_DefItemTaxCode, Tax_DefMiscTaxCode, Tax_DefFrtTaxCode, Tax_TaxCodeDescLabel, Tax_TaxItemDescLabel, Tax_FrtCodeLabel, Tax_FrtCodeDescLabel, Tax_MiscCodeLabel, Tax_MiscCodeDescLabel, Infobar);
			}
		}
	}
}
