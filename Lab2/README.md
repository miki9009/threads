
LAB.2
         W�tki startowane s� jednocze�nie, ka�dy z nich zwi�ksza warto�� zmiennej val o 10, jednak ka�dy z nich zak�ada blokad� w metodzie A,
         a nast�pnie zostaje u�piony na 1000ms. Co blokuje wykonanie metody A przez kolejny w�tek. Ka�dy kolejny w�tek musi odczeka� do zako�czenia
         pracy poprzedniego w�tku zanim zwi�kszy warto�� val, zanim wszystkie w�tki odczekaj� swoj� kolej, na konsoli zostanie wy�wietlona warto��
         val jeszcze przed ko�cem pracy wszystkich wcze�niejszych w�tk�w, je�li wykomentujemy blokad� wszystkie w�tki zako�cz� prac� przed wy�wietleniem
         informacji o warto�ci val. b�dzie ona r�wna 100, dla programu z blokad� warto�� val b�dzie wynosi� 20 poniewa� jedynie pierwszy sekwencyjny watek,
         zdazy zwolni� blokad� w metodzie A dla kolejnego w�tku