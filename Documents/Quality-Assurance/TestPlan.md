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
- MacBook Air M1 running on macOS Monterey version 12.3.1 <!-- update my mac -->
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
<!-- link to the db of bug -->
#### Testers
For this project we separate our database of tester in two groupes, the intern and extern testers.
**Intern testers:** are people who is currently working on this project and his development and be able to directly report any bug a resquest in our database of bugs. Can be people of the group 3 but also people from the other groups or Harfang 3D.
**Extern testers:** are people who are not working on this project and not be concerned by his development. These people are pretty near to the final user of this binding project.

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
| Test Case ID 	| Test Case Description 	| Test Steps 	| Test Data 	| Expected Results 	| Actual Results 	| Pass/Fail 	|
|--------------	|-----------------------	|------------	|-----------	|------------------	|----------------	|-----------	|
|              	|                       	|            	|           	|                  	|                	|           	|
|              	|                       	|            	|           	|                  	|                	|           	|
|              	|                       	|            	|           	|                  	|                	|           	|
|              	|                       	|            	|           	|                  	|                	|           	|



# Glossary
| Words                                                                     	| Definition                                                                                                                                                                                                                                                                                                                                                                                                            	|
|---------------------------------------------------------------------------	|-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------	|
| ISO/IEC/IEEE 29119 (Software and systems engineering -- Software testing) 	| It's a series of five international standards for software testing                                                                                                                                                                                                                                                                                                                                                    	|
| IEEE (Institute of Electrical and Electronics Engineers)                  	| "It's the trusted voice for engineering, computing, and technology information around the globe." (cf About in  [IEEE website](https://www.ieee.org/about/index.html))                                                                                                                                                                                                                                                 	|
| IEC (The International Electrotechnical Commission)                       	| It's an international standards organization that prepares and publishes international standards for all electrical, electronic and related technologies                                                                                                                                                                                                                                                              	|
| ISO (International Organization for Standardization)                      	| It's a worldwide federation of national standards bodies                                                                                                                                                                                                                                                                                                                                                              	|
| Standards (from ISO)                                                      	| They are the distilled wisdom of people with expertise in their subject matter and who know the needs of the organizations they represent – people such as manufacturers, sellers, buyers, customers, trade associations, users or regulators. For instance, quality management standards to help work more efficiently and reduce product failures. IT security standards to help keep sensitive information secure. 	|