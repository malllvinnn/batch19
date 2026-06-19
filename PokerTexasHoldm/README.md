# Mermaid Class Diagram Poker Texas Holdm

Ini adalah penjelasan tentang Class Diagram dari Desain [Poker Texas Holdm](./pokertexasholdm.mmd)

## Docs Spec

- [Enumerations](./Docs/Enumeration.md)
- [Interfaces](./Docs/Interfaces.md)
- [Abstract Classes](./Docs/AbstractClasses.md)
- [Concrete Classes](./Docs/ConcreteClasses.md)

## Revisi yang ke 2

- API yang perlu diexpose perlu ditambahin seperti game status,chips, dan lainnya.... intinya player tuh tahu / ngerti informasi yang ada dan Frontend tahu apa yang perlu dibuat dan di implementation
- Interface dari setiap concrete class.... jadi nanti di Game Controller cuma implement Interface nya dari concrete class yang ada
- buat Constructor masing masing concrete class.... biar nanti dari Game Controller tahu apa aja yang perlu di masukan
- Object Class Perlu di buat.... soalnya di real life Chips itu nyata...
  jadi misalnya di game controller tuh gini:
  Dictionary<Player, List<Chips>>
