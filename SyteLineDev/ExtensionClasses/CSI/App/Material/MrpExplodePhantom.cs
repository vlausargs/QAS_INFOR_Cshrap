//PROJECT NAME: Material
//CLASS NAME: MrpExplodePhantom.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class MrpExplodePhantom : IMrpExplodePhantom
	{
		readonly IApplicationDB appDB;
		
		public MrpExplodePhantom(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) MrpExplodePhantomSp(
			string PhItem,
			decimal? PhGrossQty,
			DateTime? PhDueDate,
			string PhOrderType,
			string PhRefNum,
			int? PhRefSuf,
			string PhParent,
			string PhJob,
			int? PhSuffix,
			decimal? PhOrigQty,
			DateTime? TEffCutoff,
			int? MrpParmScrapFlag,
			Guid? ProcessId,
			string UserMrpPlanningType,
			string Infobar)
		{
			ItemType _PhItem = PhItem;
			QtyUnitType _PhGrossQty = PhGrossQty;
			DateType _PhDueDate = PhDueDate;
			AnyRefTypeType _PhOrderType = PhOrderType;
			MrpOrderType _PhRefNum = PhRefNum;
			AnyRefLineType _PhRefSuf = PhRefSuf;
			LongListType _PhParent = PhParent;
			JobType _PhJob = PhJob;
			SuffixType _PhSuffix = PhSuffix;
			QtyUnitType _PhOrigQty = PhOrigQty;
			DateType _TEffCutoff = TEffCutoff;
			ListYesNoType _MrpParmScrapFlag = MrpParmScrapFlag;
			RowPointerType _ProcessId = ProcessId;
			ListRegenerationNetChangeType _UserMrpPlanningType = UserMrpPlanningType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MrpExplodePhantomSp";
				
				appDB.AddCommandParameter(cmd, "PhItem", _PhItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhGrossQty", _PhGrossQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhDueDate", _PhDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhOrderType", _PhOrderType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhRefNum", _PhRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhRefSuf", _PhRefSuf, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhParent", _PhParent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhJob", _PhJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhSuffix", _PhSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhOrigQty", _PhOrigQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TEffCutoff", _TEffCutoff, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpParmScrapFlag", _MrpParmScrapFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProcessId", _ProcessId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UserMrpPlanningType", _UserMrpPlanningType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
