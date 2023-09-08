//PROJECT NAME: Data
//CLASS NAME: IApp_ResetDocObjReferenceTableRP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IApp_ResetDocObjReferenceTableRP
	{
		(int? ReturnCode,
			string Infobar) App_ResetDocObjReferenceTableRPSp(
			string SourceServer,
			string SourceDB,
			string SourceSite,
			int? AnalyzeOnly = 1,
			string Infobar = null);
	}
}

