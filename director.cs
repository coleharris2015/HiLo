using System;
using System.Collections.Generic;

namespace unit02_hilo
{

	public class Director
	{
		List<Card> cards = new List<Card>();
		bool is_playing = true;
		int winning_bonus = 100;
		int badGuessBonus = 75;
		int start_score = 300;

		int current_card;
		int next_card;

		public Director()
		{
			for(int i =0; i < 1; i++)
			{
				Card card = new Card();
				cards.Add(card);
			}
		}
	
		public void startGame()
		{
			foreach(Card card in cards)
			{
				card.getNewCard();
				current_card = card.cardValue;
			}
			while (is_playing)
			{
				main_game();
				game_check();
			}
		}

		public void main_game()
		{
			Console.WriteLine($"The current card value is: {current_card}");

			if(!is_playing)
			{
				return;
			}

			foreach(Card card in cards)
			{
				card.getNewCard();
				next_card = card.cardValue;
			}
			Console.Write("Guess if the next card will be higher or lower [h/l]");
		
			string playerGuess = Console.ReadLine();
			
			Console.WriteLine($"The next card is: {next_card}");
			if(playerGuess.Equals("h") && current_card < next_card)
			{
				start_score += winning_bonus;
			}
			else if(playerGuess.Equals("l") && current_card > next_card)
			{
				start_score += winning_bonus;
			}
			else if(playerGuess.Equals("h") && current_card > next_card)
			{
				start_score -= badGuessBonus;
			}
			else if(playerGuess.Equals("l") && current_card < next_card)
			{
				start_score -= badGuessBonus;
			}
		}


		public void game_check()
		{
			Console.WriteLine($"Your score is: {start_score}");
            	if (start_score == 0)
				{
                	is_playing = false;
            	}
            	if (!is_playing)
            	{
                return;
            	}

            	current_card = next_card;
            	Console.Write("Keep Playing? [y/n] ");
            	string rollDice = Console.ReadLine();
            	is_playing = (rollDice == "y");
		}
	}
}