//PROJECT NAME: Material
//CLASS NAME: GetAttributeLabels.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetAttributeLabels : IGetAttributeLabels
	{
		readonly IApplicationDB appDB;
		
		
		public GetAttributeLabels(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string PDeciAttr1Label,
		string PDeciAttr2Label,
		string PDeciAttr3Label,
		string PDeciAttr4Label,
		string PDeciAttr5Label,
		string PDeciAttr6Label,
		string PDeciAttr7Label,
		string PDeciAttr8Label,
		string PDeciAttr9Label,
		string PDeciAttr10Label,
		string PCharAttr1Label,
		string PCharAttr2Label,
		string PCharAttr3Label,
		string PCharAttr4Label,
		string PCharAttr5Label,
		string PCharAttr6Label,
		string PCharAttr7Label,
		string PCharAttr8Label,
		string PCharAttr9Label,
		string PCharAttr10Label,
		string PLogiAttrLabel) GetAttributeLabelsSp(string PAttrGroupClass = null,
		string PAttrGroup = null,
		string PDeciAttr1Label = null,
		string PDeciAttr2Label = null,
		string PDeciAttr3Label = null,
		string PDeciAttr4Label = null,
		string PDeciAttr5Label = null,
		string PDeciAttr6Label = null,
		string PDeciAttr7Label = null,
		string PDeciAttr8Label = null,
		string PDeciAttr9Label = null,
		string PDeciAttr10Label = null,
		string PCharAttr1Label = null,
		string PCharAttr2Label = null,
		string PCharAttr3Label = null,
		string PCharAttr4Label = null,
		string PCharAttr5Label = null,
		string PCharAttr6Label = null,
		string PCharAttr7Label = null,
		string PCharAttr8Label = null,
		string PCharAttr9Label = null,
		string PCharAttr10Label = null,
		string PLogiAttrLabel = null,
		string PSiteRef = null)
		{
			AttributeGroupClassType _PAttrGroupClass = PAttrGroupClass;
			AttributeGroupType _PAttrGroup = PAttrGroup;
			AttributeLabelType _PDeciAttr1Label = PDeciAttr1Label;
			AttributeLabelType _PDeciAttr2Label = PDeciAttr2Label;
			AttributeLabelType _PDeciAttr3Label = PDeciAttr3Label;
			AttributeLabelType _PDeciAttr4Label = PDeciAttr4Label;
			AttributeLabelType _PDeciAttr5Label = PDeciAttr5Label;
			AttributeLabelType _PDeciAttr6Label = PDeciAttr6Label;
			AttributeLabelType _PDeciAttr7Label = PDeciAttr7Label;
			AttributeLabelType _PDeciAttr8Label = PDeciAttr8Label;
			AttributeLabelType _PDeciAttr9Label = PDeciAttr9Label;
			AttributeLabelType _PDeciAttr10Label = PDeciAttr10Label;
			AttributeLabelType _PCharAttr1Label = PCharAttr1Label;
			AttributeLabelType _PCharAttr2Label = PCharAttr2Label;
			AttributeLabelType _PCharAttr3Label = PCharAttr3Label;
			AttributeLabelType _PCharAttr4Label = PCharAttr4Label;
			AttributeLabelType _PCharAttr5Label = PCharAttr5Label;
			AttributeLabelType _PCharAttr6Label = PCharAttr6Label;
			AttributeLabelType _PCharAttr7Label = PCharAttr7Label;
			AttributeLabelType _PCharAttr8Label = PCharAttr8Label;
			AttributeLabelType _PCharAttr9Label = PCharAttr9Label;
			AttributeLabelType _PCharAttr10Label = PCharAttr10Label;
			AttributeLabelType _PLogiAttrLabel = PLogiAttrLabel;
			SiteType _PSiteRef = PSiteRef;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetAttributeLabelsSp";
				
				appDB.AddCommandParameter(cmd, "PAttrGroupClass", _PAttrGroupClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAttrGroup", _PAttrGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDeciAttr1Label", _PDeciAttr1Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr2Label", _PDeciAttr2Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr3Label", _PDeciAttr3Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr4Label", _PDeciAttr4Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr5Label", _PDeciAttr5Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr6Label", _PDeciAttr6Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr7Label", _PDeciAttr7Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr8Label", _PDeciAttr8Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr9Label", _PDeciAttr9Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PDeciAttr10Label", _PDeciAttr10Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr1Label", _PCharAttr1Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr2Label", _PCharAttr2Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr3Label", _PCharAttr3Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr4Label", _PCharAttr4Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr5Label", _PCharAttr5Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr6Label", _PCharAttr6Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr7Label", _PCharAttr7Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr8Label", _PCharAttr8Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr9Label", _PCharAttr9Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCharAttr10Label", _PCharAttr10Label, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PLogiAttrLabel", _PLogiAttrLabel, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSiteRef", _PSiteRef, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				PDeciAttr1Label = _PDeciAttr1Label;
				PDeciAttr2Label = _PDeciAttr2Label;
				PDeciAttr3Label = _PDeciAttr3Label;
				PDeciAttr4Label = _PDeciAttr4Label;
				PDeciAttr5Label = _PDeciAttr5Label;
				PDeciAttr6Label = _PDeciAttr6Label;
				PDeciAttr7Label = _PDeciAttr7Label;
				PDeciAttr8Label = _PDeciAttr8Label;
				PDeciAttr9Label = _PDeciAttr9Label;
				PDeciAttr10Label = _PDeciAttr10Label;
				PCharAttr1Label = _PCharAttr1Label;
				PCharAttr2Label = _PCharAttr2Label;
				PCharAttr3Label = _PCharAttr3Label;
				PCharAttr4Label = _PCharAttr4Label;
				PCharAttr5Label = _PCharAttr5Label;
				PCharAttr6Label = _PCharAttr6Label;
				PCharAttr7Label = _PCharAttr7Label;
				PCharAttr8Label = _PCharAttr8Label;
				PCharAttr9Label = _PCharAttr9Label;
				PCharAttr10Label = _PCharAttr10Label;
				PLogiAttrLabel = _PLogiAttrLabel;
				
				return (Severity, PDeciAttr1Label, PDeciAttr2Label, PDeciAttr3Label, PDeciAttr4Label, PDeciAttr5Label, PDeciAttr6Label, PDeciAttr7Label, PDeciAttr8Label, PDeciAttr9Label, PDeciAttr10Label, PCharAttr1Label, PCharAttr2Label, PCharAttr3Label, PCharAttr4Label, PCharAttr5Label, PCharAttr6Label, PCharAttr7Label, PCharAttr8Label, PCharAttr9Label, PCharAttr10Label, PLogiAttrLabel);
			}
		}
	}
}
