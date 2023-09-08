//PROJECT NAME: DataCollectionExt
//CLASS NAME: SLTimeatts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.DataCollection;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.DataCollection
{
    [IDOExtensionClass("SLTimeatts")]
    public class SLTimeatts : ExtensionClassBase
    {
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TimeatDSp(string Status,
		                     string TransType,
		                     string FROMEmpNum,
		                     string ToEmpNum,
		                     decimal? FROMTransNum,
		                     decimal? ToTransNum,
		                     DateTime? FROMTransDate,
		                     DateTime? ToTransDate,
		                     DateTime? FROMPostDate,
		                     DateTime? ToPostDate,
		                     ref string Infobar,
		                     [Optional] short? StartingTransDateOffset,
		                     [Optional] short? EndingTransDateOffset,
		                     [Optional] short? StartingPostDateOffset,
		                     [Optional] short? EndingPostDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTimeatDExt = new TimeatDFactory().Create(appDb);
				
				var result = iTimeatDExt.TimeatDSp(Status,
				                                   TransType,
				                                   FROMEmpNum,
				                                   ToEmpNum,
				                                   FROMTransNum,
				                                   ToTransNum,
				                                   FROMTransDate,
				                                   ToTransDate,
				                                   FROMPostDate,
				                                   ToPostDate,
				                                   Infobar,
				                                   StartingTransDateOffset,
				                                   EndingTransDateOffset,
				                                   StartingPostDateOffset,
				                                   EndingPostDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TimeattDelSp(Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTimeattDelExt = new TimeattDelFactory().Create(appDb);
				
				var result = iTimeattDelExt.TimeattDelSp(RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int TimeattUpdSp(string Shift,
		DateTime? PostDate,
		DateTime? PostTime,
		Guid? RowPointer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iTimeattUpdExt = new TimeattUpdFactory().Create(appDb);
				
				var result = iTimeattUpdExt.TimeattUpdSp(Shift,
				PostDate,
				PostTime,
				RowPointer);
				
				int Severity = result.Value;
				return Severity;
			}
		}
    }
}
