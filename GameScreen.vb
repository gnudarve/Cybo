﻿Imports System.Data.SQLite
Imports System.Drawing
Imports System.Security.Cryptography
Imports System.Windows.Forms

Public Class GameScreen

    Private m_sHistoryDBPath As String = Application.CommonAppDataPath + IO.Path.DirectorySeparatorChar + "history.db"

    Private Const m_nDiceSides As Integer = 12
    Private Const m_nRollsPerTurn As Integer = 4

    Private m_cOpenColor = Color.AliceBlue
    Private m_cSetColor = Color.DodgerBlue
    Private m_cInertColor = SystemColors.Control

    Private m_Board As Label()

    Private m_Points As Integer = 0

    Private MyTurn As New TurnInfo With {
            .nResults = New Integer(m_nRollsPerTurn - 1) {}
        }

    Private Structure TurnInfo
        Public nRollNumber As Integer
        Public nPoints As Integer
        Public nEstablishedLine As Integer
        Public nResults As Integer()
    End Structure

    Private CyboLines As Byte()() = New Byte()() {
        New Byte() {1, 5, 9},
        New Byte() {2, 6, 10},
        New Byte() {3, 7, 11},
        New Byte() {4, 8, 12},
        New Byte() {1, 2, 3, 4},
        New Byte() {5, 6, 7, 8},
        New Byte() {9, 10, 11, 12},
        New Byte() {2, 7, 12},
        New Byte() {1, 6, 11},
        New Byte() {3, 6, 9},
        New Byte() {4, 7, 10}
    }

    Private Sub GameScreen_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.Text += " - Version " + My.Application.Info.Version.ToString

        CheckDatabase()
        DumpUsers()

        m_Board = {Label1, Label2, Label3, Label4, Label5, Label6, Label7, Label8, Label9, Label10, Label11, Label12}

        ClearTurn()

    End Sub


    Private Function IsDuplicate(theTurn As TurnInfo) As Boolean

        For nRoll As Integer = 0 To theTurn.nRollNumber - 1
            If theTurn.nResults(nRoll) = theTurn.nResults(theTurn.nRollNumber) Then
                Return True
            End If
        Next

        Return False

    End Function

    Private Sub PlayTurn()

        Dim nRoll As Integer
        Dim nEval As Integer

        'roll dice
        nRoll = RollDice(m_nDiceSides)

        MyTurn.nResults(MyTurn.nRollNumber) = nRoll

        ' check for same number hit twice
        If IsDuplicate(MyTurn) Then
            Debug.WriteLine("Duplicate number.")
            SetCellColor(MyTurn.nResults(MyTurn.nRollNumber), Color.Blue)
            nEval = -1
        Else
            nEval = EvalResults(MyTurn)
        End If


        Select Case nEval
            Case -1
                Debug.WriteLine("Out of line or adjacency.")
                cmdRollDice.Text = "Start Over"

            Case 0
                'keep going 

                'go for quad?
                If MyTurn.nRollNumber + 1 = 3 And CyboLines(MyTurn.nEstablishedLine).Length = 4 Then
                    cmdRollDice.Text = "Start Over"
                    cmdRollQuad.Visible = True
                    m_Points += 3
                    Debug.WriteLine("You scored {0} points!", m_Points)
                Else
                    'evaluate points
                    Select Case MyTurn.nRollNumber + 1
                        Case 3
                            cmdRollDice.Text = "Start Over"
                            m_Points += 3
                            Debug.WriteLine("You scored {0} points!", m_Points)
                        Case 4
                            cmdRollDice.Text = "Start Over"
                            m_Points += 16
                            Debug.WriteLine("You scored {0} points!", m_Points)
                    End Select
                End If

                MyTurn.nRollNumber += 1
                lblScore.Text = "Score: " + m_Points.ToString
        End Select

    End Sub

    ' Evaluate current turn based on CyboLines map
    ' 
    ' Returns:
    '     0 - Turn can continue, no points awarded yet
    '    -1 - Turn is over, results are not in a line and adjacent
    '     n - Points this turn is awarded
    Private Function EvalResults(ByRef theTurn As TurnInfo) As Integer

        Dim nLineNum As Integer = 0
        Dim nLineHits As Integer = 0
        Dim nEval As Integer = 0

        'init board
        For i As Integer = 1 To m_nDiceSides
            SetCellColor(i, m_cInertColor)
        Next

        ' are the rolls are in the same line?
        For nLineNum = 0 To CyboLines.GetLength(0) - 1
            Dim nHits As Integer = 0
            For Each nNumber As Integer In CyboLines(nLineNum)
                For nRoll As Integer = 0 To theTurn.nRollNumber
                    If theTurn.nResults(nRoll) = nNumber Then
                        nHits += 1
                    End If
                Next
            Next

            'show possible lines
            If nHits = theTurn.nRollNumber + 1 Then
                For Each nNumber As Integer In CyboLines(nLineNum)
                    SetCellColor(nNumber, m_cOpenColor)
                Next
            End If

            'track hit count for best line
            If nHits > nLineHits Then
                nLineHits = nHits
                theTurn.nEstablishedLine = nLineNum
            End If
        Next

        'set current roll results to blue
        For i As Integer = 0 To theTurn.nRollNumber
            SetCellColor(theTurn.nResults(i), m_cSetColor)
        Next

        'confirm hits are adjacent
        ' for lines with 3 blocks they are always going to be adjacent
        ' but for the lines with 4 blocks we can simply verify that either the head or the tail is empty
        Dim bHeadHit As Boolean = False
        Dim bTailHit As Boolean = False
        If CyboLines(theTurn.nEstablishedLine).Length = 4 And theTurn.nRollNumber < 3 Then
            For i As Integer = 0 To theTurn.nRollNumber
                If theTurn.nResults(i) = CyboLines(theTurn.nEstablishedLine)(0) Then
                    bHeadHit = True
                End If
                If theTurn.nResults(i) = CyboLines(theTurn.nEstablishedLine)(3) Then
                    bTailHit = True
                End If
            Next
        End If
        Dim bNotAdjacent As Boolean = bHeadHit And bTailHit

        'how we doing?
        If nLineHits < theTurn.nRollNumber + 1 Or bNotAdjacent Then
            'turn is lost
            nEval = -1
        Else
            'keep going
            nEval = 0
        End If

        Debug.WriteLine("")
        Debug.WriteLine("RollNumber: {0}", theTurn.nRollNumber + 1)
        Debug.WriteLine("LineHits: {0}", nLineHits)
        Debug.WriteLine("Eval: {0}", nEval)

        Return nEval

    End Function

    Private Function RollDice(nDiceSides As Integer) As Integer
        Static oRandom As New Random(Now.Millisecond)
        Return oRandom.Next(1, nDiceSides + 1)
        'Dim nNums As Integer() = {1, 4, 2, 3}
        'Return nNums(MyTurn.nRollNumber)
    End Function

    Private Function RollDice_rngCsp(numberSides As UInt16) As UInt16
        Dim rngCsp As RNGCryptoServiceProvider = New RNGCryptoServiceProvider()
        Dim randomBytes As Byte() = New Byte(1) {}
        rngCsp.GetBytes(randomBytes)
        Return (BitConverter.ToUInt16(randomBytes, 0) Mod numberSides) + 1
    End Function

    Private Sub cmdRollDice_Click(sender As Object, e As EventArgs) Handles cmdRollDice.Click
        If cmdRollDice.Text = "Start Over" Then
            ClearTurn()
            cmdRollDice.Text = "Roll Dice"
        Else
            PlayTurn()
        End If
        'Timer1.Enabled = Not Timer1.Enabled
    End Sub


    Private Sub ClearBoard()
        For i As Integer = 1 To m_nDiceSides
            SetCellColor(i, m_cOpenColor)
        Next
    End Sub

    Private Sub ClearTurn()

        ClearBoard()

        cmdRollQuad.Visible = False

        MyTurn.nEstablishedLine = -1
        MyTurn.nRollNumber = 0
        For i As Integer = 0 To m_nRollsPerTurn - 1
            MyTurn.nResults(i) = 0
        Next

    End Sub

    Private Sub SetCellColor(nCellNumber As Integer, nTargetColor As Color)
        If nCellNumber >= 1 AndAlso nCellNumber <= m_Board.Length Then
            m_Board(nCellNumber - 1).BackColor = nTargetColor
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'foutain the random number generator
        RollDice(m_nDiceSides)
    End Sub

    Private Sub cmdRollQuad_Click(sender As Object, e As EventArgs) Handles cmdRollQuad.Click
        PlayTurn()
        cmdRollQuad.Visible = False
    End Sub


    Sub CheckDatabase()
        If Not My.Computer.FileSystem.FileExists(Application.CommonAppDataPath + IO.Path.DirectorySeparatorChar + "history.db") Then
            'create database
            SQLiteConnection.CreateFile(m_sHistoryDBPath)

            Using connection As New SQLiteConnection("Data Source=" + m_sHistoryDBPath)
                connection.Open()

                Using command As New SQLiteCommand(connection)
                    'create user table
                    command.CommandText = "CREATE TABLE users (id INTEGER PRIMARY KEY AUTOINCREMENT, name TEXT (32) NOT NULL, password TEXT (32))"
                    command.ExecuteNonQuery()

                    'insert some default users
                    command.CommandText = "INSERT INTO users (name, password) VALUES ('Buck', '1496'), ('Miako', 'baskinn')"
                    command.ExecuteNonQuery()

                    'create scores table
                    command.CommandText = "CREATE TABLE scores (id INTEGER PRIMARY KEY AUTOINCREMENT, user INTEGER, date TIMESTAMP, score INTEGER)"
                    command.ExecuteNonQuery()

                    'command.CommandText = "INSERT INTO scores (user, date, score) VALUES (1, '2023-07-04 17:16:23',14),(1, '2023-07-04 17:46:23',27),(2, '2023-07-04 17:26:32',16)"
                    'command.ExecuteNonQuery()
                End Using

                connection.Close()
            End Using

        End If
    End Sub

    Sub DumpUsers()

        Dim connectionString As String = "Data Source=" + Application.CommonAppDataPath + IO.Path.DirectorySeparatorChar + "history.db"

        Using connection As New SQLiteConnection(connectionString)
            connection.Open()

            Dim query As String = "SELECT * FROM users"
            Using command As New SQLiteCommand(query, connection)
                Using reader As SQLiteDataReader = command.ExecuteReader()
                    Console.WriteLine("Current users:")
                    While reader.Read()
                        Console.WriteLine("   {0}: {1} [{2}]", reader![id], reader![name], reader![password])
                    End While
                End Using
            End Using

            connection.Close()
        End Using

    End Sub

End Class