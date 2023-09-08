//PROJECT NAME: Production
//CLASS NAME: IPP_CreateMaterialUsageRecords.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_CreateMaterialUsageRecords
	{
		(int? ReturnCode,
			string Infobar) PP_CreateMaterialUsageRecordsSp(
			string Job,
			int? Suffix,
			int? OperNum,
			string Infobar);
	}
}

