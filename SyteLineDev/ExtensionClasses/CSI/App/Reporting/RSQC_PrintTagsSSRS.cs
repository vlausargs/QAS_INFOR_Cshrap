//PROJECT NAME: Reporting
//CLASS NAME: RSQC_PrintTagsSSRS.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class RSQC_PrintTagsSSRS : IRSQC_PrintTagsSSRS
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public RSQC_PrintTagsSSRS(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) RSQC_PrintTagsSSRSSp(int? i_rcvrnum,
		string i_item,
		string i_itmdesc,
		string i_reftype,
		string i_entity,
		string i_entityname,
		string i_insp,
		string i_inspname,
		DateTime? i_inspdate,
		string i_refnum,
		int? i_refline,
		int? i_refrel,
		decimal? i_acceptqty,
		string i_a_reason,
		string i_a_reason_descr,
		string i_a_dcode,
		string i_a_dcode_descr,
		int? i_accepttags,
		int? i_acceptnum,
		decimal? i_rejectqty,
		string i_r_reason,
		string i_r_reason_descr,
		string i_r_dcode,
		string i_r_dcode_descr,
		string i_r_cause,
		string i_r_cause_descr,
		int? i_rejecttags,
		int? i_rejectnum,
		decimal? i_holdqty,
		string i_h_reason,
		string i_h_reason_descr,
		int? i_holdtags,
		int? i_holdnum,
		string i_lot,
		string i_psnum,
		string i_wcdescr,
		string psite)
		{
			QCRcvrNumType _i_rcvrnum = i_rcvrnum;
			ItemType _i_item = i_item;
			DescriptionType _i_itmdesc = i_itmdesc;
			QCRefType _i_reftype = i_reftype;
			QCDocNumType _i_entity = i_entity;
			NameType _i_entityname = i_entityname;
			EmpNumType _i_insp = i_insp;
			NameType _i_inspname = i_inspname;
			DateType _i_inspdate = i_inspdate;
			QCDocNumType _i_refnum = i_refnum;
			QCRefLineType _i_refline = i_refline;
			QCRefReleaseType _i_refrel = i_refrel;
			QtyUnitType _i_acceptqty = i_acceptqty;
			QCCodeType _i_a_reason = i_a_reason;
			DescriptionType _i_a_reason_descr = i_a_reason_descr;
			QCCodeType _i_a_dcode = i_a_dcode;
			DescriptionType _i_a_dcode_descr = i_a_dcode_descr;
			ListYesNoType _i_accepttags = i_accepttags;
			IntType _i_acceptnum = i_acceptnum;
			QtyUnitType _i_rejectqty = i_rejectqty;
			QCCodeType _i_r_reason = i_r_reason;
			DescriptionType _i_r_reason_descr = i_r_reason_descr;
			QCCodeType _i_r_dcode = i_r_dcode;
			DescriptionType _i_r_dcode_descr = i_r_dcode_descr;
			QCCodeType _i_r_cause = i_r_cause;
			DescriptionType _i_r_cause_descr = i_r_cause_descr;
			ListYesNoType _i_rejecttags = i_rejecttags;
			IntType _i_rejectnum = i_rejectnum;
			QtyUnitType _i_holdqty = i_holdqty;
			QCCodeType _i_h_reason = i_h_reason;
			DescriptionType _i_h_reason_descr = i_h_reason_descr;
			ListYesNoType _i_holdtags = i_holdtags;
			IntType _i_holdnum = i_holdnum;
			LotType _i_lot = i_lot;
			PsNumType _i_psnum = i_psnum;
			DescriptionType _i_wcdescr = i_wcdescr;
			SiteType _psite = psite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_PrintTagsSSRSSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvrnum", _i_rcvrnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_item", _i_item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_itmdesc", _i_itmdesc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_reftype", _i_reftype, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entity", _i_entity, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_entityname", _i_entityname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_insp", _i_insp, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_inspname", _i_inspname, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_inspdate", _i_inspdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_refnum", _i_refnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_refline", _i_refline, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_refrel", _i_refrel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_acceptqty", _i_acceptqty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_a_reason", _i_a_reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_a_reason_descr", _i_a_reason_descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_a_dcode", _i_a_dcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_a_dcode_descr", _i_a_dcode_descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_accepttags", _i_accepttags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_acceptnum", _i_acceptnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_rejectqty", _i_rejectqty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_r_reason", _i_r_reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_r_reason_descr", _i_r_reason_descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_r_dcode", _i_r_dcode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_r_dcode_descr", _i_r_dcode_descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_r_cause", _i_r_cause, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_r_cause_descr", _i_r_cause_descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_rejecttags", _i_rejecttags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_rejectnum", _i_rejectnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_holdqty", _i_holdqty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_h_reason", _i_h_reason, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_h_reason_descr", _i_h_reason_descr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_holdtags", _i_holdtags, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_holdnum", _i_holdnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_lot", _i_lot, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_psnum", _i_psnum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "i_wcdescr", _i_wcdescr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "psite", _psite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
