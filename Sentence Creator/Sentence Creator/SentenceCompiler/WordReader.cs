using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Sentence_Creator.SentenceCompiler
{
	class WordReader
	{
		private List<string> nouns;
		private List<string> regularVerbs;
		private List<string> irregularVerbs;
		private List<string> adjectives;
		private List<string> verbs;

		public WordReader()
		{
			this.nouns = new List<string> { };
			this.regularVerbs = new List<string> { };
			this.irregularVerbs = new List<string> { };
			this.adjectives = new List<string> { };
			this.verbs = new List<string> { };
			ReadNouns();
			ReadIrVerbs();
			ReadVerbs();
			ReadAdjectives();
			CombineVerbs(this.irregularVerbs, this.regularVerbs);
		}

		public List<string> Nouns { get { return this.nouns; } }
		public List<string> RegularVerbs { get { return this.regularVerbs; } }
		public List<string> IrregularVerbs { get { return this.irregularVerbs; } }
		public List<string> Adjectives { get { return this.adjectives; } }
		public List<string> Verbs { get { return this.verbs; } }

		private void ReadNouns()
		{
			string line;
			StreamReader file = new StreamReader("C:\\Users\\john\\Desktop\\c# words\\nouns.txt");

			while ((line = file.ReadLine()) != null)
			{
				this.nouns.Add(line);
			}

			file.Close();
		}

		private void ReadIrVerbs()
		{
			string line;
			StreamReader file = new StreamReader("C:\\Users\\john\\Desktop\\c# words\\irregular_verbs.txt");

			while ((line = file.ReadLine()) != null)
			{
				this.irregularVerbs.Add(line);
			}

			file.Close();
		}

		private void ReadVerbs()
		{
			string line;
			StreamReader file = new StreamReader("C:\\Users\\john\\Desktop\\c# words\\regular_verbs.txt");

			while ((line = file.ReadLine()) != null)
			{
				this.regularVerbs.Add(line);
			}

			file.Close();
		}

		private void ReadAdjectives()
		{
			string line;
			StreamReader file = new StreamReader("C:\\Users\\john\\Desktop\\c# words\\adjectives.txt");

			while ((line = file.ReadLine()) != null)
			{
				this.adjectives.Add(line);
			}

			file.Close();
		}

		private void CombineVerbs(List<string> irVerb, List<string> rVerb)
		{
			for (int i = 0; i < irVerb.Count; i++)
			{
				this.verbs.Add(irVerb.ElementAt<string>(i));
			}
			for (int i = 0; i < rVerb.Count; i++)
			{
				this.verbs.Add(rVerb.ElementAt<string>(i));
			}
		}
	}
}
