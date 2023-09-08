//PROJECT NAME: Production
//CLASS NAME: IRevMsPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMsPost
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RevMsPostSp(string Process,
		string FromProjNum,
		string ToProjNum,
		string FromRevMsNum,
		string ToRevMsNum,
		int? MsPeriod,
		int? MsYear,
		DateTime? PostDate,
		string PrintLevel,
		string PostLevel);
	}
}

