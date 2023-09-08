//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSGetUseConsumer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSGetUseConsumer
	{
		(int? ReturnCode, int? UseCons) SSSFSGetUseConsumerSp(
			int? UseCons);

		int? SSSFSGetUseConsumerFn();
	}
}

