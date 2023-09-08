//PROJECT NAME: Production
//CLASS NAME: RSQC_GetJobData.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetJobData : IRSQC_GetJobData
	{
		readonly IApplicationDB appDB;
		
		
		public RSQC_GetJobData(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string o_ref_type,
		string o_ref_num,
		int? o_ref_line_suf,
		int? o_ref_release,
		string o_description,
		decimal? o_item_cost_conv,
		string o_um,
		int? o_po_line,
		int? o_po_release,
		string o_accept_to_jobtran,
		string Infobar) RSQC_GetJobDataSp(int? i_rcvr,
		string o_ref_type,
		string o_ref_num,
		int? o_ref_line_suf,
		int? o_ref_release,
		string o_description,
		decimal? o_item_cost_conv,
		string o_um,
		int? o_po_line,
		int? o_po_release,
		string o_accept_to_jobtran,
		string Infobar)
		{
			QCRcvrNumType _i_rcvr = i_rcvr;
			RefTypeIJKOTType _o_ref_type = o_ref_type;
			CoJobProjTrnNumType _o_ref_num = o_ref_num;
			CoLineSuffixProjTaskTrnLineType _o_ref_line_suf = o_ref_line_suf;
			CoReleaseOperNumType _o_ref_release = o_ref_release;
			DescriptionType _o_description = o_description;
			CostPrcType _o_item_cost_conv = o_item_cost_conv;
			UMType _o_um = o_um;
			CoLineSuffixProjTaskTrnLineType _o_po_line = o_po_line;
			CoReleaseOperNumType _o_po_release = o_po_release;
			QCCharType _o_accept_to_jobtran = o_accept_to_jobtran;
			InfobarType _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "RSQC_GetJobDataSp";
				
				appDB.AddCommandParameter(cmd, "i_rcvr", _i_rcvr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "o_ref_type", _o_ref_type, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_num", _o_ref_num, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_line_suf", _o_ref_line_suf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_ref_release", _o_ref_release, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_description", _o_description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_item_cost_conv", _o_item_cost_conv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_um", _o_um, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_po_line", _o_po_line, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_po_release", _o_po_release, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "o_accept_to_jobtran", _o_accept_to_jobtran, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				o_ref_type = _o_ref_type;
				o_ref_num = _o_ref_num;
				o_ref_line_suf = _o_ref_line_suf;
				o_ref_release = _o_ref_release;
				o_description = _o_description;
				o_item_cost_conv = _o_item_cost_conv;
				o_um = _o_um;
				o_po_line = _o_po_line;
				o_po_release = _o_po_release;
				o_accept_to_jobtran = _o_accept_to_jobtran;
				Infobar = _Infobar;
				
				return (Severity, o_ref_type, o_ref_num, o_ref_line_suf, o_ref_release, o_description, o_item_cost_conv, o_um, o_po_line, o_po_release, o_accept_to_jobtran, Infobar);
			}
		}
	}
}
