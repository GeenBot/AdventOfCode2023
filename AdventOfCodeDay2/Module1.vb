Imports System.IO

Module Module1

    Structure Colour
        Dim count As Integer
        Dim colour As String
    End Structure




    Sub Main()
        'Reads the input into a file and then gets the first line 
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day2Input.txt")
        Dim textInput As String = fileReader.ReadLine
        Dim possibleGames As Integer
        Dim gameID As Integer

        'Repeats for each game and adds the game ID to the possibleGames if the game was possible
        While Not (textInput = "")
            gameID += 1
            possibleGames += RoundSeperator(textInput, gameID)
            textInput = fileReader.ReadLine
        End While

        Console.WriteLine(possibleGames)
        Console.ReadLine()
    End Sub


    Function RoundSeperator(Line As String, ID As Integer)
        Dim round() As String
        Dim preText() As String
        round = Split(Line, ";")
        preText = Split(round(0), ":")
        round(0) = round(0).remove(0, (preText(0).length + 1))

        'Returns no value if it isn't a possible game and returns the game ID if it is
        Return IsRGBTooMuch(round)


    End Function

    Function IsRGBTooMuch(rounds())
        Dim individualColour() As String
        Dim seperatedColour() As String
        Dim lowestValueR As Integer
        Dim lowestValueG As Integer
        Dim lowestValueB As Integer
        For i = 0 To (rounds.length - 1)
            individualColour = Split(rounds(i), ",")
            For a = 0 To (individualColour.length - 1)
                individualColour(a) = individualColour(a).remove(0, 1)
                seperatedColour = Split(individualColour(a), " ")
                For b = 0 To ((seperatedColour.length - 2) / 2) Step +2
                    Select Case seperatedColour(b + 1)

                        Case "red"
                            If seperatedColour(b) > lowestValueR Then
                                lowestValueR = seperatedColour(b)
                            End If

                        Case "green"
                            If seperatedColour(b) > lowestValueG Then
                                lowestValueG = seperatedColour(b)
                            End If

                        Case "blue"
                            If seperatedColour(b) > lowestValueB Then
                                lowestValueB = seperatedColour(b)
                            End If
                    End Select




                Next
            Next


        Next

        Return (lowestValueB * lowestValueG * lowestValueR)
    End Function
End Module
Module Module2

    Structure Colour
        Dim count As Integer
        Dim colour As String
    End Structure




    Sub Main()
        'Reads the input into a file and then gets the first line 
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day2Input.txt")
        Dim textInput As String = fileReader.ReadLine
        Dim possibleGames As Integer
        Dim gameID As Integer

        'Repeats for each game and adds the game ID to the possibleGames if the game was possible
        While Not (textInput = "")
            gameID += 1
            possibleGames += RoundSeperator(textInput, gameID)
            textInput = fileReader.ReadLine
        End While

        Console.WriteLine(possibleGames)
        Console.ReadLine()
    End Sub


    Function RoundSeperator(Line As String, ID As Integer)
        Dim round() As String
        Dim preText() As String
        round = Split(Line, ";")
        preText = Split(round(0), ":")
        round(0) = round(0).remove(0, (preText(0).length + 1))

        'Returns no value if it isn't a possible game and returns the game ID if it is
        If IsRGBTooMuch(round) Then
            Return 0
        Else
            Console.WriteLine("End Round: " & ID)
            Return ID
        End If

    End Function

    Function IsRGBTooMuch(rounds())
        Dim individualColour() As String
        Dim seperatedColour() As String
        For i = 0 To (rounds.length - 1)
            individualColour = Split(rounds(i), ",")
            For a = 0 To (individualColour.length - 1)
                individualColour(a) = individualColour(a).remove(0, 1)
                seperatedColour = Split(individualColour(a), " ")
                For b = 0 To ((seperatedColour.length - 2) / 2) Step +2
                    Select Case seperatedColour(b + 1)

                        Case "red"
                            If seperatedColour(b) > 12 Then
                                Return True
                            End If

                        Case "green"
                            If seperatedColour(b) > 13 Then
                                Return True
                            End If

                        Case "blue"
                            If seperatedColour(b) > 14 Then
                                Return True
                            End If

                    End Select




                Next
            Next


        Next

        Return False
    End Function
End Module

