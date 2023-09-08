//PROJECT NAME: CSIDataCollection
//CLASS NAME: DcsfcJobValid.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public interface IDcsfcJobValid
	{
		(int? ReturnCode, string OutJobWhse, string JobItem, byte? CoProdMix, byte? ItemLotTracked, byte? ItemSerialTracked, byte? CntrlPoint, string Wc, byte? OperComplete, string Infobar, byte? ItemTrackECN) DcsfcJobValidSp(byte? IsNew,
		string InJob,
		short? InSuffix,
		int? InOperNum,
		string TransType,
		int? TransNum,
		string OutJobWhse,
		string JobItem,
		byte? CoProdMix,
		byte? ItemLotTracked,
		byte? ItemSerialTracked,
		byte? CntrlPoint,
		string Wc,
		byte? OperComplete,
		string Infobar,
		byte? ItemTrackECN = null);
	}
	
	public class DcsfcJobValid : IDcsfcJobValid
	{
		readonly IApplicationDB appDB;
		
		public DcsfcJobValid(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutJobWhse, string JobItem, byte? CoProdMix, byte? ItemLotTracked, byte? ItemSerialTracked, byte? CntrlPoint, string Wc, byte? OperComplete, string Infobar, byte? ItemTrackECN) DcsfcJobValidSp(byte? IsNew,
		string InJob,
		short? InSuffix,
		int? InOperNum,
		string TransType,
		int? TransNum,
		string OutJobWhse,
		string JobItem,
		byte? CoProdMix,
		byte? ItemLotTracked,
		byte? ItemSerialTracked,
		byte? CntrlPoint,
		string Wc,
		byte? OperComplete,
		string Infobar,
		byte? ItemTrackECN = null)
		{
			ListYesNoType _IsNew = IsNew;
			JobType _InJob = InJob;
			SuffixType _InSuffix = InSuffix;
			OperNumType _InOperNum = InOperNum;
			DcsfcTransTypeType _TransType = TransType;
			DcTransNumType _TransNum = TransNum;
			WhseType _OutJobWhse = OutJobWhse;
			ItemType _JobItem = JobItem;
			ListYesNoType _CoProdMix = CoProdMix;
			ListYesNoType _ItemLotTracked = ItemLotTracked;
			ListYesNoType _ItemSerialTracked = ItemSerialTracked;
			ListYesNoType _CntrlPoint = CntrlPoint;
			WcType _Wc = Wc;
			ListYesNoType _OperComplete = OperComplete;
			InfobarType _Infobar = Infobar;
			ListYesNoType _ItemTrackECN = ItemTrackECN;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcsfcJobValidSp";
				
				appDB.AddCommandParameter(cmd, "IsNew", _IsNew, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InOperNum", _InOperNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransType", _TransType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransNum", _TransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutJobWhse", _OutJobWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "JobItem", _JobItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoProdMix", _CoProdMix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemLotTracked", _ItemLotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemSerialTracked", _ItemSerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CntrlPoint", _CntrlPoint, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Wc", _Wc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OperComplete", _OperComplete, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemTrackECN", _ItemTrackECN, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutJobWhse = _OutJobWhse;
				JobItem = _JobItem;
				CoProdMix = _CoProdMix;
				ItemLotTracked = _ItemLotTracked;
				ItemSerialTracked = _ItemSerialTracked;
				CntrlPoint = _CntrlPoint;
				Wc = _Wc;
				OperComplete = _OperComplete;
				Infobar = _Infobar;
				ItemTrackECN = _ItemTrackECN;
				
				return (Severity, OutJobWhse, JobItem, CoProdMix, ItemLotTracked, ItemSerialTracked, CntrlPoint, Wc, OperComplete, Infobar, ItemTrackECN);
			}
		}
	}
}
