//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsUpdIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsUpdIns
	{
		(int? ReturnCode, int? MatlLowLevel,
		string Infobar) CurrentMaterialsUpdInsSp(string Item,
		string JobJob,
		int? JobSuffix,
		string JobType,
		string ItmItem,
		int? ItmLowLevel,
		int? DerMatlExist,
		int? MatlLowLevel,
		string Infobar,
		int? Inserted,
		Guid? OldJobmatlRowPointer = null,
		Guid? NewJobmatlRowPointer = null);
	}
}

