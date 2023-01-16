<hr>
<p  align="center"  style="font-weight: bold; font-size: 21px"> ALGOSUP Binding Project </p>

<p  align="center"  style="font-weight: bold; font-size: 18px"> Technical Specification</p>

<br>

<p  align="center">Author: <b>Robin Debry</p></b>  

<br>

<p  align="center"> ALGOSUP, Group 3. All Rights Reserved. </p>

<hr>

<details> 
<summary style="text-decoration: underline; font-size:100%">Table of contents:</summary>

- [1. Introduction](#1-introduction)
	- [a. Overview](#a-overview)
	- [b. Goal](#b-goal)
	- [c. Context](#c-context)
	- [d. Product and Technical Requirements](#d-product-and-technical-requirements)
	- [e. Future Goals](#e-future-goals)
	- [f. Assumptions](#f-assumptions)
- [2. Solutions](#2-solutions)
	- [a. Current Solution / Design](#a-current-solution--design)
	- [b. Proposed Solution / Design](#b-proposed-solution--design)
		- [Create a mapping of elementary types](#create-a-mapping-of-elementary-types)
		- [Implement a C API wrapping the C/C++ objects](#implement-a-c-api-wrapping-the-cc-objects)
		- [Better integration with the target language](#better-integration-with-the-target-language)
	- [c. Release / Roll-out and Deployment Plan](#c-release--roll-out-and-deployment-plan)
- [3. New FABGen architecture with F#](#3-new-fabgen-architecture-with-f)
- [4. Further Considerations](#4-further-considerations)
	- [a. Impact on customers of HARFANG3D](#a-impact-on-customers-of-harfang3d)
	- [b. European considerations](#b-european-considerations)
	- [c. Security considerations](#c-security-considerations)
	- [e. Privacy considerations](#e-privacy-considerations)
	- [f. Legal considerations](#f-legal-considerations)
- [5. Work](#5-work)
	- [a. Prioritization](#a-prioritization)
	- [b. Milestones](#b-milestones)
- [6. Implement functions](#6-implement-functions)
	- [a. Function 1 : Add a new language](#a-function-1--add-a-new-language)
	- [b. Function 2 : Add a folder fsharp](#b-function-2--add-a-folder-fsharp)
	- [c. Function 3 : Add a function for fsharp](#c-function-3--add-a-function-for-fsharp)
	- [d. Function 4 : Import the new language](#d-function-4--import-the-new-language)
- [7. Differences types between F# and C++](#7-differences-types-between-f-and-c)
	- [a. Integer types](#a-integer-types)
	- [b. Floating types](#b-floating-types)
	- [c. Boolean type](#c-boolean-type)
	- [d. Void type](#d-void-type)
	- [e. String type](#e-string-type)
- [8. Function change to convert the python into C++ to after convert the F# into C++](#8-function-change-to-convert-the-python-into-c-to-after-convert-the-f-into-c)
	- [a. Function to convert python types into C++ types](#a-function-to-convert-python-types-into-c-types)
	- [b. function to convert F# types into C++ types](#b-function-to-convert-f-types-into-c-types)
- [9.Test plan](#9test-plan)
- [10. Glossary](#10-glossary)
- [11. End matter](#11-end-matter)
	- [a. References](#a-references)
	- [b. Acknowledgement](#b-acknowledgement)
</details>

# 1. Introduction

## a. Overview

FABgen is a code generator for C/C++ libraries. It is a tool that takes a C/C++ library and generates a Python, Lua, or Go module that can be used to access the library from the target language.
FABgen was written for the Harfang 3D project to bring the C++ engine to languages such as Python, Lua and Go. It was written as a replacement for SWIG, a very well-known binding generator supporting a lot of target languages.

FABgen is a code generator for C/C++ libraries. It is a tool that takes a C/C++ library and generates a Python, Lua, or Go module that can be used to access the library from the target language.

SWIG has different issues we wished to address:

Very old and complex codebase. Language support is written partially in C and SWIG interface files which are almost a language by themselves. The C codebase does everything through a single Object struct hiding the real type of variables making it extremely difficult to debug and extend the SWIG core. Uneven feature support between languages with missing features although the target language could support them. FABgen tries to solve this issue by:

Using Python to implement FABgen and the binding definitions themselves. Implementing as much as possible of the features in a common part of the program. As a newer project FABgen also tries to leverage newer APIs whenever possible for example by supporting CPython limited ABI so that extension modules it generates can be used by any version of CPython >3.2 without recompilation (at least in theory, the Py_LIMITED_API support in CPython is finicky at best).

## b. Goal

FABGen was written for the [HARFANG®3D](https://www.harfang3d.com/en_US/) project to bring the C++ engine to languages such as Python, Lua and Go. It was written as a replacement for SWIG, a very well-known binding generator supporting a lot of target languages. SWIG has different issues and that's why HARFANG®3D company create another binding generator. Our objective is to create a binding for F#.<br><br>
The goal is to implement F# in FABgen to allow non-coding experts to have access to this software. C++ is a very specific language for non-coding experts people so implementing other languages such as Python, F# and Rust allows other experts to easily use FABGen. Adding F# to FABGen will benefit the F# users who need a 3D engine. In addition, people looking for an alternative to SWIG when binding a C++ library to F# might find it useful. F# is known for being a relatively concise and easy-to-learn language, which can allow you to write code more quickly and with fewer errors. Also, F# uses the .NET "int" data type, which is natively optimized for mathematical calculations and bit operations, which can make F# code runs faster than code is written in other languages.<br><br>

## c. Context
At the moment, the 3D engine created by [HARFANG3D](https://www.harfang3d.com/en_US/) is not allowed in all programming languages. Users can't use F# language or Rust language at this moment. This poses a problem especially now when users want to code in these languages. With this project the company wants its future users to be able to use these different languages.

## d. Product and Technical Requirements

Product requirements :
- Our product needs to add a language on the FABgen existing to improve it.

Technical requirements :
- Following the company's need, **HARFANG3D** advised us to use the same principle to add F# support to FABgen as the one used to add GO support. 
- Like in addition to being a real project it's also a school project. 

## e. Future Goals
At the moment, the customer only needs to add the F# language. They just want to see our ideas and how we solve this problem technically. So the main goal is to bring a solution to the customer. For the future, it's to add some other languages.

## f. Assumptions
To create our solution product, we need like written the code in python to translate the other programming languages.
  
# 2. Solutions

## a. Current Solution / Design 

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

## b. Proposed Solution / Design

The proposed solution is to add more languages, starting with Rust.

-   F#:
    -   JIT from IL,
    -   Statically typed,
    -   Link to C library (C++ has to be wrapped with C first).


This solution will be added to the existing code of the [FABGen repository](https://github.com/ejulien/FABGen).

We recommend using Docker to avoid problems during development. It will emulate an OS, Which is interesting because most of the team uses a Mac M1.

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

## c. Release / Roll-out and Deployment Plan

**HARFANG3D** wants to release the product as soon as possible.


# 3. New FABGen architecture with F#

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

# 4. Further Considerations
## a. Impact on customers of HARFANG3D

 **HARFANG3D** users cannot at the moment, use the F# language. So if we can add this language, it will be a real plus for the company. It will allow them to have more customers and be more competitive.

 ## b. European considerations

HARFANG3D is implemented all over Europe and the regulation about an iso-surface represents points of a constant value within a volume of space. This class holds a fixed-size 3-dimensional grid of values that can efficiently be converted to an iso-surface at runtime for example are the same from all countries.

## c. Security considerations

The main element of safety is the safety of the software. The software must be safe for customers. We must avoid any problems related to malware and hackers. The software must be safe for the company. We must avoid any problems related to the company's reputation. The software must be safe for the users. We must avoid any problems related to the users' reputation.

## f. Legal considerations

The legal aspect is very important. Indeed, the product must be certified. For example, in Europe, the certification is ISO. ISO permits have a good quality product.
But we don't need to concern about the certification because the customers said we don't need to take this into account.

# 5. Work
## a. Prioritization

| Function                        | Flexibility         |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Test if it works with Lua| F1 |
| Test if it works with Go| F1 |
| Test if it works with Python |F1|
| Test if it works with F# |F0|
| Permit the user to use F#|F0|


## b. Milestones
| Number of weeks                        | Work we need to do             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|1st week| In The first week we will finish the introduction of the project, writing the documentation and the functional specification. Writing the technical and the Architecture diagram.|
|2nd week|We look at how to use the FABGen already exists. After that, we try to use FABGen.|
|3rd and 4th week|We are going deeper and starting to launch the test<br> Test the Go part<br>Test the Lua part<br>Check the quality<br>|
|5th and 6th week|We finish all the test with F#. We start to prepare the presentation.|
|7th week|This is the last step of the project, everything should be done and ready to present to the client !<br>Oral presentation.

# 6. Implement functions
  
## a. Function 1 : Add a new language 

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

## b. Function 2 : Add a folder fsharp

Inside the lib folder, we create a Fsharp folder. In this folder we have the same files as other languages so, __ init__.py, std.py and stl.py .

## c. Function 3 : Add a function for fsharp

Inside the __ init__.py file, we add to the existing function the language for Fsharp.

```python
elif gen.get_language() == 'FSharp':
        import lib.fsharp.std
        import lib.fsharp.stl

        lib.fsharp.std.bind_std(gen)
        lib.fsharp.stl.bind_stl(gen)
```

## d. Function 4 : Import the new language

Inside the bind.py file we import the new language.

```python
import lang.fsharp
```

# 7. Differences types between F# and C++

## a. Integer types
F#|C & C++|
----|-------|
byte|(signed) char|
int16|short|
int|int|
int64|long|
int64long long int|
sbyte|unsigned char|
uint16|unsigned short|
uint|unsigned int|
uint64|unsigned long|
uint64|unsigned long long int|


## b. Floating types
|F#|C & C++|
|----|-------|
|float32|float|
|float or double|double|
|-|long double|

## c. Boolean type
F#|C & C++|
|----|----|-------|
|bool|bool|

## d. Void type
F#|C & C++|
----|-------|
unit|void|

## e. String type
F#|C & C++|
----|-------|
char|char|
string|string|





# 8. Function change to convert the python into C++ to after convert the F# into C++

## a. Function to convert python types into C++ types

We take at the base the function in python to convert it into C++.
  
  ```python
  def bind_std(gen):
	class PyObjectPtrTypeConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return true; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *(void **)obj = o; }\n' % self.to_c_func +\
			'PyObject *%s(void *o, OwnershipPolicy) { return *(PyObject **)o; }\n' % self.from_c_func

	gen.bind_type(PyObjectPtrTypeConverter('PyObject *'))
  ```
For example this one convert an object python into an object in C++.


After that we need to convert each types of the python into C++, then convert the F# into C++.


The first one is the bool type:
```python

  class PythonBoolConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyBool_Check(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = o == Py_True; }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyBool_FromLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonBoolConverter('bool'))

 ```

The second one is the int and string type:

```python
class PythonIntConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = (%s)PyLong_AsLong(o); }\n' % (self.to_c_func, self.ctype, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonIntConverter('char'))
	gen.bind_type(PythonIntConverter('short'))
	gen.bind_type(PythonIntConverter('int'))
	gen.bind_type(PythonIntConverter('long'))
	gen.bind_type(PythonIntConverter('int8_t'))
	gen.bind_type(PythonIntConverter('int16_t'))
	gen.bind_type(PythonIntConverter('int32_t'))
	gen.bind_type(PythonIntConverter('char16_t'))
	gen.bind_type(PythonIntConverter('char32_t'))

 ```

The third one is the unsigned int and unsigned string type until 32 bits:

```python

class PythonUnsignedIntConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = (%s)PyLong_AsUnsignedLong(o); }\n' % (self.to_c_func, self.ctype, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromUnsignedLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonUnsignedIntConverter('unsigned char'))
	gen.bind_type(PythonUnsignedIntConverter('unsigned short'))
	gen.bind_type(PythonUnsignedIntConverter('unsigned int'))
	gen.bind_type(PythonUnsignedIntConverter('unsigned long'))
	gen.bind_type(PythonUnsignedIntConverter('uint8_t'))
	gen.bind_type(PythonUnsignedIntConverter('uint16_t'))
	gen.bind_type(PythonUnsignedIntConverter('uint32_t'))

 ```

The fourth one is the int type for the 64 bits:

```python

class PythonInt64Converter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = PyLong_AsLongLong(o); }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromLongLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonInt64Converter('int64_t'))

 ```

The fifth one is the unsigned int type for the 64 bits:

```python

class PythonUnsignedInt64Converter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = PyLong_AsUnsignedLongLong(o); }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromUnsignedLongLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonUnsignedInt64Converter('uint64_t'))

 ```

The sixth one is the void pointer type:

```python

class PythonVoidPtrConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = (%s)PyLong_AsVoidPtr(o); }\n' % (self.to_c_func, self.ctype, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromVoidPtr((void *)(*((%s*)obj))); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonVoidPtrConverter('intptr_t'))

 ```
The seventh one is the convert size type:

```python

class PythonSize_tConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = PyLong_AsSize_t(o); }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromSize_t(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonSize_tConverter('size_t'))

 ```

The eighth one is the convert float type:

```python

class PythonFloatConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyFloat_Check(o) || PyLong_Check(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = (%s)PyFloat_AsDouble(o); }\n' % (self.to_c_func, self.ctype, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyFloat_FromDouble(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonFloatConverter('float'))
	gen.bind_type(PythonFloatConverter('double'))

 ```

The ninth one is the convert const char type:

```python

class PythonConstCharPtrConverter(lang.cpython.PythonTypeConverterCommon):
		def __init__(self, type, to_c_storage_type=None, bound_name=None, from_c_storage_type=None):
			super().__init__(type, to_c_storage_type, bound_name, from_c_storage_type, True)

		def get_type_glue(self, gen, module_name):
			return 'struct %s { std::string s; };\n' % self.c_storage_class +\
			'bool %s(PyObject *o) { return PyUnicode_Check(o) ? true : false; }\n' % self.check_func +\
			'''void %s(PyObject *o, void *obj, %s &storage) {
	PyObject *utf8_pyobj = PyUnicode_AsUTF8String(o);
	storage.s = PyBytes_AsString(utf8_pyobj);
	*((%s*)obj) = storage.s.data();
	Py_DECREF(utf8_pyobj);
}
''' % (self.to_c_func, self.c_storage_class, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyUnicode_FromString(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonConstCharPtrConverter('const char *'))

 ```

 When we have all of these conversions types in Python we can make the same to convert the F# types into C++ types. 

## b. function to convert F# types into C++ types


# 9.Test plan

Here is the [Test plan](https://github.com/algosup/2022-2023-project-3-harfang3d-binding-Project-3-group) for the project. It is a document that describes the test cases that will be used to verify that the software product meets or exceeds the customer’s requirements and that all of the software product’s features work as expected.

# 10. Glossary

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
| Docker | Docker is a set of platform as a service products that use OS-level virtualization to deliver software in packages called containers.|


# 11. End matter

## a. References

https://www.harfang3d.com/en_US/
https://devguide.python.org/documenting/
https://www.lua.org/docs.html
https://devguide.python.org/documentation/start-documenting/index.html
https://fsharpforfunandprofit.com
https://www.swig.org/doc.html

## b. Acknowledgement

Robert Pickering -- contact: robertfpickering@fastmail.com
Delphine Prousteau -- contact: dprousteau@quanaup.fr
Jihane Billacois -- contact: jihb@sent.com
François Gutherz -- contact: francois.gutherz@harfang3d.com
Emmanuel Julien -- contact: emmanuel.julien@harfang3d.com
[Vivien Bistrel Tsangue ](https://github.com/Bistrel2002) -  Project Manager
[Thomas PLANCHARD](https://github.com/thomas-planchard) - Program Manager
[Robin DEBRY](https://github.com/robin-debry) - Technical Leader
[Lucas AUBARD](https://github.com/robin-debry) - Software Engineer
[Laura-Lee HOLLANDE](https://github.com/lauraleehollande) - Quality Assurance
