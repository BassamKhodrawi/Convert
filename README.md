# Konvertieren

Eine C#-Anwendung zur Konvertierung von SQL-Abfragen in Code-Snippets für die Verwendung in Programmiersprachen wie VB.NET oder C#. Dieses Projekt ermöglicht es, SQL-Abfragen in eine formatierte StringBuilder-Syntax umzuwandeln.

## Funktionen

- **SQL-Abfragen in Code-Snippets umwandeln**: Der Text aus einer SQL-Abfrage wird in `StringBuilder`-Code umgewandelt, der für die Verwendung in einer Programmiersprache geeignet ist.
- **Text in Anführungszeichen extrahieren**: Wenn bereits `AppendLine`-Befehle vorhanden sind, wird der Text in den Anführungszeichen extrahiert und als Ergebnis angezeigt.
- **Ersetzen von Platzhaltern**: Der Code erkennt bestimmte SQL-Operatoren und ersetzt diese durch die entsprechenden Programmiersyntax (z.B. `*EQ` wird zu `=`).

## Beispiel

1. Geben Sie eine SQL-Abfrage ein, wie z.B.:
    ```sql
    SELECT * FROM Users WHERE Age > 30
    ```

2. Nach der Konvertierung wird der Text im `StringBuilder`-Format angezeigt:
    ```vb
    Dim variable As New System.Text.StringBuilder
    variable.AppendLine("SELECT * FROM Users WHERE Age > 30")
    ```

## Installation

Um mit diesem Projekt zu beginnen, folgen Sie diesen Schritten:

1. **Repository klonen:**
    ```bash
    git clone https://github.com/BassamKhodrawi/Convert.git
    ```

2. **Projekt in Visual Studio öffnen:**
    - Öffnen Sie Visual Studio.
    - Klicken Sie auf "Ein Projekt oder eine Lösung öffnen".
    - Navigieren Sie zum geklonten Repository-Ordner und wählen Sie die Lösungsdatei (`.sln`) aus.

## Nutzung

1. **Anwendung ausführen:**
    - Drücken Sie `F5` in Visual Studio, um die Anwendung zu erstellen und auszuführen.
    - Geben Sie Ihre SQL-Abfrage im Textfeld ein und klicken Sie auf den "Konvertieren"-Button, um das Code-Snippet zu generieren.

2. **Anwendung modifizieren:**
    - Sie können die Anwendung modifizieren, indem Sie die Quelldateien im Ordner `src` bearbeiten.

## Voraussetzungen

- Visual Studio 2019 oder später
- .NET Framework 4.7.2 oder später


## Kontakt

- **Autor:** [Bassam Khodrawi](https://github.com/BassamKhodrawi)
- **Repository:** [Convert](https://github.com/BassamKhodrawi/Convert)
