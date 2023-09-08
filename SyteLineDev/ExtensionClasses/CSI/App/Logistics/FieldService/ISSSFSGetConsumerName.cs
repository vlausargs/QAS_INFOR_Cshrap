//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetConsumerName.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetConsumerName
	{
		string SSSFSGetConsumerNameFn(
			string UsrNum,
			int? UsrSeq);
	}
}

