using System;

namespace linalg {

	public class Determinant
	{
		private double[,] matrix;

		public Determinant(double[,] matrix)
		{
			this.matrix = matrix;
		}

		public double det() 
		{
			return determinant(this.matrix);
		}
		
		private double determinant(double[,] A)
		{
			int m = A.GetLength(0);
			int n = A.GetLength(1);
			if (m != n)
			{
				throw new ArithmeticException("The matrix is not a square matrix");
			}

			if (n == 1)
			{
				return A[0, 0];
			}
			else if (n == 2) 
			{
				return A[0, 0] * A[1, 1] - A[0, 1] * A[1, 0];
			} 
			else
            {
				double det = 0;
				for (int i = 0; i < n; i++) {
					double[,] minor = getMinor(A, i, 0);
					det += cofactorSign(i, 0) * A[i, 0] * determinant(minor);
				}

				return det;
            }
		}

		private static int cofactorSign(int i, int j)
		{
			return ((i + j) % 2 == 0) ? 1 : -1;
		}

		private double[,] getMinor(double[,] A, int i, int j)
		{
			int m = A.GetLength(0);
			int n = A.GetLength(1);
			if (m != n)
			{
				throw new ArithmeticException("The matrix is not a square matrix");

			}
			double[,] minor = new double[n - 1, n - 1];
			for (int k = 0; k < n; k++) 
			{
				if (k != i) 
				{
					for (int l = 0; l < n; l++)
					{
						if (l != j) 
						{
							int k1 = (k < i) ? k : k - 1;
							int l1 = (l < j) ? l : l - 1;
							minor[k1, l1] = A[k, l];
						}
						
					}
				}
				
			}

			return minor;
		}
	}

}