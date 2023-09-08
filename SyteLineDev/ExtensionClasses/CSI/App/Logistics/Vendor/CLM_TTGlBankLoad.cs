//PROJECT NAME: CSIVendor
//CLASS NAME: CLM_TTGlBankLoad.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public interface ICLM_TTGlBankLoad
	{
		DataTable CLM_TTGlBankLoadSp(string PBankCode,
		                             int? PCheckNumStart,
		                             int? PCheckNumEnd);
	}
	
	public class CLM_TTGlBankLoad : ICLM_TTGlBankLoad
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CLM_TTGlBankLoad(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CLM_TTGlBankLoadSp(string PBankCode,
		                                    int? PCheckNumStart,
		                                    int? PCheckNumEnd)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				BankCodeType _PBankCode = PBankCode;
				GlCheckNumType _PCheckNumStart = PCheckNumStart;
				GlCheckNumType _PCheckNumEnd = PCheckNumEnd;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_TTGlBankLoadSp";
					
					appDB.AddCommandParameter(cmd, "PBankCode", _PBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCheckNumStart", _PCheckNumStart, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCheckNumEnd", _PCheckNumEnd, ParameterDirection.Input);

                    dtReturn = appDB.ExecuteQuery(cmd);

                    return dtReturn;
				}
			}
			finally
			{
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
