//PROJECT NAME: CSICodes
//CLASS NAME: GetCustPortalCoRowPointer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface IGetCustPortalCoRowPointer
	{
		int GetCustPortalCoRowPointerSp(string CustNum,
		                                string EstCoNum,
		                                ref string CoNum,
		                                ref Guid? CoRowPointer,
		                                ref string Infobar);
	}
	
	public class GetCustPortalCoRowPointer : IGetCustPortalCoRowPointer
	{
		readonly IApplicationDB appDB;
		
		public GetCustPortalCoRowPointer(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int GetCustPortalCoRowPointerSp(string CustNum,
		                                       string EstCoNum,
		                                       ref string CoNum,
		                                       ref Guid? CoRowPointer,
		                                       ref string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CoNumType _EstCoNum = EstCoNum;
			CoNumType _CoNum = CoNum;
			RowPointerType _CoRowPointer = CoRowPointer;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetCustPortalCoRowPointerSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EstCoNum", _EstCoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoNum = _CoNum;
				CoRowPointer = _CoRowPointer;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
