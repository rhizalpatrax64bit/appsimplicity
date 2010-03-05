Namespace ActiveRecord
    ''' <summary>
    '''The objects from this class store the physical values of each column of a record in the database.
    ''' </summary>
    Public Class DataValue

        Private _Column As SchemaColumn
        ''' <summary>
        ''' Contains the definition of the column of the table in the database
        ''' </summary>
        Public ReadOnly Property Column() As SchemaColumn
            Get
                Return _Column
            End Get
        End Property

        ''' <summary>
        ''' Gets the data stored without any processing
        ''' </summary>        
        Public ReadOnly Property UnderlyingValue() As Object
            Get
                If (_Value Is Nothing) Then
                    Return System.DBNull.Value
                End If
                Return _Value
            End Get
        End Property

        Private _Value As Object
        ''' <summary>
        ''' Sets or gets the value stored in the column.  Where the value of the physical 
        ''' table contains a System.DbNull value, Nothing will be returned to the property.        
        ''' </summary>
        ''' <value>If value is a string value, the maximum value will be validated</value>
        ''' <returns>Returns the value stored</returns>
        Public Property Value() As Object
            Get
                If (_Value Is System.DBNull.Value) Then
                    If (Me.Column.IsDate) Then
                        Return Nothing
                    End If

                    If (Me.Column.IsText) Then
                        Return String.Empty
                    End If

                    If (Me.Column.IsNumeric) Then
                        Return 0
                    End If

                    If (Me.Column.DataType = DbType.Boolean) Then
                        Return False
                    End If

                    Return Nothing
                End If

                Return _Value
            End Get
            Set(ByVal value As Object)
                If (_Column.IsText) Then
                    If (TypeOf (value) Is System.String) Then
                        If (CType(value, System.String).Length > _Column.MaxLength) Then
                            Throw New Exception(String.Format(My.Resources.ExceptionMessages.MaxLenghtExceeded, _Column.ColumnName))
                        End If
                    End If
                End If

                If (value Is Nothing) Then
                    value = System.DBNull.Value
                End If

                _Value = value
            End Set
        End Property

        ''' <summary>
        ''' Determines whether the stored value is a null value
        ''' </summary>
        Public ReadOnly Property IsDBNull() As Boolean
            Get
                If (_Value Is System.DBNull.Value) Then
                    Return True
                End If
                Return False
            End Get
        End Property



        ''' <summary>
        ''' Gets the name of current user's identity
        ''' </summary>        
        Private Function GetIdentityName() As String
            Dim lReturnValue As String = "Anonymous"

            If (System.Web.HttpContext.Current Is Nothing) Then
                lReturnValue = System.Threading.Thread.CurrentPrincipal.Identity.Name
            Else
                lReturnValue = System.Web.HttpContext.Current.User.Identity.Name
            End If

            Return lReturnValue
        End Function

        Public Enum AuditType
            Identity
            DateInfo
            None
        End Enum

        ''' <summary>
        ''' Gets the corresponding parameter for a data access operation
        ''' </summary>
        ''' <returns>Returns the instance of the parameter</returns>
        Public Function GetCommandParameter(Optional ByVal pAuditType As AuditType = AuditType.None) As DataAccess.DataCommandParameter
            Dim lParameter As New DataAccess.DataCommandParameter

            lParameter.Name = Me.Column.Schema.DataService.Dialect.Get_ParameterName(Me.Column)

            Select Case (pAuditType)
                Case AuditType.Identity
                    lParameter.Value = GetIdentityName()

                Case AuditType.DateInfo
                    lParameter.Value = Date.Now

                Case AuditType.None
                    lParameter.Value = Me.UnderlyingValue

            End Select

            Return lParameter
        End Function

#Region ".ctors"
        ''' <summary>
        '''Initializes the object's value with the column definition
        ''' </summary>
        ''' <param name="pColumn">Requires a TableColumn object to be instantiated</param>
        Public Sub New(ByVal pColumn As SchemaColumn)
            Me._Column = pColumn
            Me._Value = System.DBNull.Value
        End Sub
#End Region

    End Class

End Namespace
