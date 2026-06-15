# Concrete Classes

Berikut adalah beberapa detail dari Class

## Hole Card

```plantuml
class HoleCard {
    +HoleCard(CardSuit suit, CardRank rank)
    +ToString() : string
}
```

- Class ini mewakili 2 kartu privat rahasia yang dipegang secara personal oleh masing-masing pemain di atas meja

### Methods

- `+ToString() : string`
    - Mengubah objek kartu tangan menjadi teks biasa agar bisa dibaca manusia
    - Khusus di `HoleCard`, method ini biasanya di-_override_ untuk menyensor visual
    - Jika properti `IsRevealed` bernilai false (kartu ditutup dari lawan), method ini akan mengembalikan teks seperti
      `"[HIDDEN]"` atau `"[🂠]"` di layar, dan baru memunculkan teks asli seperti `"Ace of Spades"` jika statusnya
      berubah jadi true (saat giliran si pemilik kartu atau saat babak _Showdown_)

## Community Card

```plantuml
class CommunityCard {
    +CommunityCard(CardSuit suit, CardRank rank)
    +ToString() : string
}
```

- Class ini mewakili 5 kartu publik yang dibuka secara bertahap oleh sistem di tengah meja (saat babak _Flop_, _Turn_,
  dan _River_) yang bisa dikombinasikan oleh semua pemain yang ada di meja game.

### Methods

- `+ToString() : string`
    - Mengubah objek kartu tangan menjadi teks biasa agar bisa dibaca manusia
    - Berbeda dengan `HoleCard` yang perlu logika sensor/sembunyi, `CommunityCard` begitu dibagikan ke meja sifatnya
      langsung transparan dan bisa dilihat semua orang
    - Jadi method `ToString()` di sini fungsinya sangat blak-blakan—langkahnya langsung mengembalikan nama asli kartunya
      agar `IRenderer` bisa langsung menggambarnya di monitor para pemain tanpa sensor

## Deck

```plantuml
class Deck {
    -List~Card~ _card
    -Random _random
    
    +Deck()
    +Shuffle() : void
    +Deal() : Card
    +Reset() : void
}
```

- Class ini bertugas sebagai manajemen stok kartu permainan.
- Di dalamnya terdapat field _private_ berupa list kumpulan objek kartu (`_cards`) dan pengacak angka (`_random`)

### Methods

- `+Shuffle() : void`
    - Mengocok urutan 52 kartu di dalam list `_cards` secara acak
    - Method ini akan memanfaatkan variabel _random menggunakan algoritma pengacakan (seperti Fisher-Yates Shuffle)
      untuk menukar-nukar posisi indeks kartu di dalam list agar urutannya tidak bisa ditebak oleh pemain
- `+Deal() : Card`
    - Mengambil dan membagikan satu lembar kartu dari urutan paling atas tumpukan, lalu menghapusnya dari list stok agar
      tidak keluar dua kali
    - Method Mengembalikan Object `Card`
    - Saat game berjalan, `GameController` akan memanggil fungsi ini untuk membagikan kartu ke tangan player (
      `HoleCard`) atau membukanya di atas meja (`CommunityCard`)
- `+Reset() : void`
    - Mengosongkan sisa kartu yang ada di meja/tangan, lalu menyusun ulang tumpukan kartu menjadi 52 lembar baru yang
      utuh
    - Dipanggil setiap kali sebuah ronde permainan poker telah selesai (_Hand Over_) dan sistem ingin memulai babak
      permainan baru dari nol

## Hand

```plantuml
class Hand {
    -List~HoleCard~ _card
    
    +Hand()
    +AddCard(HoleCard card) : void
    +GetCards() : List~HoleCard~
    +Clear() : void
}
```

- Class ini berfungsi sebagai wadah penyimpanan kartu _privat_ milik pemain.
- Di dalamnya terdapat field private berupa list bernama `_cards` yang bertugas mengunci kartu agar tidak bisa diakses
  langsung secara ilegal dari luar kelas

### Methods

- `+AddCard(HoleCard card) : void`
    - Memasukkan sebuah objek `HoleCard` yang baru dibagikan oleh pembagi kartu ke dalam list internal `_cards`
    - Method ini akan dipanggil sebanyak 2 kali oleh `GameController` di babak _Pre-Flop_ untuk mengisi tangan pemain
      hingga batas maksimal (2 kartu)
