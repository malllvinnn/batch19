# Mermaid Class Diagram Poker Texas Holdm
Ini adalah penjelasan tentang Class Diagram dari Desain [Poker Texas Holdm](./pokertexasholdm.mmd)

## Enumeration
Beberapa detail Enumeration

### Card Suit
```plantuml
class CardSuit {
    <<enumeration>>
    Spades,
    Hearts,
    Diamonds,
    Clubs
}
```
- Ini adalah **Icon Suit** dari Card
- Spades: waruh, Hearth: Hati, Diamond: Wajik, Clubs: Keriting 

### Card Rank
```plantuml
class CardRank {
    <<enumeration>>
    Two= 2,
    Three,
    ...
    Ten,
    Jack= 11,
    Queen= 12,
    King= 13,
    Ace= 14
}
```
- Class untuk Top Level Rank Card (Value)

### Hand Rank
```plantuml
class HandRank {
    <<enumeration>>
    HighCard= 1,
    OnePair,
    TwoPair,
    ThreeOfAKind,
    Straight,
    Flush,
    FullHouse,
    FourOfAKind,
    StraightFlush,
    RoyalFLush
}
```
- Untuk Kombinasi Top Rank Card

#### High Hand / High Card
- 5 Kartu yang dipegang **acak total**. 
- Tidak ada angka yang kembar
- **Simbol Suit** campur - campur dan angkanya tidak berurutan
- 10 Clubs, 8 Diamond, 5 Heart, 3 Spades, 2 Diamond

#### One Pair
- Kondisi dimana memiliki dua card dengan angka atau rank yang sama persis
- Misal memegang kartu angka 7 sebanyak dua biji
- Suitnya Terserah
- Contoh: **7** Club, **7** Diamond, 2 Heart, A Spade
- Contoh: **A** Spade, **A** Heart, 7 Diamond, 4 Club

#### Two Pair
- Sama seperti **One Pair** yang satu kombo tapi kalau ini dia **dua kombo**
- Suitnya Terserah
- Contoh: **A** Spade, **A** Heart, **7** Diamond, **7** Heart, 6 Club

#### Three of A Kind
- Kondisi dimana tiga kartu rank yang sama semua
- Dua kartu sisanya terserah
- Suitnya juga terserah
- Contoh: **J** Diamond, **J** Heart, **J** Spade, 3 Diamond, 8 Heart

#### Straight
- Kondisi dimana **5 Card dengan angka yang berurutan secara Matematika**. 
- Simbol Suit nya terserah dan boleh sama juga
- Contoh: **9** Heart, **8** Spade, **7** Diamond, **6** Diamond, **5** Heart

#### Flush
- Kondisi dimana 5 Card memiliki Simbol Suit yang sama
- Untuk Rank Nomor / Key nya Terserah
- Contoh: K **Heart**, Q **Heart**, 9 **Heart**, 8 **Heart**, 5 **Heart**

#### Full House
- Kondisi memiliki Card gabungan dari Tiga Card dengan angka / rank yang sama (Three of A Kind) dan Dua Card dengan angka / rank yang sama (One Pair)
- Simbol Suit terserah
- Contoh: **K** Spade, **K** Club, **K** Heart, **5** Diamond, **5** Heart

#### Four of A Kind
- Kondisi dimana memiliki 4 Card dengan angka / rank yang sama
- Untuk sisanya (1 Card) terserah
- Simbol Suit Terserah
- Contoh: **A** Spade, **A** Club, **A** Heart, **A** Diamond, 9 Diamond

#### Straight Flush
- Kondisi Card angka / rank nya berurutan (Straight) tapi untuk Simbol Suitnya Sama juga
- Contoh: **5 Heart**, **6 Heart**, **7 Heart**, **8 Heart**, **9 Heart**

#### Royal Flush
- Kondisi Card sama seperti **Straight Flush**, cuma di-scope **10 >=**
- Contoh: **10 Heart**, **J Heart**, **Q Heart**, **K Heart**, **A Heart**

