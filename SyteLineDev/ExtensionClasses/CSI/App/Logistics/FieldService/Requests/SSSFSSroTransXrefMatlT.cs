//PROJECT NAME: CSIFSPlusSRO
//CLASS NAME: SSSFSSroTransXrefMatlT.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSroTransXrefMatlT
	{
		int SSSFSSroTransXrefMatlTSp(string PTrnNum,
		                             short? PTrnLine,
		                             ref int? XrefTrn,
		                             ref string RefDescription,
		                             ref string Infobar);
	}
	
	public class SSSFSSroTransXrefMatlT : ISSSFSSroTransXrefMatlT
	{
		readonly IApplicationDB appDB;
		
		public SSSFSSroTransXrefMatlT(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public int SSSFSSroTransXrefMatlTSp(string PTrnNum,
		                                    short? PTrnLine,
		                                    ref int? XrefTrn,
		                                    ref string RefDescription,
		                                    ref string Infobar)
		{
			TrnNumType _PTrnNum = PTrnNum;
			TrnLineType _PTrnLine = PTrnLine;
			IntType _XrefTrn = XrefTrn;
			LongDescType _RefDescription = RefDescription;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSSroTransXrefMatlTSp";
				
				appDB.AddCommandParameter(cmd, "PTrnNum", _PTrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTrnLine", _PTrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "XrefTrn", _XrefTrn, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RefDescription", _RefDescription, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				XrefTrn = _XrefTrn;
				RefDescription = _RefDescription;
				Infobar = _Infobar;
				
				return Severity;
			}
		}
	}
}
