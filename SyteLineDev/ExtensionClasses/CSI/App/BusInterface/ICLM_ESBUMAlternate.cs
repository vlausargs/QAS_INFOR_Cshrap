//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBUMAlternate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBUMAlternate
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ESBUMAlternateSp(
			string item);
	}
}

