//PROJECT NAME: Logistics
//CLASS NAME: ISerialLoad.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISerialLoad
	{
		(ICollectionLoadResponse Data, int? ReturnCode) SerialLoadSp(string SerialLike,
		string TransType,
		string WhseType,
		string Stat,
		int? RestoreLoss = 0,
		int? JmtRETURN = 0,
		string Item = null,
		string Whse = null,
		string Loc = null,
		string Lot = null,
		string DoNum = null,
		int? DoLine = 0,
		string TrnNum = null,
		int? TrnLine = 0,
		decimal? RsvdNum = 0,
		string RefNum = null,
		int? RefLine = 0,
		int? RefRelease = 0,
		string Site = null,
		string ImportDocId = null,
		int? PreassignSerials = null,
		string ContainerNum = null,
		string StartingSerial = null,
		string EndingSerial = null,
		string TrcTrans = null);
	}
}

