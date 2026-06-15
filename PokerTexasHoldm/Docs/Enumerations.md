# Enumeration Class Diagram

Beberapa detail Enumeration

## Card Suit

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

## Card Rank

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

## Hand Rank

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

### High Hand / High Card

- 5 Kartu yang dipegang **acak total**.
- Tidak ada angka yang kembar
- **Simbol Suit** campur - campur dan angkanya tidak berurutan
- 10 Clubs, 8 Diamond, 5 Heart, 3 Spades, 2 Diamond

### One Pair

- Kondisi dimana memiliki dua card dengan angka atau rank yang sama persis
- Misal memegang kartu angka 7 sebanyak dua biji
- Suitnya Terserah
- Contoh: **7** Club, **7** Diamond, 2 Heart, A Spade
- Contoh: **A** Spade, **A** Heart, 7 Diamond, 4 Club

### Two Pair

- Sama seperti **One Pair** yang satu kombo tapi kalau ini dia **dua kombo**
- Suitnya Terserah
- Contoh: **A** Spade, **A** Heart, **7** Diamond, **7** Heart, 6 Club

### Three of A Kind

- Kondisi dimana tiga kartu rank yang sama semua
- Dua kartu sisanya terserah
- Suitnya juga terserah
- Contoh: **J** Diamond, **J** Heart, **J** Spade, 3 Diamond, 8 Heart

### Straight

- Kondisi dimana **5 Card dengan angka yang berurutan secara Matematika**.
- Simbol Suit nya terserah dan boleh sama juga
- Contoh: **9** Heart, **8** Spade, **7** Diamond, **6** Diamond, **5** Heart

### Flush

- Kondisi dimana 5 Card memiliki Simbol Suit yang sama
- Untuk Rank Nomor / Key nya Terserah
- Contoh: K **Heart**, Q **Heart**, 9 **Heart**, 8 **Heart**, 5 **Heart**

### Full House

- Kondisi memiliki Card gabungan dari Tiga Card dengan angka / rank yang sama (Three of A Kind) dan Dua Card dengan
  angka / rank yang sama (One Pair)
- Simbol Suit terserah
- Contoh: **K** Spade, **K** Club, **K** Heart, **5** Diamond, **5** Heart

### Four of A Kind

- Kondisi dimana memiliki 4 Card dengan angka / rank yang sama
- Untuk sisanya (1 Card) terserah
- Simbol Suit Terserah
- Contoh: **A** Spade, **A** Club, **A** Heart, **A** Diamond, 9 Diamond

### Straight Flush

- Kondisi Card angka / rank nya berurutan (Straight) tapi untuk Simbol Suitnya Sama juga
- Contoh: **5 Heart**, **6 Heart**, **7 Heart**, **8 Heart**, **9 Heart**

### Royal Flush

- Kondisi Card sama seperti **Straight Flush**, cuma di-scope **10 >=**
- Contoh: **10 Heart**, **J Heart**, **Q Heart**, **K Heart**, **A Heart**

> Noted: Card A (Ace) ini Uniq. Dia bisa memiliki value 1 dan 14.
> Jika bisa di kombinasikan berada di rank angka sebagai 1 contohnya A, 2, 3, 4, 5 (artinya 1, 2, 3, 4, ,5) atau sebagai
> 14 contohnya J, Q, K, A (11, 12, 13, 14).
> Jadi Ace ini bisa digunakan di berbagai kombinasi

## Betting Action

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
- Misalnya Jika kartu benar - benar jelek di awal permainan, player bisa memutuskan untuk menyerah dengan memilih Fold
  atau pilihan lain misalnya Raise untuk menaikan jumlah taruhan

### Fold

- Seperti yang sudah di mention diatas, Player memutuskan untuk menyerah atau berhenti dari permainan
- Card tangan milik pemain akan langsung ditutup dan dibuang (tidak ikut diadu lagi)
- Semua Chip yang diadukan dimeja Pot akan Hangus
- Dan dilewati dari giliran

### Check

- Opsi untuk bertahan dan lanjut mengikuti permainan dengan lanjut ke tahap berikutnya
- Tujuannya menge-check kartu komunitas kedepannya tanpa harus menambah taruhan chip

