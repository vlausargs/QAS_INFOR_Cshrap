Option Explicit On
Option Strict On

Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.IDO.DataAccess
Imports Mongoose.Core.Common
Imports System.Xml
Imports System.Messaging.MessageQueue

<IDOExtensionClass("SLBomListing")> _
Public Class SLBomListing
    Inherits ExtensionClassBase

    'load job_sch
    Sub AddJobSchData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal curNode As XmlNode)
        Dim Filter As String
        Dim iRow As Integer
        Dim oCollection As LoadCollectionResponseData

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix

        oCollection = Me.Context.Commands.LoadCollection("SL.SLJobSchs", "StartDate", Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJobSchs")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("StartDate")
            newElement.InnerText = CStr(Now)
            newNode.AppendChild(newElement)
        Next 'Again, should iterate only once

    End Sub

    'load jobitem
    Sub AddJobitemData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal curNode As XmlNode)
        Dim Filter As String
        Dim oCollection As LoadCollectionResponseData

        Dim newElement As XmlElement
        Dim newNode As XmlNode
        Dim iRow As Integer

        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix
        oCollection = Me.Context.Commands.LoadCollection("SL.SLJobitems", "Item, Ratio1, QtyReleased", _
            Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJobitems")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("Item")
            newElement.InnerText = oCollection.Item(iRow, "Item").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Ratio1")
            newElement.InnerText = oCollection.Item(iRow, "Ratio1").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("QtyReleased")
            newElement.InnerText = oCollection.Item(iRow, "QtyReleased").GetValue(Of String)()
            newNode.AppendChild(newElement)
        Next

    End Sub

    Sub AddJobrouteData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal curNode As XmlNode)
        Dim Filter As String
        Dim PropertyList As String
        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        'load jobroute
        PropertyList = "RowPointer, OperNum, Wc, CntrlPoint, EffectDate, ObsDate, BflushType, Efficiency, SetupRate, RunRateLbr, FixovhdRate,"
        PropertyList = PropertyList & "VarovhdRate, FovhdRateMch, VovhdRateMch, RunBasisLbr, RunBasisMch, NoteExistsFlag"

        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix
        oCollection = Me.Context.Commands.LoadCollection("SL.SLJobRoutes", PropertyList, Filter, "", 0)

        'process collection
        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJobRoutes")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("OperNum")
            newElement.InnerText = oCollection.Item(iRow, "OperNum").GetValue(Of String)()
            newElement.SetAttribute("Key", "1")
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Wc")
            newElement.InnerText = oCollection.Item(iRow, "Wc").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("CntrlPoint")
            newElement.InnerText = oCollection.Item(iRow, "CntrlPoint").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("EffectDate")
            newElement.InnerText = oCollection.Item(iRow, "EffectDate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("ObsDate")
            newElement.InnerText = oCollection.Item(iRow, "ObsDate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("BflushType")
            newElement.InnerText = oCollection.Item(iRow, "BflushType").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Efficiency")
            newElement.InnerText = oCollection.Item(iRow, "Efficiency").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("SetupRate")
            newElement.InnerText = oCollection.Item(iRow, "SetupRate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("RunRateLbr")
            newElement.InnerText = oCollection.Item(iRow, "RunRateLbr").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("FixovhdRate")
            newElement.InnerText = oCollection.Item(iRow, "FixovhdRate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("VarovhdRate")
            newElement.InnerText = oCollection.Item(iRow, "VarOvhdRate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("FovhdRateMch")
            newElement.InnerText = oCollection.Item(iRow, "FovhdRateMch").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("VovhdRateMch")
            newElement.InnerText = oCollection.Item(iRow, "VovhdRateMch").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("RunBasisLbr")
            newElement.InnerText = oCollection.Item(iRow, "RunBasisLbr").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("RunBasisMch")
            newElement.InnerText = oCollection.Item(iRow, "RunBasisMch").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("NoteExistsFlag")
            newElement.InnerText = oCollection.Item(iRow, "NoteExistsFlag").GetValue(Of String)()
            newNode.AppendChild(newElement)

            AddNotes("jobroute", oCollection.Item(iRow, "RowPointer").GetValue(Of String)(), newNode)
            AddJrtSchData(FromJob, FromSuffix, oCollection.Item(iRow, "OperNum").GetValue(Of String)(), newNode)
            AddJrtResourceGroupData(FromJob, FromSuffix, oCollection.Item(iRow, "OperNum").GetValue(Of String)(), newNode)
            AddJrtItemsData(FromJob, FromSuffix, oCollection.Item(iRow, "OperNum").GetValue(Of String)(), newNode)
            AddJobmatlData(FromJob, FromSuffix, oCollection.Item(iRow, "OperNum").GetValue(Of String)(), newNode)
        Next

    End Sub
    Sub AddJrtSchData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal pOperNum As String, ByVal curNode As XmlNode)
        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer

        Dim Filter As String
        Dim PropertyList As String

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        'load jrt_sch
        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix & " and OperNum = " & pOperNum
        PropertyList = "PcsPerLbrHr, PcsPerMchHr, SetupHrs, MoveHrs, QueueHrs, RunLbrHrs,"
        PropertyList = PropertyList & "RunMchHrs, FinishHrs, Setuprgid, Whenrule, Matrixtype, Setuprule,"
        PropertyList = PropertyList & "Tabid, Schedsteprule, Splitsize, Plannerstep, Crsbrkrule, SchedDrv"

        oCollection = Me.Context.Commands.LoadCollection("SL.SLJrtSchs", PropertyList, Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJrtSchs")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("PcsPerLbrHr")
            newElement.InnerText = oCollection.Item(iRow, "PcsPerLbrHr").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("PcsPerMchHr")
            newElement.InnerText = oCollection.Item(iRow, "PcsPerMchHr").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("SetupHrs")
            newElement.InnerText = oCollection.Item(iRow, "SetupHrs").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("MoveHrs")
            newElement.InnerText = oCollection.Item(iRow, "MoveHrs").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("QueueHrs")
            newElement.InnerText = oCollection.Item(iRow, "QueueHrs").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("RunLbrHrs")
            newElement.InnerText = oCollection.Item(iRow, "RunLbrHrs").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("RunMchHrs")
            newElement.InnerText = oCollection.Item(iRow, "RunMchHrs").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("FinishHrs")
            newElement.InnerText = oCollection.Item(iRow, "FinishHrs").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Setuprgid")
            newElement.InnerText = oCollection.Item(iRow, "Setuprgid").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Whenrule")
            newElement.InnerText = oCollection.Item(iRow, "Whenrule").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Matrixtype")
            newElement.InnerText = oCollection.Item(iRow, "Matrixtype").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Setuprule")
            newElement.InnerText = oCollection.Item(iRow, "Setuprule").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Tabid")
            newElement.InnerText = oCollection.Item(iRow, "Tabid").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Schedsteprule")
            newElement.InnerText = oCollection.Item(iRow, "Schedsteprule").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Splitsize")
            newElement.InnerText = oCollection.Item(iRow, "Splitsize").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Plannerstep")
            newElement.InnerText = oCollection.Item(iRow, "Plannerstep").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Crsbrkrule")
            newElement.InnerText = oCollection.Item(iRow, "Crsbrkrule").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("SchedDrv")
            newElement.InnerText = oCollection.Item(iRow, "SchedDrv").GetValue(Of String)()
            newNode.AppendChild(newElement)
        Next

    End Sub
    Sub AddJrtResourceGroupData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal pOperNum As String, ByVal curNode As XmlNode)
        Dim Filter As String

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer
        'load JrtResourceGroup
        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix & " and OperNum = " & pOperNum

        oCollection = Me.Context.Commands.LoadCollection("SL.SLJrtResourceGroups", "Rgid, QtyResources, Resactn", _
            Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJrtResourceGroups")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("Rgid")
            newElement.InnerText = oCollection.Item(iRow, "Rgid").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("QtyResources")
            newElement.InnerText = oCollection.Item(iRow, "QtyResources").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Resactn")
            newElement.InnerText = oCollection.Item(iRow, "Resactn").GetValue(Of String)()
            newNode.AppendChild(newElement)
        Next

    End Sub

    Sub AddJrtItemsData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal pOperNum As String, ByVal curNode As XmlNode)
        Dim Filter As String

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer

        'load JrtItems
        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix & " and OperNum = " & pOperNum

        oCollection = Me.Context.Commands.LoadCollection("SL.SLJrtItems", "Item, LaborPct, MachPct, MaterialPct", _
            Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJrsItems")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("Item")
            newElement.InnerText = oCollection.Item(iRow, "Item").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("LaborPct")
            newElement.InnerText = oCollection.Item(iRow, "LaborPct").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("MachPct")
            newElement.InnerText = oCollection.Item(iRow, "MachPct").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("MaterialPct")
            newElement.InnerText = oCollection.Item(iRow, "MaterialPct").GetValue(Of String)()
            newNode.AppendChild(newElement)
        Next
    End Sub

    Sub AddJobmatlData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal pOperNum As String, ByVal curNode As XmlNode)
        Dim PropertyList As String
        Dim Filter As String

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer

        'load jobmatl
        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix & " and OperNum = " & pOperNum
        PropertyList = "RowPointer, Sequence, MatlType, Item, Description, MatlQtyConv, UM, Units, EffectDate, ObsDate, ScrapFact,"
        PropertyList = PropertyList & "BomSeq, Backflush, BflushLoc, Fmatlovhd, Vmatlovhd, CostConv, MatlCostConv,"
        PropertyList = PropertyList & "LbrCostConv, FovhdCostConv, VovhdCostConv, OutCostConv, Feature, Probable,"
        PropertyList = PropertyList & "OptCode, IncPriceConv, NoteExistsFlag, AltGroup, AltGroupRank"

        oCollection = Me.Context.Commands.LoadCollection("SL.SLJobmatls", PropertyList, Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJobmatls")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("Sequence")
            newElement.InnerText = oCollection.Item(iRow, "Sequence").GetValue(Of String)()
            newElement.SetAttribute("Key", "1")
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("MatlType")
            newElement.InnerText = oCollection.Item(iRow, "MatlType").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Item")
            newElement.InnerText = oCollection.Item(iRow, "Item").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Description")
            newElement.InnerText = oCollection.Item(iRow, "Description").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("MatlQtyConv")
            newElement.InnerText = oCollection.Item(iRow, "MatlQtyConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("UM")
            newElement.InnerText = oCollection.Item(iRow, "UM").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Units")
            newElement.InnerText = oCollection.Item(iRow, "Units").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("EffectDate")
            newElement.InnerText = oCollection.Item(iRow, "EffectDate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("ObsDate")
            newElement.InnerText = oCollection.Item(iRow, "ObsDate").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("ScrapFact")
            newElement.InnerText = oCollection.Item(iRow, "ScrapFact").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("BomSeq")
            newElement.InnerText = oCollection.Item(iRow, "BomSeq").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Backflush")
            newElement.InnerText = oCollection.Item(iRow, "Backflush").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("BflushLoc")
            newElement.InnerText = oCollection.Item(iRow, "BflushLoc").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Fmatlovhd")
            newElement.InnerText = oCollection.Item(iRow, "Fmatlovhd").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Vmatlovhd")
            newElement.InnerText = oCollection.Item(iRow, "Vmatlovhd").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("CostConv")
            newElement.InnerText = oCollection.Item(iRow, "CostConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("MatlCostConv")
            newElement.InnerText = oCollection.Item(iRow, "MatlCostConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("LbrCostConv")
            newElement.InnerText = oCollection.Item(iRow, "LbrCostConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("FovhdCostConv")
            newElement.InnerText = oCollection.Item(iRow, "FovhdCostConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("VovhdCostConv")
            newElement.InnerText = oCollection.Item(iRow, "VovhdCostConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("OutCostConv")
            newElement.InnerText = oCollection.Item(iRow, "OutCostConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Feature")
            newElement.InnerText = oCollection.Item(iRow, "Feature").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Probable")
            newElement.InnerText = oCollection.Item(iRow, "Probable").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("OptCode")
            newElement.InnerText = oCollection.Item(iRow, "OptCode").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("IncPriceConv")
            newElement.InnerText = oCollection.Item(iRow, "IncPriceConv").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("NoteExistsFlag")
            newElement.InnerText = oCollection.Item(iRow, "NoteExistsFlag").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("AltGroup")
            newElement.InnerText = oCollection.Item(iRow, "AltGroup").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("AltGroupRank")
            newElement.InnerText = oCollection.Item(iRow, "AltGroupRank").GetValue(Of String)()
            newNode.AppendChild(newElement)

            AddNotes("jobmatl", oCollection.Item(iRow, "RowPointer").GetValue(Of String)(), newNode)
            AddJobrefData(FromJob, FromSuffix, pOperNum, oCollection.Item(iRow, "Sequence").GetValue(Of String), newNode)
        Next
    End Sub

    'load job_ref
    Sub AddJobrefData(ByVal FromJob As String, ByVal FromSuffix As String, ByVal pOperNum As String, ByVal pSequence As String, ByVal curNode As XmlNode)
        Dim Filter As String

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer

        Filter = "Job = '" & FromJob & "' and Suffix = " & FromSuffix & " and OperNum = " & pOperNum & " and Sequence = " & pSequence

        oCollection = Me.Context.Commands.LoadCollection("SL.SLJobRefs", "RefSeq, RefDes, Bubble, AssySeq", _
            Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLJobRefs")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("RefSeq")
            newElement.InnerText = oCollection.Item(iRow, "RefSeq").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("RefDes")
            newElement.InnerText = oCollection.Item(iRow, "RefDes").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("Bubble")
            newElement.InnerText = oCollection.Item(iRow, "Bubble").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("AssySeq")
            newElement.InnerText = oCollection.Item(iRow, "AssySeq").GetValue(Of String)()
            newNode.AppendChild(newElement)
        Next
    End Sub

    Sub AddNotes(ByVal Table As String, ByVal RefRowPointer As String, ByVal curNode As XmlNode)
        Dim Filter As String

        Dim newElement As XmlElement
        Dim newNode As XmlNode

        Dim oCollection As LoadCollectionResponseData
        Dim iRow As Integer

        Filter = "NhObjectName = '" & Table & "' and RefRowPointer = '" & RefRowPointer & "'"
        oCollection = Me.Context.Commands.LoadCollection("SL.SLObjectNotes", "SpcnNoteDesc, SpcnNoteContent, NhNoteFlag", _
            Filter, "", 0)

        For iRow = 0 To oCollection.Items.Count - 1
            newNode = curNode.OwnerDocument.CreateElement("SLObjectNotes")
            curNode.AppendChild(newNode)

            newElement = newNode.OwnerDocument.CreateElement("SpcnNoteDesc")
            newElement.InnerText = oCollection.Item(iRow, "SpcnNoteDesc").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("SpcnNoteContent")
            newElement.InnerText = oCollection.Item(iRow, "SpcnNoteContent").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("NhNoteFlag")
            newElement.InnerText = oCollection.Item(iRow, "NhNoteFlag").GetValue(Of String)()
            newNode.AppendChild(newElement)

            newElement = newNode.OwnerDocument.CreateElement("NhObjectName")
            newElement.InnerText = Table
            newNode.AppendChild(newElement)
        Next
    End Sub

    Private Function GetFormName() As String
        Dim oDataReader As IDataReader = Nothing

        GetFormName = ""
        Using appDB As ApplicationDB = IDORuntime.Context.CreateApplicationDB()
            Using Cmd As IDbCommand = appDB.CreateCommand()
                Try
                    Cmd.CommandType = CommandType.Text
                    Cmd.CommandText = "SELECT FormName=dbo.GetFormName()"
                    ' execute the command through the framework
                    oDataReader = appDB.ExecuteReader(Cmd)
                    If oDataReader.Read() Then
                        GetFormName = oDataReader.Item("FormName").ToString
                    End If
                Catch ex As Exception
                    MGException.Throw(MGException.ExtractMessages(ex))
                Finally
                    If oDataReader IsNot Nothing AndAlso Not oDataReader.IsClosed Then
                        oDataReader.Close()
                    End If
                End Try
            End Using
        End Using
    End Function
End Class
