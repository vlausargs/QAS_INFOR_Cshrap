//PROJECT NAME: MG
//CLASS NAME: FSSROSerials.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using CSI.Data.RecordSets;
using System.Runtime.InteropServices;

namespace CSI.MG.FSPlusSRO
{
	[IDOExtensionClass("FSSROSerials")]
	public class FSSROSerials : CSIExtensionClassBase
	{
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSerialCheckSp(string SerNum,
		ref string Prompt,
		ref string Infobar,
		string Item)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSerialCheckExt = new SSSFSSerialCheckFactory().Create(appDb);
				
				var result = iSSSFSSerialCheckExt.SSSFSSerialCheckSp(SerNum,
				Prompt,
				Infobar,
				Item);
				
				int Severity = result.ReturnCode.Value;
				Prompt = result.Prompt;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SerialLoadSp(string SerialLike,
		string TransType,
		string WhseType,
		string Stat,
		[Optional, DefaultParameterValue(0)] int? RestoreLoss,
		[Optional, DefaultParameterValue(0)] int? JmtRETURN,
		[Optional] string Item,
		[Optional] string Whse,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] string DoNum,
		[Optional, DefaultParameterValue(0)] int? DoLine,
		[Optional] string TrnNum,
		[Optional, DefaultParameterValue(0)] int? TrnLine,
		[Optional, DefaultParameterValue(0)] decimal? RsvdNum,
		[Optional] string RefNum,
		[Optional, DefaultParameterValue(0)] int? RefLine,
		[Optional, DefaultParameterValue(0)] int? RefRelease,
		[Optional] string Site,
		[Optional] string ImportDocId,
		[Optional] int? PreassignSerials,
		[Optional] string ContainerNum,
		[Optional] string StartingSerial,
		[Optional] string EndingSerial,
		[Optional] string TrcTrans)
		{
			var iSerialLoadExt = new SerialLoadFactory().Create(this, true);
			
			var result = iSerialLoadExt.SerialLoadSp(SerialLike,
			TransType,
			WhseType,
			Stat,
			RestoreLoss,
			JmtRETURN,
			Item,
			Whse,
			Loc,
			Lot,
			DoNum,
			DoLine,
			TrnNum,
			TrnLine,
			RsvdNum,
			RefNum,
			RefLine,
			RefRelease,
			Site,
			ImportDocId,
			PreassignSerials,
			ContainerNum,
			StartingSerial,
			EndingSerial,
			TrcTrans);
			
			IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
			
			DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
			return dt;
		}

	}
}
