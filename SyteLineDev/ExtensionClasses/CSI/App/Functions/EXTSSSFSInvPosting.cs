//PROJECT NAME: Data
//CLASS NAME: EXTSSSFSInvPosting.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class EXTSSSFSInvPosting : IEXTSSSFSInvPosting
	{
		readonly IApplicationDB appDB;
		
		public EXTSSSFSInvPosting(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			Guid? CoRowPointer,
			string CoCustNum,
			int? CoCustSeq,
			string Infobar,
			int? InclSROInOnOrdBal) EXTSSSFSInvPostingSp(
			string ArinvInvNum,
			Guid? CoRowPointer,
			string CoCustNum,
			int? CoCustSeq,
			string Infobar,
			int? InclSROInOnOrdBal = 1)
		{
			InvNumType _ArinvInvNum = ArinvInvNum;
			RowPointerType _CoRowPointer = CoRowPointer;
			CustNumType _CoCustNum = CoCustNum;
			CustSeqType _CoCustSeq = CoCustSeq;
			InfobarType _Infobar = Infobar;
			ListYesNoType _InclSROInOnOrdBal = InclSROInOnOrdBal;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "EXTSSSFSInvPostingSp";
				
				appDB.AddCommandParameter(cmd, "ArinvInvNum", _ArinvInvNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCustNum", _CoCustNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoCustSeq", _CoCustSeq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InclSROInOnOrdBal", _InclSROInOnOrdBal, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CoRowPointer = _CoRowPointer;
				CoCustNum = _CoCustNum;
				CoCustSeq = _CoCustSeq;
				Infobar = _Infobar;
				InclSROInOnOrdBal = _InclSROInOnOrdBal;
				
				return (Severity, CoRowPointer, CoCustNum, CoCustSeq, Infobar, InclSROInOnOrdBal);
			}
		}
	}
}
