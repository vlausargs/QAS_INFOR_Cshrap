//PROJECT NAME: Material
//CLASS NAME: EcniRevision.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class EcniRevision : IEcniRevision
	{
		readonly IApplicationDB appDB;
		
		
		public EcniRevision(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string OutJob,
		string OutDrawingNbr,
		string Infobar) EcniRevisionSp(string InRevision,
		string InItem,
		string OutJob,
		string OutDrawingNbr,
		string Infobar)
		{
			LongListType _InRevision = InRevision;
			LongListType _InItem = InItem;
			LongListType _OutJob = OutJob;
			LongListType _OutDrawingNbr = OutDrawingNbr;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EcniRevisionSp";
				
				appDB.AddCommandParameter(cmd, "InRevision", _InRevision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InItem", _InItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutJob", _OutJob, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutDrawingNbr", _OutDrawingNbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutJob = _OutJob;
				OutDrawingNbr = _OutDrawingNbr;
				Infobar = _Infobar;
				
				return (Severity, OutJob, OutDrawingNbr, Infobar);
			}
		}
	}
}