- `+GetCards() : List~HoleCard~`
    - Mengembalikan (_return_) seluruh daftar kartu tangan yang sedang dipegang oleh pemain dalam bentuk koleksi `List`
    - Karena variabel `_cards` di atas bersifat rahasia (_private_), method publik inilah yang akan digunakan oleh mesin
      pengadu kartu (`HandEvaluator`) untuk membaca apa saja kartu yang dimiliki pemain saat babak penentuan pemenang (
      _Showdown_)
- `+Clear() : void`
    - Mengosongkan total semua kartu yang ada di dalam list `_cards` (menjadikan jumlah kartu kembali 0)
    - Dipanggil di akhir ronde ketika kartu harus dikembalikan ke meja, bersiap mengosongkan tangan pemain sebelum babak
      baru berikutnya dimulai lagi dari nol

## Table

```plantuml
class Table {
    -List~CommunityCard~ _communityCard
    
    +Table()
    +AddCommunityCard(CommunityCard card) : void
    +GetCommunityCards() : List~CommunityCard~
    +Clear() : void
}
```

- Class ini berfungsi sebagai wadah penampung kartu komunitas di tengah meja.
- Di dalamnya terdapat field _private_ berupa list bernama `_communityCards` agar kartu di meja tidak bisa dimanipulasi
  atau diubah datanya secara ilegal di luar alur game

### Methods

- `AddCommunityCard(CommunityCard card) : void`
    - Memasukkan objek `CommunityCard` yang diambil dari `Deck` ke dalam list internal `_communityCards`
    - Method ini akan dipanggil oleh `GameController` secara bertahap sepanjang ronde:
        - membuka 3 kartu sekaligus di babak _Flop_,
        - menambah 1 kartu di babak _Turn_,
        - dan menambah 1 kartu terakhir di babak _River_
- `GetCommunityCards() : List~CommunityCard~`
    - Mengembalikan (_return_) seluruh daftar kartu komunitas yang saat ini sudah terbuka di atas meja
    - Method ini akan diakses oleh dua komponen penting:
        - `IRenderer` untuk menggambar kartu apa saja yang ada di meja ke layar monitor
        - Dan `IEvaluator` untuk menggabungkan kartu meja ini dengan kartu tangan pemain saat menghitung kombinasi
          terbaik
- `Clear() : void`
    - Mengosongkan total list `_communityCards` sehingga jumlah kartu di meja kembali menjadi 0
    - Dipanggil tepat setelah sebuah ronde permainan berakhir (_Hand Over_), membersihkan meja dari kartu lama agar siap
      digunakan kembali untuk ronde taruhan berikutnya

## Player

```plantuml
class Player {
    +int Id: readonly
    +string Name: readonly
    +int Chips
    +int CurrentRoundBet
    +PlayerStatus Status
    +Hand Hand: readonly
    +Player(int id, string name, int initialChips)
    +PlaceBet(int amount): int
    +WinPot(int amount): void
    +ResetRoundBet(): void
    +IsActive(): bool
    }
```

- Class ini merepresentasikan setiap pemain yang duduk di meja game.
- Class ini menggabungkan data identitas, dompet chip (_Chips_), dan kartu di tangan (_Hand_)

### Constructor

- `+Player(int id, string name, int initialChip)`
    - Method yang berjalan saat objek pemain baru diciptakan (misal: saat pendaftaran pemain di awal game)
    - Mengunci ID dan nama pemain, memberikan modal awal chip (`initialChips`), serta menghidupkan objek `Hand` kosong
      yang menempel khusus pada pemain tersebut

### Method

- `+PlaceBet(int amount) : void`
    - Mengurangi jumlah chip milik pemain sebesar nominal `amount` untuk dimasukkan ke dalam taruhan di meja, lalu
      mengembalikan (_return_) jumlah chip yang berhasil ditaruhkan
    - Method ini bertugas memotong saldo chip pemain saat mereka melakukan aksi _Call_ atau _Raise_
    - Nilai `amount` yang dipotong akan ditambahkan ke properti `CurrentRoundBet` untuk melacak total taruhan pemain di
      babak aktif tersebut
