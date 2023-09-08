//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBQuoteSubLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBQuoteSubLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBQuoteSubLineSp(string CoitemItem);
	}
}

