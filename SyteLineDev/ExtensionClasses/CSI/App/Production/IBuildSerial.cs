//PROJECT NAME: Production
//CLASS NAME: IBuildSerial.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBuildSerial
	{
		(int? ReturnCode, string Infobar) BuildSerialSp(decimal? TransNum,
		string Infobar,
		string ContainerNum = null,
		DateTime? ManufacturedDate = null);
	}
}