> Noted: Card A (Ace) ini Uniq. Dia bisa memiliki value 1 dan 14.
> Jika bisa di kombinasikan berada di rank angka sebagai 1 contohnya A, 2, 3, 4, 5 (artinya 1, 2, 3, 4, ,5) atau sebagai 14 contohnya J, Q, K, A (11, 12, 13, 14). 
> Jadi Ace ini bisa digunakan di berbagai kombinasi

### Betting Action
```plantuml
class BettingAction {
    <<enumeration>>
    Fold,
    Check,
    Call,
    Raise,
    AllIn
}
```
- Ini adalah aktivitas atau keputusan yang bisa diambil oleh player ketika sedang berjalannya permainan
- Misalnya Jika kartu benar - benar jelek di awal permainan, player bisa memutuskan untuk menyerah dengan memilih Fold atau pilihan lain misalnya Raise untuk menaikan jumlah taruhan

#### Fold
- Seperti yang sudah di mention diatas, Player memutuskan untuk menyerah atau berhenti dari permainan
- Card tangan milik pemain akan langsung ditutup dan dibuang (tidak ikut diadu lagi)
- Semua Chip yang diadukan dimeja Pot akan Hangus
- Dan dilewati dari giliran

#### Check
- Opsi untuk bertahan dan lanjut mengikuti permainan dengan lanjut ke tahap berikutnya
- Tujuannya menge-check kartu komunitas kedepannya tanpa harus menambah taruhan chip

#### Call
- Sama seperti Check yang untuk lanjut mengikuti permainan
- Tetapi dia untuk menuetujui bertaruh dari orang yang mengusulkan Raise (Mengusulkan Penambahan Tarihan Chip)

#### Raise
- Sama Seperti lainnya untuk lanjut mengikuti jalannya permainan
- Tetapi dia mengusulkan penambahan pertaruhan jumlah chip (seperti yang sudah di mention)
- Ketika ada pemain yang melakukan Raise, Pemain lain juga boleh melakukan perlawanan dengan melakukan Raise juga dengan, tetapi taruhan chipnya harus lebih besar daripada Raise sebelumnya

#### All In
- Aksi mempertaruhkan seluruh sisa chip yang dimiliki pemain ke dalam Pot dalam satu ronde taruhan.
- Ini dapat dilakukan ketika Raise Custom jumlah chip atau ketika Call dengan jumlah chip yang kurang dari minimum pertaruhan chipnya

### Game Round
```plantuml
class GameRound {
    <<enumeration>>
    PreFlop,
    Flop,
    Turn,
    River,
    Showdown
}
```
- Ini adalah Rounde jalannya permainan

#### Pre-Flop
- Babak awal saat semua pemain mendapatkan 2 Card Private (Hole Cards)
- Belum ada card community dimeja sama sekali
- Ronde taruhan pertama dimulai disini

#### Flop
- Babak dimana 3 card community dimeja dibuka secara bersamaan
- Ronde taruhan kedua dimulai

#### Turn
- Babak dimana membuka 1 card community tambahan (kartu ke 4) di atas meja
- Ronde taruhan ketiga dimulai

#### River
- Babak final pembukaan kartu di mana sistem membuka 1 kartu komunitas terakhir (kartu ke-5) di atas meja
- Ini adalah ronde taruhan keempat atau yang terakhir di dalam permainan

#### Showdown
- Babak akhir jika masih ada minimal 2 pemain yang bertaruh setelah ronde River
- Disini tidak ada taruhan lagi, melainkan semua pemain aktif wajib membuka Card di tangan mereka untuk diadu siapa yang memiliki kombinasi 5 card terbaik dan value terbanyak demi memenangkan seluruh chip dimeja Pot

### Player Status
```plantuml
class PlayerStatus {
    <<Enumeration>>
    Active,
    Folded,
    AllIn,
    Bust
}
```
- Status ini untuk menentukan siapa saja pemain yang berhak mendapatkan giliran (turn), berhak ikut taruhan, atau berhak memenangkan chip di akhir ronde

