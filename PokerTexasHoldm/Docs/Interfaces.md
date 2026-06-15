# Interfaces Class Diagram

Beberapa detail dari Interface

## Interface Renderer

```plantuml
class IRenderer {
    <<Interface>>
    +DisplayTable(Table table, List~Player~ players, GameRound round, Pot pot) : void
    +DisplayPlayerHand(Player player) : void
    +DisplayAllHands(List~HandResult~ results) : void
    +DisplayWinner(List~HandResult~ winners, int potAmount) : void
    +ClearScreen() : void
    +WaitForPlayer(Player player) : void
    +PromptAction(Player player, List~BettingAction~ allowedActions, int callAmount) : BettingAction
    +PromptRaiseAmount(Player player, int minRaise) : int
}
```

- `IRenderer` adalah sebuah interface (kontrak) yang bertugas mengatur semua urusan input dan output visual di dalam
  game
- _Interface_ ini memisahkan total antara logika bisnis game (Game Loop di `GameController`) dengan bagaimana game itu
  digambar di layar monitor
- `GameController` tidak perlu tahu apakah game ini digambar pakai teks di Console atau pakai grafik 3D, dia hanya tahu
  beres lewat interface ini

### Methods

- `+DisplayTable(...) : void`
    - Menggambar situasi meja taruhan saat ini. Menampilkan kartu komunitas yang terbuka di `Table`, posisi dan chip
      para `Player`, babak taruhan aktif (`GameRound`), serta total chip di tengah meja (`Pot`)
- `DisplayPlayerHand(Player player) : void`
    - Menampilkan 2 kartu tangan privat (Hole Cards) milik pemain yang sedang aktif ke layarnya sendiri (menjaga
      kerahasiaan kartu dari pemain lain)
- `+DisplayAllHands(List<HandResult> results) : void`
    - Dipanggil saat babak **Showdown**.
    - Berfungsi membuka semua kartu tangan pemain yang tersisa dan menampilkan hasil evaluasi kombinasi kartunya ke
      layar
- `+DisplayWinner(...) : void`
    - Menampilkan pengumuman pemenang ronde beserta jumlah chip (Pot) yang berhasil dikantongi
- `+ClearScreen() : void`
    - Membersihkan layar (misal `Console.Clear()`) sebelum menggambar ulang kondisi meja yang baru agar visualnya tidak
      menumpuk dan rapi
- `+WaitForPlayer(Player player) : void`
    - Menahan jalannya program (misal: _"Tekan ENTER untuk giliran Player B"_) agar pemain siap sebelum kartu privatnya
      ditampilkan di layar.
- `+PromptAction(...) : BettingAction`
    - Menampilkan menu pilihan aksi taruhan yang valid untuk pemain (seperti `Fold`, `Check`, `Call`, dll.) berdasarkan
      situasi meja saat itu, lalu menangkap tombol yang diklik/diketik pemain dan mengembalikannya ke sistem
- `+PromptRaiseAmount(...) : int`
    - Jika pemain memilih aksi `Raise`, method ini memunculkan kolom input khusus untuk menangkap berapa nominal chip
      yang ingin dinaikkan oleh pemain (minimal sebesar `minRaise`)

## Interface Evaluator

```plantuml
class IEvaluator {
    <<Interface>>
    +Evaluate(Hand playerHand, Table table) : HandResult
}
```

- interface (kontrak) yang bertugas mengatur seluruh logika penentuan kekuatan kombinasi kartu di akhir ronde permainan
  poker
- Interface ini memastikan bahwa `GameController` tidak perlu pusing memikirkan algoritma rumit cara mengecek kartu
  _Flush_, _Straight_, atau _Full House_
- `GameController` cukup melempar kartu yang ada ke _interface_ ini, dan _interface_ ini akan menjawab siapa pemenangnya
  secara otomatis

### Methods

- `+Evaluate(Hand playerHand, Table table) : HandResult`
    - Method ini menerima dua data input utama, yaitu kartu privat yang digenggam di tangan pemain (`Hand`) dan lima
      kartu komunitas yang terbuka di atas meja (`Table`)
    - Di belakang layar, sistem akan menggabungkan 2 kartu tangan + 5 kartu meja (total 7 kartu), lalu mencari *
      *kombinasi 5 kartu terbaik** yang bisa dibentuk berdasarkan aturan Hand Rankings Texas Hold'em
    - Setelah selesai dihitung, method ini akan membungkus hasilnya ke dalam objek `HandResult`, yang berisi informasi:
      nama pemainnya, tingkatan ranking kartunya (misal: _Two Pair_ dengan bobot nilai tertentu), dan daftar 5 kartu
      terbaiknya