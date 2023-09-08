//PROJECT NAME: Production
//CLASS NAME: IProjJmatl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjJmatl
	{
		(int? ReturnCode,
			string Infobar) ProjJmatlSp(
			string ProjNum,
			int? TaskNum,
			int? Seq,
			string ProdcodeUnit,
			Guid? MatltranRowPointer,
			Guid? MatltranAmtRowPointer,
			string ControlPrefix = null,
			string ControlSite = null,
			int? ControlYear = null,
			int? ControlPeriod = null,
			decimal? ControlNumber = null,
			string Infobar = null);
	}
}

