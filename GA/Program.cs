using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace GA
{
	class MainClass
	{	static List<string> canadates;
		public static void Main (string[] args)
		{
			//Console.WriteLine ("Hello World!");
			canadates = new List<string>();
			Random ran = new Random ();
			for (int i = 0; i <4; i++) {
				string temp = Convert.ToString (ran.Next (0, 31), 2);
				if (temp.Length < 5) {

					temp = temp.PadLeft (5, '0');
				}
				canadates.Add (temp);


			}

		//	canadates.Sort ();

			do {

				for(int j=0;j<10;j++){

					RemoveLowest();

					string strongest = FindStrongest();
					//Console.WriteLine();

					List<String> firstCross = Reproduce(strongest,canadates[0]);
					List<String> secondCross = Reproduce(strongest,canadates[1]);

					canadates.Clear();

					foreach(string s  in firstCross){

						canadates.Add(s);

					}

					foreach(string s in secondCross){
						canadates.Add(s);

					}

					Mutate();


				}




			} while(!Console.ReadLine ().Equals('.'));





		}

		public static string FindStrongest(){

			string toDouble = canadates[0];
			double highestFitness = FitnessFunction(canadates[0]);
			foreach (string c in canadates) {

				double cand = FitnessFunction (c);
				if (cand > highestFitness) {
					toDouble = c;
					highestFitness = cand;

				}

			}
			Console.WriteLine (highestFitness);
			canadates.Remove (toDouble);

			return toDouble;


		}

		public static void RemoveLowest(){
			string toRemove = canadates[0];
			double lowesetFitness = FitnessFunction(canadates[0]);

			foreach( string c in canadates){
				double cand = FitnessFunction(c);

				if(cand<lowesetFitness){

					toRemove = c;

					lowesetFitness =cand;

				}



			}

			canadates.Remove(toRemove);


		}



		public static double FitnessFunction(string x){

			int y = Convert.ToInt32 (x, 2);
			double func = Math.Pow (y, 2);
			return func / Math.Pow (31, 2);


		}

		public static List<string> Reproduce(string x, string y){
			// selection
			//string first  = x.Substring (0, 2);
			//string  = y.Substring (2,3);
			List<string> selection = new List<string>();
			int [] first = {0,2,2,3};
			int[] second = { 2, 3, 0, 2 };
			selection.Add (Selection (x, y, first));
			selection.Add (Selection (x, y, second));




			return selection;

		}


		public static string Selection(string x,string y, int[] selection){

			x = x.Substring (selection [0], selection [1]);
			y = y.Substring (selection [2], selection [3]);


			return x+y;

		}

		public static void Mutate(){
			Random ran = new Random ();
			for(int i =0; i<canadates.Count;i++) {

				double mutate = ran.NextDouble () * 100;
				double mutateChance = ran.NextDouble () * 100;
				if (mutateChance > mutate) {
					int index = ran.Next (0, 5);

					char swap = canadates [i] [index];
					if (swap.Equals ('1')) {

						swap = '0';
					} else {
						swap = '1';
					}
					StringBuilder mutableString = new StringBuilder (canadates [i]);
					mutableString [index] = swap;
					canadates [i] = mutableString.ToString();

				}
			}
		}
	}
}
