Imports System.IO

Module Module1

    Sub Main()
        'Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day9Input.txt")
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day9Test.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim inputLayer As String()
        Dim inputString As Integer(,)
        Dim temp As String
        Dim bottomLayer
        Dim nextHistory As Integer


        Do
            inputLayer = Split(textInput)
            For i = 0 To inputLayer.Length - 1
                ReDim Preserve inputString(0, i)
                inputString(0, i) = inputLayer(i).ToString
            Next
            nextHistory = ToBottomLayer(inputString, 0)
            textInput = fileReader.ReadLine()
        Loop Until textInput = ""

    End Sub

    Function ToBottomLayer(layer As Integer(,), counter As Integer)
        Dim resultantLayer As Integer(,)
        Dim zeroCount As Integer = 0
        Dim tempResultantLayer(,) = layer
        For i = 0 To layer.GetLength(1) - 2
            ReDim Preserve resultantLayer(20, i + 1)
            resultantLayer(counter, i) = layer(counter, i + 1) - layer(counter, i)
        Next
        For i = 0 To resultantLayer.GetLength(1) - 1
            If resultantLayer(counter, i) = 0 Then
                zeroCount += 1
            End If
        Next
        If zeroCount = resultantLayer.GetLength(1) Then
            Return Extrapolate(tempResultantLayer, counter)
        Else
            counter += 1
            ToBottomLayer(resultantLayer, counter)
        End If
    End Function

    Function Extrapolate(layers(,) As Integer, layerLevel As Integer)
        If Not layerLevel = 0 Then
            layers(layerLevel - 1, layers.GetLength(1) - 1) = layers(layerLevel, layers.GetLength(1) - 1)
            Return Extrapolate(layers(,), layerLevel - 1)
        Else
            Return layers(0, layers.GetLength(1) - 1)
        End If

    End Function
End Module
