"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.PlayingCard = void 0;
var Number;
(function (Number) {
    Number[Number["A"] = 1] = "A";
    Number[Number["Two"] = 2] = "Two";
    Number[Number["Three"] = 3] = "Three";
    Number[Number["Four"] = 4] = "Four";
    Number[Number["Five"] = 5] = "Five";
    Number[Number["Six"] = 6] = "Six";
    Number[Number["Seven"] = 7] = "Seven";
    Number[Number["Eight"] = 8] = "Eight";
    Number[Number["Nine"] = 9] = "Nine";
    Number[Number["Ten"] = 10] = "Ten";
    Number[Number["Jack"] = 11] = "Jack";
    Number[Number["Queen"] = 12] = "Queen";
    Number[Number["King"] = 13] = "King";
})(Number || (Number = {}));
var Suit;
(function (Suit) {
    Suit[Suit["Club"] = 0] = "Club";
    Suit[Suit["Diamond"] = 1] = "Diamond";
    Suit[Suit["Heart"] = 2] = "Heart";
    Suit[Suit["Spade"] = 3] = "Spade";
})(Suit || (Suit = {}));
class PlayingCard {
    constructor(cardIndex) {
        cardIndex = Math.abs(cardIndex) % 52;
        this.number_ = (cardIndex % 13) + 1;
        this.suit_ = Math.floor(cardIndex / 13);
        switch (this.number_) {
            case 1:
                this.sortValue_ = 13;
                break;
            default:
                this.sortValue_ = this.number_ - 1;
                break;
        }
    }
    get face() {
        return Suit[this.suit_] + this.suit_ + " " + Number[this.number_] + this.number_;
    }
    get sortValue() {
        return this.sortValue_;
    }
}
exports.PlayingCard = PlayingCard;
