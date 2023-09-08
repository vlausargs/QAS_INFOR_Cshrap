//PROJECT NAME: Logistics
//CLASS NAME: IValidateArtranInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IValidateArtranInvNum
	{
		(int? ReturnCode, string DerInvNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar) ValidateArtranInvNumSp(Guid? RowPointer,
		int? Filter,
		string ArtranType,
		string CustNum,
		string InvNum,
		int? InvSeq,
		int? CheckSeq,
		string PayType,
		string DerInvNum,
		string PromptMsg,
		string PromptButtons,
		string Infobar,
		string ApplyToInvNum);
	}
}

