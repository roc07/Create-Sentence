using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sentence_Creator.SentenceCompiler;

namespace Sentence_Creator
{
	class Program
	{
		static void Main(string[] args)
		{
			Combinator tester = new Combinator();
			tester.CreateSentence();
			//WordReader xx = new WordReader();
		}
	}
}
