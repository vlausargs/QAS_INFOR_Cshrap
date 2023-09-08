Imports Mongoose.IDO
Imports Mongoose.IDO.Protocol
Imports Mongoose.Core.Common
Imports System.Collections.Generic
Imports System.Net
Imports System.IO
Imports Mongoose.IDO.DataAccess
Imports CSI.MG
Imports CSI.Admin
Imports System.Runtime.InteropServices

<IDOExtensionClass("SLDocumentObjectAndRefExtViews")> _
Public Class SLDocumentObjectAndRefExtViews
    Inherits ExtensionClassBase
    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function CU_DocumentsCa(
            ByVal TableName As String,
            ByVal RefRowPointer As String,
            ByVal DocumentName As String,
            ByVal DocumentDescr As String,
            ByVal DocumentType As String,
            ByVal DocumentExtension As String,
            ByVal MediaType As String,
            ByVal Internal As Byte,
            ByVal FileURL As String,
            ByVal TxtFileContent As String,
            ByVal Revision As String,
            ByVal Status As String,
            ByVal EffStartDate As DateTime?,
            ByVal EffEndDate As DateTime?,
            ByVal IsExternal As Byte,
            ByRef InfoBar As String) As Integer

        Dim Severity As String = String.Empty
        Dim InsertFlag As String = String.Empty
        Dim DocObjRowPointer As String = String.Empty
        Dim NewRowPointer As String = String.Empty
        Dim FileBinary As Byte() = Nothing

        DocObjRowPointer = GetDocObjectRowPointer(TableName, DocumentName, RefRowPointer)

        If String.IsNullOrEmpty(DocObjRowPointer) Then
            InsertFlag = "1"
        Else
            InsertFlag = "0"
        End If

        If String.IsNullOrEmpty(DocumentName) Then
            InfoBar = "CU_DocumentsCa Programmer Error: " + Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoCompare", "@DocumentObject.DocumentName", "@!blank")
            Throw New MGException(InfoBar)
        End If

        If String.IsNullOrEmpty(DocumentType) Then
            InfoBar = "CU_DocumentsCa Programmer Error: " + Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoCompare", "@DocumentObject.DocumentType", "@!blank")
            Throw New MGException(InfoBar)
        End If

        If String.IsNullOrEmpty(Status) Then
            InfoBar = "CU_DocumentsCa Programmer Error: " + Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoCompare", "@document_object_ext.status", "@!blank")
            Throw New MGException(InfoBar)
        End If

        If 0 = InStr("PAR", Status) Then
            InfoBar = "CU_DocumentsCa Programmer Error: " + Me.CreateAppDB.GetMessageProvider.GetMessage("E=NoCompare", "@document_object_ext.status", Status)
            Throw New MGException(InfoBar)
        End If

        If FileURL <> String.Empty Then
            FileBinary = GetFile(FileURL)
        ElseIf TxtFileContent <> String.Empty Then
            FileBinary = Convert.FromBase64String(TxtFileContent)
        End If

        ' Perform INSERT OR UPDATE
        If InsertFlag = "1" Then
            Dim Sequence As Integer
            Dim RefSequence As Integer

            If IsObjectDocumentExist(DocumentName) = True Then
                Sequence = GetObjectSequence(DocumentName)
            Else
                Sequence = 1
            End If

            If IsObjectDocumentReferenceExist(TableName, RefRowPointer) = True Then
                RefSequence = GetObjectRefSequence(TableName, RefRowPointer)
            Else
                RefSequence = 1
            End If

            NewRowPointer = GetNewID()

            Try
                'Insert Into SLDocumentObjects 
                Dim insertItem3 As New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 1
                }
                insertItem3.Properties.Add("DocumentName", DocumentName, True)
                insertItem3.Properties.Add("Sequence", Sequence, True)
                insertItem3.Properties.Add("Description", DocumentDescr, True)
                insertItem3.Properties.Add("DocumentType", DocumentType, True)
                insertItem3.Properties.Add("DocumentExtension", DocumentExtension, True)
                insertItem3.Properties.Add("Internal", Internal, True)
                insertItem3.Properties.Add("DocumentObject", FileBinary, True)
                insertItem3.Properties.Add("MediaType", MediaType, True)
                insertItem3.Properties.Add("RowPointer", NewRowPointer, True)

                'Insert Into SLDocumentObjectExts
                Dim insertItem5 As New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 2
                }
                insertItem5.Properties.Add("DocumentObjectRowPointer", NewRowPointer, True)
                insertItem5.Properties.Add("Revision", Revision, True)
                insertItem5.Properties.Add("Status", Status.Substring(0, 1), True)
                insertItem5.Properties.Add("EffectiveStartDate", EffStartDate, True)
                insertItem5.Properties.Add("EffectiveEndDate", EffEndDate, True)
                insertItem5.Properties.Add("IsExternal", IsExternal, True)

                Dim insertRequestData5 As New UpdateCollectionRequestData("SLDocumentObjectExts")
                insertRequestData5.Items.Add(insertItem5)
                insertRequestData5.SetLinkBy("RowPointer", "DocumentObjectRowPointer")

                Dim insertRequestData3 As New UpdateCollectionRequestData("SLDocumentObjects")
                insertRequestData3.Items.Add(insertItem3)
                insertRequestData3.Items(0).AddNestedUpdate(insertRequestData5)
                Me.Context.Commands.UpdateCollection(insertRequestData3)

                'Insert Into SLDocumentObjectReferences 
                Dim insertItem2 As New IDOUpdateItem With {
                    .Action = UpdateAction.Insert,
                    .ItemNumber = 1
                }
                insertItem2.Properties.Add("TableName", TableName)
                insertItem2.Properties.Add("TableRowPointer", RefRowPointer)
                insertItem2.Properties.Add("RefSequence", RefSequence)
                insertItem2.Properties.Add("DocumentObjectRowPointer", NewRowPointer)
                Dim insertRequestData2 As New UpdateCollectionRequestData("SLDocumentObjectReferences")
                insertRequestData2.Items.Add(insertItem2)
                Me.Context.Commands.UpdateCollection(insertRequestData2)

                insertItem3 = Nothing
                insertItem5 = Nothing
                insertRequestData5 = Nothing
                insertRequestData3 = Nothing
                insertItem2 = Nothing
                insertRequestData2 = Nothing

            Catch ex As Exception
                InfoBar = ex.Message.ToString() + " Failed to Insert to SLDocumentObjectExts and SLDocumentObjects"
                Throw New MGException(InfoBar)
            End Try
        Else
            'Perform Update
            Try

                Dim loadResponseCollection As New LoadCollectionResponseData()
                Dim propertyList1 As New PropertyList()
                propertyList1.Add("RowPointer")
                Dim loadResponseCollection5 As New LoadCollectionResponseData()
                Dim propertyList5 As New PropertyList()
                propertyList5.Add("DocumentObjectRowPointer")

                Dim filter As String = String.Format("RowPointer = '{0}'", DocObjRowPointer)
                Dim filter5 As String = String.Format("DocumentObjectRowPointer = '{0}'", DocObjRowPointer)

                loadResponseCollection = Me.Context.Commands.LoadCollection("SLDocumentObjects", propertyList1, filter, String.Empty, 0)
                loadResponseCollection5 = Me.Context.Commands.LoadCollection("SLDocumentObjectExts", propertyList5, filter5, String.Empty, 0)

                Dim updateRequest As New UpdateCollectionRequestData("SLDocumentObjects")
                Dim updateRequest5 As New UpdateCollectionRequestData("SLDocumentObjectExts")

                For Each item As IDOItem In loadResponseCollection.Items

                    Dim updateItem As New IDOUpdateItem With {
                        .Action = UpdateAction.Update,
                        .ItemNumber = 1,
                        .ItemID = item.ItemID
                    }
                    'updateItem.Properties.Add("DocumentName", DocumentName); //may not be modified
                    updateItem.Properties.Add("DocumentType", DocumentType)
                    updateItem.Properties.Add("DocumentExtension", DocumentExtension)
                    updateItem.Properties.Add("DocumentObject", FileBinary)
                    updateRequest.Items.Add(updateItem)

                    Me.Context.Commands.UpdateCollection(updateRequest)
                Next
                ' flush now because SLDocumentObjectExts is a sub collection of SLDocumentObjects 
                ' and might overwrite the next code with delayed garbage collection.
                updateRequest = Nothing
                loadResponseCollection = Nothing
                propertyList1 = Nothing

                For Each item As IDOItem In loadResponseCollection5.Items

                    Dim updateItem5 As New IDOUpdateItem With {
                        .Action = UpdateAction.Update,
                        .ItemNumber = 1,
                        .ItemID = item.ItemID
                    }
                    updateItem5.Properties.Add("Revision", Revision)

                    updateRequest5.Items.Add(updateItem5)

                    Me.Context.Commands.UpdateCollection(updateRequest5)
                Next

                updateRequest5 = Nothing
                loadResponseCollection5 = Nothing
                propertyList5 = Nothing

            Catch ex As Exception
                InfoBar = ex.Message.ToString() + " Failed To Update SLDocumentObjects/SLDocumentObjectExts"
                Throw New MGException(InfoBar)
            End Try
        End If
        Return 0
    End Function
    Private Shared Function IsValidUrl(ByVal urlString As String) As Boolean
        Dim uri__1 As Uri = Nothing
        Return Uri.TryCreate(urlString, UriKind.Absolute, uri__1) AndAlso (uri__1.Scheme = Uri.UriSchemeHttp OrElse uri__1.Scheme = Uri.UriSchemeHttps OrElse uri__1.Scheme = Uri.UriSchemeFtp OrElse uri__1.Scheme = Uri.UriSchemeMailto)

    End Function

    Public Function GetNewID() As String
        Dim NewGuid As Guid
        NewGuid = Guid.NewGuid()
        Return NewGuid.ToString()
    End Function

    Public Function GetObjectSequence(ByVal DocumentName As String) As Integer
        Dim TempValue As Integer = 1
        Dim IsParsed As Boolean = False

        Dim propList As New PropertyList(New [String]() {"Sequence"})
        Dim idoName As String = "SLDocumentObjects"
        Dim filter As String = String.Format("DocumentName = '{0}'", DocumentName)
        Dim recordCap As Integer = 1

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, "Sequence desc", recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            IsParsed = Integer.TryParse(DocumentObjectRefView.Items(0).PropertyValues(0).GetValue(Of String)(), TempValue)
        End If

        If IsParsed Then
            TempValue += 1
        Else
            TempValue = 1
        End If

        Return TempValue
    End Function

    Public Function GetObjectRefSequence(ByVal TableName As String, ByVal RefRowPointer As String) As Integer
        Dim TempValue As Integer = 1
        Dim IsParsed As Boolean = False

        Dim propList As New PropertyList(New [String]() {"RefSequence"})
        Dim idoName As String = "SLDocumentObjectReferences"
        Dim filter As String = String.Format("TableName = '{0}' and TableRowPointer = '{1}'", TableName, RefRowPointer)
        Dim recordCap As Integer = 1
        Dim orderby As String = "TableName, TableRowPointer, RefSequence DESC"

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, orderby, recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            IsParsed = Integer.TryParse(DocumentObjectRefView.Items(0).PropertyValues(0).GetValue(Of String)(), TempValue)
        End If

        If IsParsed Then
            TempValue += 1
        Else
            TempValue = 1
        End If

        Return TempValue
    End Function

    Public Function IsObjectDocumentExist(ByVal DocumentName As String) As Boolean
        Dim ReturnValue As Boolean = False

        Dim propList As New PropertyList(New [String]() {"DocumentName"})
        Dim idoName As String = "SLDocumentObjects"
        Dim filter As String = String.Format("DocumentName = '{0}'", DocumentName)
        Dim recordCap As Integer = 1

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, String.Empty, recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            ReturnValue = True
        End If

        Return ReturnValue
    End Function

    Public Function IsObjectDocumentReferenceExist(ByVal TableName As String, ByVal RefRowPointer As String) As Boolean
        Dim ReturnValue As Boolean = False

        Dim propList As New PropertyList(New [String]() {"TableName", "TableRowPointer"})
        Dim idoName As String = "SLDocumentObjectReferences"
        Dim filter As String = String.Format("TableName = '{0}' and TableRowPointer = '{1}'", TableName, RefRowPointer)
        Dim recordCap As Integer = 1

        Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, String.Empty, recordCap)

        If DocumentObjectRefView.Items.Count > 0 Then
            ReturnValue = True
        End If

        Return ReturnValue
    End Function

    Public Function GetDocObjectRowPointer(ByVal TableName As String, ByVal DocumentName As String, ByVal TableRowPointer As String) As String
        Dim tempString As String = String.Empty
        Try
            Dim propList As New PropertyList(New [String]() {"RowPointer"})
            Dim idoName As String = "SLDocumentObjectAndReferences"
            Dim filter As String = String.Format("TableName = '{0}' and DocumentName = '{1}' and TableRowPointer = '{2}'", TableName, DocumentName, TableRowPointer)
            Dim recordCap As Integer = 1

            Dim DocumentObjectRefView As LoadCollectionResponseData = Me.Context.Commands.LoadCollection(idoName, propList, filter, String.Empty, recordCap)

            If DocumentObjectRefView.Items.Count > 0 Then
                tempString = DocumentObjectRefView.Items(0).PropertyValues(0).GetValue(Of String)()
            End If
        Catch generatedExceptionName As Exception
            tempString = String.Empty
        End Try
        Return tempString
    End Function

    Public Function GetFile(ByVal path As String) As Byte()
        Dim IsUNC As Boolean = False
        Dim b As Byte() = Nothing

        IsUNC = IsValidUrl(path)

        If IsUNC = True Then
            Dim myReq As HttpWebRequest = DirectCast(WebRequest.Create(path), HttpWebRequest)
            Dim myResp As WebResponse = myReq.GetResponse()


            Using stream As Stream = myResp.GetResponseStream()
                Using ms As New MemoryStream()
                    Dim count As Integer = 0
                    Do
                        Dim buf As Byte() = New Byte(1023) {}
                        count = stream.Read(buf, 0, 1024)
                        ms.Write(buf, 0, count)
                    Loop While stream.CanRead AndAlso count > 0
                    b = ms.ToArray()
                End Using
            End Using
        Else
            b = File.ReadAllBytes(path)
        End If

        Return b
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function DocumentObjectsPostQuerySp(ByVal DocumentObjectRowPointer As Guid?, ByRef Revision As String, ByRef Status As String, ByRef EffectiveStartDate As DateTime?, ByRef EffectiveEndDate As DateTime?, ByRef IsExternal As Byte?) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iDocumentObjectsPostQueryExt As IDocumentObjectsPostQuery = New DocumentObjectsPostQueryFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, Revision As String, Status As String, EffectiveStartDate As DateTime?, EffectiveEndDate As DateTime?, IsExternal As Integer?) = iDocumentObjectsPostQueryExt.DocumentObjectsPostQuerySp(DocumentObjectRowPointer, Revision, Status, EffectiveStartDate, EffectiveEndDate, IsExternal)
            Dim Severity As Integer = result.ReturnCode.Value
            Revision = result.Revision
            Status = result.Status
            EffectiveStartDate = result.EffectiveStartDate
            EffectiveEndDate = result.EffectiveEndDate
            IsExternal = result.IsExternal
            Return Severity
        End Using
    End Function

    <IDOMethod(MethodFlags.None, "Infobar")>
    Public Function UpdateDocumentObjectAndRefExtViewsSp(ByVal TableName As String, ByVal TableRowPointer As Guid?, ByVal RefSequence As Decimal?, ByRef DocumentObjectRowPointer As Guid?, ByVal RowPointer As Guid?, ByVal DocumentName As String, ByVal Sequence As Decimal?, ByVal Description As String, ByVal DocumentType As String, ByVal DocumentExtension As String, ByVal Internal As Byte?, ByVal Revision As String, ByVal Status As String, ByVal effective_start_date As DateTime?, ByVal effective_end_date As DateTime?, ByVal is_external As Byte?,
<[Optional]> ByVal DocumentObject As Byte(), ByRef Infobar As String) As Integer
        Using MGAppDB As AppDB = Me.CreateAppDB()
            Dim appDb As IApplicationDB = New CSIAppDBFactory().CreateAppDB(MGAppDB, Me.Context, Me.GetMessageProvider())
            Dim mgInvoker As MGInvoker = New MGInvoker(Me.Context)
            Dim iUpdateDocumentObjectAndRefExtViewsExt As IUpdateDocumentObjectAndRefExtViews = New UpdateDocumentObjectAndRefExtViewsFactory().Create(appDb, mgInvoker, New CSI.Data.SQL.SQLParameterProvider(), True)
            Dim result As (ReturnCode As Integer?, DocumentObjectRowPointer As Guid?, Infobar As String) = iUpdateDocumentObjectAndRefExtViewsExt.UpdateDocumentObjectAndRefExtViewsSp(TableName, TableRowPointer, RefSequence, DocumentObjectRowPointer, RowPointer, DocumentName, Sequence, Description, DocumentType, DocumentExtension, Internal, Revision, Status, effective_start_date, effective_end_date, is_external, DocumentObject, Infobar)
            Dim Severity As Integer = result.ReturnCode.Value
            DocumentObjectRowPointer = result.DocumentObjectRowPointer
            Infobar = result.Infobar
            Return Severity
        End Using
    End Function
End Class
