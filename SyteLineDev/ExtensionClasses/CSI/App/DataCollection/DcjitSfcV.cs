//PROJECT NAME: DataCollection
//CLASS NAME: DcjitSfcV.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcjitSfcV : IDcjitSfcV
	{
		readonly IApplicationDB appDB;
		
		public DcjitSfcV(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? CanOverride,
			string Infobar) DcjitSfcVSp(
			int? PTransNum,
			decimal? PJobtranTransNum,
			int? CanOverride,
			string Infobar)
		{
			DcTransNumType _PTransNum = PTransNum;
			HugeTransNumType _PJobtranTransNum = PJobtranTransNum;
			ListYesNoType _CanOverride = CanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcjitSfcVSp";
				
				appDB.AddCommandParameter(cmd, "PTransNum", _PTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PJobtranTransNum", _PJobtranTransNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CanOverride", _CanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanOverride = _CanOverride;
				Infobar = _Infobar;
				
				return (Severity, CanOverride, Infobar);
			}
		}
	}
}
