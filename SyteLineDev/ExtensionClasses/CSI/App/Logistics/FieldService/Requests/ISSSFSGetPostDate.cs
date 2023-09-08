//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetPostDate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSGetPostDate
	{
		(int? ReturnCode, DateTime? TransDate,
		DateTime? PostDate,
		string Prompt,
		string PromptButtons,
		string Infobar) SSSFSGetPostDateSp(DateTime? TransDate,
		DateTime? PostDate,
		int? Error,
		string Prompt,
		string PromptButtons,
		string Infobar);
	}
}

