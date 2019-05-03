using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW4
{
    class Program
    {
        static void Main(string[] args)
        {
            double[,] array1 = new double[4, 6]
            {
                {1, 5.3, 9, 13, 17, 21},
                {2, 6, 10, 14, 18, 22},
                {3, 7, 11, 15, 19.5, 23},
                {4, 8, 12, 16, 20.8, 24},
            };
            double[,] array2 = new double[6, 4]
            {
                {25, 26, 27.1 ,28 },
                {31.5, 32, 33, 34.2 },
                {37, 38, 39, 40 },
                {43, 44, 45.8, 46 },
                {50, 51, 52, 53 },
                {54.2, 55, 56.1 ,57 }
            };
            double tmp = 0; // 행렬을 계산한 값들을 임시적으로 더해서 값을 보관하고 있는 용도이다.
            string result; // tmp저장된 값을 최종적으로 출력하기 전에 보기좋게 데이터 형식을 설정한다.

            for (int i = 0; i < array1.GetLength(0); i++) // 첫 번째 배열의 행의 수 즉, i < 4를 의미한다.
            {
                Console.Write("{ ");
                for (int j = 0; j < array2.GetLength(1); j++) // 두 번째 배열의 열의 수 즉, j < 4를 의미한다.
                {
                    for (int k = 0; k < array1.GetLength(1); k++) // 한 번에 여섯 번의 곱이 나와서 합하므로 첫 번째 배열의 열의 수 k < 6을 의미한다.
                    {
                        tmp += array1[i, k] * array2[k, j];
                    }
                    result = string.Format("{0:#.##}", tmp); // tmp를 소수점 둘째 자리까지만 반올림해서 표현하기 위해서 사용한다.
                    Console.Write($"{result}"); // 보기좋게 정리된 값을 출력해준다.
                    tmp = 0; // 하나의 행렬 값의 계산이 끝나면 초기화 해준다.
                    if (j != array2.GetLength(1) - 1) // 보기좋게 ,를 찍되, 행의 마지막 값이 나오면 찍지않는다.
                        Console.Write(", ");
                }
                Console.WriteLine(" }");
            }
        }
    }
}
