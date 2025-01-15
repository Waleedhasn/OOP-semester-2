#include <iostream>
#include <iomanip>
using namespace std;

int main()
{
int i = 1;
int j = 2;
int* ptr;
ptr = &i;       // ptr points to location of i
*ptr = 3;      // contents of i are updated
ptr = &j;       // ptr points to location of j
*ptr = 4;      // contents of j are updated
cout << i << " " << j << endl;
}