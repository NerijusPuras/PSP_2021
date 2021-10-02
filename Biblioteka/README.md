Pastabos sukurtiems testams:

* nebuvo testuose True testo - nebuvo testuojama, ar pateikus teisinga reiksme, grazinama true pagrindiniai validate metodai
* i kai kuriuos skirtingus testus buvo paduodamos vienodos reiksmes. Pvz:
	- Password_WhenWithoutUppercaseSymbols_ShouldNotBeValid -> reiktu paduot tinkama password tik be upper case simboliu - paduoti su special simboliais siuo atveju
		ir
	- Password_WhenWithoutSpecialSymbol_ShouldNotBeValid -> paduoti tinkama password tik be specialiu simboliu. Dabartiniu atveju truksta tiek special symbol, tiek upper case