### Call

- Sama seperti Check yang untuk lanjut mengikuti permainan
- Tetapi dia untuk menuetujui bertaruh dari orang yang mengusulkan Raise (Mengusulkan Penambahan Tarihan Chip)

### Raise

- Sama Seperti lainnya untuk lanjut mengikuti jalannya permainan
- Tetapi dia mengusulkan penambahan pertaruhan jumlah chip (seperti yang sudah di mention)
- Ketika ada pemain yang melakukan Raise, Pemain lain juga boleh melakukan perlawanan dengan melakukan Raise juga
  dengan, tetapi taruhan chipnya harus lebih besar daripada Raise sebelumnya

### All In

- Aksi mempertaruhkan seluruh sisa chip yang dimiliki pemain ke dalam Pot dalam satu ronde taruhan.
- Ini dapat dilakukan ketika Raise Custom jumlah chip atau ketika Call dengan jumlah chip yang kurang dari minimum
  pertaruhan chipnya

## Game Round

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

### Pre-Flop

- Babak awal saat semua pemain mendapatkan 2 Card Private (Hole Cards)
- Belum ada card community dimeja sama sekali
- Ronde taruhan pertama dimulai disini

### Flop

- Babak dimana 3 card community dimeja dibuka secara bersamaan
- Ronde taruhan kedua dimulai

### Turn

- Babak dimana membuka 1 card community tambahan (kartu ke 4) di atas meja
- Ronde taruhan ketiga dimulai

### River

- Babak final pembukaan kartu di mana sistem membuka 1 kartu komunitas terakhir (kartu ke-5) di atas meja
- Ini adalah ronde taruhan keempat atau yang terakhir di dalam permainan

### Showdown

- Babak akhir jika masih ada minimal 2 pemain yang bertaruh setelah ronde River
- Disini tidak ada taruhan lagi, melainkan semua pemain aktif wajib membuka Card di tangan mereka untuk diadu siapa yang
  memiliki kombinasi 5 card terbaik dan value terbanyak demi memenangkan seluruh chip dimeja Pot

## Player Status

```plantuml
class PlayerStatus {
    <<Enumeration>>
    Active,
    Folded,
    AllIn,
    Bust
}
```

- Status ini untuk menentukan siapa saja pemain yang berhak mendapatkan giliran (turn), berhak ikut taruhan, atau berhak
  memenangkan chip di akhir ronde

### Active

- Pemain yang masih hidup didalam ronde yang berjalan dan masih memiliki modal chip dikantongnya
- Kondisi digame, pemain ini wajib mengikuti alur taruhan
- Bisa memilih opsi `Check`, `Bet` (Player yang mulai awal), `Call`, `Raise`, atau `Fold` saat giliran tiba

### Folded

- Pemain yang memilih untuk mengundurkan diri diawal permainan atau di tengah - tengah Ronde yang berjalan
- Kartunya sudah dibuang dan akan dilewati dari giliran taruhan
- kehilangan hak atas aduan kartu di baba _Showdown_ untuk ronde tersebut
- Status ini akan di-reset otomatis kembali menjadi `Active` begitu Ronde baru dimulai lagi

### All In

- Pemain yang masih aktif bertanding tetapi seluruh sisa chip di kantongnya sudah habis dimasukkan ke dalam meja (Pot)
- Karena chipnya sudah 0, jalurnya tidak akan dimintai taruhan lagi di babak berikutnya (gilirannya otomatis di-pass
  oleh sistem)
- Tapi ingat, mereka tidak kalah
- Mereka tetap berhak ikut sampai babak Showdown untuk mengadu kartu dan memenangkan chip sesuai porsi taruhan yang
  mereka ikuti

### Bust

- Kondisi di mana seorang pemain sudah kehabisan seluruh chipnya secara permanen di dalam game (total chip di akun/meja
  benar-benar Rp0)
- Ini adalah status "Game Over" bagi si pemain
- Mereka dikeluarkan dari daftar pemain aktif di meja dan tidak bisa ikut lagi ke ronde-ronde besar berikutnya, kecuali
  mereka melakukan isi ulang chip (Buy-In ulang)
