Public Interface IAuditable

    Property CreatedOn As Nullable(Of DateTime)
    Property CreatedBy As String

    Property ModifiedOn As Nullable(Of DateTime)
    Property ModifiedBy As String

End Interface
