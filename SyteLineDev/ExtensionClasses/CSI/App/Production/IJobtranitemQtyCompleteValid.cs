//PROJECT NAME: Production
//CLASS NAME: IJobtranitemQtyCompleteValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobtranitemQtyCompleteValid
	{
		(int? ReturnCode, string PromptMsg,
		string PromptButtons,
		string Infobar) JobtranitemQtyCompleteValidSp(string Job,
		int? Suffix,
		int? OperNum,
		string JobtranitemItem,
		decimal? QtyComplete,
		string PromptMsg,
		string PromptButtons,
		string Infobar);
	}
}

