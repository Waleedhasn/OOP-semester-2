#include <iostream>
using namespace std;
main()
{
int x = 25;
int *ptr;
ptr - &x;

cout << "Here is the value in x, printed twice: \n";
cout << x << endl;
cout << *ptr << endl; 
*ptr = 100;
cout << "Once again, here is the value in x: \n";

cout << *ptr << endl; 
return 0;

cout << x << endl;
}