# Abstract Classes

Berikut adalah detail dari Abstract Class

## Card

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
- Daripada menulis properti `Suit` dan `Rank` berkali-kali di kelas `HoleCard` dan `CommunityCard`, cukup menulisnya
  sekali di kelas `Card` ini
- Semua kelas Child otomatis langsung punya data tersebut

### Methods

- `+ToString() : string`
    - Mengubah objek kartu menjadi teks murni (misal: `"Ace of Spades"`).
    - Kelas anak bisa meng-_override_ (merombak) fungsinya untuk menyensor teks jika kartu dalam posisi tertutup (
      `IsRevealed = false`)
- `+GetPowerValue() : int`
    - Mengubah teks enum CardRank menjadi angka matematika (`int`) murni (misal: _Jack_ jadi 11, _Ace_ jadi 14)
    - Ini adalah fungsi wajib yang akan dipanggil oleh `HandEvaluator` untuk mengurutkan dan mengadu kekuatan kartu saat
      babak _Showdown_