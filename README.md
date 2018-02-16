# unity_rekr
zadanie rekrutacyjne


The solution is focused on creation of a new class pinPair, with 4 variables, position X Y, hole and temporary pin inside it. Every hole and pin have its own legality state, represented by the tag (legal illegal). To check legality of pin (possibility of movement)  informationa bout nighbouring holes are gathered (as objects of pinPair class) along vectors of movement. All operations are made and supervised by the Player, which has defined all GameObjects, assigned to class objects. It checks wether the game has ended and conducts moves.


Rozwiazanie zadania opiera siê o stworzenie klasy pinPair, posiadaj¹cej cztery zmienne, pozycjê X Y, przypisany otwór i tymczasowy pionek, który w nim jest. Ka¿dy otwór i pionek ma sprawdzany swój stan legalnoœci, reprezentowany tagiem (legal illegal). Aby sprawdziæ legalnoœæ pionka (czy mo¿na wykonaæ nim ruch) pobierane s¹ informacje o s¹siaduj¹cych otworach (obiektach klasy pinPair) parami wzd³ó¿ odpowiednich wektorów ruchu. Gdy najbli¿szy jest zajêty, a nastêpny nie (pinPair.pin == null) to pionek jest legalny. Podobne dzia³anie jest wykonane przy sprawdzaniu legalnoœci otworu.
Ca³oœæ jest nadzorowana przez obiekt Gracza, który ma zapisane wszystkie elementy gry, przypisane od odpowiednich obiektów klasy. Sprawdza on, czy gra siê skoñczy³a i wykonuje tury ruchu.

Najwa¿niejsze funkcje i metody zamkniête w rozwi¹zaniu.

LegalityCheckGlobalPins() - sprawdzenie ka¿dego pionka czy jest legalny, pozwala to na zadeklarowanie koñca gry oraz umo¿liwienie ruchu (i podœwietlenia), CheckGlobalHoles analogicznie

SetAllPinsIllegal (pinPair[] pairs_) - po wybraniu jednego pionka, wszystkie w grze s¹ nazywane nielegalnymi, poniewa¿ zamkniêto cykl wyboru, analogicznie z ..AllHoles..

UpdateMouse() - sprawdzanie pozycji myszy, poprzez kolizjê promienia i klikniêcie pobierane s¹ informacje o pozycji i podejmowane dzia³ania - zapisanie pionka, zapisanie otworu, nadanie flagi ruchu startOperation

MovementOperation (pinPair In, pinPair Out) - wszystkie dzia³ania wykonywane przy ruchu pionkiem, czyli znalezienie pionka poœredniego i usuniêcie go, restartowanie wartoœci temp (tutaj powinno byæ zapisywanie danych do nowej klasy replaya, operuj¹ce na obiektach temp)

Start() - spisanie pierwotnych par pionek otwór

Update() - we czasie rzeczywistym mierzenie timera gry, który deklaruje koniec, oczekiwanie na wciœniêcie klawisza myszy, wykonywanie ruchu obiektów temp, jeœli flaga startOperation jest w³¹czona

Jako UI pierwszego panelu u¿yto gotowe rozwi¹zanie z za³¹czonego linku, w którym zmieniono kilka rzeczy:
dodano zmianê sceny zgodnie z poziomem trudnoœci,
nadano muzykê zale¿n¹ od poziomu trudnoœci,
odrzucono zbêdne opcje. 
https://assetstore.unity.com/packages/essentials/game-jam-menu-template-40465