<hr>
<p  align="center"  style="font-weight: bold; font-size: 21px"> ALGOSUP Binding | </p>

<p  align="center"  style="font-weight: bold; font-size: 18px"> Technical Specification</p>

<br>

<p  align="center">Author: <b>Robin Debry</p></b>  

<br>

<p  align="center"> ALGOSUP, Group 3. All Rights Reserved. </p>

<hr>

<details> 
<summary style="text-decoration: underline; font-size:100%">Table of contents</summary>

- [Introduction](#introduction)
	- [Overview](#overview)
	- [Goal](#goal)
	- [Context](#context)
	- [Product and Technical Requirements](#product-and-technical-requirements)
	- [Future Goals](#future-goals)
	- [Assumptions](#assumptions)
- [Solutions](#solutions)
	- [Current Solution / Design](#current-solution--design)
	- [Proposed Solution / Design](#proposed-solution--design)
		- [Create a mapping of elementary types](#create-a-mapping-of-elementary-types)
		- [Implement a C API wrapping the C/C++ objects](#implement-a-c-api-wrapping-the-cc-objects)
		- [Better integration with the target language](#better-integration-with-the-target-language)
	- [Release / Roll-out and Deployment Plan](#release--roll-out-and-deployment-plan)
- [New FABGen architecture with F#](#new-fabgen-architecture-with-f)
- [Further Considerations](#further-considerations)
	- [Impact on customers of HARFANG3D](#impact-on-customers-of-harfang3d)
	- [European considerations](#european-considerations)
	- [Security considerations](#security-considerations)
	- [Legal considerations](#legal-considerations)
- [Work](#work)
	- [Architecture Diagram](#architecture-diagram)
	- [Prioritization](#prioritization)
	- [Milestones](#milestones)
- [Implement functions](#implement-functions)
	- [Function 1 : Add a new language](#function-1--add-a-new-language)
	- [Function 2 : Add a folder fsharp](#function-2--add-a-folder-fsharp)
	- [Function 3 : Add a function for fsharp](#function-3--add-a-function-for-fsharp)
	- [Function 4 : Import the new language](#function-4--import-the-new-language)
- [Differences types between F# and C++](#differences-types-between-f-and-c)
	- [Integer types](#integer-types)
	- [Floating types](#floating-types)
	- [Boolean type](#boolean-type)
	- [Void type](#void-type)
	- [String type](#string-type)
- [Function change to convert the Go into C++ to after convert the C++ into F#](#function-change-to-convert-the-go-into-c-to-after-convert-the-c-into-f)
	- [Function to convert Go types into C++ types](#function-to-convert-go-types-into-c-types)
- [Test plan](#test-plan)
- [Glossary](#glossary)
- [End matter](#end-matter)
	- [References](#references)
	- [Acknowledgement](#acknowledgement)
	- [Team members](#team-members)
</details>

# Introduction

## Overview

FABgen is a code generator for C/C++ libraries. It is a tool that takes a C/C++ library and generates a Python, Lua, or Go module that can be used to access the library from the target language.
FABgen was written for the Harfang 3D | to bring the C++ engine to languages such as Python, Lua and Go. It was written as a replacement for SWIG, a very well-known binding generator supporting a lot of target languages.

FABgen is a code generator for C/C++ libraries. It is a tool that takes a C/C++ library and generates a Python, Lua, or Go module that can be used to access the library from the target language.

SWIG has different issues we wished to address:

Very old and complex codebase. Language support is written partially in C and SWIG interface files which are almost a language by themselves. The C codebase does everything through a single Object struct hiding the real type of variables making it extremely difficult to debug and extend the SWIG core. Uneven feature support between languages with missing features although the target language could support them. FABgen tries to solve this issue by:

Using Python to implement FABgen and the binding definitions themselves. Implementing as much as possible of the features in a common part of the program. As a newer | FABgen also tries to leverage newer APIs whenever possible for example by supporting CPython limited ABI so that extension modules it generates can be used by any version of CPython >3.2 without recompilation (at least in theory, the Py_LIMITED_API support in CPython is finicky at best).

## Goal

FABGen was written for the [HARFANG®3D](https://www.harfang3d.com/en_US/) | to bring the C++ engine to languages such as Python, Lua and Go. It was written as a replacement for SWIG, a very well-known binding generator supporting a lot of target languages. SWIG has different issues and that's why HARFANG®3D company create another binding generator. Our objective is to create a binding for F#.<br><br>
The goal is to implement F# in FABgen to allow non-coding experts to have access to this software. C++ is a very specific language for non-coding experts people so implementing other languages such as Python, F# and Rust allows other experts to easily use FABGen. Adding F# to FABGen will benefit the F# users who need a 3D engine. In addition, people looking for an alternative to SWIG when binding a C++ library to F# might find it useful. F# is known for being a relatively concise and easy-to-learn language, which can allow you to write code more quickly and with fewer errors. Also, F# uses the .NET "int" data type, which is natively optimized for mathematical calculations and bit operations, which can make F# code runs faster than code is written in other languages.<br><br>

## Context
At the moment, the 3D engine created by [HARFANG3D](https://www.harfang3d.com/en_US/) is not allowed in all programming languages. Users can't use F# language or Rust language at this moment. This poses a problem especially now when users want to code in these languages. With this | the company wants its future users to be able to use these different languages.

## Product and Technical Requirements

Product requirements :
- Our product needs to add a language on the FABgen existing to improve it.

Technical requirements :
- Following the company's need, **HARFANG3D** advised us to use the same principle to add F# support to FABgen as the one used to add GO support. 
- Like in addition to being a real | it's also a school |. 

## Future Goals
At the moment, the customer only needs to add the F# language. They just want to see our ideas and how we solve this problem technically. So the main goal is to bring a solution to the customer. For the future, it's to add some other languages.

## Assumptions
To create our solution product, we need like written the code in python to translate the other programming languages.
  
# Solutions

## Current Solution / Design 

For the past years, Harfang3D used to work with SWIG, but they had issues like:

-   Very old and complex codebase. Language support was written partially in C and SWIG interface files which are almost a language by themselves. The C codebase does everything through a single Object struct hiding the real type of variables making it extremely difficult to debug and extend the SWIG core.
-   Uneven feature support between languages with missing features although the target language could support them.

So they decided to develop FABGen to solve these issues by:

-   Using Python to implement FABGen and the binding definitions themselves.
-   Implementing as much as possible of the features in a common part of the program (gen. py).

Now, the problem is the number of languages supported (only three):

-   Python 3.2+ (CPython),
-   Lua 5.3+,
-   Go 1.11+.

## Proposed Solution / Design

The proposed solution is to add more languages, starting with Rust.

-   F#:
    -   JIT from IL,
    -   Statically typed,
    -   Link to C library (C++ has to be wrapped with C first).


This solution will be added to the existing code of the [FABGen repository](https://github.com/ejulien/FABGen).

For this | we need to use CLANG to parse the C++ code and generate the F# code, with the help of the DLL file generated by the C/C++ code to link and make the conversion between the F# code to the C/C++ code.

The F# language is a statically typed language. It is compiled to IL (Intermediate Language) and then JIT compiled to native code. This means that it is possible to call into a C-style ABI from F# using the F# FFI (Foreign Function Interface) mechanism. This is the same mechanism that is used to call into native code from F#.

### Create a mapping of elementary types

Identify the elementary types common to both languages and create a mapping between them. C types might map to a single or more types in the F# language. For example, C's int type might map to F#'s int, int32, int64, or nativeint types. The mapping should be as complete as possible, but it is not necessary to map every type. For example, it is not necessary to map C's long double type to F#.

### Implement a C API wrapping the C/C++ objects

Create functions to access object members of the elementary type. Implement a mechanism to access nested objects. For example, if a C/C++ object has a member of type struct foo, then the C API should provide a function to access the foo object.

### Better integration with the target language

While the wrapped API can technically do everything we need to use the native library its usage will feel completely foreign to the target language. Using the wrapped API directly, let's consider the following sequence of instructions to add two vectors in Python. First, we create two vectors, then we call the add function to add them together, and finally we print the result.

```python
import ctypes
import numpy as np

# Load the library
lib = ctypes.cdll.LoadLibrary("./libmylib.so")

# Create two vectors
a = np.array([1, 2, 3], dtype=np.float32)
b = np.array([4, 5, 6], dtype=np.float32)

# Create a vector to hold the result
c = np.empty(3, dtype=np.float32)

# Call the add function
lib.add(a.ctypes.data_as(ctypes.POINTER(ctypes.c_float)),
        b.ctypes.data_as(ctypes.POINTER(ctypes.c_float)),
        c.ctypes.data_as(ctypes.POINTER(ctypes.c_float)))

# Print the result
print(c)
```

## Release / Roll-out and Deployment Plan

**HARFANG3D** wants to release the product as soon as possible.


# New FABGen architecture with F#

FABGen had already a specific architecture for files and folders, so you must follow the pattern.

<pre>
├── lang
|  ├── __init__.py
|  ├── cpython.py
|  ├── go.py
|  ├── lua.py
|  ├── xml.py
|  ├── xml.py
|  ├── xml.py
|  └── <b>fsharp.py (added) </b>
|
├── lib
|  ├── cpython
|  │	├── __init__.py
|  │	├── std.py
|  │	└── stl.py
|  ├── lua
|  │	├── __init__.py
|  │	├── std.py
|  │	└── stl.py
|  ├── xml
|  │	├── __init__.py
|  │	├── std.py
|  │	└── stl.py
|  └── <b>fsharp (added)
|  	├── __init__.py
|  	├── std.py
|  	└── stl.py </b>
|		
├── tests
├── bind.py
├── gen.py
├── license.md
├── readme.md
└── tests.py

</pre>

# Further Considerations
## Impact on customers of HARFANG3D

 **HARFANG3D** users cannot at the moment, use the F# language. So if we can add this language, it will be a real plus for the company. It will allow them to have more customers and be more competitive.

 ## European considerations

HARFANG3D is implemented all over Europe and the regulation about an iso-surface represents points of a constant value within a volume of space. This class holds a fixed-size 3-dimensional grid of values that can efficiently be converted to an iso-surface at runtime for example are the same from all countries.

## Security considerations

The main element of safety is the safety of the software. The software must be safe for customers. We must avoid any problems related to malware and hackers. The software must be safe for the company. We must avoid any problems related to the company's reputation. The software must be safe for the users. We must avoid any problems related to the users' reputation.

## Legal considerations

The legal aspect is very important. Indeed, the product must be certified. For example, in Europe, the certification is ISO. ISO permits have a good quality product.
But we don't need to concern about the certification because the customers said we don't need to take this into account.

# Work


## Architecture Diagram

<img src="../img/Architecture_diagram-ADDC_fabgen.drawio.png" alt="Architecture_diagram-ADDC_fabgen.drawio"/>

## Prioritization

| Flexibility                        | importance             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| F0| Most important |
| F1| Important |
| F2| Less important |

| Function                        | Flexibility         |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Test if it works with Lua| F1 |
| Test if it works with Go| F1 |
| Test if it works with F# |F0|
| Create the dynamic link library| F0|
| Create the F# files| F0|
| Implement the dynamic link library| F0|
| Permit the user to use F#|F0|


## Milestones
| Number of weeks                        | Work we need to do             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|1st week| In The first week we will finish the introduction of the |, writing the documentation and the functional specification. Writing the technical and the Architecture diagram.|
|2nd week|We look at how to use the FABGen already exists. After that, we try to use FABGen.|
|3rd and 4th week|We are going deeper and starting to launch the test<br> Test the Go part<br>Test the Lua part<br>Check the quality<br>Create all dynamic link library(dll) to use C code for the F#|
|5th and 6th week|We finish all the test with F#. We start to prepare the presentation.|
|7th week|This is the last step of the project everything should be done and ready to present to the client !<br>Oral presentation.|

# Implement functions
  
## Function 1 : Add a new language 

Inside the lang folder we create a fsharp.py file.

```python
class StdSharedPtrProxyFeature:
    def __init__(self, wrapped_conv):
        self.wrapped_conv = wrapped_conv

    def init_type_converter(self, gen, conv):
        # declare shared_ptr<T> to T cast support
        gen.add_cast(conv, self.wrapped_conv, lambda in_var, out_var: '%s = ((%s *)%s)->get();\n' % (out_var, conv.ctype, in_var))

    def unwrap(self, in_var, out_var):
        return '%s = %s->get();\n' % (out_var, in_var)

    def wrap(self, in_var, out_var):
        return '%s = new std::shared_ptr<%s>(%s);\n' % (out_var, self.wrapped_conv.ctype, in_var)
```

## Function 2 : Add a folder fsharp

Inside the lib folder, we create a Fsharp folder. In this folder we have the same files as other languages so, __ init__.py, std.py and stl.py .

## Function 3 : Add a function for fsharp

Inside the __ init__.py file, we add to the existing function the language for Fsharp.

```python
elif gen.get_language() == 'FSharp':
        import lib.fsharp.std
        import lib.fsharp.stl

        lib.fsharp.std.bind_std(gen)
        lib.fsharp.stl.bind_stl(gen)
```

## Function 4 : Import the new language

Inside the bind.py file we import the new language.

```python
import lang.fsharp
```

# Differences types between F# and C++

## Integer types
F#|C & C++|
----|-------|
byte|(signed) char|
int16|short|
int|int|
int64|long|
int64|long long int|
sbyte|unsigned char|
uint16|unsigned short|
uint|unsigned int|
uint64|unsigned long|
uint64|unsigned long long int|


## Floating types
|F#|C & C++|
|----|-------|
|float32|float|
|float or double|double|
|-|long double|

## Boolean type
F#|C & C++|
|----|----|
|bool|bool|

## Void type
F#|C & C++|
----|-------|
unit|void|

## String type
F#|C & C++|
----|-------|
char|char|
string|string|





# Function change to convert the Go into C++ to after convert the C++ into F#

## Function to convert Go types into C++ types

We take at the base the function in python to convert it into C++.
  
  ```python
  def bind_std(gen):
	class GoConstCharPtrConverter(lang.go.GoTypeConverterCommon):
		def __init__(self, type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None, needs_c_storage_class=False):
			super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, needs_c_storage_class)
			self.go_to_c_type = "*C.char"
			self.go_type = "string"
			
		def get_type_glue(self, gen, module_name):
			return ''

		def get_type_api(self, module_name):
			return ''

		def to_c_call(self, in_var, out_var_p, is_pointer=False):
			if is_pointer:
				out = f"{out_var_p.replace('&', '_')}1 := C.CString(*{in_var})\n"
				out += f"{out_var_p.replace('&', '_')} := &{out_var_p.replace('&', '_')}1\n"
			else:
				out = f"{out_var_p.replace('&', '_')}, idFin{out_var_p.replace('&', '_')} := wrapString({in_var})\n"
				out += f"defer idFin{out_var_p.replace('&', '_')}()\n"
			return out

		def from_c_call(self, out_var, expr, ownership):
			return "C.GoString(%s)" % (out_var)

	gen.bind_type(GoConstCharPtrConverter("const char *"))

  ```
For example this one convert a String in Go into a String in C++.


After that we need to convert each types of the Go language into C++, then convert the C++ into F#.


After that we need to convert each types of the Go language into C++, then convert the C++ into F# .
For this we need to create a basic type converter. This converter will be used to convert the Go types into C++ types.

```python

  class GoBasicTypeConverter(lang.go.GoTypeConverterCommon):
		def __init__(self, type, c_type, go_type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None, needs_c_storage_class=False):
			super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, needs_c_storage_class)
			self.go_to_c_type = c_type
			self.go_type = go_type

		def get_type_glue(self, gen, module_name):
			return ''

		def get_type_api(self, module_name):
			return ''

		def to_c_call(self, in_var, out_var_p, is_pointer):
			if is_pointer:
				out = f"{out_var_p.replace('&', '_')} := (*{self.go_to_c_type})(unsafe.Pointer({in_var}))\n"
			else:
				out = f"{out_var_p.replace('&', '_')} := {self.go_to_c_type}({in_var})\n"
			return out

		def from_c_call(self, out_var, expr, ownership):
			return f"{self.go_type}({out_var})"

 ```

With this converter we can convert the Go types into C++ types except the String and the boolean types.

```python

gen.bind_type(GoBasicTypeConverter("char", "C.char", "int8"))

	gen.bind_type(GoBasicTypeConverter("unsigned char", "C.uchar", "uint8"))
	gen.bind_type(GoBasicTypeConverter("uint8_t", "C.uchar", "uint8"))

	gen.bind_type(GoBasicTypeConverter("short", "C.short", "int16"))
	gen.bind_type(GoBasicTypeConverter("int16_t", "C.short", "int16"))
	gen.bind_type(GoBasicTypeConverter("char16_t", "C.short", "int16"))

	gen.bind_type(GoBasicTypeConverter("uint16_t", "C.ushort", "uint16"))
	gen.bind_type(GoBasicTypeConverter("unsigned short", "C.ushort ", "uint16"))
	
	gen.bind_type(GoBasicTypeConverter("int32", "C.int32_t", "int32"))
	gen.bind_type(GoBasicTypeConverter("int", "C.int32_t", "int32"))
	gen.bind_type(GoBasicTypeConverter("int32_t", "C.int32_t", "int32"))
	gen.bind_type(GoBasicTypeConverter("char32_t", "C.int32_t", "int32"))
	gen.bind_type(GoBasicTypeConverter("size_t", "C.size_t", "int32"))

	gen.bind_type(GoBasicTypeConverter("uint32_t", "C.uint32_t", "uint32"))
	gen.bind_type(GoBasicTypeConverter("unsigned int32_t", "C.uint32_t", "uint32"))
	gen.bind_type(GoBasicTypeConverter("unsigned int", "C.uint32_t", "uint32"))

	gen.bind_type(GoBasicTypeConverter("int64_t", "C.int64_t", "int64"))
	gen.bind_type(GoBasicTypeConverter("long", "C.int64_t", "int64"))

	gen.bind_type(GoBasicTypeConverter("float32", "C.float", "float32"))
	gen.bind_type(GoBasicTypeConverter("float", "C.float", "float32"))
	
	gen.bind_type(GoBasicTypeConverter("intptr_t", "C.intptr_t", "uintptr"))

	gen.bind_type(GoBasicTypeConverter("unsigned long", "C.uint64_t", "uint64"))
	gen.bind_type(GoBasicTypeConverter("uint64_t", "C.uint64_t ", "uint64"))
	gen.bind_type(GoBasicTypeConverter("double", "C.double", "float64"))


 ```

For the Boolean type we need to create a new converter.

```python

  class GoBoolConverter(lang.go.GoTypeConverterCommon):
		def __init__(self, type, c_type, go_type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None, needs_c_storage_class=False):
			super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, needs_c_storage_class)
			self.go_to_c_type = c_type
			self.go_type = go_type

		def get_type_glue(self, gen, module_name):
			return ''

		def get_type_api(self, module_name):
			return ''

		def to_c_call(self, in_var, out_var_p, is_pointer):
			if is_pointer:
				out = f"{out_var_p.replace('&', '_')} := (*{self.go_to_c_type})(unsafe.Pointer({in_var}))\n"
			else:
				out = f"{out_var_p.replace('&', '_')} := {self.go_to_c_type}({in_var})\n"
			return out

		def from_c_call(self, out_var, expr, ownership):
			return f"{self.go_type}({out_var})"
	gen.bind_type(GoBoolConverter('bool')).nobind = True

 ```

 When we have all of these conversions types in Go we can make the same to convert the C++ types into F# types. 

This is the command line to generate the DLL file we will use in the F# |.
 ```
 clang++  -shared -o <name_for_dll_file>.dll <name_of_cpp_file>.cpp
 ```

 In other way we can use CMake to generate the DLL file. For that you need to create a CMakeLists.txt file with the following content.

 ```cmake
cmake_minimum_required(VERSION 3.10)
project(<name_of_dll_file>)
set(CMAKE_CXX_STANDARD 17)
set(CMAKE_CXX_STANDARD_REQUIRED ON)
set(CMAKE_CXX_EXTENSIONS OFF)


```

Then we need to add the following lines to the CMakeLists.txt file.

```cmake
add_library(<name_of_dll_file> SHARED <name_of_cpp_file>.cpp)
target_include_directories(<name_of_dll_file> PUBLIC <path_to_harfang3d_include_files>)
target_link_libraries(<name_of_dll_file> <path_to_harfang3d_lib_files>)
```

Then we can generate the DLL file with the following command.

```
cmake --build . --config Release
```


# Test plan

Here is the [Test plan](https://github.com/algosup/2022-2023-|-3-harfang3d-binding-|-3-group/blob/main/Documents/Quality-Assurance/TestPlan.md) for the |. It is a document that describes the test cases that will be used to verify that the software product meets or exceeds the customer’s requirements and that all of the software product’s features work as expected.

# Glossary

| Terms                        | Definition             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ISO|International Standards Organisation is an organization that makes international rules about the quality of products and services. |
| MISRA|Motor Industry Software Reliability Association is a consortium of companies in the automotive industry that develops guidelines and standards for the development of safety-critical software. |
| API|They are mechanisms that enable two software components to communicate with each other using a set of definitions and protocols.|
| ABI | An application binary interface is an interface between two binary program modules. Often, one of these modules is a library or operating system facility, and the other is a program that is being run by a user.|
| Unit Test | It's a type of software testing where individual units or components of the software are tested.|
| Statically-typed language  | It's a language (such as Java, C, or C++) where variable types are known at compile time.|
| Dynamically typed languages | Type checking takes place at runtime or execution time. This means that variables are checked against types only when the program is executing. |
| AUTOSAR | AUTomotive Open System ARchitecture is a standard for the development of automotive software that provides a set of guidelines and tools for the development of software that is portable across different hardware platforms.|
| C++ | C++ is a general-purpose programming language created by Bjarne Stroustrup as an extension of the C programming language, or "C with Classes".|
| F# | F# is a functional programming language that is also object-oriented and imperative. It is a multi-paradigm language that supports both functional and object-oriented programming.|
| Python | Python is an interpreted, high-level, general-purpose programming language.|
| Lua | Lua is a lightweight, high-level, multi-paradigm programming language designed primarily for embedded use in applications.|
| Go | Go is a statically typed, compiled programming language designed by Google.|
| C# | C# is a general-purpose, multi-paradigm programming language encompassing strong typing, lexically scoped, imperative, declarative, functional, generic, object-oriented (class-based), and component-oriented programming disciplines.|
| SWIG | Simplified Wrapper and Interface Generator is a software development tool that connects programs written in C and C++ with a variety of high-level programming languages.|
| JIT | Just-in-time compilation (JIT) is a way of executing computer code that involves compilation during execution of a program - at run time - rather than prior to execution.|
| IL | Intermediate Language is a stack-based instruction set and computer programming language, intermediate between high-level languages and the computer's native machine code.|
| DLL | A dynamic-link library (DLL) is a library that contains code and data that can be used by more than one program at the same time.|
|Clang|Clang is a compiler front-end for the C, C++, Objective-C, and Objective-C++ programming languages.|
|CMake|CMake is an open-source, cross-platform family of tools designed to build, test and package software.|




# End matter

## References

https://www.harfang3d.com/en_US/
https://devguide.python.org/documenting/
https://www.lua.org/docs.html
https://devguide.python.org/documentation/start-documenting/index.html
https://fsharpforfunandprofit.com
https://www.swig.org/doc.html

## Acknowledgement

| Name | Contact             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|Robert Pickering|robertfpickering@fastmail.com|
|Delphine Prousteau|dprousteau@quanaup.fr|
|Jihane Billacois|jihb@sent.com|
|Caroline Cordier|caroline.cordier@gmail.com|
|François Gutherz|francois.gutherz@harfang3d.com|
|Emmanuel Julien|emmanuel.julien@harfang3d.com|

## Team members

| Name and Github| Role             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|[Vivien Bistrel Tsangue ](https://github.com/Bistrel2002) |Project Manager|
|[Thomas PLANCHARD](https://github.com/thomas-planchard) |Program Manager|
|[Robin DEBRY](https://github.com/robin-debry)|Technical Leader
|[Lucas AUBARD](https://github.com/LucasAub)|Software Engineer|
|[Laura-Lee HOLLANDE](https://github.com/lauraleehollande) |Quality Assurance|
