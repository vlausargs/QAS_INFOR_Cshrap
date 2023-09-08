//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSSDHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSSDHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSSDHeaderSp();
	}
}

