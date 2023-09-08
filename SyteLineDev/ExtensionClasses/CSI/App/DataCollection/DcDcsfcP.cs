//PROJECT NAME: DataCollection
//CLASS NAME: DcDcsfcP.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.DataCollection
{
	public class DcDcsfcP : IDcDcsfcP
	{
		readonly IApplicationDB appDB;
		
		
		public DcDcsfcP(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, int? StopPost,
		int? PCanOverride,
		string Infobar) DcDcsfcPSp(Guid? DcsfcRowpointer,
		DateTime? PPostDate,
		int? StopPost,
		int? PCanOverride,
		string Infobar)
		{
			RowPointerType _DcsfcRowpointer = DcsfcRowpointer;
			CurrentDateType _PPostDate = PPostDate;
			ListYesNoType _StopPost = StopPost;
			ListYesNoType _PCanOverride = PCanOverride;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "DcDcsfcPSp";
				
				appDB.AddCommandParameter(cmd, "DcsfcRowpointer", _DcsfcRowpointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PPostDate", _PPostDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StopPost", _StopPost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PCanOverride", _PCanOverride, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				StopPost = _StopPost;
				PCanOverride = _PCanOverride;
				Infobar = _Infobar;
				
				return (Severity, StopPost, PCanOverride, Infobar);
			}
		}
	}
}
