//PROJECT NAME: Production
//CLASS NAME: SaveBomIBJobmatl.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production
{
	public class SaveBomIBJobmatl : ISaveBomIBJobmatl
	{
		readonly IApplicationDB appDB;
		
		
		public SaveBomIBJobmatl(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int? SaveBomIBJobmatlSp(Guid? ProcessId,
		string Job,
		int? Suffix,
		int? OperNum,
		int? Sequence,
		int? Create,
		int? BomSeq,
		string Item,
		string ItemDescription,
		string Revision,
		string ProductCode,
		decimal? MatlQty,
		string UM,
		string Units,
		string PMTCode,
		string MatlType)
		{
			RowPointerType _ProcessId = ProcessId;
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			JobmatlSequenceType _Sequence = Sequence;
			FlagNyType _Create = Create;
			EcnBomSeqType _BomSeq = BomSeq;
			ItemType _Item = Item;
			DescriptionType _ItemDescription = ItemDescription;
			RevisionType _Revision = Revision;
			ProductCodeType _ProductCode = ProductCode;
			QtyPerType _MatlQty = MatlQty;
			UMType _UM = UM;
			JobmatlUnitsType _Units = Units;
			PMTCodeType _PMTCode = PMTCode;
			MatlTypeType _MatlType = MatlType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SaveBomIBJobmatlSp";
				
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Create", _Create, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BomSeq", _BomSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemDescription", _ItemDescription, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlQty", _MatlQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Units", _Units, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				return (Severity);
			}
		}
	}
}
