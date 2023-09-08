//PROJECT NAME: Logistics
//CLASS NAME: IGetArparmLinesPerDoc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetArparmLinesPerDoc
	{
		(int? ReturnCode, int? PArparmUsePrePrintedForms,
		int? PArparmLinesPerInv,
		int? PArparmLinesPerDM,
		int? PArparmLinesPerCM) GetArparmLinesPerDocSp(int? PArparmUsePrePrintedForms,
		int? PArparmLinesPerInv,
		int? PArparmLinesPerDM,
		int? PArparmLinesPerCM);
	}
}

