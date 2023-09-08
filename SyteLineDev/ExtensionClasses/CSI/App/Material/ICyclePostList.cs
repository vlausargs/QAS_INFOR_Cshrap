//PROJECT NAME: Material
//CLASS NAME: ICyclePostList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICyclePostList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CyclePostListSp(string Whse,
		int? Counter);
	}
}

