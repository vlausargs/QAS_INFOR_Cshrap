Public Class SubConfigurationMap

    Private _componentId As Integer
    Public Property ComponentId() As Integer
        Get
            Return _componentId
        End Get
        Set(ByVal value As Integer)
            _componentId = value
        End Set
    End Property

    Private _configId As String
    Public Property ConfigId() As String
        Get
            Return _configId
        End Get
        Set(ByVal value As String)
            _configId = value
        End Set
    End Property

    Private _configModel As String
    Public Property ConfigModel() As String
        Get
            Return _configModel
        End Get
        Set(ByVal value As String)
            _configModel = value
        End Set
    End Property

    Private _item As String
    Public Property Item() As String
        Get
            Return _item
        End Get
        Set(ByVal value As String)
            _item = value
        End Set
    End Property

    Private _parentComponentId As Integer
    Public Property ParentComponentId() As Integer
        Get
            Return _parentComponentId
        End Get
        Set(ByVal value As Integer)
            _parentComponentId = value
        End Set
    End Property



End Class
