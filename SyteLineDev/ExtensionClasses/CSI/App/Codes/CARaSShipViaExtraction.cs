//PROJECT NAME: CSICodes
//CLASS NAME: CARaSShipViaExtraction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Codes
{
	public interface ICARaSShipViaExtraction
	{
		DataTable CARaSShipViaExtractionSp(string StartShipCode,
		                                   string EndShipCode);
	}
	
	public class CARaSShipViaExtraction : ICARaSShipViaExtraction
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		
		public CARaSShipViaExtraction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
		}
		
		public DataTable CARaSShipViaExtractionSp(string StartShipCode,
		                                          string EndShipCode)
		{
			bunchedLoadCollection.StartBunching();
			
			try
			{
				ShipCodeType _StartShipCode = StartShipCode;
				ShipCodeType _EndShipCode = EndShipCode;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CARaSShipViaExtractionSp";
					
					appDB.AddCommandParameter(cmd, "StartShipCode", _StartShipCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "EndShipCode", _EndShipCode, ParameterDirection.Input);

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
