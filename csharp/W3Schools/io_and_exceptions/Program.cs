using System;
using System.IO;
namespace linalg {
	public class Program
	{
		static void Main()
		{
			string invertibleMatRaw = File.ReadAllText("../../../matrixInvertible.csv");
			string singularMatRaw = File.ReadAllText("../../../matrixSingular.csv");
			string[] invertibleMatLines = invertibleMatRaw.Split("\n");
			string[] singularMatLines = singularMatRaw.Split("\n");

			int invertibleMatDim = invertibleMatLines.Length;
			int singularMatDim = singularMatLines.Length;

			double[,] invertibleMat = new double[invertibleMatDim, invertibleMatDim];
			double[,] singularMat = new double[singularMatDim, singularMatDim];

			for (int i = 0; i < invertibleMatDim; i++) 
			{
				string[] invertibleMatLine = invertibleMatLines[i].Split(",");
				for (int j = 0; j < invertibleMatLine.Length; j++) 
				{
					invertibleMat[i, j] = Convert.ToDouble(invertibleMatLine[j]);
				}
			}

			for (int i = 0; i < singularMatDim; i++)
			{
				string[] singularMatLine = singularMatLines[i].Split(",");
				for (int j = 0; j < singularMatLine.Length; j++)
				{
					singularMat[i, j] = Convert.ToDouble(singularMatLine[j]);
				}
			}

			Determinant det1 = new Determinant(invertibleMat);
			Determinant det2 = new Determinant(singularMat);

			double d1 = det1.det();
			double d2 = det2.det();

			Console.WriteLine($"For invertible matrix the determinant is {d1}");
			Console.WriteLine($"For singular matrix the determinant is {d2}");
		}
	}
}

