//PROJECT NAME: Material
//CLASS NAME: IGetAttributeLabels.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetAttributeLabels
	{
		(int? ReturnCode, string PDeciAttr1Label,
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
		string PSiteRef = null);
	}
}

