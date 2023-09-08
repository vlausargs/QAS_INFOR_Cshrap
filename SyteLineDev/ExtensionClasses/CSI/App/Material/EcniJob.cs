//PROJECT NAME: Material
//CLASS NAME: EcniJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class EcniJob : IEcniJob
	{
		readonly IApplicationDB appDB;
		
		
		public EcniJob(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutType,
		string OutStat,
		string OutItem,
		string OutRevision,
		string OutDrawingNbr,
		string OutDescription,
		string Infobar) EcniJobSp(string InEcnitemType,
		string InJob,
		string InSuffix,
		int? InQuick,
		string OutType,
		string OutStat,
		string OutItem,
		string OutRevision,
		string OutDrawingNbr,
		string OutDescription,
		string Infobar)
		{
			LongListType _InEcnitemType = InEcnitemType;
			LongListType _InJob = InJob;
			LongListType _InSuffix = InSuffix;
			ListYesNoType _InQuick = InQuick;
			LongListType _OutType = OutType;
			LongListType _OutStat = OutStat;
			LongListType _OutItem = OutItem;
			LongListType _OutRevision = OutRevision;
			LongListType _OutDrawingNbr = OutDrawingNbr;
			LongListType _OutDescription = OutDescription;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcniJobSp";
				
				appDB.AddCommandParameter(cmd, "InEcnitemType", _InEcnitemType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InJob", _InJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InSuffix", _InSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InQuick", _InQuick, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutType", _OutType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutStat", _OutStat, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutItem", _OutItem, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutRevision", _OutRevision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutDrawingNbr", _OutDrawingNbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutDescription", _OutDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutType = _OutType;
				OutStat = _OutStat;
				OutItem = _OutItem;
				OutRevision = _OutRevision;
				OutDrawingNbr = _OutDrawingNbr;
				OutDescription = _OutDescription;
				Infobar = _Infobar;
				
				return (Severity, OutType, OutStat, OutItem, OutRevision, OutDrawingNbr, OutDescription, Infobar);
			}
		}
	}
}
