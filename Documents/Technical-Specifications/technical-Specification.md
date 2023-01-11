<hr>
<p  align="center"  style="font-weight: bold; font-size: 21px"> ALGOSUP Binding Project </p>

<p  align="center"  style="font-weight: bold; font-size: 18px"> Technical Specification</p>

<br>

<p  align="center"> Robin Debry</p>  

<br>

<p  align="center"> ALGOSUP, Group 3. All Rights Reserved. </p>

<hr>

<details> 
<summary style="text-decoration: underline; font-size:100%">Table of contents:</summary>

- [1. Front matter](#1-front-matter)
- [2. Introduction](#2-introduction)
  - [a. Overview](#a-overview)
  - [b. Goal](#b-goal)
  - [c. Glossary  or Terminology](#c-glossary--or-terminology)
  - [d. Context or Background](#d-context-or-background)
  - [e. Product and Technical Requirements](#e-product-and-technical-requirements)
  - [f. Future Goals](#f-future-goals)
  - [g. Assumptions](#g-assumptions)
- [3. Solutions](#3-solutions)
  - [a. Suggested or Proposed Solution / Design](#a-suggested-or-proposed-solution--design)
  - [b. Release / Roll-out and Deployment Plan](#b-release--roll-out-and-deployment-plan)
- [4. Further Considerations](#4-further-considerations)
  - [a. Impact on other teams](#a-impact-on-other-teams)
  - [b. European considerations](#b-european-considerations)
  - [c. Security considerations](#c-security-considerations)
  - [e. Privacy considerations](#e-privacy-considerations)
  - [f. Legal considerations](#f-legal-considerations)
  - [h. Support considerations](#h-support-considerations)
- [5. Work](#5-work)
  - [a. Prioritization](#a-prioritization)
  - [b. Milestones](#b-milestones)
- [6. Implement functions](#6-implement-functions)
  - [a. Function 1 : Add a new language](#a-function-1--add-a-new-language)
  - [b. Function 2 : Add a folder fsharp](#b-function-2--add-a-folder-fsharp)
  - [c. Function 3 : Add a function for fsharp](#c-function-3--add-a-function-for-fsharp)
  - [d. Function 4 : Import the new language](#d-function-4--import-the-new-language)
- [7. Function change to convert the python into C++ to after convert the F# into C++](#7-function-change-to-convert-the-python-into-c-to-after-convert-the-f-into-c)
- [8. End matter](#8-end-matter)
  - [a. References](#a-references)
  - [b. Acknowledgement](#b-acknowledgement)
</details>

# 1. Front matter
HARFANG3D Project 3 Group 3

Author: Robin Debry 

Team: Vivien Bistrel Tsangue , Robin Debry, Lucas Aubard, Laura-Lee Hollande, Thomas Planchard

Last updated : 11/01/2022

# 2. Introduction
## a. Overview
Fabgen is a code generator for C/C++ libraries. It is a tool that takes a C/C++ library and generates a Python, Lua or Go module that can be used to access the library from the target language.
Fabgen was written for the Harfang 3D project to bring the C++ engine to languages such as Python, Lua and Go. It was written as a replacement for SWIG, a very well-known binding generator supporting a lot of target languages.

Fabgen is a code generator for C/C++ libraries. It is a tool that takes a C/C++ library and generates a Python, Lua or Go module that can be used to access the library from the target language.

SWIG has different issues we wished to address:

Very old and complex codebase. Language support is written partially in C and SWIG interface files which are almost a language by themselves. The C codebase does everything through a single Object struct hiding the real type of variables making it extremely difficult to debug and extend the SWIG core. Uneven feature support between languages with missing features although the target language could support them. Fabgen tries to solve this issues by:

Using Python to implement Fabgen and the binding definitions themselves. Implementing as much as possible of the features in a common part of the program . As a newer project Fabgen also tries to leverage newer APIs whenever possible for example by supporting CPython limited ABI so that extension modules it generates can be used by any version of CPython >3.2 without recompilation (at least in theory, the Py_LIMITED_API support in CPython is finicky at best).

## b. Goal

Our goal for this project is to implement the F# in FABgen to be use by the users of the 3D engine create by [HARFANG3D](https://www.harfang3d.com/en_US/).


## c. Glossary  or Terminology

| Terms                        | Definition             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| ISO|(International Standards Organisation) an organization that makes international rules about the quality of products and services:|
| MISRA|(Motor Industry Software Reliability Association), a consortium of companies in the automotive industry that develops guidelines and standards for the development of safety-critical software. |
| API|They are mechanisms that enable two software components to communicate with each other using a set of definitions and protocols.|
| ABI | An application binary interface (ABI) is an interface between two binary program modules. Often, one of these modules is a library or operating system facility, and the other is a program that is being run by a user.|
| Unit Test | It's a type of software testing where individual units or components of a software are tested.|
| Statically-typed language  | It's a language (such as Java, C, or C++) where variable types are known at compile time.|
| Dynamically typed languages | Type checking takes place at runtime or execution time. This means that variables are checked against types only when the program is executing|
| AUTOSAR | AUTomotive Open System ARchitecture), a standard for the development of automotive software that provides a set of guidelines and tools for the development of software that is portable across different hardware platforms.|




## d. Context or Background
At the moment, the 3D engine create by [HARFANG3D](https://www.harfang3d.com/en_US/) are not allowed all programming language. Users can't use F# language or Rust language at this moment. This poses a problem especially now when a users want to code in this languages. With this project the company wants their future users to be able to use this differents languages.



## e. Product and Technical Requirements

Product requirements :
- Our product need to be a add a language on the FABgen existing to improve it.

Technical requirements :
- Following the company's need, **HARFANG3D** advised us to use the same principe to add F# support to FABGen as the one used to add GO support. 
- Like in addition to be a real project it's also a school project. 

## f. Future Goals
At the moment, the customer only needs to add the F# language. They just want to see our ideas and how we solve this problem technically. So the main goal is to bring a solution to the customer. For the future it's to add some other languages.

## g. Assumptions
In order to create our solution product, we need like written the code in python to translate the other programming languages.
  
# 3. Solutions

## a. Suggested or Proposed Solution / Design 




## b. Release / Roll-out and Deployment Plan

**HARFANG3D** wants to release the product as soon as possible.

# 4. Further Considerations
## a. Impact on other teams

 **HARFANG3D** users cannot at the moment, use the F# language. So if we can add this language, it will be a real plus for the company. It will allow them to have more customers and to be more competitive.

 ## b. European considerations

HARFANG3D is implemented all over Europe and the regulation about An iso-surface represents points of a constant value within a volume of space. This class holds a fixed-size 3-dimensional grid of values that can efficiently be converted to a at runtime for exmaple are the same from all countries.

## c. Security considerations

The main element of safety is the safety of the software. The software must be safe for customers. We must avoid any problems related to malware and hackers. The software must be safe for the company. We must avoid any problems related to the company's reputation. The software must be safe for the users. We must avoid any problems related to the users' reputation.

## e. Privacy considerations

We use Lora to avoid a lot of problems with data privacy, data leaks. If instead of using Lora, we used  wifi, it would have been much more problematic, because wifi is weaker in terms of security.

## f. Legal considerations

The legal aspect is very important. Indeed, the product must be in accordance with the certification. For example, in Europe, the certification is ISO. ISO permit to have a good quality of product.
## h. Support considerations

At the moment the support is complicated with the actual sign. There is no way to know if a sign is broken or not. The only way is to move where the sign is located. So one of the goal of the product is to save the technician time by avoiding them to move for nothing. In addition Signall want to predict the future state of led depending of the weather. 


# 5. Work
## a. Prioritization

| Function                        | Flexibility         |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
| Test if it's work with Lua| F1 |
| Test if it's work with Go| F1 |
| Test if it's work with Python |F1|
| Test if it's work with F# |F1|
| Permit to the user to use F#|F0|

## b. Milestones
| Number of weeks                        | Work we need to do             |
| ---------------------------- | ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- |
|1st week|The first week we will finish the introduction of the project, writing the documentation and the functional specification. Writing the technical and the Architecture diagram|
|2nd week|We look how to use the FABgen already exist and we look how to use the FABgen already exist. After that we try to use FABgen.|
|3rd and 4th week|We are going deeper, and start to launch the. test<br> Test the Go part<br>Test the Lua part<br>Check the quality<br>|
|5th and 6th week|We finish all the test with F#. We start to prepare the presentation.|
|7th week|this is the last step of the project, everything should be done and ready to present to the client !<br>Oral presentation



# 6. Implement functions
  
## a. Function 1 : Add a new language 

inside the folder lang we create a file fsharp.py

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

Inside the folder lib we create a folder fsharp in this folder we have the same file than others languages so, __ init__.py, std.py and stl.py 

## c. Function 3 : Add a function for fsharp

Inside the file __ init__.py we add the function for fsharp

```python
elif gen.get_language() == 'FSharp':
        import lib.fsharp.std
        import lib.fsharp.stl

        lib.fsharp.std.bind_std(gen)
        lib.fsharp.stl.bind_stl(gen)
```

## d. Function 4 : Import the new language

Inside the file bind .py we import the new language

```python
import lang.fsharp
```

# 7. Function change to convert the python into C++ to after convert the F# into C++

We take at the base the function in python to convert the python into C++
  
  ```python
  def bind_std(gen):
	class PyObjectPtrTypeConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return true; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *(void **)obj = o; }\n' % self.to_c_func +\
			'PyObject *%s(void *o, OwnershipPolicy) { return *(PyObject **)o; }\n' % self.from_c_func

	gen.bind_type(PyObjectPtrTypeConverter('PyObject *'))
  ```
  for example this one convert an object python into an object in C++


After that we need to convert each types of the python into C++ to after convert the F# into C++


The first one is the bool type
```python

  class PythonBoolConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyBool_Check(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = o == Py_True; }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyBool_FromLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonBoolConverter('bool'))

 ```

The second one is the int and string type

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

The third one is the unsigned int and unsigned string type until 32 bits

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

The fourth one is the int type for the 64 bits

```python

class PythonInt64Converter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = PyLong_AsLongLong(o); }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromLongLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonInt64Converter('int64_t'))

 ```

the fifth one is the unsigned int type for the 64 bits

```python

class PythonUnsignedInt64Converter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = PyLong_AsUnsignedLongLong(o); }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromUnsignedLongLong(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonUnsignedInt64Converter('uint64_t'))

 ```

The sixth one is the void pointer type 

```python

class PythonVoidPtrConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = (%s)PyLong_AsVoidPtr(o); }\n' % (self.to_c_func, self.ctype, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromVoidPtr((void *)(*((%s*)obj))); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonVoidPtrConverter('intptr_t'))

 ```
The seventh one is the convert size type

```python

class PythonSize_tConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyLong_CheckExact(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = PyLong_AsSize_t(o); }\n' % (self.to_c_func, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyLong_FromSize_t(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonSize_tConverter('size_t'))

 ```

The eighth one is the convert float type

```python

class PythonFloatConverter(lang.cpython.PythonTypeConverterCommon):
		def get_type_glue(self, gen, module_name):
			return 'bool %s(PyObject *o) { return PyFloat_Check(o) || PyLong_Check(o) ? true : false; }\n' % self.check_func +\
			'void %s(PyObject *o, void *obj) { *((%s*)obj) = (%s)PyFloat_AsDouble(o); }\n' % (self.to_c_func, self.ctype, self.ctype) +\
			'PyObject *%s(void *obj, OwnershipPolicy) { return PyFloat_FromDouble(*((%s*)obj)); }\n' % (self.from_c_func, self.ctype)

	gen.bind_type(PythonFloatConverter('float'))
	gen.bind_type(PythonFloatConverter('double'))

 ```

The ninth one is the convert const char type

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



# 8. End matter


## a. References

https://www.harfang3d.com/en_US/
https://devguide.python.org/documenting/
https://www.lua.org/docs.html
https://devguide.python.org/documentation/start-documenting/index.html
https://fsharpforfunandprofit.com
## b. Acknowledgement

Robert Pickering -- contact: robertfpickering@fastmail.com
Delphine Prousteau -- contact: dprousteau@quanaup.fr
Jihane Billacois -- contact: jihb@sent.com
François Gutherz -- contact: francois.gutherz@harfang3d.com
Emmanuel Julien -- contact: emmanuel.julien@harfang3d.com
