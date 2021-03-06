﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Threading
Imports Microsoft.CodeAnalysis.Editor.Implementation.Highlighting
Imports Microsoft.CodeAnalysis.Text
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.Editor.VisualBasic.KeywordHighlighting
    <ExportHighlighter(LanguageNames.VisualBasic)>
    Friend Class UsingBlockHighlighter
        Inherits AbstractKeywordHighlighter(Of SyntaxNode)

        Protected Overloads Overrides Function GetHighlights(node As SyntaxNode, cancellationToken As CancellationToken) As IEnumerable(Of TextSpan)
            Dim usingBlock = node.GetAncestor(Of UsingBlockSyntax)()
            If usingBlock Is Nothing Then
                Return SpecializedCollections.EmptyEnumerable(Of TextSpan)()
            End If

            With usingBlock
                Return { .UsingStatement.UsingKeyword.Span,
                        .EndUsingStatement.Span}
            End With
        End Function
    End Class
End Namespace
