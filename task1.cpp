#include <iostream>
using namespace std;
main()
{
 int x = 25;
int *ptr;
ptr = &x;
cout << "The value in x is " << x << endl;
cout << "The address of x is " << ptr << endl;
return 0;
}