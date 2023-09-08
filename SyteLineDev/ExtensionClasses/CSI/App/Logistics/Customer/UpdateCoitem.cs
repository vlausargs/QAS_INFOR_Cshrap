//PROJECT NAME: Logistics
//CLASS NAME: UpdateCoitem.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public interface IUpdateCoitem
	{
		(int? ReturnCode, string Infobar, byte? CoAlreadyPlaced, byte? EstAlreadyConverted, Guid? CoRowPointer) UpdateCoitemSp(short? CoLine,
		decimal? QtyOrderedConv = null,
		decimal? PriceConv = null,
		int? CustSeq = null,
		string Infobar = null,
		byte? CoAlreadyPlaced = null,
		byte? EstAlreadyConverted = null,
		Guid? CoRowPointer = null,
		string CoNum = null,
		string CustNum = null,
		string CoType = null,
		DateTime? CoitemProjectedDate = null,
		DateTime? CoitemDueDate = null,
		DateTime? CoitemPromiseDate = null,
		string CoitemUM = null);
	}
	
	public class UpdateCoitem : IUpdateCoitem
	{
		readonly IApplicationDB appDB;
		
		public UpdateCoitem(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Infobar, byte? CoAlreadyPlaced, byte? EstAlreadyConverted, Guid? CoRowPointer) UpdateCoitemSp(short? CoLine,
		decimal? QtyOrderedConv = null,
		decimal? PriceConv = null,
		int? CustSeq = null,
		string Infobar = null,
		byte? CoAlreadyPlaced = null,
		byte? EstAlreadyConverted = null,
		Guid? CoRowPointer = null,
		string CoNum = null,
		string CustNum = null,
		string CoType = null,
		DateTime? CoitemProjectedDate = null,
		DateTime? CoitemDueDate = null,
		DateTime? CoitemPromiseDate = null,
		string CoitemUM = null)
		{
			CoLineType _CoLine = CoLine;
			QtyUnitType _QtyOrderedConv = QtyOrderedConv;
			CostPrcType _PriceConv = PriceConv;
			CustSeqType _CustSeq = CustSeq;
			InfobarType _Infobar = Infobar;
			ListYesNoType _CoAlreadyPlaced = CoAlreadyPlaced;
			ListYesNoType _EstAlreadyConverted = EstAlreadyConverted;
			RowPointerType _CoRowPointer = CoRowPointer;
			CoNumType _CoNum = CoNum;
			CustNumType _CustNum = CustNum;
			CoTypeType _CoType = CoType;
			DateType _CoitemProjectedDate = CoitemProjectedDate;
			DateType _CoitemDueDate = CoitemDueDate;
			DateType _CoitemPromiseDate = CoitemPromiseDate;
			UMType _CoitemUM = CoitemUM;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "UpdateCoitemSp";
				
				appDB.AddCommandParameter(cmd, "CoLine", _CoLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PriceConv", _PriceConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustSeq", _CustSeq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoAlreadyPlaced", _CoAlreadyPlaced, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "EstAlreadyConverted", _EstAlreadyConverted, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoRowPointer", _CoRowPointer, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CoNum", _CoNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoType", _CoType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemProjectedDate", _CoitemProjectedDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemDueDate", _CoitemDueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemPromiseDate", _CoitemPromiseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CoitemUM", _CoitemUM, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				CoAlreadyPlaced = _CoAlreadyPlaced;
				EstAlreadyConverted = _EstAlreadyConverted;
				CoRowPointer = _CoRowPointer;
				
				return (Severity, Infobar, CoAlreadyPlaced, EstAlreadyConverted, CoRowPointer);
			}
		}
	}
}
