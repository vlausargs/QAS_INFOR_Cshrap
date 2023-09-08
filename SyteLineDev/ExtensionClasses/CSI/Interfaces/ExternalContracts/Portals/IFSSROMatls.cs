using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IFSSROMatls
    {
        int SSSFSPortalCreateSROMatlSp(string SroNum, int? SroLine, int? SroOper, string PartnerID, DateTime? TransDate, string CustNum, string CustSeq, string Username, string Item, string MatlDescription, string UM, decimal? QtyConv, string NoteContent, [Optional][DefaultParameterValue((byte)0)] byte? Validate, ref Guid? RowPointer, ref string Infobar);

        int SSSFSPortalValidateSROMatlSp(string SroNum, int? SroLine, int? SroOper, string PartnerID, DateTime? TransDate, string CustNum, string CustSeq, string Username, string Item, string UM, ref string Infobar);
    }
}
