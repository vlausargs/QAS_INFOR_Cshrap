//PROJECT NAME: Material
//CLASS NAME: ICombineXferDateValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICombineXferDateValid
	{
		(int? ReturnCode, string Infobar,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2) CombineXferDateValidSp(string FromSite,
		string ToSite,
		DateTime? InDate,
		string Infobar,
		string PromptMsg1,
		string PromptButtons1,
		string PromptMsg2,
		string PromptButtons2);
	}
}

