//PROJECT NAME: BusInterface
//CLASS NAME: IESBInventoryCountCreation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface IESBInventoryCountCreation
	{
		int? ESBInventoryCountCreationSp(
			string Item,
			string Whse,
			string loc,
			string lot,
			decimal? CountSequence,
			int? UpdateItemWhse);
	}
}

