Namespace ActiveRecord
    Public Interface IActiveRecord

        Event OnBeforeSave(ByRef e As DataOperationEventArgs)

        Event OnBeforeCreate(ByRef e As DataOperationEventArgs)

        Event OnBeforeUpdate(ByRef e As DataOperationEventArgs)

        Event OnBeforeDelete(ByRef e As DataOperationEventArgs)

        Event OnAfterSave()

        Event OnAfterCreate()

        Event OnAfterUpdate()

        Event OnAfterDelete()

        Function Get_INSERT_Parameters() As List(Of DataAccess.DataCommandParameter)

        Function Get_UPDATE_Parameters() As List(Of DataAccess.DataCommandParameter)

        Function Get_DELETE_Parameters() As List(Of DataAccess.DataCommandParameter)

        Function GetSchema() As ActiveRecord.Schema

        Sub Save()

        Sub Create()

        Sub Update()

        Sub Delete()

        Sub SetId(ByVal pId As Object)

    End Interface

    Public Class DataOperationEventArgs
        Inherits EventArgs

        Private _PerformOperation As Boolean

        ''' <summary>
        ''' This property determines whether to perform the physical write operation
        ''' </summary>        
        Public Property PerformOperation() As Boolean
            Get
                Return _PerformOperation
            End Get
            Set(ByVal value As Boolean)
                _PerformOperation = value
            End Set
        End Property

        Public Sub New()
            _PerformOperation = True
        End Sub

    End Class
End Namespace

