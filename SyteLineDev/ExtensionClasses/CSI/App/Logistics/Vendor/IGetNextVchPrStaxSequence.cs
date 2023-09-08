//PROJECT NAME: Logistics
//CLASS NAME: IGetNextVchPrStaxSequence.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetNextVchPrStaxSequence
	{
		(int? ReturnCode, int? NextSequenceNum,
		string Infobar) GetNextVchPrStaxSequenceSp(int? PreRegisterNum,
		int? NextSequenceNum,
		string Infobar);
	}
}

