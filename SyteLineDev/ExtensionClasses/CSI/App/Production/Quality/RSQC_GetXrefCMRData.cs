//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefCMRData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefCMRData : IRSQC_GetXrefCMRData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetXrefCMRData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefCMRDataSp(string i_cmr,
		string o_desc,
		string Infobar)
		{
			QCDocNumType _i_cmr = i_cmr;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetXrefCMRDataSp";
				
				appDB.AddCommandParameter(cmd, "i_cmr", _i_cmr, ParameterDirection.Input);
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