#### Active
- Pemain yang masih hidup didalam ronde yang berjalan dan masih memiliki modal chip dikantongnya
- Kondisi digame, pemain ini wajib mengikuti alur taruhan
- Bisa memilih opsi `Check`, `Bet` (Player yang mulai awal), `Call`, `Raise`, atau `Fold` saat giliran tiba

#### Folded
- Pemain yang memilih untuk mengundurkan diri diawal permainan atau di tengah - tengah Ronde yang berjalan
- Kartunya sudah dibuang dan akan dilewati dari giliran taruhan
- kehilangan hak atas aduan kartu di baba _Showdown_ untuk ronde tersebut
- Status ini akan di-reset otomatis kembali menjadi `Active` begitu Ronde baru dimulai lagi

#### All In
- Pemain yang masih aktif bertanding tetapi seluruh sisa chip di kantongnya sudah habis dimasukkan ke dalam meja (Pot)
- Karena chipnya sudah 0, jalurnya tidak akan dimintai taruhan lagi di babak berikutnya (gilirannya otomatis di-pass oleh sistem)
- Tapi ingat, mereka tidak kalah
- Mereka tetap berhak ikut sampai babak Showdown untuk mengadu kartu dan memenangkan chip sesuai porsi taruhan yang mereka ikuti

#### Bust
- Kondisi di mana seorang pemain sudah kehabisan seluruh chipnya secara permanen di dalam game (total chip di akun/meja benar-benar Rp0)
- Ini adalah status "Game Over" bagi si pemain
- Mereka dikeluarkan dari daftar pemain aktif di meja dan tidak bisa ikut lagi ke ronde-ronde besar berikutnya, kecuali mereka melakukan isi ulang chip (Buy-In ulang)

## Interfaces
Beberapa detail dari Interface

### Interface Renderer
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
- `IRenderer` adalah sebuah interface (kontrak) yang bertugas mengatur semua urusan input dan output visual di dalam game
- _Interface_ ini memisahkan total antara logika bisnis game (Game Loop di `GameController`) dengan bagaimana game itu digambar di layar monitor
- `GameController` tidak perlu tahu apakah game ini digambar pakai teks di Console atau pakai grafik 3D, dia hanya tahu beres lewat interface ini

#### Methods
- `+DisplayTable(...) : void`
  - Menggambar situasi meja taruhan saat ini. Menampilkan kartu komunitas yang terbuka di `Table`, posisi dan chip para `Player`, babak taruhan aktif (`GameRound`), serta total chip di tengah meja (`Pot`)
- `DisplayPlayerHand(Player player) : void`
  - Menampilkan 2 kartu tangan privat (Hole Cards) milik pemain yang sedang aktif ke layarnya sendiri (menjaga kerahasiaan kartu dari pemain lain)
- `+DisplayAllHands(List<HandResult> results) : void`
  - Dipanggil saat babak **Showdown**. 
  - Berfungsi membuka semua kartu tangan pemain yang tersisa dan menampilkan hasil evaluasi kombinasi kartunya ke layar
- `+DisplayWinner(...) : void`
  - Menampilkan pengumuman pemenang ronde beserta jumlah chip (Pot) yang berhasil dikantongi
- `+ClearScreen() : void`
  - Membersihkan layar (misal `Console.Clear()`) sebelum menggambar ulang kondisi meja yang baru agar visualnya tidak menumpuk dan rapi
- `+WaitForPlayer(Player player) : void`
  - Menahan jalannya program (misal: _"Tekan ENTER untuk giliran Player B"_) agar pemain siap sebelum kartu privatnya ditampilkan di layar.
- `+PromptAction(...) : BettingAction`
  - Menampilkan menu pilihan aksi taruhan yang valid untuk pemain (seperti `Fold`, `Check`, `Call`, dll.) berdasarkan situasi meja saat itu, lalu menangkap tombol yang diklik/diketik pemain dan mengembalikannya ke sistem
- `+PromptRaiseAmount(...) : int`
  - Jika pemain memilih aksi `Raise`, method ini memunculkan kolom input khusus untuk menangkap berapa nominal chip yang ingin dinaikkan oleh pemain (minimal sebesar `minRaise`)

