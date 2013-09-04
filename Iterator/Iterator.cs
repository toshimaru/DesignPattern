using System;
using System.Collections.Generic;

class MainClass
{
	public static void Main (string[] args)
	{
		foreach(int i in FromTo(10, 50))
		{
			Console.Write("{0}\n", i);
		}
	}

	// generate a class imprements IEnubrable automatically
	// ref. http://ufcpp.net/study/csharp/sp2_iterator.html
	static public IEnumerable<int> FromTo(int from, int to)
	{
		while(from <= to)
			yield return from++;
	}
}
