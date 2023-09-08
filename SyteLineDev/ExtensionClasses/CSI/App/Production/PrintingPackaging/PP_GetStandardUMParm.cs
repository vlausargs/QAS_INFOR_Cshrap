//PROJECT NAME: Production
//CLASS NAME: PP_GetStandardUMParm.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public interface IPP_GetStandardUMParm
	{
		(int? ReturnCode, string LinearDimensionUM, string DensityUM, string AreaUM, string BulkMassUM, string ReamMassUM, string Infobar) PP_GetStandardUMParmSp(string LinearDimensionUM,
		                                                                                                                                                          string DensityUM,
		                                                                                                                                                          string AreaUM,
		                                                                                                                                                          string BulkMassUM,
		                                                                                                                                                          string ReamMassUM,
		                                                                                                                                                          string Infobar);
	}
	
	public class PP_GetStandardUMParm : IPP_GetStandardUMParm
	{
		readonly IApplicationDB appDB;
		
		public PP_GetStandardUMParm(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string LinearDimensionUM, string DensityUM, string AreaUM, string BulkMassUM, string ReamMassUM, string Infobar) PP_GetStandardUMParmSp(string LinearDimensionUM,
		                                                                                                                                                                 string DensityUM,
		                                                                                                                                                                 string AreaUM,
		                                                                                                                                                                 string BulkMassUM,
		                                                                                                                                                                 string ReamMassUM,
		                                                                                                                                                                 string Infobar)
		{
			UMType _LinearDimensionUM = LinearDimensionUM;
			UMType _DensityUM = DensityUM;
			UMType _AreaUM = AreaUM;
			UMType _BulkMassUM = BulkMassUM;
			UMType _ReamMassUM = ReamMassUM;
			UMType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PP_GetStandardUMParmSp";
				
				appDB.AddCommandParameter(cmd, "LinearDimensionUM", _LinearDimensionUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DensityUM", _DensityUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AreaUM", _AreaUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BulkMassUM", _BulkMassUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReamMassUM", _ReamMassUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				LinearDimensionUM = _LinearDimensionUM;
				DensityUM = _DensityUM;
				AreaUM = _AreaUM;
				BulkMassUM = _BulkMassUM;
				ReamMassUM = _ReamMassUM;
				Infobar = _Infobar;
				
				return (Severity, LinearDimensionUM, DensityUM, AreaUM, BulkMassUM, ReamMassUM, Infobar);
			}
		}
	}
}
