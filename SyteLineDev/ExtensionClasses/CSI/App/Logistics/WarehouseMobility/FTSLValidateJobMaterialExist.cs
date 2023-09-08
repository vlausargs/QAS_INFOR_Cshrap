//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidateJobMaterialExist.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLValidateJobMaterialExist
	{
		(int? ReturnCode, string MaterialDesc,
		decimal? Sequence,
		string UM,
		byte? LotTracked,
		byte? SerialTracked,
		decimal? QtyRequired,
		decimal? QtyIssued,
		decimal? MaterialCost,
		byte? JobmatlNotExists,
		byte? ItemNotExists,
		byte? TaxFreeMatl,
		string ImportDocId,
		string InfoBar) FTSLValidateJobMaterialExistSp(string Job,
		short? Suffix,
		int? OperNum,
		string Material,
		byte? AllowNonBomItems = (byte)0,
		byte? AllowNonInvItems = (byte)0,
		byte? AdjustForScrap = (byte)0,
		string MaterialDesc = null,
		decimal? Sequence = null,
		string UM = null,
		byte? LotTracked = null,
		byte? SerialTracked = null,
		decimal? QtyRequired = null,
		decimal? QtyIssued = null,
		decimal? MaterialCost = null,
		byte? JobmatlNotExists = null,
		byte? ItemNotExists = null,
		byte? TaxFreeMatl = null,
		string ImportDocId = null,
		string InfoBar = null);
	}
	
	public class FTSLValidateJobMaterialExist : IFTSLValidateJobMaterialExist
	{
		readonly IApplicationDB appDB;
		
		public FTSLValidateJobMaterialExist(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string MaterialDesc,
		decimal? Sequence,
		string UM,
		byte? LotTracked,
		byte? SerialTracked,
		decimal? QtyRequired,
		decimal? QtyIssued,
		decimal? MaterialCost,
		byte? JobmatlNotExists,
		byte? ItemNotExists,
		byte? TaxFreeMatl,
		string ImportDocId,
		string InfoBar) FTSLValidateJobMaterialExistSp(string Job,
		short? Suffix,
		int? OperNum,
		string Material,
		byte? AllowNonBomItems = (byte)0,
		byte? AllowNonInvItems = (byte)0,
		byte? AdjustForScrap = (byte)0,
		string MaterialDesc = null,
		decimal? Sequence = null,
		string UM = null,
		byte? LotTracked = null,
		byte? SerialTracked = null,
		decimal? QtyRequired = null,
		decimal? QtyIssued = null,
		decimal? MaterialCost = null,
		byte? JobmatlNotExists = null,
		byte? ItemNotExists = null,
		byte? TaxFreeMatl = null,
		string ImportDocId = null,
		string InfoBar = null)
		{
			JobType _Job = Job;
			SuffixType _Suffix = Suffix;
			OperNumType _OperNum = OperNum;
			ItemType _Material = Material;
			ListYesNoType _AllowNonBomItems = AllowNonBomItems;
			ListYesNoType _AllowNonInvItems = AllowNonInvItems;
			ListYesNoType _AdjustForScrap = AdjustForScrap;
			DescriptionType _MaterialDesc = MaterialDesc;
			SequenceType _Sequence = Sequence;
			UMType _UM = UM;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _SerialTracked = SerialTracked;
			QtyPerType _QtyRequired = QtyRequired;
			QtyPerType _QtyIssued = QtyIssued;
			CostPrcType _MaterialCost = MaterialCost;
			ListYesNoType _JobmatlNotExists = JobmatlNotExists;
			ListYesNoType _ItemNotExists = ItemNotExists;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			ImportDocIdType _ImportDocId = ImportDocId;
			InfobarType _InfoBar = InfoBar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTSLValidateJobMaterialExistSp";
				
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OperNum", _OperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Material", _Material, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowNonBomItems", _AllowNonBomItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowNonInvItems", _AllowNonInvItems, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AdjustForScrap", _AdjustForScrap, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MaterialDesc", _MaterialDesc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Sequence", _Sequence, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyRequired", _QtyRequired, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "QtyIssued", _QtyIssued, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MaterialCost", _MaterialCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobmatlNotExists", _JobmatlNotExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemNotExists", _ItemNotExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ImportDocId", _ImportDocId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfoBar", _InfoBar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				MaterialDesc = _MaterialDesc;
				Sequence = _Sequence;
				UM = _UM;
				LotTracked = _LotTracked;
				SerialTracked = _SerialTracked;
				QtyRequired = _QtyRequired;
				QtyIssued = _QtyIssued;
				MaterialCost = _MaterialCost;
				JobmatlNotExists = _JobmatlNotExists;
				ItemNotExists = _ItemNotExists;
				TaxFreeMatl = _TaxFreeMatl;
				ImportDocId = _ImportDocId;
				InfoBar = _InfoBar;
				
				return (Severity, MaterialDesc, Sequence, UM, LotTracked, SerialTracked, QtyRequired, QtyIssued, MaterialCost, JobmatlNotExists, ItemNotExists, TaxFreeMatl, ImportDocId, InfoBar);
			}
		}
	}
}
