//PROJECT NAME: Reporting
//CLASS NAME: SSSFSRpt_UnifiedTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class SSSFSRpt_UnifiedTransaction : ISSSFSRpt_UnifiedTransaction
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public SSSFSRpt_UnifiedTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) SSSFSRpt_UnifiedTransactionSp(string beg_partner_id,
		DateTime? beg_trans_date,
		string beg_sro_num,
		string end_partner_id,
		DateTime? end_trans_date,
		string end_sro_num,
		string RefType,
		int? IncludeMaterial,
		int? IncludeMaterialNotes,
		int? IncludeLabor,
		int? IncludeLaborNotes,
		int? IncludeMisc,
		int? IncludeMiscNotes,
		int? PageBreak,
		int? ShowPosted,
		int? ShowUnPosted,
		int? ShowInternal,
		int? ShowExternal,
		string pSite = null)
		{
			FSPartnerType _beg_partner_id = beg_partner_id;
			DateType _beg_trans_date = beg_trans_date;
			FSSRONumType _beg_sro_num = beg_sro_num;
			FSPartnerType _end_partner_id = end_partner_id;
			DateType _end_trans_date = end_trans_date;
			FSSRONumType _end_sro_num = end_sro_num;
			StringType _RefType = RefType;
			ListYesNoType _IncludeMaterial = IncludeMaterial;
			ListYesNoType _IncludeMaterialNotes = IncludeMaterialNotes;
			ListYesNoType _IncludeLabor = IncludeLabor;
			ListYesNoType _IncludeLaborNotes = IncludeLaborNotes;
			ListYesNoType _IncludeMisc = IncludeMisc;
			ListYesNoType _IncludeMiscNotes = IncludeMiscNotes;
			ListYesNoType _PageBreak = PageBreak;
			ListYesNoType _ShowPosted = ShowPosted;
			ListYesNoType _ShowUnPosted = ShowUnPosted;
			ListYesNoType _ShowInternal = ShowInternal;
			ListYesNoType _ShowExternal = ShowExternal;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "SSSFSRpt_UnifiedTransactionSp";
				
				appDB.AddCommandParameter(cmd, "beg_partner_id", _beg_partner_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_trans_date", _beg_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "beg_sro_num", _beg_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_partner_id", _end_partner_id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_trans_date", _end_trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "end_sro_num", _end_sro_num, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RefType", _RefType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeMaterial", _IncludeMaterial, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeMaterialNotes", _IncludeMaterialNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeLabor", _IncludeLabor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeLaborNotes", _IncludeLaborNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeMisc", _IncludeMisc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IncludeMiscNotes", _IncludeMiscNotes, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PageBreak", _PageBreak, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowPosted", _ShowPosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowUnPosted", _ShowUnPosted, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInternal", _ShowInternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowExternal", _ShowExternal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
