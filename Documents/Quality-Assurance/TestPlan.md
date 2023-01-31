<hr>

<p align="center" style="font-weight: bold; font-size: 21px"> Binding F# </p>
<p align="center" style="font-weight: bold; font-size: 18px"> Test Plan</p>
<br>
<p align="center"> Laura-Lee Hollande</p>
<br>

<p align="center"> ALGOSUP, Group 3. All Rights Reserved. </p>

<hr>
# Test plan - Harfang 3D

<summary>
        <b>Table of Content</b>
</summary>

- [Test plan - Harfang 3D](#test-plan---harfang-3d)
- [Test policy](#test-policy)
  - [Mission of testing](#mission-of-testing)
- [Test strategy](#test-strategy)
  - [Test objectives](#test-objectives)
    - [Test level performed](#test-level-performed)
    - [Test types performed](#test-types-performed)
  - [Test environment](#test-environment)
    - [Hardware used](#hardware-used)
    - [Software used](#software-used)
    - [Bug reporting](#bug-reporting)
      - [Testers](#testers)
      - [How to report a bug](#how-to-report-a-bug)
  - [Test Environment Management](#test-environment-management)
  - [Configuration management](#configuration-management)
- [Test case](#test-case)
- [Glossary](#glossary)

# Test policy
## Mission of testing
We realize a test process to anticipate all the risks that would impact our solution and make sure to deliver a working solution to our customer HARFANG 3D.

# Test strategy
## Test objectives
The objective of our software testing is to integrate the risk management process to identify any risk as soon as possible in the development process.
We also comply with legal and regulatory requirements. We need to bring a solution that verifies the test object’s compliance with such requirements or standards:
- This objective ensures that our software is developed to be in line with the national and international standards of testing.
- We have ISO, IEC and IEEE 29119 standards that deal with the software testing concept.
### Test level performed
| Test level                   	| Objectives                                                                                                      	|
|-------------------------	|-----------------------------------------------------------------------------------------------------------------	|
| Unit test               	| Detect defective code in units and reduce risk of unit failure in Production                                    	|
| Regression testing      	| Ensure no new defects have been introduced (in case of enhancements or defect fix)                              	|
| User acceptance testing 	| Confirm the system works as expected by the customer and the end-user                                           	|
| Operational testing     	| Checks the reliability and performance of the software and should be tested to find out if it works as expected 	|

### Test types performed
| Test types     	| Objectives                                                                                                                                                          	|
|----------------	|---------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| Functional     	| Verifies that the operational execution of the program happens according to the technical specifications                                                            	|
| Non-functional 	| Make sure that the interests of the end-user are respected by checking these different aspect: performance, usability, scalability, and reliability of the software 	|

## Test environment
Following people are involved in test environment setup:
- Lucas Aubard as a Software engineer
- Robin Debry  as Tech lead 
- Laura-Lee Hollande as Quality assurance
- Vivien Bistrel Tsangue as a Project manager

### Hardware used
- MacBook Air M1 running on macOS Monterey version 13.2 <!-- update my mac -->
- ThinkBook running on Windows 11

### Software used
- Visual Studio Code version 1.74.3 (Universal)
- Github
- Languages used:
  - F#
  - C++
  - C

### Bug reporting
Bug reporting tools are used and provided to testers.

#### Testers
We have recruited our tester based on several points:
- potential end-users
- F# developpers or have knowledge about F#
- C++ developpers or have knowledge about C++
- C developpers or have knowledge about C
- Software development students

For this project we split our database of tester in two groups, the intern and extern testers. All the people selected as testers have an ID tester and  an access to report any bugs.
**Intern testers:** are people who is currently working on this project and his development and be able to directly report any bug a resquest in our database of bugs. Can be people of the group 3 but also people from the other groups or Harfang 3D.
**Extern testers:** are people who are not working on this project and not be concerned by his development. These people are pretty near to the final user of this binding project.

#### How to report a bug
There is two ways to do this. The person who finds a bug and want to report it can sent a request to our database with this [link](https://docs.google.com/spreadsheets/d/1fDos23q6zS2Z5zB_uRxEs8iQ92olEdAjjrUPKbLEBtk/edit?usp=sharing) our directly send me an email at <laura-lee.hollande@algosup.com>. No matter how a bug is reported, these following information need to appear when it is reported:
| Information                                  	| Description                                                                                	|
|----------------------------------------------	|--------------------------------------------------------------------------------------------	|
| Defect description                           	| A detailed description of the bug                                                          	|
| Version of the application                   	| The version of the application in which bug was found                                      	|
| Version and operating system of the hardware 	| The version and the operating system of the hardware in which bug was found                	|
| Steps                                        	| The detailed steps so that the developer can reproduce the defects. Can include screenshot 	|
| Date raised                                  	| The date when the bug is raised                                                            	|
| ID tester/Name                               	| The ID/Name of the tester who raised the defect                                            	|

In the ```Database-of-Bugs.md``` file, the bugs are reported from the original database manually by Hollande Laura-Lee.

## Test Environment Management
List of the different activities used for an efficient test management: 
1. Maintenance of a [central repository](https://github.com/algosup/2022-2023-project-3-harfang3d-binding-Project-3-group) with all the updated version of test environments 
2. Create new environments depending on the new requirments
3. Environments's monitoring
4. Updating and deleting outdated test-environments
5. Issues on the environment's monitoring
6. Co-ordination untill an issue resolution.

## Configuration management
<!-- WIP -->
# Test case
**Features need to be tested:** Transform a C++ function in F# function
**Features need not be tested:** Transform a F# function in C++ function
| Test Case ID 	| Test Case Description                                               	| Test Steps                 	| Test Data              	| Expected Results                                 	| Actual Results                                   	| Pass/Fail 	|
|--------------	|---------------------------------------------------------------------	|----------------------------	|------------------------	|--------------------------------------------------	|--------------------------------------------------	|-----------	|
| TC_1         	| Check the distance to origin in Vector 2                            	| Dotnet run on the project  	| Vector2(2.0, 2.0)      	| Distance to origin in Vector 2: 2.828427         	| Distance to origin in Vector 2: 2.828427         	| Pass      	|
| TC_2         	| Check the percent distance to origin in Vector 2                    	| Dotnet run on the project  	| Vector2(2.0, 2.0)      	| Percent distance to origin in Vector 2: 1.414214 	| Percent distance to origin in Vector 2: 1.414214 	| Pass      	|
| TC_3         	| Check the distance to origin in Vector 3                            	| Dotnet run on the project  	| Vector3(1.0, 2.0, 3.0) 	| Distance to origin in Vector 3: 3.741657         	| Distance to origin in Vector 3: 3.741657         	| Pass      	|
| TC_4         	| Check the percent distance to origin in Vector 3                    	| Dotnet run on the project  	| Vector3(1.0, 2.0, 3.0) 	| Percent distance to origin in Vector 3: 1.870829 	| Percent distance to origin in Vector 3: 1.870829 	| Pass      	|
| TC_5         	| Know if the user use a Mac or a Windows to import dll or dylib file 	| Dotnet run on the project  	| /                      	| Run successfully on Windows                      	| Not as expected                                  	| Fail      	|

# Glossary
| Words                                                                     	| Definition                                                                                                                                                                                                                                                                                                                                                                                                            	|
|---------------------------------------------------------------------------	|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| ISO/IEC/IEEE 29119 (Software and systems engineering -- Software testing) 	| It's a series of five international standards for software testing                                                                                                                                                                                                                                                                                                                                                    	|
| IEEE (Institute of Electrical and Electronics Engineers)                  	| "It's the trusted voice for engineering, computing, and technology information around the globe." (cf About in  [IEEE website](https://www.ieee.org/about/index.html))                                                                                                                                                                                                                                                 	|
| IEC (The International Electrotechnical Commission)                       	| It's an international standards organization that prepares and publishes international standards for all electrical, electronic and related technologies                                                                                                                                                                                                                                                              	|
| ISO (International Organization for Standardization)                      	| It's a worldwide federation of national standards bodies                                                                                                                                                                                                                                                                                                                                                              	|
| Standards (from ISO)                                                      	| They are the distilled wisdom of people with expertise in their subject matter and who know the needs of the organizations they represent – people such as manufacturers, sellers, buyers, customers, trade associations, users or regulators. For instance, quality management standards to help work more efficiently and reduce product failures. IT security standards to help keep sensitive information secure. 	|