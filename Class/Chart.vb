Imports System

Namespace Chart.Annotations
    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Parameter Or AttributeTargets.[Property] Or AttributeTargets.[Delegate] Or AttributeTargets.Field Or AttributeTargets.[Event])>
    Public NotInheritable Class CanBeNullAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Parameter Or AttributeTargets.[Property] Or AttributeTargets.[Delegate] Or AttributeTargets.Field Or AttributeTargets.[Event])>
    Public NotInheritable Class NotNullAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Parameter Or AttributeTargets.[Property] Or AttributeTargets.[Delegate] Or AttributeTargets.Field)>
    Public NotInheritable Class ItemNotNullAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Parameter Or AttributeTargets.[Property] Or AttributeTargets.[Delegate] Or AttributeTargets.Field)>
    Public NotInheritable Class ItemCanBeNullAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Constructor Or AttributeTargets.Method Or AttributeTargets.[Property] Or AttributeTargets.[Delegate])>
    Public NotInheritable Class StringFormatMethodAttribute
        Inherits Attribute

        Public Sub New(ByVal formatParameterName As String)
            formatParameterName = formatParameterName
        End Sub

        Public Property FormatParameterName As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.[Property] Or AttributeTargets.Field)>
    Public NotInheritable Class ValueProviderAttribute
        Inherits Attribute

        Public Sub New(ByVal name As String)
            name = name
        End Sub

        <NotNull>
        Public Property Name As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class InvokerParameterNameAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class NotifyPropertyChangedInvocatorAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(ByVal parameterName As String)
            parameterName = parameterName
        End Sub

        Public Property ParameterName As String
    End Class

    <AttributeUsage(AttributeTargets.Method, AllowMultiple:=True)>
    Public NotInheritable Class ContractAnnotationAttribute
        Inherits Attribute

        Public Sub New(
<NotNull> ByVal contract As String)
            Me.New(contract, False)
        End Sub

        Public Sub New(
<NotNull> ByVal contract As String, ByVal forceFullStates As Boolean)
            contract = contract
            forceFullStates = forceFullStates
        End Sub

        Public Property Contract As String
        Public Property ForceFullStates As Boolean
    End Class

    <AttributeUsage(AttributeTargets.All)>
    Public NotInheritable Class LocalizationRequiredAttribute
        Inherits Attribute

        Public Sub New()
            Me.New(True)
        End Sub

        Public Sub New(ByVal required As Boolean)
            required = required
        End Sub

        Public Property Required As Boolean
    End Class

    <AttributeUsage(AttributeTargets.[Interface] Or AttributeTargets.[Class] Or AttributeTargets.Struct)>
    Public NotInheritable Class CannotApplyEqualityOperatorAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True)>
    <BaseTypeRequired(GetType(Attribute))>
    Public NotInheritable Class BaseTypeRequiredAttribute
        Inherits Attribute

        Public Sub New(
<NotNull> ByVal baseType As Type)
            baseType = baseType
        End Sub

        <NotNull>
        Public Property BaseType As Type
    End Class

    <AttributeUsage(AttributeTargets.All)>
    Public NotInheritable Class UsedImplicitlyAttribute
        Inherits Attribute

        Public Sub New()
            Me.New(ImplicitUseKindFlags.[Default], ImplicitUseTargetFlags.[Default])
        End Sub

        Public Sub New(ByVal useKindFlags As ImplicitUseKindFlags)
            Me.New(useKindFlags, ImplicitUseTargetFlags.[Default])
        End Sub

        Public Sub New(ByVal targetFlags As ImplicitUseTargetFlags)
            Me.New(ImplicitUseKindFlags.[Default], targetFlags)
        End Sub

        Public Sub New(ByVal useKindFlags As ImplicitUseKindFlags, ByVal targetFlags As ImplicitUseTargetFlags)
            useKindFlags = useKindFlags
            targetFlags = targetFlags
        End Sub

        Public Property UseKindFlags As ImplicitUseKindFlags
        Public Property TargetFlags As ImplicitUseTargetFlags
    End Class

    <AttributeUsage(AttributeTargets.[Class] Or AttributeTargets.GenericParameter)>
    Public NotInheritable Class MeansImplicitUseAttribute
        Inherits Attribute

        Public Sub New()
            Me.New(ImplicitUseKindFlags.[Default], ImplicitUseTargetFlags.[Default])
        End Sub

        Public Sub New(ByVal useKindFlags As ImplicitUseKindFlags)
            Me.New(useKindFlags, ImplicitUseTargetFlags.[Default])
        End Sub

        Public Sub New(ByVal targetFlags As ImplicitUseTargetFlags)
            Me.New(ImplicitUseKindFlags.[Default], targetFlags)
        End Sub

        Public Sub New(ByVal useKindFlags As ImplicitUseKindFlags, ByVal targetFlags As ImplicitUseTargetFlags)
            useKindFlags = useKindFlags
            targetFlags = targetFlags
        End Sub

        <UsedImplicitly>
        Public Property UseKindFlags As ImplicitUseKindFlags
        <UsedImplicitly>
        Public Property TargetFlags As ImplicitUseTargetFlags
    End Class

    <Flags>
    Public Enum ImplicitUseKindFlags
        [Default] = Access Or Assign Or InstantiatedWithFixedConstructorSignature
        Access = 1
        Assign = 2
        InstantiatedWithFixedConstructorSignature = 4
        InstantiatedNoFixedConstructorSignature = 8
    End Enum

    <Flags>
    Public Enum ImplicitUseTargetFlags
        [Default] = Itself
        Itself = 1
        Members = 2
        WithMembers = Itself Or Members
    End Enum

    <MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)>
    Public NotInheritable Class PublicAPIAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(
<NotNull> ByVal comment As String)
            comment = comment
        End Sub

        Public Property Comment As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class InstantHandleAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class PureAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class MustUseReturnValueAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(
<NotNull> ByVal justification As String)
            justification = justification
        End Sub

        Public Property Justification As String
    End Class

    <AttributeUsage(AttributeTargets.Field Or AttributeTargets.[Property] Or AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class ProvidesContextAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class PathReferenceAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(
<PathReference> ByVal basePath As String)
            basePath = basePath
        End Sub

        Public Property BasePath As String
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class SourceTemplateAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method, AllowMultiple:=True)>
    Public NotInheritable Class MacroAttribute
        Inherits Attribute

        Public Property Expression As String
        Public Property Editable As Integer
        Public Property Target As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class AspMvcAreaMasterLocationFormatAttribute
        Inherits Attribute

        Public Sub New(ByVal format As String)
            format = format
        End Sub

        Public Property Format As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class AspMvcAreaPartialViewLocationFormatAttribute
        Inherits Attribute

        Public Sub New(ByVal format As String)
            format = format
        End Sub

        Public Property Format As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class AspMvcAreaViewLocationFormatAttribute
        Inherits Attribute

        Public Sub New(ByVal format As String)
            format = format
        End Sub

        Public Property Format As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class AspMvcMasterLocationFormatAttribute
        Inherits Attribute

        Public Sub New(ByVal format As String)
            format = format
        End Sub

        Public Property Format As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class AspMvcPartialViewLocationFormatAttribute
        Inherits Attribute

        Public Sub New(ByVal format As String)
            format = format
        End Sub

        Public Property Format As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class AspMvcViewLocationFormatAttribute
        Inherits Attribute

        Public Sub New(ByVal format As String)
            format = format
        End Sub

        Public Property Format As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class AspMvcActionAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(ByVal anonymousProperty As String)
            anonymousProperty = anonymousProperty
        End Sub

        Public Property AnonymousProperty As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcAreaAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(ByVal anonymousProperty As String)
            anonymousProperty = anonymousProperty
        End Sub

        Public Property AnonymousProperty As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class AspMvcControllerAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(ByVal anonymousProperty As String)
            anonymousProperty = anonymousProperty
        End Sub

        Public Property AnonymousProperty As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcMasterAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcModelTypeAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class AspMvcPartialViewAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Class] Or AttributeTargets.Method)>
    Public NotInheritable Class AspMvcSuppressViewErrorAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcDisplayTemplateAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcEditorTemplateAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcTemplateAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class AspMvcViewAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AspMvcViewComponentAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class AspMvcViewComponentViewAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.[Property])>
    Public NotInheritable Class AspMvcActionSelectorAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.[Property] Or AttributeTargets.Field)>
    Public NotInheritable Class HtmlElementAttributesAttribute
        Inherits Attribute

        Public Sub New()
        End Sub

        Public Sub New(ByVal name As String)
            name = name
        End Sub

        Public Property Name As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Field Or AttributeTargets.[Property])>
    Public NotInheritable Class HtmlAttributeValueAttribute
        Inherits Attribute

        Public Sub New(
<NotNull> ByVal name As String)
            name = name
        End Sub

        <NotNull>
        Public Property Name As String
    End Class

    <AttributeUsage(AttributeTargets.Parameter Or AttributeTargets.Method)>
    Public NotInheritable Class RazorSectionAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method Or AttributeTargets.Constructor Or AttributeTargets.[Property])>
    Public NotInheritable Class CollectionAccessAttribute
        Inherits Attribute

        Public Sub New(ByVal collectionAccessType As CollectionAccessType)
            collectionAccessType = collectionAccessType
        End Sub

        Public Property CollectionAccessType As CollectionAccessType
    End Class

    <Flags>
    Public Enum CollectionAccessType
        None = 0
        Read = 1
        ModifyExistingContent = 2
        UpdatedContent = ModifyExistingContent Or 4
    End Enum

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class AssertionMethodAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class AssertionConditionAttribute
        Inherits Attribute

        Public Sub New(ByVal conditionType As AssertionConditionType)
            conditionType = conditionType
        End Sub

        Public Property ConditionType As AssertionConditionType
    End Class

    Public Enum AssertionConditionType
        IS_TRUE = 0
        IS_FALSE = 1
        IS_NULL = 2
        IS_NOT_NULL = 3
    End Enum

    <Obsolete("Use [ContractAnnotation('=> halt')] instead")>
    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class TerminatesProgramAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class LinqTunnelAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class NoEnumerationAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class RegexPatternAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Class])>
    Public NotInheritable Class XamlItemsControlAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Property])>
    Public NotInheritable Class XamlItemBindingOfItemsControlAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True)>
    Public NotInheritable Class AspChildControlTypeAttribute
        Inherits Attribute

        Public Sub New(ByVal tagName As String, ByVal controlType As Type)
            tagName = tagName
            controlType = controlType
        End Sub

        Public Property TagName As String
        Public Property ControlType As Type
    End Class

    <AttributeUsage(AttributeTargets.[Property] Or AttributeTargets.Method)>
    Public NotInheritable Class AspDataFieldAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Property] Or AttributeTargets.Method)>
    Public NotInheritable Class AspDataFieldsAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Property])>
    Public NotInheritable Class AspMethodPropertyAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Class], AllowMultiple:=True)>
    Public NotInheritable Class AspRequiredAttributeAttribute
        Inherits Attribute

        Public Sub New(
<NotNull> ByVal attribute As String)
            attribute = attribute
        End Sub

        Public Property Attribute As String
    End Class

    <AttributeUsage(AttributeTargets.[Property])>
    Public NotInheritable Class AspTypePropertyAttribute
        Inherits Attribute

        Public Property CreateConstructorReferences As Boolean

        Public Sub New(ByVal createConstructorReferences As Boolean)
            createConstructorReferences = createConstructorReferences
        End Sub
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class RazorImportNamespaceAttribute
        Inherits Attribute

        Public Sub New(ByVal name As String)
            name = name
        End Sub

        Public Property Name As String
    End Class

    <AttributeUsage(AttributeTargets.Assembly, AllowMultiple:=True)>
    Public NotInheritable Class RazorInjectionAttribute
        Inherits Attribute

        Public Sub New(ByVal type As String, ByVal fieldName As String)
            type = type
            fieldName = fieldName
        End Sub

        Public Property Type As String
        Public Property FieldName As String
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class RazorHelperCommonAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.[Property])>
    Public NotInheritable Class RazorLayoutAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class RazorWriteLiteralMethodAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Method)>
    Public NotInheritable Class RazorWriteMethodAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.Parameter)>
    Public NotInheritable Class RazorWriteMethodParameterAttribute
        Inherits Attribute
    End Class

    <AttributeUsage(AttributeTargets.All)>
    Public NotInheritable Class NoReorder
        Inherits Attribute
    End Class
End Namespace
