//PROJECT NAME: POS
//CLASS NAME: FormatAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.POS
{
	public class FormatAddress : IFormatAddress
	{
		readonly IApplicationDB appDB;
		
		
		public FormatAddress(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string BillToAddress,
		string ShipToAddress,
		string Infobar) FormatAddressSp(string CustNum,
		int? CustSeq,
		string BillToAddress,
		string ShipToAddress,
		string Infobar)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;
			LongAddress _BillToAddress = BillToAddress;
			LongAddress _ShipToAddress = ShipToAddress;
			Infobar _Infobar = Infobar;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FormatAddressSp";
				
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BillToAddress", _BillToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ShipToAddress", _ShipToAddress, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				BillToAddress = _BillToAddress;
				ShipToAddress = _ShipToAddress;
				Infobar = _Infobar;
				
				return (Severity, BillToAddress, ShipToAddress, Infobar);
			}
		}

		public string FormatAddressFn(
			string CustNum,
			int? CustSeq)
		{
			CustNumType _CustNum = CustNum;
			CustSeqType _CustSeq = CustSeq;

			using (IDbCommand cmd = appDB.CreateCommand())
			{

				cmd.CommandType = CommandType.Text;
				cmd.CommandText = "SELECT  dbo.[FormatAddress](@CustNum, @CustSeq)";

				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);

				var Output = appDB.ExecuteScalar<string>(cmd);

				return Output;
			}
		}
	}
}
