1.

Telephone number: string
Height: double
Age: int
Gender: enum or string
Salary: decimal
ISBN: string
Price: decimal
Shipping weight: double
Population: long
Stars in the universe: BigInteger
Employees in UK businesses: int

2.

Value types store data directly and are stored on the stack.
Reference types store references to the data on the heap.
Boxing is converting a value type to a reference type.
Unboxing is converting a reference type back to a value type.

3.

Managed resources are handled by the .NET runtime.
Unmanaged resources are outside .NET control and must be released manually.

4.

The garbage collector automatically reclaims memory by destroying objects no longer in use.


Controlling Flow and converting types

Questions:
1. What happens when you divide an int variable by 0?
2. What happens when you divide a double variable by 0?
3. What happens when you overflow an int variable, that is, set it to a value beyond its
range?
4. What is the difference between x = y++; and x = ++y;?
5. What is the difference between break, continue, and return when used inside a loop
statement?
6. What are the three parts of a for statement and which of them are required?
7. What is the difference between the = and == operators?
8. Does the following statement compile? for ( ; true; ) ;
9. What does the underscore _ represent in a switch expression?
10. What interface must an object implement to be enumerated over by using the foreach
statement?

Answers:
1. It throws a DivideByZeroException at runtime.
2. It returns Infinity if numerator is non-zero, or NaN if numerator is also zero.
3. It wraps around if unchecked. In checked context, it throws OverflowException.
4. x = y++ assigns y to x, then increments y. x = ++y increments y, then assigns to x.
5. break exits the loop. continue skips to next iteration. return exits the method.
6. Initialization, condition, increment. None are required; for(;;) is valid.
7. \= is assignment. == is equality comparison.
8. Yes, it compiles and runs as an infinite loop with empty body.
9. It represents the default case in a switch expression.
10. It must implement IEnumerable or IEnumerable<T>.
