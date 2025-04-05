#include <iostream>
using namespace std;
int main()
{
int M=3, N=4; 


    int** A = new int*[M];

    
    for (int i = 0; i < M; i++)
        A[i] = new int[N+i];

  
    for (int i = 0; i < M; i++)
        for (int j = 0; j < N+i; j++)
            A[i][j] = rand() % 100;

   
    for (int i = 0; i < M; i++)
    {
        for (int j = 0; j < N+i; j++)
            std::cout << A[i][j] << " ";

        std::cout << std::endl;
    }
    for (int i = 0; i < M; i++)
        delete[] A[i];

    delete[] A;

    return 0;
}
