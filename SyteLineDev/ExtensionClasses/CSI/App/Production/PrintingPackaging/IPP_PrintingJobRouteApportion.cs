//PROJECT NAME: Production
//CLASS NAME: IPP_PrintingJobRouteApportion.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_PrintingJobRouteApportion
	{
		(int? ReturnCode,
			string Infobar) PP_PrintingJobRouteApportionSp(
			string Job,
			int? Suffix,
			int? OperNum = null,
			string Infobar = null);
	}
}

