enum Number {
    A = 1,
    Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, Jack, Queen, King
}
enum Suit {
    Club, Diamond, Heart, Spade
}
export class PlayingCard {
    private number_: Number
    private suit_: Suit
    private sortValue_: number
    constructor(cardIndex: number) {
        cardIndex = Math.abs(cardIndex) % 52
        this.number_ = (cardIndex % 13) + 1
        this.suit_ = Math.floor(cardIndex / 13)
        switch (this.number_) {
            case 1:
                this.sortValue_ = 13
                break;
            default:
                this.sortValue_ = this.number_ - 1
                break;
        }
    }
    public get face(): string {
        return Suit[this.suit_] + this.suit_ + " " + Number[this.number_] + this.number_
    }
    public get sortValue(): number {
        return this.sortValue_
    }
}