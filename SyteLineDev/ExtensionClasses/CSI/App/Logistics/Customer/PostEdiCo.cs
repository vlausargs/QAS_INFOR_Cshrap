//PROJECT NAME: CSICustomer
//CLASS NAME: PostEdiCo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IPostEdiCo
	{
		int PostEdiCoSp(byte? PostAll,
		                string PEdiCoNum,
		                ref string Infobar);
	}
	
	public class PostEdiCo : IPostEdiCo
	{
		readonly IApplicationDB appDB;
		
		public PostEdiCo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int PostEdiCoSp(byte? PostAll,
		                       string PEdiCoNum,
		                       ref string Infobar)
		{
			FlagNyType _PostAll = PostAll;
			CoNumType _PEdiCoNum = PEdiCoNum;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PostEdiCoSp";
				
				appDB.AddCommandParameter(cmd, "PostAll", _PostAll, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEdiCoNum", _PEdiCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
