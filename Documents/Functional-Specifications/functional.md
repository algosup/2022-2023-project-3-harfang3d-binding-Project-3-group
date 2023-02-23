<hr>

<p align="center" style="font-weight: bold; font-size: 21px"> Binding F# </p>
<p align="center" style="font-weight: bold; font-size: 18px"> Functional Specification</p>
<br>
<p align="center"> Thomas Planchard</p>
<br>

<p align="center"> ALGOSUP, Group 3. All Rights Reserved. </p>

<hr>

<details>

<summary>Table of content</summary>
    
- [Context](#context)
- [Goal](#goal)
- [Solution](#solution)
  - [Existing Solution](#existing-solution)
  - [Suggested Solution](#suggested-solution)
  - [Alternate Solutions / Designs](#alternate-solutions--designs)
- [Functional requirements](#functional-requirements)
- [Acceptance criteria](#acceptance-criteria)
- [Personae](#personae)
- [Design](#design)
- [Non-functional requirements](#non-functional-requirements)
- [Constraints and assumptions](#constraints-and-assumptions)
- [Security](#security)
- [Glossary](#glossary)
- [References](#references)

</details>
 
<br>


# Context
HARFANG®3D is a 3D engine that allows professionals to create 3D games and applications. HARFANG®3D builds real-time 3D tools for industry professionals. Its software suite is tailored to developers, designers and engineers aiming to efficiently and seamlessly develop, implement & deploy 3D solutions (HMI, VR/AR, simulation, interactive 3D), regardless of development language or platform constraints. 
# Goal
FABGen is a dependency of HARFANG®3D project to bring the C++ engine to languages such as Python, Lua and Go. HARFANG®3D company create  binding generator. And our objective is to create a binding for F#.<br><br>
The goal is to implement F# in FABGen to allow non-coding experts in imperative languages (C++/Lua/Go/Python) to have access to this software. Allow F# expert to benefits of the full power of HARFANG®3D. C++ is a very specific language for non-coding experts people so implementing other languages such as Python, F# and Rust allows other experts to easily use FABGen. Adding F# to FABGen will benefit the F# users who need a 3D engine. In addition, people looking for an alternative to SWIG when binding a C++ library to F# might find it useful. F# is known for being a relatively concise and easy to learn language, which can allow you to write code more quickly and with fewer errors. Also, F# uses the .NET "int" data type, which is natively optimized for mathematical calculations and bit operations, which can make F# code runs faster than code which is written in other languages.<br><br>
Attached below is a diagram illustrating the relationship between HARFANG®3D and FABGen in this project.

![Schema](../img/Schema.png "Schema")


**Company distribution**
| Person           	| Company role         	| Contact                        	|
|------------------	|----------------------	|--------------------------------	|
| François Gutherz 	| CTO & Project leader 	| mail	|
| Emmanuel Julien  	| Lead developer       	| mail  	|


# Solution
## Existing Solution 
SWIG is a very well-known binding generator supporting a lot of target languages.

SWIG has different issues:

- Very old and complex codebase. Language support is written partially in C and SWIG interface files which are almost a language by themselves. The C codebase does everything through a single Object struct hiding the real type of variables making it extremely difficult to debug and extend the SWIG core.
- Uneven feature support between languages with missing features although the target language could support them.
## Suggested Solution 
FABGen was written for the HArfang3D project to bring the C++ engine to languages such as Python, Lua, Go and now F#. Currently F# commmunity don't have way to acces to 3D engine and that's why we will create the F# binding in FABGen.  
To create a correct solution, it is essential to have a deep understanding of C++ as well as the target language (such as Python, Lua, or GO) and its feature set. Cutting corners or taking shortcuts can lead to problems such as a core dump or memory leak in the user's program later on. It's important to approach this task like building Jenga blocks, each piece must be correct from every angle, as you don't know how they will fit together in the user's program.

## Alternate Solutions / Designs
There are a few tools available that can help automate the process of creating F# bindings for C++ code. 
| Solution  	| Pros 	| Cons 	|
|-----------	|-----	|------	|
| FsSwig    	|  - It's based on the widely-used SWIG tool, which means it's well-established and has a lot of documentation and resources available. <br><br> - It can handle a wide variety of C++ code, including complex templates and STL types.   	| - It may have a steeper learning curve, as it requires knowledge of SWIG syntax.<br><br> - It may not be able to handle all C++ code, especially if it uses advanced features such as C++11 or C++14|
| FsInterop 	|- It's easy to use, as it relies on C++/CLI and P/Invoke, which are familiar to many .NET developers. <br><br>- It can handle a wide variety of C++ code, including complex templates and STL types.| - It may not be able to handle all C++ code, especially if it uses advanced features such as C++11 or C++14. <br><br>- It may have some performance issues as it uses P/Invoke which is slower than other options.     	|
| CppSharp  	|  - It's easy to use, as it relies on C++/CLI and P/Invoke, which are familiar to many .NET developers.<br><br> - It can handle a wide variety of C++ code, including complex templates and STL types.   	| - It may not be able to handle all C++ code, especially if it uses advanced features such as C++11 or C++14.<br><br> - It may have some performance issues as it uses P/Invoke which is slower than other options.     	|
| CppAst    	| - It's a lightweight library that can be used as a starting point for generating F# bindings.<br><br>- It's based on an abstract syntax tree (AST) representation of the C++ code, which makes it easy to navigate and understand the code.    	| - It doesn't automatically generate F# bindings, so you'll need to write additional code to create the bindings.<br><br>- It may not be able to handle all C++ code, especially if it uses advanced features such as C++11 or C++14.     	|
# Functional requirements 
To create a binding for F# in FABGen, we need to do the following tasks:
- Being able to run FABgen to generate the existing binding layers to Cpython and Lua (easiest target to deal with).  
 - Being able to run FABGen to generate the binding to Go.
 - Run the unit tests.
 - Examine how the Go binding work.
 - Our F# binding should be based on gen.py, as much as possible but of course, gen.py was mainly written for Cpyton and Lua (interpreted languages) so we will have to specialize some of the code.
 - Map the types and implement the features required by the tests, starting with the "easy" ones ("basic_type_exchange.py", "function_call.py"), here: https://github.com/ejulien/FABGen/tree/master/tests
- Ultimately, improve the integration with the target language. 

# Acceptance criteria
In this category, we will list the acceptance criteria for the F# binding. The acceptance criteria are the conditions that must be met in order to consider that the F# binding is complete. The acceptance criteria are the following:
- The F# binding must be able to run the unit tests.
- FABgen must be able to generate the binding for CPython, Lua, Go and F#.
- The binding must be integrated into FABGen and made available to users.
# Personae
| Name   	| Age 	| Role| Description  	|
|--------	|-----	|-------------|----------|
| James  	| 35  	| software engineer| James is a software developer with over 10 years of experience in the industry. He's an expert in F# and has a particular interest in using 3D engines to create interactive and visually stunning applications. He's been working with F# for many years and has become proficient in using it for various types of projects. <br> James starts researching different 3D engines that can be used with F#, and discovers several options such as Unity, Unreal Engine, and Godot. He evaluates each engine based on their features, performance, and community support. He found that none of them were usable in his specific case.<br>James is determined to find a solution to use F# with HARFARG. He spends a lot of time researching and experimenting with different options, but he is unable to find a solution that fits his needs. He's disappointed, but he doesn't give up and continues to look for a solution.	|
| Rachel 	| 20  	| student | Rachel is a computer science student with a strong passion for 3D graphics and F#. She's always been fascinated by the possibilities of creating immersive and interactive 3D worlds and has been learning F# in her spare time to improve her programming skills.<br>Rachel is excited to continue using F# in her future projects and is always looking for new opportunities to improve her skills and knowledge. So she is trying to find a software to combine her two passions.                   	|
| Gérard 	| 50  	| senior dev | Gerard is a senior developer with over 10 years of experience in the industry. He's an expert in C++ and has been working with the Harfang3D game engine for several years. He's been involved in multiple projects using this engine and has become very proficient in it.<br>Gerard is always looking for ways to improve his skills, and he's recently become interested in F#. He's heard good things about the language and is excited about the prospect of using it to improve his development workflows and productivity.<br>Gerard is glad that he was able to learn F# and apply it to his work with Harfang3D. However, he realized that there was no specific tool to use F# in Harfang3D.   
| John 	| 30  	| software engineer | John is a software engineer with 5 years of experience working in the industry. He's a highly skilled F# developer and has been working on a new project for the past few months. The project is a complex financial application that requires high performance and scalability.<br> John is excited about the project and has been making great progress, but he's run into a roadblock. He needs to add a feature to the application that requires some C++ code, but he's never worked with C++ before and doesn't know how to import it into his F# project. <br>John is excited about the project and has been making great progress, but he's run into a roadblock. He needs to add a feature to the application that requires some C++ code, but he's never worked with C++ before and doesn't know how to import it into his F# project.unfortunately<br>John is relieved that he was able to find a solution and is grateful for the resources and tools available to help him bridge the gap between F# and C++. He's also excited to continue working on the project and bringing it to fruition.                           	|
# Design
Below is a diagram of FABGen and existing bindings. The F# binding will be added to this diagram. We need to apply the same principle as the other bindings to F#.<br><br>
![Architecture](../img/Architecture_diagram-ADDC_fabgen.drawio.png "diagram")

# Non-functional requirements
Non-functional requirements for our solution are the following:


| Requirement 	| Description 	|
|--------	|-----	|
| Performance   	| The binding generator must be able to generate bindings for large code bases in a reasonable amount of time. 	| 
| Scalability  	|  The binding generator must be able to handle increasing numbers of source code files and dependencies as the codebase grows.| 
|Robustness| The binding generator must be able to function correctly and efficiently even in the presence of unexpected or unusual inputs, conditions, or circumstances. Specifically, to the ability to use a C++ library in F# without experiencing any memory leaks or issues.| 
| Security 	| The binding generator should not introduce any security vulnerabilities to the generated code or to the system on which it is run.| 
| Usability 	|The binding generator for F# should be as close as possible to the original paradigms and coding standards of F#.	|  
| Compatibility 	| The generated binding code should be compatible with the target programming language, operating system (Win32, Win64 Intel, Linux 64 Intel and Aarch 64 ARM), and other technologies and libraries. SEE: https://github.com/algosup/2022-2023-project-3-harfang3d-binding-Project-3-group/blob/main/Documents/Technical-Specifications/technical-Specification.md	|   
| Maintainability 	| The binding generator should be easy to maintain and should be designed in such a way that it is easy to fix bugs and add new features in the future.|   



# Constraints and assumptions

In this section, we will list the constraints and assumptions that we have made for our project. The constraints and assumptions are the following:
- If we forgot to implement a function, it will not be possible to use it in F# and maybe it will create an error.
- The binding generator should validate all input and reject any that does not meet specific requirements or may be harmful.

# Security
For the security part, we haven't added anything new that is not already implemented in the current version of FABGen: 
- **Defense in depth**: the Binding generator should provide multiple layers of security in order to make it harder for an attacker to find and exploit a vulnerability.
- **Least privilege principle**: The binding generator should run with the minimal access and privilege level required for its task.
- **Input validation**: The binding generator should validate all input and reject any that does not meet specific requirements or may be harmful.
# Glossary
| Term   	| Definition 	| 
|--------	|-----	|
| HARFANG®3D  	| HARFANG®3D is a software that allows developers to create 3D computer graphics applications, such as video games, simulations, and animations.  	| 
| F# 	| F# is a functional-first programming language that was developed by Microsoft. F# is characterized by its strong static typing, pattern matching, and support for functional programming concepts such as first-class functions, immutability, and higher-order functions.  	| 
| Lua 	| Lua is a lightweight, high-performance programming language that is widely used as an embedded scripting language in many applications, such as video games, web servers, and other software.  	| 
| GO 	| Go (often referred to as Golang) is a programming language developed by Google in 2007. Go was designed to be a fast, efficient, and statically typed language that is easy to learn and use, with a focus on simplicity, readability, and reliability.  	|  
| Python 	| Python is an interpreted language, and it supports multiple programming paradigms such as object-oriented, functional and procedural, making it a versatile and adaptable language.  	|   
| CPython  	| CPython is the reference implementation of the Python programming language. It is written in C and is the most widely used implementation of Python. CPython is an interpreted language, meaning that the source code is not compiled to machine code before it is executed, rather the interpreter reads and executes the code directly.|  
| C++ 	| C++ is a high-performance, general-purpose programming language that was developed in the early 1980s as an extension of the C programming language. C++ is a strongly typed, compiled language that supports both imperative and object-oriented programming styles.  	| 
| Swig 	| SWIG (Simplified Wrapper and Interface Generator) is an open-source software development tool that is used to create interfaces between high-level programming languages and C or C++ code. It is particularly useful for creating bindings between C/C++ libraries and languages such as Python, Perl, Ruby, Lua, and others.| 

# References
| ID | Description | URL |
| :--- | :--- | :--- |
| 1 | HARFANG® 3D | [Link](https://www.harfang3d.com/en_US/) |
| 2 | FABgen | [Link](https://github.com/ejulien/FABGen) |

