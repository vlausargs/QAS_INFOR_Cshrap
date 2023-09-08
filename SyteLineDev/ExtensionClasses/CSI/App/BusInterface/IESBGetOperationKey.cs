//PROJECT NAME: BusInterface
//CLASS NAME: IESBGetOperationKey.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IESBGetOperationKey
	{
		string ESBGetOperationKeyFn(
			string Job,
			int? Suffix,
			int? OperNum);
	}
}

