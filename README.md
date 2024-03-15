# MultiParse
A C# highly customizable expression parser

## Project Description
MultiParse is a mathematical expression parser written in the .NET framework. The focus of the project is building a highly customizable expression parser. This involves custom types, custom operators and custom functions. Also dynamic/static variables are perfectly feasible.
The documentation guides you through the steps of making your own data type with its own functions and operators.

The expression parser itself is based on Dijkstra's Shunting Yard algorithm with a few modifications to accommodate variable argument length functions. The interface is loosely based on NCalc (https://github.com/sheetsync/NCalc), which is a very user-friendly expression parser. This library then goes one step further and allows users to define their own types, functions and even operators.

The customizing features makes this parser a very useful tool. As an example, a complex number parser is implemented in the Documentation. It then becomes as simple as it can get to parse expressions with complex numbers!

Install the [![NuGet](https://img.shields.io/nuget/v/MultiParseX.svg)](https://www.nuget.org/packages/MultiParseX/) package!

## Getting Started
Using the expression parser is as easy as

```csharp
Expression e = new Expression();
object result = e.Evaluate("(3+cos(9.0f/2)*2f)/(3+2)");
```

Check the Documentation to explore the full potential of the expression parser.

## Features
* Custom user-defined data types
  * C# native data types have been implemented
    * Boolean/bool
    * Byte/byte, Char/char, SByte/sbyte
    * Int16/short, UInt16/ushort, Int32/int, UInt32/uint, Int64/long, UInt64/ulong, Decimal/decimal
    * String/string (supports C# escape sequences including unicode \xX(XXX) \uXXXX and \UXXXXXXXX)
    * Single/float, Double/double
    * DateTime is not implemented as it does not have a literal format in C#. But it can be implemented by the user.
    * Variables, static and dynamic.
* Custom user-defined operators
  * Default C# binary operators have been implemented for all native data types
    * Arithmetic operators: +, -, *, /, %
    * Relational operators: <=, >=, <, >, ==, !=
    * Logical operators: &, |, ^
    * Conditional operators: ||, &&
  * Default C# unary operators have been implemented for all native data types
    * Arithmetic operators: +, -
    * Logical operators: ~
    * Conditional operators: !
    * Explicit type casts: eg. (Boolean), (int), etc.
* Customizable functions
  * Default C# Math functions have been implemented
    * Generic functions: Abs(), Ceiling(), Exp(), Floor(), Log(), Log10(), Max(), Min(), Pow(), Round(), Sign(), Sqrt(), Truncate()
    * Trigometric functions: Acos(), Asin(), Atan(), Atan2(), Cos(), Sin(), Tan()
    * Hyperbolic functions: Cosh(), Sinh(), Tanh()
* Compilation at first evaluation
  * Subsequent evaluations will use the compiled action queue.

## Source of this fork
http://multiparse.codeplex.com/
