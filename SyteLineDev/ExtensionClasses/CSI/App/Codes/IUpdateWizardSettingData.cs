//PROJECT NAME: Codes
//CLASS NAME: IUpdateWizardSettingData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface IUpdateWizardSettingData
	{
		(int? ReturnCode, string Infobar) UpdateWizardSettingDataSP(string TableName,
		string RowData,
		string Infobar);
	}
}

