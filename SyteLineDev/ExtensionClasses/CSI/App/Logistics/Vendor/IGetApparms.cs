//PROJECT NAME: Logistics
//CLASS NAME: IGetApparms.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetApparms
	{
		(int? ReturnCode, string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice) GetApparmsSp(string PEFTBankCode,
		string PEFTFormat,
		string PEFTUserName,
		string PEFTUserNumber,
		int? PPrintManualRemitAdvice,
		int? PPrintEFTRemitAdvice,
		int? PPrintWireRemitAdvice,
		int? PPrintDraftRemitAdvice);
	}
}

