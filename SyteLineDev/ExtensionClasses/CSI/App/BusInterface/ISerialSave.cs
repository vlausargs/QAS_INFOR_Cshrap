//PROJECT NAME: BusInterface
//CLASS NAME: ISerialSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ISerialSave
	{
		(int? ReturnCode, string Infobar) SerialSaveSp(string SerNum,
		Guid? TmpSerId = null,
		string RefStr = null,
		string Infobar = null,
		DateTime? ManufacturedDate = null,
		DateTime? ExpirationDate = null,
		string TrxRestrictCode = null);
	}
}

