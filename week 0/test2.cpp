#include <iostream>
using namespace std;
main()
{
    int val[]={4,7,11};
    int *valPtr=val;
    valPtr+=2;
    cout<<valPtr-val;
}