- `+WinPot(int amount) : void`
    - Menambahkan chip pemain sebesar nominal `amount` yang didapat dari total hadiah taruhan di tengah meja
    - Method ini dipanggil oleh `GameController` di akhir ronde (_Showdown_) khusus untuk pemain yang dinyatakan menang,
      agar chip kemenangan mereka langsung masuk kembali ke dompet (`Chips`)
- `+ResetRoundBet() : void`
    - Mengembalikan nilai properti `CurrentRoundBet` menjadi angka 0
    - Dipanggil setiap kali babak taruhan berpindah (misal dari _Pre-Flop_ ke _Flop_)
    - Taruhan ronde sebelumnya sudah dianggap aman, sehingga taruhan pemain di babak baru harus dihitung ulang dari nol
- `+IsActive() : bool`
    - Mengecek dan mengembalikan nilai boolean (`true`/`false`) apakah pemain ini masih berhak ikut bermain atau tidak
    - Method ini menyederhanakan pengecekan kondisi pemain.
    - Di dalamnya, sistem tinggal mengecek status dari enum `PlayerStatus`.
    - Jika status pemain adalah `Active` atau `AllIn`, method ini mereturn `true`.
    - Tapi jika statusnya `Folded` (menyerah) atau `Bust` (bangkrut/chip habis), method ini mereturn `false` sehingga
      mereka dilewati dari giliran bertaruh

## Pot

```plantuml
class Pot {
    -Dictionary~int, int~ _contributions
    +int TotalChips
    +Pot()
    +AddContribution(int playerId, int amount) : void
    +GetContribution(int playerId) : int
    +Reset() : void
}
```

- Class ini bertanggung jawab penuh untuk mengelola, mencatat, dan menampung seluruh chip taruhan yang dipertaruhkan
  oleh para pemain di atas meja

### Fields / Properties

- `-Dictonary~int, int~ _contributions`
    - Kamus Data (Dictionary) dengan pasangan `Key: int` dan `Value: int`
    - Tempat penyimpanan rahasia (_private_) untuk mendata kontribusi taruhan.
    - `Key` (kunci) digunakan untuk mengunci ID unik Pemain, dan `Value` (nilai) digunakan untuk mengunci total
      akumulasi chip taruhan yang sudah disetorkan oleh pemain tersebut sepanjang babak berjalan
- `+int TotalChip`
    - Publik (bisa dibaca oleh kelas lain seperti `GameController` atau `IRenderer`)
    - Dan menyimpan total kesuluran chip yang ditengah meja tarihan saat ini secara _real-time_ (gabungan dari seluru
      taruhan pemain)

### Constructor

- `+Pot()`
    - Menyediakan ruang penyimpanan di memori saat objek wadah taruhan pertama kali dibuat oleh game
    - Ini akan menginstansiasi field `_contributions` secara mandiri dari dalam kelas menggunakan keyword
      `new Dictionary<int, int>()` sebagai objek kamus yang kosong, serta menyetel properti `TotalChips` ke angka 0

### Methods

- `+AddContribution(int playerId, int amount) : void`
    - Memasukkan atau menambahkan nominal chip yang ditaruhkan oleh pemain ke dalam kas meja
    - Method ini menerima kiriman data dari luar melalui parameternya
        - Parameter `playerId` dipetakan sebagai `Key` (identitas)
        - Parameter `amount` dipetakan sebagai `Value` (nominal)
        - Sistem akan mengecek apakah `playerId` (Key) tersebut sudah terdaftar di dalam Dictionary `_contributions`
        - Jika Sudah Ada, nominal `amount` baru akan dijumlahkan ke dalam nilai `Value` lama milik pemain tersebut.
        - Jika Belum Ada, data baru akan didaftarkan ke dalam `Dictionary` (Key baru dengan Value awal).
        - Method ini juga otomatis menambahkan angka `amount` ke properti global `TotalChips`
