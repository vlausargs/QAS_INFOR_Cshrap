//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InactiveAccountNumbers.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_InactiveAccountNumbers
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InactiveAccountNumbersSp(DateTime? PStartingEffectiveDate = null,
		DateTime? PEndingEffectiveDate = null,
		DateTime? PStartingObsoleteDate = null,
		DateTime? PEndingObsoleteDate = null,
		string PAccountType = "ALORE",
		byte? PDisplayHeader = (byte)1,
		short? PStartingEffectiveDateOffset = null,
		short? PEndingEffectiveDateOffset = null,
		short? PStartingObsoleteDateOffset = null,
		short? PEndingObsoleteDateOffset = null,
		string PMessageLanguage = null,
		string pSite = null,
		string BGUser = null);
	}
	
	public class Rpt_InactiveAccountNumbers : IRpt_InactiveAccountNumbers
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_InactiveAccountNumbers(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_InactiveAccountNumbersSp(DateTime? PStartingEffectiveDate = null,
		DateTime? PEndingEffectiveDate = null,
		DateTime? PStartingObsoleteDate = null,
		DateTime? PEndingObsoleteDate = null,
		string PAccountType = "ALORE",
		byte? PDisplayHeader = (byte)1,
		short? PStartingEffectiveDateOffset = null,
		short? PEndingEffectiveDateOffset = null,
		short? PStartingObsoleteDateOffset = null,
		short? PEndingObsoleteDateOffset = null,
		string PMessageLanguage = null,
		string pSite = null,
		string BGUser = null)
		{
			DateType _PStartingEffectiveDate = PStartingEffectiveDate;
			DateType _PEndingEffectiveDate = PEndingEffectiveDate;
			DateType _PStartingObsoleteDate = PStartingObsoleteDate;
			DateType _PEndingObsoleteDate = PEndingObsoleteDate;
			Infobar _PAccountType = PAccountType;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			DateOffsetType _PStartingEffectiveDateOffset = PStartingEffectiveDateOffset;
			DateOffsetType _PEndingEffectiveDateOffset = PEndingEffectiveDateOffset;
			DateOffsetType _PStartingObsoleteDateOffset = PStartingObsoleteDateOffset;
			DateOffsetType _PEndingObsoleteDateOffset = PEndingObsoleteDateOffset;
			MessageLanguageType _PMessageLanguage = PMessageLanguage;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_InactiveAccountNumbersSp";
				
				appDB.AddCommandParameter(cmd, "PStartingEffectiveDate", _PStartingEffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingEffectiveDate", _PEndingEffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingObsoleteDate", _PStartingObsoleteDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingObsoleteDate", _PEndingObsoleteDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PAccountType", _PAccountType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingEffectiveDateOffset", _PStartingEffectiveDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingEffectiveDateOffset", _PEndingEffectiveDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartingObsoleteDateOffset", _PStartingObsoleteDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndingObsoleteDateOffset", _PEndingObsoleteDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMessageLanguage", _PMessageLanguage, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
