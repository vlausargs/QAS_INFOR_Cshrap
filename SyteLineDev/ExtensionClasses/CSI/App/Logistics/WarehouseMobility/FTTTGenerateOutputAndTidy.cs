//PROJECT NAME: CSIWarehouseMobility
//CLASS NAME: FTTTGenerateOutputAndTidy.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTTTGenerateOutputAndTidy
	{
		int FTTTGenerateOutputAndTidySp(Guid? SessionID,
		                                byte? PreserveSession,
		                                ref string OutputXmlString,
		                                ref string Infobar);
	}
	
	public class FTTTGenerateOutputAndTidy : IFTTTGenerateOutputAndTidy
	{
		readonly IApplicationDB appDB;
		
		public FTTTGenerateOutputAndTidy(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int FTTTGenerateOutputAndTidySp(Guid? SessionID,
		                                       byte? PreserveSession,
		                                       ref string OutputXmlString,
		                                       ref string Infobar)
		{
			RowPointerType _SessionID = SessionID;
			ListYesNoType _PreserveSession = PreserveSession;
			StringType _OutputXmlString = OutputXmlString;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FTTTGenerateOutputAndTidySp";
				
				appDB.AddCommandParameter(cmd, "SessionID", _SessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreserveSession", _PreserveSession, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OutputXmlString", _OutputXmlString, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				OutputXmlString = _OutputXmlString;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