### Interface Evaluator
```plantuml
class IEvaluator {
    <<Interface>>
    +Evaluate(Hand playerHand, Table table) : HandResult
}
```
- interface (kontrak) yang bertugas mengatur seluruh logika penentuan kekuatan kombinasi kartu di akhir ronde permainan poker
- Interface ini memastikan bahwa `GameController` tidak perlu pusing memikirkan algoritma rumit cara mengecek kartu _Flush_, _Straight_, atau _Full House_
- `GameController` cukup melempar kartu yang ada ke _interface_ ini, dan _interface_ ini akan menjawab siapa pemenangnya secara otomatis

#### Methods
- `+Evaluate(Hand playerHand, Table table) : HandResult`
  - Method ini menerima dua data input utama, yaitu kartu privat yang digenggam di tangan pemain (`Hand`) dan lima kartu komunitas yang terbuka di atas meja (`Table`)
  - Di belakang layar, sistem akan menggabungkan 2 kartu tangan + 5 kartu meja (total 7 kartu), lalu mencari **kombinasi 5 kartu terbaik** yang bisa dibentuk berdasarkan aturan Hand Rankings Texas Hold'em
  - Setelah selesai dihitung, method ini akan membungkus hasilnya ke dalam objek `HandResult`, yang berisi informasi: nama pemainnya, tingkatan ranking kartunya (misal: _Two Pair_ dengan bobot nilai tertentu), dan daftar 5 kartu terbaiknya

## Abstract Classes
Berikut adalah detail dari Abstract Class

### Card
```plantuml
class Card {
    <<Abstract>>
    +CardSuit Suit : readonly
    +CardRank Rank : readonly
    +bool IsRevealed
    
    #Card(CardSuit suit, CardRank rank)
    +ToString() : string
    +GetPowerValue() : int
}
```
- Kelas ini adalah representasi abstrak dari selembar kartu poker
- Kartu itu harus jelas wujudnya: 
  - Apakah dia kartu genggam (HoleCard) 
  - Atau kartu meja (CommunityCard).
- Abstract Class ini berfungsi untuk menghindari duplikasi kode (_Don't Repeat Yourself_ / DRY)
- Daripada menulis properti `Suit` dan `Rank` berkali-kali di kelas `HoleCard` dan `CommunityCard`, cukup menulisnya sekali di kelas `Card` ini
- Semua kelas Child otomatis langsung punya data tersebut
#### Methods
- `+ToString() : string`
  - Mengubah objek kartu menjadi teks murni (misal: `"Ace of Spades"`).
  - Kelas anak bisa meng-_override_ (merombak) fungsinya untuk menyensor teks jika kartu dalam posisi tertutup (`IsRevealed = false`)
- `+GetPowerValue() : int`
  - Mengubah teks enum CardRank menjadi angka matematika (`int`) murni (misal: _Jack_ jadi 11, _Ace_ jadi 14)
  - Ini adalah fungsi wajib yang akan dipanggil oleh `HandEvaluator` untuk mengurutkan dan mengadu kekuatan kartu saat babak _Showdown_

## Concrete Classes
Berikut adalah beberapa detail dari Class

### Hole Card
```plantuml
class HoleCard {
    +HoleCard(CardSuit suit, CardRank rank)
    +ToString() : string
}
```
- Class ini mewakili 2 kartu privat rahasia yang dipegang secara personal oleh masing-masing pemain di atas meja

#### Methods
- `+ToString() : string`
  - Mengubah objek kartu tangan menjadi teks biasa agar bisa dibaca manusia
  - Khusus di `HoleCard`, method ini biasanya di-_override_ untuk menyensor visual 
  - Jika properti `IsRevealed` bernilai false (kartu ditutup dari lawan), method ini akan mengembalikan teks seperti `"[HIDDEN]"` atau `"[🂠]"` di layar, dan baru memunculkan teks asli seperti `"Ace of Spades"` jika statusnya berubah jadi true (saat giliran si pemilik kartu atau saat babak _Showdown_)

