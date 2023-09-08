//PROJECT NAME: Production
//CLASS NAME: IInsertOverrideForJobTranPieces.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IInsertOverrideForJobTranPieces
	{
		(int? ReturnCode, string Infobar) InsertOverrideForJobTranPiecesSp(decimal? TransNum,
		int? PieceCount,
		int? CompletedPieceCount,
		string Item,
		decimal? DeciDimension1,
		decimal? DeciDimension2,
		decimal? DeciDimension3,
		decimal? DeciDimension4,
		decimal? DeciDimension5,
		decimal? DeciDimension6,
		decimal? DeciDimension7,
		decimal? DeciDimension8,
		decimal? DeciDimension9,
		decimal? DeciDimension10,
		string CharDimension1,
		string CharDimension2,
		string CharDimension3,
		string CharDimension4,
		string CharDimension5,
		string CharDimension6,
		string CharDimension7,
		string CharDimension8,
		string CharDimension9,
		string CharDimension10,
		int? LogiDimension,
		Guid? JobTranPieceRowPointer,
		string Infobar,
		Guid? JobtranRowPointer = null);
	}
}

