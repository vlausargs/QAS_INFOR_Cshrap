//PROJECT NAME: Production
//CLASS NAME: RSQC_GetXrefCustomerData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetXrefCustomerData : IRSQC_GetXrefCustomerData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetXrefCustomerData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_desc,
		string Infobar) RSQC_GetXrefCustomerDataSp(string i_custnum,
		int? i_custseq,
		string o_desc,
		string Infobar)
		{
			CoNumType _i_custnum = i_custnum;
			IntType _i_custseq = i_custseq;
			DescriptionType _o_desc = o_desc;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetXrefCustomerDataSp";
				
				appDB.AddCommandParameter(cmd, "i_custnum", _i_custnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_custseq", _i_custseq, ParameterDirection.Input);
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
