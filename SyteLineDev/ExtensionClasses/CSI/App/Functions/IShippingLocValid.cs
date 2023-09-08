//PROJECT NAME: Data
//CLASS NAME: IShippingLocValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IShippingLocValid
	{
		(int? ReturnCode,
			int? ItemLocQuestionAsked,
			string PromptMsg,
			string PromptButtons,
			string Infobar) ShippingLocValidSp(
			string Item,
			string Whse,
			string Site,
			string Loc,
			int? ItemLocQuestionAsked,
			string PromptMsg,
			string PromptButtons,
			string Infobar);
	}
}

