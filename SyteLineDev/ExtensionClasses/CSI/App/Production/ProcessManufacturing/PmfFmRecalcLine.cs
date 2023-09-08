//PROJECT NAME: Production
//CLASS NAME: PmfFMRecalcLine.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFMRecalcLine
	{
		(int? ReturnCode, string Infobar) PmfFMRecalcLineSp(Guid? LineRp = null,
		                                                    Guid? FmRp = null,
		                                                    string Infobar = null,
		                                                    int? UseRecalcFlag = 0);
	}
	
	public class PmfFMRecalcLine : IPmfFMRecalcLine
	{
		readonly IApplicationDB appDB;
		
		public PmfFMRecalcLine(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar) PmfFMRecalcLineSp(Guid? LineRp = null,
		                                                           Guid? FmRp = null,
		                                                           string Infobar = null,
		                                                           int? UseRecalcFlag = 0)
		{
			RowPointerType _LineRp = LineRp;
			RowPointerType _FmRp = FmRp;
			InfobarType _Infobar = Infobar;
			IntType _UseRecalcFlag = UseRecalcFlag;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFMRecalcLineSp";
				
				appDB.AddCommandParameter(cmd, "LineRp", _LineRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseRecalcFlag", _UseRecalcFlag, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				
				return (Severity, Infobar);
			}
		}
	}
}
