//PROJECT NAME: Logistics
//CLASS NAME: Arsummv.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class Arsummv : IArsummv
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Arsummv(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) ArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string ArsummFilter,
		string SiteGroup = null,
		string CustaddrCurrCode = null,
		string Salesperson = null,
		int? IncludeDirectReports = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				CustNumType _PCustNum = PCustNum;
				ListYesNoType _PCurrentSite = PCurrentSite;
				ListYesNoType _PSubordinate = PSubordinate;
				ListYesNoType _PActive = PActive;
				LongListType _ArsummFilter = ArsummFilter;
				SiteGroupType _SiteGroup = SiteGroup;
				CurrCodeType _CustaddrCurrCode = CustaddrCurrCode;
				SlsmanType _Salesperson = Salesperson;
				ListYesNoType _IncludeDirectReports = IncludeDirectReports;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "ArsummvSp";
					
					appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PCurrentSite", _PCurrentSite, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PSubordinate", _PSubordinate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PActive", _PActive, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "ArsummFilter", _ArsummFilter, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "CustaddrCurrCode", _CustaddrCurrCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "Salesperson", _Salesperson, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "IncludeDirectReports", _IncludeDirectReports, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
