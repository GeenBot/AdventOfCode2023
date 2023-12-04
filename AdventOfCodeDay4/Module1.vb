Imports System.IO

Module Module1
    Structure Card
        Dim winCount As Integer
        Dim multiplier As Integer
    End Structure



    Sub Main()
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day4Input.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim twoSides As String()
        Dim cardNumber As Integer = 1
        Dim winningNumbers(9) As String '+5
        Dim ownedNumbers(24) As String '+17
        Dim totalCards As Integer
        Dim cards(224) As Card

        'Setting the multiplier to base 1 for every value as structures are annoying 
        For i = 0 To cards.Length - 1
            cards(i).multiplier = 1
        Next

        Do
            'Ignoring useless beginning part
            textInput = textInput.Remove(0, 10)

            'Splitting into winning values and the values found before splitting it each group into individual characters because splits also don't work
            twoSides = Split(textInput, "|")
            For i = 0 To 9
                winningNumbers(i) = twoSides(0).Substring(i * 3, 2)
            Next
            For i = 0 To 24
                ownedNumbers(i) = twoSides(1).Substring(i * 3 + 1, 2)
            Next

            'Calculates the win count for each game 
            cards(cardNumber).winCount = FindPointValue(winningNumbers, ownedNumbers)

            textInput = fileReader.ReadLine()
            'Counts the base cards before we look at the big numbers
            totalCards += 1
            'Find the current card position
            cardNumber += 1
        Loop Until textInput = ""

        'Big number part
        totalCards = EvaluateCardsWinning(cards, totalCards)


        Console.WriteLine(totalCards)
        Console.ReadLine()
    End Sub

    Function EvaluateCardsWinning(cards As Card(), totalCards As Integer)
        'Repeats for every card to increase multipliear and totalCards to the right amount (And a little extra since I didn't want to risk off by 1 errors)
        For i = 1 To 224
            totalCards = EvaluateSingleCardWinning(cards, totalCards, i)
        Next
        Return totalCards
    End Function


    Function EvaluateSingleCardWinning(cards As Card(), totalCards As Integer, counter As Integer)
        'Win count is the amount of values after its position that its effect has an affect on and so is the amount of times the for loop repeats 
        For a = 1 To (cards(counter).winCount)
            'Adds the current multiplier of the following values to the multiplier of the current card
            cards(counter + a).multiplier = cards(counter).multiplier + cards(counter + a).multiplier
            'Increases the card count once for each copy of the card
            totalCards += cards(counter).multiplier
        Next
        Return totalCards
    End Function


    Function FindPointValue(winNum As String(), ownNum As String())
        Dim winning As New Dictionary(Of String, Boolean)
        Dim pointValue As Integer
        For i = 0 To (winNum.Length - 1)
            If Not (winning.ContainsKey(winNum(i))) Then
                winning.Add(winNum(i), True)
            End If
        Next

        For i = 0 To (ownNum.Length - 1)
            If winning.ContainsKey(ownNum(i)) Then
                pointValue += 1
            End If
        Next
        Return pointValue
    End Function


End Module
Module Module2

    Sub Main()
        Dim fileReader As StreamReader = My.Computer.FileSystem.OpenTextFileReader("C:\Users\Xander\source\repos\AdventOfCode2023\TextInputs\Day4Input.txt")
        Dim textInput As String = fileReader.ReadLine()
        Dim twoSides As String()
        Dim winningNumbers(9) As String '+5
        Dim ownedNumbers(24) As String '+17
        Dim totalWorth As Integer

        Do
            textInput = textInput.Remove(0, 6)
            textInput = textInput.Remove(0, 3)
            twoSides = Split(textInput, "|")
            For i = 0 To 9
                winningNumbers(i) = twoSides(0).Substring(i * 3 + 1, 2)
            Next
            For i = 0 To 24
                ownedNumbers(i) = twoSides(1).Substring(i * 3 + 1, 2)
            Next
            totalWorth += FindPointValue(winningNumbers, ownedNumbers)
            textInput = fileReader.ReadLine()
        Loop Until textInput = ""
        Console.WriteLine(totalWorth)
        Console.ReadLine()
    End Sub

    Function FindPointValue(winNum As String(), ownNum As String())
        Dim winning As New Dictionary(Of String, Boolean)
        Dim pointValue As Integer
        For i = 0 To (winNum.Length - 1)
            If Not (winning.ContainsKey(winNum(i))) Then
                winning.Add(winNum(i), True)
            End If
        Next

        For i = 0 To (ownNum.Length - 1)
            If winning.ContainsKey(ownNum(i)) Then
                If pointValue = 0 Then
                    pointValue = +1
                Else
                    pointValue = pointValue * 2

                End If
            End If
        Next
        Return pointValue
    End Function


End Module

