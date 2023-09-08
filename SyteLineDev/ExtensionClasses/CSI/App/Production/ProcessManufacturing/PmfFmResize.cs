//PROJECT NAME: Production
//CLASS NAME: PmfFmResize.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public interface IPmfFmResize
	{
		(int? ReturnCode, string Infobar, decimal? Factor) PmfFmResizeSp(string Infobar = null,
		                                                                 Guid? FmRp = null,
		                                                                 string Fm = null,
		                                                                 int? SizeOption = null,
		                                                                 decimal? NewSize = null,
		                                                                 string NewSizeUm = null,
		                                                                 decimal? Factor = null,
		                                                                 int? GetFactorOnly = 0);
	}
	
	public class PmfFmResize : IPmfFmResize
	{
		readonly IApplicationDB appDB;
		
		public PmfFmResize(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, decimal? Factor) PmfFmResizeSp(string Infobar = null,
		                                                                        Guid? FmRp = null,
		                                                                        string Fm = null,
		                                                                        int? SizeOption = null,
		                                                                        decimal? NewSize = null,
		                                                                        string NewSizeUm = null,
		                                                                        decimal? Factor = null,
		                                                                        int? GetFactorOnly = 0)
		{
			InfobarType _Infobar = Infobar;
			RowPointerType _FmRp = FmRp;
			ProcessMfgFormulaIdType _Fm = Fm;
			IntType _SizeOption = SizeOption;
			ProcessMfgQuantityType _NewSize = NewSize;
			UMType _NewSizeUm = NewSizeUm;
			ProcessMfgQuantityType _Factor = Factor;
			IntType _GetFactorOnly = GetFactorOnly;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PmfFmResizeSp";
				
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FmRp", _FmRp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Fm", _Fm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SizeOption", _SizeOption, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSize", _NewSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NewSizeUm", _NewSizeUm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Factor", _Factor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "GetFactorOnly", _GetFactorOnly, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				Factor = _Factor;
				
				return (Severity, Infobar, Factor);
			}
		}
	}
}
