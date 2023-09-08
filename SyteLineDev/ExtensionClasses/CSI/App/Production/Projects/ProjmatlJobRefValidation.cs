//PROJECT NAME: CSIProjects
//CLASS NAME: ProjmatlJobRefValidation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.Projects
{
	public interface IProjmatlJobRefValidation
	{
		int ProjmatlJobRefValidationSp(string PRefNum,
		                               short? PSuffix,
		                               string PRefType,
		                               ref string Infobar);
	}
	
	public class ProjmatlJobRefValidation : IProjmatlJobRefValidation
	{
		readonly IApplicationDB appDB;
		
		public ProjmatlJobRefValidation(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int ProjmatlJobRefValidationSp(string PRefNum,
		                                      short? PSuffix,
		                                      string PRefType,
		                                      ref string Infobar)
		{
			JobPoReqNumType _PRefNum = PRefNum;
			SuffixType _PSuffix = PSuffix;
			RefTypeIJPRType _PRefType = PRefType;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ProjmatlJobRefValidationSp";
				
				appDB.AddCommandParameter(cmd, "PRefNum", _PRefNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSuffix", _PSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PRefType", _PRefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
