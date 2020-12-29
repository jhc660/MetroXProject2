using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public StationStatus type;
    public int value;
    public Card(StationStatus type, int value)
    {
        this.type = type;
        this.value = value;
    }
}

public class CardDeck {
    List<Card> Deck = new List<Card>();
    List<Card> Discard = new List<Card>();

	public CardDeck()
    {
        Deck.Add(new Card(StationStatus.Filled, 2));
        Deck.Add(new Card(StationStatus.Filled, 2));
        Deck.Add(new Card(StationStatus.Filled, 3));
        Deck.Add(new Card(StationStatus.Filled, 3));
        Deck.Add(new Card(StationStatus.Filled, 3));
        Deck.Add(new Card(StationStatus.Filled, 3));
        Deck.Add(new Card(StationStatus.Filled, 4));
        Deck.Add(new Card(StationStatus.Filled, 4));
        Deck.Add(new Card(StationStatus.Filled, 4));
        Deck.Add(new Card(StationStatus.Filled, 4));
        Deck.Add(new Card(StationStatus.Filled, 4));
        Deck.Add(new Card(StationStatus.Filled, 5));
        Deck.Add(new Card(StationStatus.Filled, 5));
        Deck.Add(new Card(StationStatus.Filled, 6));
        Deck.Add(new Card(StationStatus.Star, 1));
        Deck.Add(new Card(StationStatus.Star, 1));
        Deck.Add(new Card(StationStatus.Star, 1));
        Deck.Add(new Card(StationStatus.FreeFill, 1));
        Deck.Add(new Card(StationStatus.CircleFill, 2));
        Deck.Add(new Card(StationStatus.CircleFill, 2));
        Deck.Add(new Card(StationStatus.CircleFill, 3));
    }

    public Card Draw()
    {
        int select = Random.Range(0, Deck.Count);
        Card card = Deck[select];
        Deck.RemoveAt(select);
        Discard.Add(card);

        if (card.value == 6)
        {
            Reshuffle();
        }

        return card;
    }

    void Reshuffle()
    {
        Deck.AddRange(Discard);
        Discard = new List<Card>();
    }
}
