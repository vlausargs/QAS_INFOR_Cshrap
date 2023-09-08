//PROJECT NAME: Finance
//CLASS NAME: MultiFSBJourpost.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBJourpost : IMultiFSBJourpost
	{
		readonly IApplicationDB appDB;
		
		public MultiFSBJourpost(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			int? last_seq,
			string Infobar) MultiFSBJourpostSp(
			string FSBName,
			string id = "General",
			DateTime? trans_date = null,
			string acct = null,
			string acct_unit1 = null,
			string acct_unit2 = null,
			string acct_unit3 = null,
			string acct_unit4 = null,
			decimal? amount = null,
			string _ref = null,
			string curr_code = null,
			decimal? exch_rate = 1M,
			int? reverse = 0,
			int? last_seq = null,
			string Infobar = null,
			Guid? BufferJournal = null,
			string DomCurrCode = null,
			int? DomCurrPlaces = null)
		{
			FSBNameType _FSBName = FSBName;
			JournalIdType _id = id;
			DateType _trans_date = trans_date;
			AcctType _acct = acct;
			UnitCode1Type _acct_unit1 = acct_unit1;
			UnitCode2Type _acct_unit2 = acct_unit2;
			UnitCode3Type _acct_unit3 = acct_unit3;
			UnitCode4Type _acct_unit4 = acct_unit4;
			AmountType _amount = amount;
			ReferenceType __ref = _ref;
			CurrCodeType _curr_code = curr_code;
			ExchRateType _exch_rate = exch_rate;
			ListYesNoType _reverse = reverse;
			JournalSeqType _last_seq = last_seq;
			InfobarType _Infobar = Infobar;
			RowPointerType _BufferJournal = BufferJournal;
			CurrCodeType _DomCurrCode = DomCurrCode;
			DecimalPlacesType _DomCurrPlaces = DomCurrPlaces;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "MultiFSBJourpostSp";
				
				appDB.AddCommandParameter(cmd, "FSBName", _FSBName, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "id", _id, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "trans_date", _trans_date, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct", _acct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit1", _acct_unit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit2", _acct_unit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit3", _acct_unit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "acct_unit4", _acct_unit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "amount", _amount, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ref", __ref, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "curr_code", _curr_code, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "exch_rate", _exch_rate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "reverse", _reverse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "last_seq", _last_seq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BufferJournal", _BufferJournal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrCode", _DomCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DomCurrPlaces", _DomCurrPlaces, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				last_seq = _last_seq;
				Infobar = _Infobar;
				
				return (Severity, last_seq, Infobar);
			}
		}
	}
}
