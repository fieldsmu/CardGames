using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames {
	class Program {

		int DrawCard(List<int> Cards) {
			Random rnd = new Random();
			int temp = rnd.Next(0, Cards.Count());
			int draw = Cards[temp];
			Cards.RemoveAt(temp);
			return draw;
		}

		int AceHandling(int draw) {
			if (draw == 1) {
				Console.WriteLine("Would you like the Ace to be a 1 or 11? Enter 1 for 1 or Enter 11 for 11");
				string ace = Console.ReadLine();
				if (ace == "1") {
					return 1;
				} else if (ace == "11") {
					return 11;
				} else {
					Console.WriteLine("That is not 1 or 11. The value of the Ace was set to 1.");
					return 1;
				}
			}
			return draw;
		}

		int HitMe(int total, int draw) {
			total += draw;
			if (total > 21) {
				Console.WriteLine("\nYOU LOSE!");
			} else if (total == 21) {
				Console.WriteLine("\nYOU WIN!");
			}
			return total;
		}

		void Print(int total) {
			Console.WriteLine($"This is your current total: {total}");
			Console.WriteLine("\nWould you like to hit? Enter y for yes");
		}

		void PlayGame() {
			string playAgain = "Y";
			while (playAgain == "Y") {
				int total = 0;
				playAgain = "";
				List<int> Cards = new List<int> { 1, 1, 1, 1, 2, 2, 2, 2, 3, 3, 3, 3, 4, 4, 4, 4, 5, 5, 5, 5, 6, 6, 6, 6, 7, 7, 7, 7, 8, 8, 8, 8, 9, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
				bool _continue = true;
				bool firstcard = true;
				while (total < 21 && _continue == true) {
					int draw = DrawCard(Cards);
					if (firstcard == true) {
						draw = AceHandling(draw);
						total += draw;
						firstcard = false;
					} else {
						Print(total);
						string answer = Console.ReadLine();
						if (answer == "y") {
							draw = AceHandling(draw);
							total = HitMe(total, draw);
						} else {
							total += draw;
							if (total > 21) {
								Console.WriteLine("\nYOU WIN!");
							} else {
								Console.WriteLine("\nYOU LOSE!");
							}
							_continue = false;
						}
					}
				}
				Console.WriteLine("\n----------Would you like to play again? Enter y for yes----------");
				playAgain = Console.ReadLine().ToUpper();
				Console.WriteLine();
			}
		}

		static void Main(string[] args) {
			(new Program()).PlayGame();
		}
	}
}
