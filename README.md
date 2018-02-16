# unity_rekr
zadanie rekrutacyjne


The solution is focused on creation of a new class pinPair, with 4 variables, position X Y, hole and temporary pin inside it. Every hole and pin have its own legality state, represented by the tag (legal illegal). To check legality of pin (possibility of movement)  informationa bout nighbouring holes are gathered (as objects of pinPair class) along vectors of movement. All operations are made and supervised by the Player, which has defined all GameObjects, assigned to class objects. It checks wether the game has ended and conducts moves.


Rozwiazanie zadania opiera si� o stworzenie klasy pinPair, posiadaj�cej cztery zmienne, pozycj� X Y, przypisany otw�r i tymczasowy pionek, kt�ry w nim jest. Ka�dy otw�r i pionek ma sprawdzany sw�j stan legalno�ci, reprezentowany tagiem (legal illegal). Aby sprawdzi� legalno�� pionka (czy mo�na wykona� nim ruch) pobierane s� informacje o s�siaduj�cych otworach (obiektach klasy pinPair) parami wzd�� odpowiednich wektor�w ruchu. Gdy najbli�szy jest zaj�ty, a nast�pny nie (pinPair.pin == null) to pionek jest legalny. Podobne dzia�anie jest wykonane przy sprawdzaniu legalno�ci otworu.
Ca�o�� jest nadzorowana przez obiekt Gracza, kt�ry ma zapisane wszystkie elementy gry, przypisane od odpowiednich obiekt�w klasy. Sprawdza on, czy gra si� sko�czy�a i wykonuje tury ruchu.

Najwa�niejsze funkcje i metody zamkni�te w rozwi�zaniu.

LegalityCheckGlobalPins() - sprawdzenie ka�dego pionka czy jest legalny, pozwala to na zadeklarowanie ko�ca gry oraz umo�liwienie ruchu (i pod�wietlenia), CheckGlobalHoles analogicznie

SetAllPinsIllegal (pinPair[] pairs_) - po wybraniu jednego pionka, wszystkie w grze s� nazywane nielegalnymi, poniewa� zamkni�to cykl wyboru, analogicznie z ..AllHoles..

UpdateMouse() - sprawdzanie pozycji myszy, poprzez kolizj� promienia i klikni�cie pobierane s� informacje o pozycji i podejmowane dzia�ania - zapisanie pionka, zapisanie otworu, nadanie flagi ruchu startOperation

MovementOperation (pinPair In, pinPair Out) - wszystkie dzia�ania wykonywane przy ruchu pionkiem, czyli znalezienie pionka po�redniego i usuni�cie go, restartowanie warto�ci temp (tutaj powinno by� zapisywanie danych do nowej klasy replaya, operuj�ce na obiektach temp)

Start() - spisanie pierwotnych par pionek otw�r

Update() - we czasie rzeczywistym mierzenie timera gry, kt�ry deklaruje koniec, oczekiwanie na wci�ni�cie klawisza myszy, wykonywanie ruchu obiekt�w temp, je�li flaga startOperation jest w��czona

Jako UI pierwszego panelu u�yto gotowe rozwi�zanie z za��czonego linku, w kt�rym zmieniono kilka rzeczy:
dodano zmian� sceny zgodnie z poziomem trudno�ci,
nadano muzyk� zale�n� od poziomu trudno�ci,
odrzucono zb�dne opcje. 
https://assetstore.unity.com/packages/essentials/game-jam-menu-template-40465