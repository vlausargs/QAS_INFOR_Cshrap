//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefProjectData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefProjectData : IRSQC_GetXrefProjectData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetXrefProjectData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefProjectDataSp(string i_proj,
		string o_desc,
		string Infobar)
		{
			ProjNumType _i_proj = i_proj;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetXrefProjectDataSp";
				
				appDB.AddCommandParameter(cmd, "i_proj", _i_proj, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_desc", _o_desc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_desc = _o_desc;
				Infobar = _Infobar;
				
				return (Severity, o_desc, Infobar);
			}
		}
	}
}
