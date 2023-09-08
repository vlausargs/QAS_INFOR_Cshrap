//PROJECT NAME: Material
//CLASS NAME: IistkrPostSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IistkrPostSave
	{
		(int? ReturnCode, string Infobar,
		string PromptMsg) istkrPostSaveSp(string PWhseList,
		string PItemList,
		string Infobar,
		string PromptMsg);
	}
}

