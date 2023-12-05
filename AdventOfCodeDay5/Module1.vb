Imports System.IO

Module Module1


    'Provides the range with which to compare
    Structure Map
        Dim destinationStartValue As Double
        Dim sourceStartValue As Double
        Dim destinationEndValue As Double
        Dim sourceEndValue As Double
    End Structure


    Sub Main()
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day5Input.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim seedString = textInput.Remove(0, 7)
        Dim numberArray(7, 19) As String
        Dim seedArray(19) As String
        Dim counter As Integer = 0
        Dim valueRange(60) As Map

        'Splits the string into an array of number and then adds it to one dimension of an array using a for loop since I don't know how to otherwise
        seedArray = Split(seedString, " ")
        For i = 0 To seedArray.Length - 1
            numberArray(0, i) = seedArray(i)
        Next


        'Goes to the beginning of the first Map
        textInput = fileReader.ReadLine()
        textInput = fileReader.ReadLine()
        textInput = fileReader.ReadLine()

        Do
            Dim i = 0
            Do
                'Makes one range of values for which to compare with
                valueRange(i) = FillRange(textInput)
                textInput = fileReader.ReadLine()
                i += 1
                'Repeats for every line in the map
            Loop Until textInput = ""
            'Compares the currently held number against the ranges of values
            numberArray = FindValue(valueRange, numberArray, counter)

            'increments the stage at which you are looking before heading to the next map
            counter += 1
            textInput = fileReader.ReadLine()
            textInput = fileReader.ReadLine()

            'Repeats for every map
        Loop Until textInput = ""

        'prints out the values in the final stage
        For i = 0 To numberArray.GetLength(1) - 1
            Console.WriteLine(numberArray(7, i))
        Next
        Console.ReadLine()
    End Sub

    'Compares the number to see whether it is in the range and then gives it the the correct new value based on whether it is or not
    Function FindValue(valRange() As Map, num(,) As String, counter As Integer)
        For i = 0 To num.GetLength(1) - 1
            For a = 0 To valRange.Length - 1
                If num(counter, i) >= valRange(a).sourceStartValue And num(counter, i) <= valRange(a).sourceEndValue Then
                    num(counter + 1, i) = num(counter, i) - valRange(a).sourceStartValue + valRange(a).destinationStartValue
                    Exit For
                ElseIf a = valRange.Length - 1 Then
                    num(counter + 1, i) = num(counter, i)
                End If
            Next

        Next
        Return num
    End Function


    'Calculates the ranges by adding the base range to the two starting values
    Function FillRange(textInput As String)
        Dim rangeParts(2) As String
        Dim valueRange As Map
        Dim range(2) As Double
        rangeParts = Split(textInput, " ")
        For i = 0 To 2
            range(i) = Val(rangeParts(i))
        Next

        valueRange.destinationStartValue = range(0)
        valueRange.destinationEndValue = range(0) + range(2)
        valueRange.sourceStartValue = range(1)
        valueRange.sourceEndValue = range(1) + range(2)
        Return valueRange
    End Function

End Module

Module Module2


    'Provides the range with which to compare
    Structure Map
        Dim destinationStartValue As Double
        Dim sourceStartValue As Double
        Dim destinationEndValue As Double
        Dim sourceEndValue As Double
    End Structure


    Sub Main()
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day5Input.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim seedString = textInput.Remove(0, 7)
        Dim numberArray(7, 19) As String
        Dim seedArray(19) As String
        Dim counter As Integer = 0
        Dim valueRange(60) As Map

        'Splits the string into an array of number and then adds it to one dimension of an array using a for loop since I don't know how to otherwise
        seedArray = Split(seedString, " ")
        For i = 0 To seedArray.Length - 1
            numberArray(0, i) = seedArray(i)
        Next


        'Goes to the beginning of the first Map
        textInput = fileReader.ReadLine()
        textInput = fileReader.ReadLine()
        textInput = fileReader.ReadLine()

        Do
            Dim i = 0
            Do
                'Makes one range of values for which to compare with
                valueRange(i) = FillRange(textInput)
                textInput = fileReader.ReadLine()
                i += 1
                'Repeats for every line in the map
            Loop Until textInput = ""
            'Compares the currently held number against the ranges of values
            numberArray = FindValue(valueRange, numberArray, counter)

            'increments the stage at which you are looking before heading to the next map
            counter += 1
            textInput = fileReader.ReadLine()
            textInput = fileReader.ReadLine()

            'Repeats for every map
        Loop Until textInput = ""

        'prints out the values in the final stage
        For i = 0 To numberArray.GetLength(1) - 1
            Console.WriteLine(numberArray(7, i))
        Next
        Console.ReadLine()
    End Sub

    'Compares the number to see whether it is in the range and then gives it the the correct new value based on whether it is or not
    Function FindValue(valRange() As Map, num(,) As String, counter As Integer)
        For i = 0 To num.GetLength(1) - 1
            For a = 0 To valRange.Length - 1
                If num(counter, i) >= valRange(a).sourceStartValue And num(counter, i) <= valRange(a).sourceEndValue Then
                    num(counter + 1, i) = num(counter, i) - valRange(a).sourceStartValue + valRange(a).destinationStartValue
                    Exit For
                ElseIf a = valRange.Length - 1 Then
                    num(counter + 1, i) = num(counter, i)
                End If
            Next

        Next
        Return num
    End Function


    'Calculates the ranges by adding the base range to the two starting values
    Function FillRange(textInput As String)
        Dim rangeParts(2) As String
        Dim valueRange As Map
        Dim range(2) As Double
        rangeParts = Split(textInput, " ")
        For i = 0 To 2
            range(i) = Val(rangeParts(i))
        Next

        valueRange.destinationStartValue = range(0)
        valueRange.destinationEndValue = range(0) + range(2)
        valueRange.sourceStartValue = range(1)
        valueRange.sourceEndValue = range(1) + range(2)
        Return valueRange
    End Function

End Module
