//PROJECT NAME: Data
//CLASS NAME: EcnMassI.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EcnMassI : IEcnMassI
	{
		readonly IApplicationDB appDB;
		
		public EcnMassI(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar) EcnMassISp(
			int? CurEcnNum,
			int? CurEcnLine,
			string CurMatl,
			string SubMatl,
			decimal? SubQty,
			string SubUM,
			string Action,
			string UpdateType,
			DateTime? EffectDate,
			string EcnGroup,
			string EcnStat,
			Guid? JobmatlRP,
			Guid? JobRP,
			Guid? ItemRP,
			string Infobar)
		{
			EcnNumType _CurEcnNum = CurEcnNum;
			EcnLineType _CurEcnLine = CurEcnLine;
			ItemType _CurMatl = CurMatl;
			ItemType _SubMatl = SubMatl;
			QtyPerType _SubQty = SubQty;
			UMType _SubUM = SubUM;
			StringType _Action = Action;
			StringType _UpdateType = UpdateType;
			DateType _EffectDate = EffectDate;
			EcnGroupType _EcnGroup = EcnGroup;
			EcnStatusType _EcnStat = EcnStat;
			RowPointerType _JobmatlRP = JobmatlRP;
			RowPointerType _JobRP = JobRP;
			RowPointerType _ItemRP = ItemRP;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcnMassISp";
				
				appDB.AddCommandParameter(cmd, "CurEcnNum", _CurEcnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurEcnLine", _CurEcnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurMatl", _CurMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubMatl", _SubMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubQty", _SubQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubUM", _SubUM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Action", _Action, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UpdateType", _UpdateType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectDate", _EffectDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnGroup", _EcnGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EcnStat", _EcnStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobmatlRP", _JobmatlRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobRP", _JobRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ItemRP", _ItemRP, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
