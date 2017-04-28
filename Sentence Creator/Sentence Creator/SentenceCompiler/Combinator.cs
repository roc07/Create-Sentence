using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sentence_Creator.SentenceCompiler
{
	class Combinator
	{
		private StringBuilder result;
		private WordReader words;

		public Combinator()
		{
			result = new StringBuilder();
			words = new WordReader();
		}

		public void CreateSentence()
		{
			CombineWords(this.words.Nouns, this.words.Verbs, this.words.Adjectives);
		}

		private void CombineWords(List<string> noun, List<string> verb, List<string> adj)
		{
			Random rnd = new Random();
			int chs = rnd.Next(1, 3);
			
			if (chs > 0)
			{
				int chsNoun = (int)rnd.Next(1, noun.Count + 1);

				string nounOne = noun.ElementAt<string>(chsNoun);
				this.result.Append(nounOne);

				this.result.Append(" ");
				string nextWord = ReturnNextWord(nounOne, this.words.Nouns, this.words.Verbs, this.words.Adjectives, "verb");
				this.result.Append(nextWord);

				this.result.Append(" ");
				this.result.Append(ReturnNextWord(nextWord, this.words.Nouns, this.words.Verbs, this.words.Adjectives, "adj"));
			}

			Console.WriteLine(result);
		}

		private string ReturnNextWord(string word, List<string> noun, List<string> verb, List<string> adj, string type)
		{
			Random count = new Random();

			if (type == "verb")
			{
				return LoopOverWords(verb, word, count.Next(2,4));
			}
			else if (type == "adj")
			{
				return LoopOverWords(adj, word, count.Next(2, 4));
			}
			else
			{
				return LoopOverWords(noun, word, count.Next(2, 4));
			}
			
		}

		private string GetLastLetters(string word, int count)
		{
			string lastLetter;

			if (count == 2)
			{
				lastLetter = word.Substring(word.Length - 2);
			}
			else
			{
				lastLetter = word.Substring(word.Length - 3);
			}

			return lastLetter;
		}

		private string LoopOverWords(List<string> x, string word, int count)
		{
			string letters = GetLastLetters(word, 2);
			int possibilities = 2;
			int failCount = 0;

			List<string> potentials = new List<string> { };
			for (int i = 0; i < x.Count; i++)
			{
				string current = x.ElementAt<string>(i);
				if (current.Substring(0, letters.Length) == letters)
				{
					potentials.Add(current);
				}
			}

			if (potentials.Count >= 2)
			{
				possibilities = potentials.Count;
			}
			else
			{
				if (count == 2)
				{
					failCount++;
					Console.Write(failCount);
					if (failCount == 3)
					{
						CombineWords(this.words.Nouns, this.words.Verbs, this.words.Adjectives);
					}
					LoopOverWords(x, word, 3);
				}
				else
				{
					failCount++;
					Console.Write(failCount);
					if (failCount == 3)
					{
						CombineWords(this.words.Nouns, this.words.Verbs, this.words.Adjectives);
					}
					LoopOverWords(x, word, 2);
				}				
			}

			Random pickWord = new Random();

			return potentials.ElementAt<string>((int)pickWord.Next(1, possibilities));
		}
	}
}
