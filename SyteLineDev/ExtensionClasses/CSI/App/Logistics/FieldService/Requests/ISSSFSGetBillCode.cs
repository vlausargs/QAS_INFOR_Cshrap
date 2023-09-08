//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetBillCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSGetBillCode
	{
		(int? ReturnCode, string OBillCode,
		string Prompt,
		string PromptButtons,
		string Infobar) SSSFSGetBillCodeSp(string Table,
		string ISroNum,
		int? ISroLine,
		int? ISroOper,
		DateTime? TransDate,
		DateTime? LineExchDate,
		string OBillCode,
		string Prompt,
		string PromptButtons,
		string Infobar);
	}
}

