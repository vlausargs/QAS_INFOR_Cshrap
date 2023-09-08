//PROJECT NAME: Logistics
//CLASS NAME: Rpt_TaxPayable.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class Rpt_TaxPayable : IRpt_TaxPayable
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_TaxPayable(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_TaxPayableSp(DateTime? PDistDateStarting,
		DateTime? PDistDateEnding,
		string PTaxCodeStarting,
		string PTaxCodeEnding,
		string PVendorStarting,
		string PVendorEnding,
		string PSite = null)
		{
			DateType _PDistDateStarting = PDistDateStarting;
			DateType _PDistDateEnding = PDistDateEnding;
			TaxCodeType _PTaxCodeStarting = PTaxCodeStarting;
			TaxCodeType _PTaxCodeEnding = PTaxCodeEnding;
			VendNumType _PVendorStarting = PVendorStarting;
			VendNumType _PVendorEnding = PVendorEnding;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_TaxPayableSp";
				
				appDB.AddCommandParameter(cmd, "PDistDateStarting", _PDistDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDistDateEnding", _PDistDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCodeStarting", _PTaxCodeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PTaxCodeEnding", _PTaxCodeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorStarting", _PVendorStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PVendorEnding", _PVendorEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
