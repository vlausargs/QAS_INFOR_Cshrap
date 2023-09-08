//PROJECT NAME: Logistics
//CLASS NAME: IInsertSignatureWrap.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface IInsertSignatureWrap
	{
		(int? ReturnCode, string Infobar) InsertSignatureWrapSp(byte[] Signature,
		string RefType,
		string RefNum,
		int? RefLineSuf,
		int? RefRelease,
		DateTime? SignatureDate,
		string Infobar,
		decimal? Latitude = 0,
		decimal? Longitude = 0);
	}
}

