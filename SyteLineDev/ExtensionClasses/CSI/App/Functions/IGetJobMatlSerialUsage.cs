//PROJECT NAME: Data
//CLASS NAME: IGetJobMatlSerialUsage.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetJobMatlSerialUsage
	{
		ICollectionLoadResponse GetJobMatlSerialUsageFn(
			string Job,
			int? Suffix,
			int? OperNum,
			string EndItem,
			string EndItemSerial,
			string JobMatlItem,
			string JobMatlSerial);
	}
}

