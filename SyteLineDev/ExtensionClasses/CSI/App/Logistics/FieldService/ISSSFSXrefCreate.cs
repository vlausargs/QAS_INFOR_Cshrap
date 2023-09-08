//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSXrefCreate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSXrefCreate
	{
		(int? ReturnCode, string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRelease,
		string Infobar) SSSFSXrefCreateSp(string FromRefType,
		string FromRefNum,
		int? FromRefLineSuf,
		int? FromRefRelease,
		int? FromTransNum,
		string ToRefType,
		string ToRefNum,
		int? ToRefLineSuf,
		int? ToRefRelease,
		string CustNum,
		string Item,
		string ItemDescription,
		string UM,
		DateTime? DueDate,
		string Whse,
		string NewRefNum,
		int? NewRefLineSuf,
		int? NewRefRelease,
		string Infobar,
		string FromWhse = null,
		string FromSite = null,
		string ToSite = null,
		int? PoChangeOrd = 1,
		int? MpwxrefDelete = 0,
		int? CreateProj = 0,
		int? CreateProjtask = 0,
		string TrnLoc = null,
		string FOBSite = null,
		int? CustSeq = 0);
	}
}

