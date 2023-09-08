using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace CSI.ExternalContracts.Portals
{
    public interface IFSIncidents
    {
        int SSSFSPortalCreateIncidentSp(string CustNum, int? CustSeq, string Username, string SerNum, string Item, string Site, string PriorCode, string Contact, string Phone, string FaxNum, string Email, string Description, string IncNotes, [Optional][DefaultParameterValue((byte)0)] byte? Validate, ref string IncNum, ref string Infobar);

        int SSSFSPortalValidateIncidentRequestSp(string CustNum, string CustSeq, string Username, string SerNum, string Item, string Site, string PriorCode, ref string Infobar);
    }

}