- `+GetContribution(int playerId) : void`
    - Mengambil dan mengembalikan (_return_) total nominal chip yang sudah disetorkan oleh satu pemain spesifik
    - Menggunakan parameter `playerId` sebagai kunci pencarian (_Key_) untuk membongkar Dictionary internal
      `_contributions`, lalu mengembalikan total akumulasi chip (_Value_) yang sudah disetorkan oleh pemain tersebut.
    - Sangat krusial digunakan oleh `GameController` untuk menghitung kalkulasi taruhan sampingan (_Side Pot_) jika ada
      pemain yang melakukan aksi _All-In_
- `+Reset() : void`
    - Mengosongkan kembali seluruh catatan taruhan di dalam meja
    - Mengosongkan total isi Dictionary `_contributions` (menghapus semua pasangan Key & Value) dan mengembalikan angka
      properti `TotalChips` menjadi 0
    - Dipanggil tepat setelah chip hadiah diserahkan kepada pemenang ronde, membuat kelas ini siap digunakan kembali
      untuk babak taruhan berikutnya dari nol

## Hand Result

```plantuml
class HandResult {
    +Player Player : readonly
    +HandRank Rank : readonly
    +List~Card~ BestFiveCards : readonly
    +HandResult(Player player, HandRank rank, List~Card~ bestFive)
    +CompareTo(HandResult other) : int
}
```

- Class ini bertugas untuk membungkus data hasil penilaian akhir kombinasi kartu seorang pemain agar siap diadu dengan
  hasil milik pemain lainnya

### Properties

- `+Player player : readonly`
    - Object dari class `Player`
    - Menyimpan data identitas pemain pemilik kartu tersebut.
    - Diberi tanda `readonly` agar data kepemilikan kartu terkunci aman dan tidak bisa ditukar dengan objek pemain lain
      di tengah jalan
- `+HandRank Rank : readonly`
    - Enumeration dari HandRank, berisi rank poker (seperti _HighCard_, _TwoPair_, _FullHouse_, hingga _RoyalFlush_)
    - Menyimpan kasta/ranking tertinggi yang berhasil diraih dari kombinasi kartu pemain tersebut
- `+List~Card~ BestFiveCards : readonly`
    - Daftar koleksi objek kartu (`List<Card>`)
    - Menyimpan 5 lembar kartu terbaik yang membentuk ranking tersebut (gabungan dari kartu tangan dan kartu meja).
    - Ini penting dicatat karena jika ada dua pemain yang memiliki Rank yang sama (misal sama-sama punya _One Pair_),
      sistem akan melihat isi kartu di dalam daftar ini untuk menentukan siapa yang angka kartunya lebih tinggi (_Kicker
      card_)

### Constructor

- `+HandResult(Player player, HandRank rank, List~Card~ bestFive)`
    - Konstruktor utama untuk menciptakan objek "Sertifikat Skor" ini setelah mesin `HandEvaluator` selesai menghitung
      kartu seorang pemain
    - Menerima 3 parameter input dari luar (objek player, tingkatan rankingnya, dan daftar 5 kartu terbaiknya)
    - Di dalam constructor, ketiga data kiriman dari luar ini langsung disuntikkan dan dikunci ke dalam properti
      `Player`, `Rank`, dan `BestFiveCards`

### Methods

- `+CompareTo(HandResult other) : int`
    - Method yang digunakan untuk mengadu/membandingkan kekuatan skor dirinya dengan skor milik pemain lain (`other`)
    - Method ini menerima objek `HandResult` milik lawan lewat parameter `other`, lalu membandingkan nilai kasta `Rank`
      keduanya.
    - Method ini mengembalikan angka matematika (`int`):
        - Angka Positif (1): Jika kombinasi kartu kita lebih kuat daripada lawan
        - Angka Negatif (-1): Jika kombinasi kartu kita lebih lemah daripada lawan
        - Angka Nol (0): Jika kekuatan kartu kita benar-benar imbang/seri (_Split Pot_)
    - Tujuan Desainnya adalah menerapkan interface bawaan C# (`IComparable`).
    - Taktik ini mempermudah `GameController` untuk mengurutkan semua skor pemain dari yang terendah ke tertinggi cukup
      dengan memanggil fungsi otomatis seperti `List.Sort()`

## Hand Evaluate

