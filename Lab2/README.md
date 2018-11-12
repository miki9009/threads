
LAB.2
         W¹tki startowane s¹ jednoczeœnie, ka¿dy z nich zwiêksza wartoœæ zmiennej val o 10, jednak ka¿dy z nich zak³ada blokadê w metodzie A,
         a nastêpnie zostaje uœpiony na 1000ms. Co blokuje wykonanie metody A przez kolejny w¹tek. Ka¿dy kolejny w¹tek musi odczekaæ do zakoñczenia
         pracy poprzedniego w¹tku zanim zwiêkszy wartoœæ val, zanim wszystkie w¹tki odczekaj¹ swoj¹ kolej, na konsoli zostanie wyœwietlona wartoœæ
         val jeszcze przed koñcem pracy wszystkich wczeœniejszych w¹tków, jeœli wykomentujemy blokadê wszystkie w¹tki zakoñcz¹ pracê przed wyœwietleniem
         informacji o wartoœci val. bêdzie ona równa 100, dla programu z blokad¹ wartoœæ val bêdzie wynosiæ 20 poniewa¿ jedynie pierwszy sekwencyjny watek,
         zdazy zwolniæ blokadê w metodzie A dla kolejnego w¹tku