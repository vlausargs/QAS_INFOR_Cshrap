//PROJECT NAME: CSICustomer
//CLASS NAME: CARaSPartsExtraction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface ICARaSPartsExtraction
	{
		DataTable CARaSPartsExtractionSp(string StartCustNum,
		                                 string EndCustNum,
		                                 byte? ExtractAll);
	}
	
	public class CARaSPartsExtraction : ICARaSPartsExtraction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CARaSPartsExtraction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CARaSPartsExtractionSp(string StartCustNum,
		                                        string EndCustNum,
		                                        byte? ExtractAll)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _StartCustNum = StartCustNum;
				CustNumType _EndCustNum = EndCustNum;
				FlagNyType _ExtractAll = ExtractAll;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CARaSPartsExtractionSp";
					
					appDB.AddCommandParameter(cmd, "StartCustNum", _StartCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndCustNum", _EndCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ExtractAll", _ExtractAll, ParameterDirection.Input);

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