```plantuml
class HandEvaluator {
    +Evaluate(Hand playerHand, Table table) : HandResult
    -EvaluateBestFive(List~Card~ allCards) : HandResult
    -IsRoyalFlush(List~Card~ cards) : bool
    -IsStraightFlush(List~Card~ cards) : bool
    -IsFourOfAKind(List~Card~ cards) : bool
    -IsFullHouse(List~Card~ cards) : bool
    -IsFlush(List~Card~ cards) : bool
    -IsStraight(List~Card~ cards) : bool
    -IsThreeOfAKind(List~Card~ cards) : bool
    -IsTwoPair(List~Card~ cards) : bool
    -IsOnePair(List~Card~ cards) : bool
}
```

Class ini bertindak sebagai Rule Engine (mesin penegak aturan game) yang murni berisi algoritma pemrosesan data tanpa
menyimpan status data permainan apa pun

### Methods

- `+Evaluate(Hand playerHand, Table table) : HandResult`
    - Method utama yang dipanggil oleh GameController untuk meminta hasil penilaian kartu seorang pemain
    - Method ini menerima 2 objek:
        - playerHand (2 kartu rahasia player)
        - Dan table (5 kartu komunitas di meja)
    - Di dalam method ini, sistem akan mengambil daftar kartu dari keduanya lewat fungsi `.GetCards()` dan
      `.GetCommunityCards()`, lalu menggabungkannya ke dalam satu buah `List<Card>` raksasa yang berisi 7 lembar kartu
    - Daftar 7 kartu ini kemudian dilempar ke method _privat_ `EvaluateBestFive` untuk dicari 5 kartu terbaiknya
- `-EvaluateBestFive(List~Card~ allCards) : HandResult`
    - Menyaring 7 lembar kartu menjadi 5 lembar kartu kombinasi terbaik dengan kasta tertinggi
    - Menerima gabungan 7 kartu dari parameter `allCards`
    - Method ini akan menjalankan rangkaian fungsi pengecekan (kombinasi matematika poker) secara berurutan dari kasta
      paling dewa ke kasta paling ampas (mulai dari IsRoyalFlush ke bawah).
    - Begitu salah satu fungsi bernilai true, pencarian dihentikan, lalu method ini langsung membungkus hasilnya dan
      me-mereturn objek HandResult baru
- `-IsRoyalFlush(List~Card~ cards) : bool` sampai `-IsOnePair(List~Card~ cards) : bool`
    - Rangkaian fungsi validator khusus untuk mengecek keabsahan pola kartu poker (seperti urutan angka, kesamaan
      lambang, atau jumlah kembar)
    - Semuanya bertipe _private_ (`-`) karena kelas lain tidak boleh ikut campur dalam hitungan dapur ini.
    - Semuanya menerima parameter `List<Card>` (7 kartu gabungan) dan mengembalikan nilai boolean (`true` jika polanya
      cocok, atau `false` jika tidak cocok)
    - Urutan Pengecekan Kasta (Sangat Krusial):
        1. `IsRoyalFlush`: Cek apakah ada kartu 10-J-Q-K-A dengan lambang yang sama
        2. `IsStraightFlush`: Cek apakah ada 5 kartu berurutan dengan lambang yang sama
        3. `IsFourOfAKind`: Cek apakah ada 4 kartu dengan angka kembar yang sama
        4. `IsFullHouse`: Cek apakah ada kombinasi 3 kartu kembar + 2 kartu kembar (Three of a Kind + Pair)
        5. `IsFlush`: Cek apakah ada 5 kartu yang lambangnya sama semua (angkanya bebas)
        6. `IsStraight`: Cek apakah ada 5 kartu yang angkanya berurutan (lambangnya bebas)
        7. `IsThreeOfAKind`: Cek apakah ada 3 kartu dengan angka kembar yang sama
        8. `IsTwoPair`: Cek apakah ada dua pasang kartu kembar (misal sepasang angka 4 dan sepasang angka King)
        9. `IsOnePair`: Cek apakah ada sepasang kartu dengan angka kembar yang sama
        10. `High Card` (Jika semua fungsi di atas mereturn false, otomatis kartu pemain hanya dihitung berdasarkan
            angka tertinggi yang dipegangnya)
