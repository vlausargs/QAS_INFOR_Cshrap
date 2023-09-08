//PROJECT NAME: Data
//CLASS NAME: Inter11.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class Inter11 : IInter11
	{
		readonly IApplicationDB appDB;
		
		public Inter11(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? TcSeqReturn) Inter11Sp(
			int? TLevel,
			string TItem,
			string TGroupItem,
			decimal? TQty,
			string TUm,
			string TUnit,
			string TRef,
			string TType,
			DateTime? TEffectiveDate,
			Guid? TRecid,
			int? DisplayRefer,
			int? TcSeq,
			int? TcSeqReturn,
			int? PrintAlternateMaterials = null,
			int? IncludeRevision = 0,
			string TcItemJob = null,
			int? AltGroup = null,
			int? AltGroupRank = null)
		{
			IntType _TLevel = TLevel;
			ItemType _TItem = TItem;
			ItemType _TGroupItem = TGroupItem;
			QtyPerType _TQty = TQty;
			UMType _TUm = TUm;
			StringType _TUnit = TUnit;
			RefTypeIJKPRTType _TRef = TRef;
			StringType _TType = TType;
			DateType _TEffectiveDate = TEffectiveDate;
			RowPointerType _TRecid = TRecid;
			FlagNyType _DisplayRefer = DisplayRefer;
			IntType _TcSeq = TcSeq;
			IntType _TcSeqReturn = TcSeqReturn;
			FlagNyType _PrintAlternateMaterials = PrintAlternateMaterials;
			ListYesNoType _IncludeRevision = IncludeRevision;
			JobType _TcItemJob = TcItemJob;
			JobmatlSequenceType _AltGroup = AltGroup;
			JobmatlRankType _AltGroupRank = AltGroupRank;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Inter11Sp";
				
				appDB.AddCommandParameter(cmd, "TLevel", _TLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TItem", _TItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TGroupItem", _TGroupItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TQty", _TQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUm", _TUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TUnit", _TUnit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRef", _TRef, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TType", _TType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEffectiveDate", _TEffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TRecid", _TRecid, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayRefer", _DisplayRefer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcSeq", _TcSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcSeqReturn", _TcSeqReturn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PrintAlternateMaterials", _PrintAlternateMaterials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeRevision", _IncludeRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TcItemJob", _TcItemJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltGroup", _AltGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltGroupRank", _AltGroupRank, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				TcSeqReturn = _TcSeqReturn;
				
				return (Severity, TcSeqReturn);
			}
		}
	}
}
